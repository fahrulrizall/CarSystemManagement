# CarSystemManagement

Car Management system is system API base with JWT token and notification using SMFT Provider using MailTrap. In this system, there are 3 types of users (Admin, Car Owner, and Mechanics)

1.	Clone github Project [Here](https://github.com/fahrulrizall/CarSystemManagement "Github")
2.	Open the code with your favorite code editor
3.	Change database connection in ‘appsettings.json’
4.	Run migration with ‘update-database’
5.	Run the project with CLI ‘dotnet run’
6.	There is 4 controller 
      <br />
      Account Controller 
      <br />
      -Post    Local:{port}/api/account/authenticate to login and get token (Username : Admin;Password : Admin)
      <br />
      
      Owner Controller
      <br />
      -Get    	Localhost:{port}/api/owner
      <br />
      -Get    	Localhost:{port}/api/owner/{id}
      <br />
      -Create   Localhost:{port}/api/owner/[model]
      <br />
      -Put    	Localhost:{port}/api/owner/{id}/[model]
      <br />
      -Delete	Localhost:{port}/api/owner/{id}
      <br />

      Mechanic Controller 
      <br />
      -Get    	Localhost:{port}/api/mechanics
      <br />
      -Get    	Localhost:{port}/api/mechanics/{id}
      <br />
      -Create   Localhost:{port}/api/mechanics/[model]
      <br />
      -Put    	Localhost:{port}/api/mechanics/{id}/[model]
      <br />
      -Delete	Localhost:{port}/api/mechanics/{id}
      <br />

      Services Controller 
      <br />
      -Get    	Localhost:{port}/api/Services
      <br />
      -Get    	Localhost:{port}/api/Services/{id}
      <br />
      -Create   Localhost:{port}/api/Services/[model]
      <br />
      -Put    	Localhost:{port}/api/Services/{id}/[model]
      <br />
      -Delete	Localhost:{port}/api/Services/{id}
      <br />

7.	SMTP Notification
-	Change configuration in ‘appsettings.json’ for SMTPConfig base your account
-	Notification will send when there are create and update in services controller to owner and mechanics

