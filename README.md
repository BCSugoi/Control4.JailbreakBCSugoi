# What

Jailbreak tool for Control4 3.4.1 - allowing add/rename/move rooms/drivers/devices without being a dealer.

*** this forked version is intended primarily to add a method of providing parameter values via an xml config file ***

*** Please see [Garry Newman's page](https://github.com/garrynewman/Control4.Jailbreak) for more info ***

Head over to the [releases page](https://github.com/BCSugoi/Control4.JailbreakBCSugoi/releases) and download the zip (not the source). 
Unzip and then EDIT the config.xml file to set values you like for the certificate name and the "ComposerCN" name.  Other values
should not need to be updated.

A couple of notes that may be helpful:
1. make sure the computer running the program is on the same subnet as the controller.  Just being able to ping or even SSH to the controller isn't good enough; there are ARP commands that won't work if the controller isn't in your subnet.
2. the project is in C# and set up for use in Visual Studio 2022
   
