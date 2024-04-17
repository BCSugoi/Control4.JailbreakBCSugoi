using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garry.Control4.Jailbreak
{
    // 2024.04.16 replaced original static class "Constants" with a non-static class that
    // creates static variables using values determined at runtime from config.xml
    // If config.xml import doesn't work, we revert to default hard-coded values

    public class Constants
	{
		public static int Version = 6;
        public static string ComposerCertName { get; private set; }
        public static string CertificateCN { get; private set; }
        public static string CertPassword { get; private set; }
        public static string OpenSslExe { get; private set; }
        public static string OpenSslConfig { get; private set; }
        public static string TargetDirectorVersion { get; private set; }
        public static int CertificateExpireDays { get; private set; }

        static Constants()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            try
            {
                // try to load config file -- looking in same directory as executable
                XDocument doc = XDocument.Load("config.xml");

                ComposerCertName = doc.Root.Element("ComposerCertName").Value;
                CertificateCN = doc.Root.Element("CertificateCN").Value;
                CertPassword = doc.Root.Element("CertPassword").Value;
                OpenSslExe = doc.Root.Element("OpenSslExe").Value;
                OpenSslConfig = doc.Root.Element("OpenSslConfig").Value;
                TargetDirectorVersion = doc.Root.Element("TargetDirectorVersion").Value;
                CertificateExpireDays = int.Parse(doc.Root.Element("CertificateExpireDays").Value);
            }
            catch (Exception ex)
            {
                // If unable to load config.xml, generate a popup to tell user about the error
                // Maybe should have tried using existing LogWindow for this

                string message = "Unable to load config.xml, reverting to defaults ( " + ex + ")";
                CenteredMessageBoxForm messageBox = new CenteredMessageBoxForm(message);
                messageBox.ShowDialog();

                // Now proceed to load default values

                /// The cert for composer needs to be named cacert-*.pem
                ComposerCertName = "cacert-yourcert.pem";

                /// Needs to start with Composer_ and can be anything after
                CertificateCN = "Composer_user@yourmail.com";

                /// Should always be this unless they change something internally
                CertPassword = "R8lvpqtgYiAeyO8j8Pyd";

                /// How many days until the certificate expires. Doesn't seem any harm in setting this to
                /// a huge value so you don't have to re-crack every year.
                CertificateExpireDays = 3650;

                /// Where OpenSSL is installed (it's installed with Composer)
                OpenSslExe = @"C:\Program Files (x86)\Control4\Composer\Pro\RemoteAccess\bin\openssl.exe";

                /// Where OpenSSL's Config is located (it's installed with Composer)
                OpenSslConfig = @"Certs\openssl.cfg";

                /// What version of Director/Composer we're aiming at
                TargetDirectorVersion = @"3.4.1";

            }

        }

	}

}
