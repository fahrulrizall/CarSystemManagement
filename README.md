# CarSystemManagement

Car Management system is system API base with JWT token and notification using SMFT Provider using MailTrap. In this system, there are 3 types of users (Admin, Car Owner, and Mechanics)
1.	Clone github Project fahrulrizall/CarSystemManagement (github.com)
2.	Open the code with your favorite code editor
3.	Change database connection in ‘appsettings.json’
4.	Run migration with ‘update-database’
5.	Run the project with CLI ‘dotnet run’
6.	There is 4 controller 
Account Controller 
Post    Local:{port}/api/account/authenticate to login and get token

Owner Controller 
Get    	Localhost:{port}/api/owner
Get    	Localhost:{port}/api/owner/{id}
Create   Localhost:{port}/api/owner/[model]
Put    	Localhost:{port}/api/owner/{id}/[model]
Delete	Localhost:{port}/api/owner/{id}

Mechanic Controller 
Get    	Localhost:{port}/api/mechanics
Get    	Localhost:{port}/api/mechanics/{id}
Create   Localhost:{port}/api/mechanics/[model]
Put    	Localhost:{port}/api/mechanics/{id}/[model]
Delete	Localhost:{port}/api/mechanics/{id}

Services Controller 
Get    	Localhost:{port}/api/Services
Get    	Localhost:{port}/api/Services/{id}
Create   Localhost:{port}/api/Services/[model]
Put    	Localhost:{port}/api/Services/{id}/[model]
Delete	Localhost:{port}/api/Services/{id}

7.	SMTP Notification
-	Change configuration in ‘appsettings.json’ for SMTPConfig base your account
-	Notification will send when there are create and update in services controller to owner and mechanics

