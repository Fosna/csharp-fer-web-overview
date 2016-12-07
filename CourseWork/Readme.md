# CourseWork
Web application for managing students and courses.

#### 1 Setup solution
1.1 ASP.net Core with full .NET Framework.

1.2 Remove production CSS and JS. It's confusing for now.

1.3. Remove contact and about pages. It makes to much noise.

1.4 Update bootstrap to version 3.3.7 and include bootswatch themes with version 3.3.7+2 to solution. 

Can search for packages at https://bower.io/

Use bower to add front end dependencies.
bower.json is visible only after all files in folder are visible. Consider using file explorer to locate bower.json which is in the root of web project.

Look how wwwroot/lib folder grows...

1.5 Include bootswatch theme CSS in HTML head.

1.6 Put two links that look like a button on home page.

1.7 Add same links to navigation bar.



#### 2 Manage students

2.1 Add student controller and placeholder page. Make sure that controller and view are wired up nicely.

2.2 Hook up Entity Framework 6 (not EF Core!). Make sure database can be reached.

2.3 Add random students to the database. Use seed database.

Consider manually deleting database if seed doesn't work.
Use test method on student controller to get number of students in a database. Idea is to check if students really exist in Students table in database.

2.4 Create student list view.

2.5 Remove student from database. Use POST request. Respond with message on success.

2.6 Show student details. Hook up remove student button on that page as well.

2.7 Enable student editing.

2.8 Setup server side student validation.

2.9 Introduce client side validation as well.

2.10 Be able to add student.


#### 3. Manage courses

3.1. Seed database with courses. Show list and course details.



