CREATE TABLE Project(
	Project_ID INT IDENTITY(101, 1) PRIMARY KEY NOT NULL,
	Project_Name NVARCHAR(100) NOT NULL,
	Project_StartDate DATE NOT NULL,
	Project_EndDate DATE NOT NULL,
	Project_Details NVARCHAR(300) NOT NULL	
);

insert into Project  Values('xyz', '2020-09-29', '2020-10-23', 'all');
insert into Project  Values('abc', '2020-09-29', '2021-12-03', 'alllllllll');
select * from Project;

CREATE TABLE Employee(
	Employee_ID INT IDENTITY(1001,1) PRIMARY KEY NOT NULL,
	Employee_Name NVARCHAR(50) NOT NULL,
	Employee_Email NVARCHAR(50) unique NOT NULL,
	Employee_Phone_Number NVARCHAR(13) unique NOT NULL,
	Employee_Role NVARCHAR(30) NOT NULL,
	Employee_Status NVARCHAR(10) NOT NULL,
	Employee_Password NVARCHAR(30) NOT NULL,
	Manager_ID INT,
	Project_Id INT FOREIGN KEY references Project(Project_ID)
);

insert into Employee  Values('Amar', 'amarp@gmail.com','8989789168','Analyst','Active','password',null,101);
insert into Employee  Values('Amar  Kumar', 'apoddark@gmail.com','838849568','Analyst A4','Inactive','pass',1001,102);
insert into Employee  Values('Amar  Kumar POddar', 'akppoddar@gmail.com','8358849568','Analyst A5','Active','passw',1001,101);
select * from Employee;

drop table Employee_Project
CREATE TABLE Employee_Project(
	Employee_ID INT FOREIGN KEY references Employee(Employee_ID),
	Project_ID INT FOREIGN KEY references Project(Project_ID),
	Project_Manager_ID INT FOREIGN KEY references Employee(Employee_ID)
);

INSERT into Employee_Project values(1002, 102, 1001),(1003,101, 1001);
select * from Employee_Project;

drop table Attendance
CREATE TABLE Attendance(
	Attendance_ID INT IDENTITY PRIMARY KEY NOT NULL,
	Attedance_Type nvarchar(10) NOT NULL,
	Attedance_Date DATE NOT NULL,
	In_Time TIME(0) NOT NULL,
	Out_Time TIME(0) NOT NULL,
	Status_Of_Attendance NVARCHAR(10) NOT NULL,
	Status_Update_Date DATE NOT  NULL,
	Status_Updated_By INT FOREIGN KEY references Employee(EMPLOYEE_ID) ,
	Employee_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID),
	Manager_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID)
);

insert into Attendance values('P','2020-09-29','08:30','16:00','A', '2020-08-16', 1001, 1002, 1001),
('ASDDD','2020-11-29','09:30','18:00','P', '2020-07-16', 1001, 1003, 1001);
select * from Attendance;

drop table Leave
CREATE TABLE Leave(
	Leave_Request_ID int IDENTITY PRIMARY KEY NOT NULL,
	LeaveType NVARCHAR(30) NOT NULL,
	NO_Of_Days int NOT NULL,
	Leave_Balance int NOT NULL,
	Leave_Date_From DATE NOT NULL,
	Leave_Date_To DATE NOT NULL,
	Leave_Status NVARCHAR(30) NOT NULL,
	Employee_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID),
	Manager_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID)
);

insert into Leave values('P',5,2,'2020-09-29','2020-09-30','pending',1002,1001),
('M',3,4,'2020-10-25','2020-10-30','Approved',1003,1001);
select * from Leave;


CREATE TABLE Admin(
	Admin_ID int IDENTITY(100001,1) PRIMARY KEY NOT NULL,
	Admin_Name NVARCHAR(30) NOT NULL,
	Admin_Password NVARCHAR(30) NOT NULL,
);

insert into Admin values('Amar','password'),('Kumar','pass');
select * from Admin;
select * from Leave;
Select * from Attendance;
Select * from Project;
select * from Employee;
Select * from Employee_Project;

CREATE TABLE LeaveCredit
(
LeaveCredit_ID int IDENTITY PRIMARY KEY NOT NULL,
LeaveCredit_Value int not null
)

insert into LeaveCredit 
values (2),(2),(2),(2),(2),(2),(2),(2),(2),(2),(2),(2);

select * from LeaveCredit;


CREATE TABLE ListOfHolidays
(
Holiday_ID int IDENTITY primary KEy not null,
Holiday_Name nvarchar(50) not null,
Holiday_Date Date not null
)

insert into ListOfHolidays values
('Republic Day','2021-01-26'),
('Rama Navami','2021-04-21'),
('Good Friday','2021-04-02'),
('Ambedkar Jayanti','2021-04-14'),
('Eid al-Fitr','2021-05-12'),
('Indian Independence Day','2021-08-15'),
('Gandhi Jayanti','2021-10-02'),
('Dussehra','2021-10-15'),
('Diwali','2021-11-04'),
('Christmas Day','2021-12-25');

select * from ListOfHolidays;

create table ListOfWeekEnds
(
WeekEnd_Id int identity not null,
WeekEndDate Date not null
)

insert into ListOfWeekEnds values
('2021-01-02'),
('2021-01-03'),
('2021-01-09'),
('2021-01-10'),
('2021-01-16'),
('2021-01-17'),
('2021-01-23'),
('2021-01-24'),
('2021-01-30'),
('2021-01-31'),
('2021-02-06'),
('2021-02-07'),
('2021-02-13'),
('2021-02-14'),
('2021-02-20'),
('2021-02-21'),
('2021-02-27'),
('2021-02-28'),
('2021-03-06'),
('2021-03-07'),
('2021-03-13'),
('2021-03-14'),
('2021-03-20'),
('2021-03-21'),
('2021-03-27'),
('2021-03-28'),
('2021-04-03'),
('2021-04-04'),
('2021-04-10'),
('2021-04-11'),
('2021-04-17'),
('2021-04-18'),
('2021-04-24'),
('2021-04-25'),
('2021-05-01'),
('2021-05-02'),
('2021-05-08'),
('2021-05-09'),
('2021-05-15'),
('2021-05-16'),
('2021-05-22'),
('2021-05-23'),
('2021-05-29'),
('2021-05-30'),
('2021-06-05'),
('2021-06-06'),
('2021-06-12'),
('2021-06-13'),
('2021-06-19'),
('2021-06-20'),
('2021-06-26'),
('2021-06-27'),
('2021-07-03'),
('2021-07-04'),
('2021-07-10'),
('2021-07-11'),
('2021-07-17'),
('2021-07-18'),
('2021-07-24'),
('2021-07-25'),
('2021-07-31'),
('2021-08-01'),
('2021-08-07'),
('2021-08-08'),
('2021-08-14'),
('2021-08-15'),
('2021-08-21'),
('2021-08-22'),
('2021-08-28'),
('2021-08-29'),
('2021-09-04'),
('2021-09-05'),
('2021-09-11'),
('2021-09-12'),
('2021-09-18'),
('2021-09-19'),
('2021-09-25'),
('2021-09-26'),
('2021-10-02'),
('2021-10-03'),
('2021-10-09'),
('2021-10-10'),
('2021-10-16'),
('2021-10-17'),
('2021-10-23'),
('2021-10-24'),
('2021-10-30'),
('2021-10-31'),
('2021-11-06'),
('2021-11-07'),
('2021-11-13'),
('2021-11-14'),
('2021-11-20'),
('2021-11-21'),
('2021-11-27'),
('2021-11-28'),
('2021-12-04'),
('2021-12-05'),
('2021-12-11'),
('2021-12-12'),
('2021-12-18'),
('2021-12-19'),
('2021-12-25'),
('2021-12-26')

select * from ListOfWeekEnds
