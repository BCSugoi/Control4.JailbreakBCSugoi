using System;
using System.Drawing;
using System.Windows.Forms;

namespace Garry.Control4.Jailbreak
{
    public partial class CenteredMessageBoxForm : Form
    {
        public CenteredMessageBoxForm(string message)
        {
            //InitializeComponent();
            InitializeMessageBox(message);
        }

        private void InitializeMessageBox(string message)
        {
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set form size
            this.Size = new Size(600, 400);

            // Create message label
            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.Font = new Font(messageLabel.Font.FontFamily, 10, FontStyle.Regular);
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.Dock = DockStyle.Fill;

            // Create OK button
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Dock = DockStyle.Bottom;
            okButton.Click += (sender, e) => this.Close();

            // Add controls to form
            this.Controls.Add(messageLabel);
            this.Controls.Add(okButton);
        }
    }
}
