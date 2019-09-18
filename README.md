MASGLOBAL HandsOn Test

- Open MASGlobalTest Solutuin in MS VS 2017
- When you Run the Application The Index View is Opened http://localhost:50218/
- All views have a Navigation Bar With Three Links: 
	- MASGLOBAL HandsOnTest: It calls Index View and it deploys a list of all employees
          http://localhost:50218/
	- Get Employee: GetEmployees View is opned and it has a form used to search employees
          http://localhost:50218/Employees/GetEmployees
		  If the TextBox is empty the information of all employees is displayed
		  If a numeric Id is filled in the TextBox the information for that particular employee is displayed 
	- Consume API: API View is opned at it shows howto consume the API
          http://localhost:50218/Employees/API
        
- You can consume the API as follows:
  Please change the correct port that asigns your VS 2017 => http://localhost:50218
  GET api/data => http://localhost:50218/api/data/
  GET api/data/id/ =>http://localhost:50218/api/data/1
  
