"# BitcubeEval" 

The whole web app runs on a local sql database.

if it doesn't run from the solution then:
1. from visual studio open the NuGet Package Manager
2. from the console run : add-migration AddDatabase (This will automatically generate a script that creates a database with all the tables)
3. also run : update-database (This will check if the database exist, if not the scrip will rin and create The database you'll need for the whole application)
4  Open up Microsoft SQLServer Management Studio 18, connect to the sever (LocalDb)\\MSSQLLocalDB and the database called Facility will be created. then add values to the table, run the   application
5. If not using #4(LocalDB) but have already created the database, Open the appsettings.json file in the root directory and the first lines:
  "ConnectionStrings": {
    "DefaultConnection": "Server=(LocalDb)\\MSSQLLocalDB;DataBase=LecturerList;Trusted_Connection=True;MultipleActiveResultSets=True"
  },
  
Change the sever (LocalDb)\\MSSQLLocalDB and use  your own where database is located.
  
  --------
  This application uses .Net core 5.0 Razor pages instead of MVC
  --------------------------------------------------------
  
  The Validation folder contains the projects for Section 2.
  
  
