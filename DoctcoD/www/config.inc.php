<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

//set timezone
date_default_timezone_set('Europe/Rome');

//set database credentials
$mssql_hostname = 'HOSTNAME';
$mssql_database = 'DATABASE';
$mssql_username = 'USERNAME';
$mssql_password = 'PASSWORD';

//set the type of database driver: sqlsrv OR mssql
$mssql_driver = 'sqlsrv';

//set language
$language = 'en';

//set calendar startpage (month, agendaWeek, agendaDay)
$calendarStartPage = 'agendaWeek';

//set calendar scrolltime
$calendarScrollTime = '08:00:00';

//enable or disable patient login
$isPatientLoginEnabled = false;

//show doctor name to patient
$patientEventShowDoctorName = true;

//set the login cookie secret key
$cookieHashSecret = 'hy3D6aTk';

//set the login cookie expire time (in seconds)
$cookieTime = 3600*24*60; //60 days

//set the login token purge time (in days)
$tokenPurgeTime = 60;

//enable error display
$enableErrorDisplay = false;

?>