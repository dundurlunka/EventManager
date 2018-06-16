# EventManager
Console application for Internship

<strong>Assignment</strong>

Create an application for managing events.

The following information is stored for each event: name, location, start date and time, end date and time (all are required).

The application should allow you to read all events, create a new event, update an existing event and delete it.

<strong>Setup guide</strong>

Download the files from the repository in <strong>GitHub</strong> to your local machine. Create a solution with a name of yours and add
the <strong>4 projects</strong>:
  <strong>
  - EventManager.Client
  - EventManager.Data
  - EventManager.Models
  - EventManager.Service
  </strong>
  
Make sure you setup <strong>EventManager.Client</strong> as a <strong>StartUp project</strong> before starting the application.
The connection string for the database is called <strong>EventManagerContext</strong> and is located in <strong>App.Config</strong> in <strong>EventManager.Client</strong> under the
<strong>\<connectionStrings\> tag</strong>. In default, the database is initialized under <strong>(LocalDb)\MSSQLLocalDB</strong> server.
Build the <strong>StartUp project</strong> and run it. This will launch the console application. For more information about the commands
of the program type <strong>Help</strong> in the console.
