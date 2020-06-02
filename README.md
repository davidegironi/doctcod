# DoctcoD


![DoctcoD](Raw/ico_doctcod.png?raw=true)


DoctcoD is a **Medical Practice Management Software**.

It's a complete **open source** solution to manage you patients.

You can trace your patient, treatments, scheduling appointments, doing reports, and billing management.
It features a client-server architecture.

## Download

**[Latest Release](../../releases/latest)**


## Features:

* Doctors records, manage more than one doctor
* Patient records
* Full patient medical records
* Patients attachments and notes management
* Billing management, with invoices and estimates
* Treatments lists
* Scheduling agenda
* Customizable reports
* PDF output templates
* Cloud backup scripts
* Calendar and patient treatments web interface
* Client-server architecture, access by multiple computer at the same time
* Multilanguage
* Send appointments reminder
* Password form protection
* Windows service for additional features


## Requirements

* Microsoft Windows with .NET framework 4.6.2 or later
* Microsoft SQL Server 2012 or later


## Requirements: web app

* PHP 5.3 or later


## Installation

* Install all software listed in the requirements
* Restore the *doctcod.bak* files you can find under the *_DBDump* folder as a new *doctcod* database, alternatively use the *doctcod-schema.sql* files
* Create a new folder, and copy all the DoctcoD files in that folder
* Sets the *DoctcoD.exe.config* file according to your preferences, (see inline comments for further informations)
* To add a new translation, or for language settings, change files under the *lang* folder
* Change the *config.db-backup.bat* parameters to fit your needs, optionally add the backup script
  as a cron job to activate it automatically


## Installation: web app

* Install all software listed in the requirement
* Copy all the files under the *www* folder to you webserver page
* Sets the *config.inc.php* file according to your preferences
* To add a new translation, or for language settings, change files under the *lang* folder


## Screenshots

![Patient Treatments](Raw/doctcod-medical_practice_software-patients_treatments.jpg?raw=true)
![Appointments](Raw/doctcod-medical_practice_software-appointments.jpg?raw=true)
![Invoice](Raw/doctcod-medical_practice_software-invoice.jpg?raw=true)
![PDF Invoice](Raw/doctcod-medical_practice_software-PDF_invoice.jpg?raw=true)


## Development

If you want to contribute, or you found a bug, please send an e-mail to the software author.


## License

Copyright (c) Davide Gironi, 2020

DoctcoD is an open source software licensed under the [GPLv3 license](http://opensource.org/licenses/GPL-3.0)