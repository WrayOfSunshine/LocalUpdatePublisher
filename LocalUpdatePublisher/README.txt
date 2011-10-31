Copyright (c) <2010> <Bryan R. Dam>
Released under the MIT license as found in LICENSE.txt

***This project is currently in Beta release.  It has been used extensively by the author an several others.  The bulk of the functionality has been tested and proven to work.  However, serious and dangerous bugs may still exist.  Please report anything you find.***

Read this entire document before trying to use Local Update Publisher.  You have little hope of success if you skip this step.

***Connecting to the Server***
You must have a WSUS 3.0 SP2 server setup and running successfully.  

If you are running the program locally on the WSUS server, start the program, leave the connection settings blank, and hit connect.

If you are running the program remotely:
-Install the WSUS Administration Console according to these instructions: http://technet.microsoft.com/en-us/library/cc720498%28WS.10%29.aspx.  
-Connect using a user in the WSUS Administrators or local Administrators group.
-If you are in a domain you must have a domain trust between the remote computer and the WSUS server.  
-If you are not in a domain you must setup such a trust by managing your passwords and adding appropriate credentials for the WSUS server.  Refer to these instructions: http://www.microsoft.com/resources/documentation/windows/xp/all/proddocs/en-us/usercpl_manage_passwords.mspx


***Setup certificate ***
Once you connect to the server you must create a self-signed certificate or import an existing certificate.  To create or import the certificate go to Tools > Certificate Information.  Once the certificate has been created or imported you must distribute that certificate to every machine that will receive updates including the server itself if it receives updates via WSUS.  Follow these directions to do so: http://msdn.microsoft.com/en-us/library/bb902479%28VS.85%29.aspx


***Author Updates***
Use Tools > Import Update to create updates packages to be distributed by your WSUS server.  
Select the update files.
  -It is generally recommended to use an MSI/MSP file for the update although EXEs are supported.
  -If there is a second MSI in the package you can specify it's relative path
  -If additional files are needed by the update you can load them into the file list.
Enter the correct metadata.
Create rules to determine if the update is already installed.
Create rules to determine if the update can be installed on the client.
Review rules, if any, determining if the update is superseded.
Review the metadata, if any, that the rules use.
Review the XML that describes the Software Definition Package.
Hit finish to publish the update to the WSUS server.
Test the update by approving it to a testing group and making sure it does not install on systems that already have the update and where the update is not supported or needed.

***Manage the Update***
Right click on the update to approve, revise, expire, decline, or remove it. 

To successfully distribute updates you must become familiar with the information found here:
http://msdn.microsoft.com/en-us/library/bb902470%28VS.85%29.aspx (WSUS Local Publishing)
http://technet.microsoft.com/en-us/library/bb531004.aspx (Basic Rules)
