--PROJECT MODULE.......................................................>

CREATE PROCEDURE spViewProjectDetails
	@pId int
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT Project.Project_ID, Project.Project_Name, Project.Project_StartDate, Project.Project_EndDate, 
	Project.Project_Details, Employee_Project.Employee_ID, Employee_Project.Project_Manager_ID 
	FROM Project JOIN Employee_Project
	on Project.Project_ID = Employee_Project.Project_ID
	Where Project.Project_ID = @pId;
END
GO
exec spViewProjectDetails 102;

CREATE PROCEDURE spAddProject
	@projectName NVARCHAR(100),
	@projectStartDate DATE,
	@projectEndDate DATE,
	@projectDetails NVARCHAR(300)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO Project VALUES(@projectName, @projectStartDate, @projectEndDate, @projectDetails);
END
GO

exec spAddProject 'ABCD', '2020-09-18', '2020-10-19', 'ABCDEFGHIJKL';
select * from Project;


CREATE PROCEDURE spUpdateProject
	@pId int,
	@projectName NVARCHAR(100),
	@projectStartDate DATE,
	@projectEndDate DATE,
	@projectDetails NVARCHAR(300)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Project set Project_Name = @projectName, Project_StartDate = @projectStartDate, 
	Project_EndDate = @projectEndDate, Project_Details = @projectDetails where Project_ID = @pId;
END
GO


exec spUpdateProject @projectName ='aaa', @projectStartDate = '2020-08-05', @projectEndDate = '2020-09-08',
@projectDetails = 'abcdabcd', @pId =101;

select * from Project;


CREATE PROCEDURE spDeleteProject
	@pId int
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM Project where Project_ID = @pId;
END
GO

exec spDeleteProject 103;
select * from Project;

CREATE PROCEDURE spAssignProjectToEmployee
	@eId int,
	@pId int,
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO Employee_Project VALUES(@eId, @pId, @mId);
END
GO

exec spAssignProjectToEmployee 1002, 102, 1001;
select * from Employee_Project;


CREATE PROCEDURE spUpdateEmployeeOnProject
	@eId int,
	@pId int,
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Employee_Project set Employee_ID = @eId, Project_Manager_ID = @mId where Project_ID = @pId; 
END
GO

exec spUpdateEmployeeOnProject @pId = 101, @eId = 1003, @mId = 1001

select * from Employee_Project ;


CREATE PROCEDURE spListProject
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT Project_ID, Project_Name, Project_StartDate, Project_EndDate from Project
END
GO
exec spListProject;


--Attendance Module.....................................................................................
drop procedure spAddAttendance
Create procedure spAddAttendance
	@Attedance_Type nvarchar(30),
	@Attedance_Date DATE,
	@In_Time TIME(0),
	@Out_Time TIME(0),
	@Status_Of_Attendance NVARCHAR(10) = 'Pending',
	@Status_Update_Date DATE = NULL,
	@Status_Updated_By INT = NULL ,
	@Employee_ID INT,
	@Manager_ID int =NULL,
	@Project_ID int
AS
BEGIN
	SET NOCOUNT OFF;
	insert into Attendance values(@Attedance_Type, @Attedance_Date, @In_Time, @Out_Time,
	@Status_Of_Attendance, @Status_Update_Date, @Status_Updated_By, @Employee_ID, @Manager_ID, @Project_ID);
END
GO
 
 exec spAddAttendance 'Working From Home','01-10-2020','10:00:00','20:00:00','Pending',null,null,1003,1001,101;
 select * from Attendance;



 /*-------------------------modify attendance------------------------*/
 
 drop procedure spModifyAttendance
 CREATE procedure spModifyAttendance
	@Attedance_Type nvarchar(30),
	@Attedance_Date DATE,
	@In_Time TIME(0),
	@Out_Time TIME(0),
	@Employee_ID INT,
	@aId int

as 
BeGIN
 SET NOCOUNT OFF;
	update Attendance set Attedance_Type = @Attedance_Type,
	Attedance_Date= @Attedance_Date,
	In_Time= @In_Time,
	Out_Time= @Out_Time
	where Attendance_ID = @aId and Employee_ID = @Employee_ID and Status_Of_Attendance = 'Pending';
 END
 
 exec spModifyAttendance @Attedance_Type = 'Business Travel', @Attedance_Date = '2020-09-08', 
 @In_Time = '10:30:00', @Out_Time = '17:00:00', @aId = 3, @Employee_ID = 1003;


 select * from Attendance;


 /*---------------------delete Attendance---------------------------*/

CREATE PROCEDURE spDeleteAttendance
	@aId int,
	@eId int
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM Attendance where Attendance_ID = @aId AND Employee_ID = @eId and Status_Of_Attendance = 'Pending';
END
GO

exec spDeleteAttendance @aId = 1, @eId = 1002;
select * from attendance;


CREATE PROCEDURE spSearchAttendance
	@aId int,
	@eId int

AS
BEGIN
	SET NOCOUNT OFF;
	SELECT * FROM Attendance where Attendance_ID = @aId and Employee_ID = @eId;
END
GO

exec spSearchAttendance @aid = 2, @eId = 1003;
select * from attendance;

/*---------------------------------attandanceDetailsDisplay------------------------*/

CREATE PROCEDURE spAttendanceDetailsDisplay

AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance;
END
GO

exec spAttendanceDetailsDisplay ;



CREATE PROCEDURE spListAttendanceDetailsDisplay
	@eId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance where @eId = Employee_ID;
END
GO

select * from Employee
exec spListAttendanceDetailsDisplay @eId= 1004
/*---------------------------------ApproveRejectAttendance--------------------------*/

CREATE PROCEDURE spApproveRejectAttendanceRequest
	@aId int,
	@Status_Of_Attendance varchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	update Attendance set Status_Of_Attendance = @Status_Of_Attendance where Attendance_ID = @aId; 
END
GO

exec spApproveRejectAttendanceRequest @status_Of_Attendance = 'p', @aId = 8;
select * from Attendance;


--=======================================================================================

CREATE PROCEDURE spLeaveCheck
	@ADate Date,
	@eId int
AS
BEGIN
	SET NOCOUNT on;
	select Employee_ID, Leave_Date_From, Leave_Date_To from Leave where
	@ADate  between Leave_Date_From and Leave_Date_To and Employee_ID = @eId;
END
GO
exec spLeaveCheck '2020-10-13', 1001;
select * from Leave



CREATE PROCEDURE spAttendanceAlreadyAppliedCheck
	@ADate Date,
	@eId int
AS
BEGIN
	SET NOCOUNT on;
	select Employee_ID from Attendance where
	Attedance_Date = @ADate and Employee_ID = @eId;
END
GO

exec spAttendanceAlreadyAppliedCheck '2020-10-03', 1003;
select * from Attendance;
select * from Leave;

--Request Leave
CREATE PROCEDURE spRequestLeave  
	@LeaveType NVARCHAR(30),
	@NoOfDays int,
	@LeaveBalance int,
	@LeaveDateFrom  Date,
	@LeaveDateTo Date,
	@Status nvarchar(30),
	@eId  int,
	@mId int
AS
BEGIN
	
	SET NOCOUNT OFF;
	INSERT INTO Leave VALUES(@LeaveType, @NoOfDays, @LeaveBalance, @LeaveDateFrom, @LeaveDateTo,@Status, @eId, @mId);
END
GO
select * from Employee;
Exec spRequestLeave 'x',5,5,'2020-10-12','2020-10-17','Pending',1002,1001;
Exec spRequestLeave 'p',2,3,'2020-10-12','2020-10-14','Accepted',1003,1001;
Exec spRequestLeave 'm',3,5,'2020-10-12','2020-10-15','Rejected',1004,1001;
Exec spRequestLeave 'p',1,4,'2020-10-12','2020-10-13','Pending',1002,1001;

select * from leave;

--Check Status of Leave Request
CREATE PROCEDURE spStatusOfAllLeave
  @eId int
As
Begin 
Set Nocount OFF;
select Leave_Request_ID, Leave_Status from Leave where Employee_ID=@eId;
END
GO

exec spStatusOfAllLeave 1003;
select * from leave;


--Delete Leave Request
CREATE PROCEDURE spDeleteLeaveRequest
 @LeaveRequestId int

 As
Begin 
Set Nocount OFF;

delete  from Leave where leave.Leave_Request_ID=@LeaveRequestId;
END
GO

exec spDeleteLeaveRequest 3;

select * from Leave;


-- Modify requested leave
Create PROCEDURE spModifyLeaves 
  @LeaveRequestId int,
  @LeaveType NVARCHAR(30),
	@NoOfDays int,
	@LeaveBalance int,
	@LeaveDateFrom  Date,
	@LeaveDateTo Date,
	@Status nvarchar(30),
	@eId  int,
	@mId int
 As
Begin 
Set Nocount OFF;

UPDATE Leave  
            SET    LeaveType=  @LeaveType,  
                   NO_Of_Days = @NoOfDays,  
                   Leave_Balance = @LeaveBalance,  
                   Leave_Date_From = @LeaveDateFrom ,
				   Leave_Date_To=@LeaveDateTo,
				   Leave_Status=@Status,
				   Employee_ID=@eId,
				  Manager_ID =@mId
            WHERE  Leave_Request_ID = @LeaveRequestId 
END
GO

exec spModifyLeaves 2,'mm',5,08,'2020-11-12','2020-11-17','Accepted',1002,1001;

select * from Leave;


--Leave Credit
CREATE PROCEDURE spLeaveBalance

As
Begin 
Set Nocount OFF;

select Leave_Balance  from Leave ;
END
GO


--Leave History
Create Procedure spLeaveHistory
	 @EmployeeID int
 As
Begin 
Set Nocount OFF;

select * from Leave where Employee_ID=@EmployeeID;
END
GO

exec spLeaveHistory 1003;


--List of Leave request in pending status
Create Procedure spApproveRejectLeaveRequest
	
 As
Begin 
Set Nocount OFF;

select * from Leave where Leave_Status  like'%Pending%' ;
END
GO

Exec spApproveRejectLeaveRequest;

--List of Requested Leaves
Create Procedure spListOfRequestedLeaves
	
 As
Begin 
Set Nocount on;

select * from Leave;
END
GO

exec spListOfRequestedLeaves;




/* Employee Module---------------------add employee-----------------------*/

CREATE PROCEDURE spAddEmployee	
	@Employee_Name NVARCHAR(50),
	@Employee_Email NVARCHAR(50) ,
	@Employee_Phone_Number NVARCHAR(13),
	@Employee_Role NVARCHAR(30),
	@Employee_Status NVARCHAR(10),
	@Employee_Password NVARCHAR(30),
	@mId INT,
	@pId INT 
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO Employee VALUES(@Employee_Name, @Employee_Email, @Employee_Phone_Number,
	@Employee_Role, @Employee_Status, @Employee_Password, @mId, @pId);
END
GO

exec spAddEmployee 'dhara', 'dhara@gmail.com','8888888888','Analyst','Active', 'password',1001,101;
select * from employee;

/*-----------------Delete Employee -------------------------*/
-- here i face some issue.................

--The DELETE statement conflicted with the REFERENCE constraint "FK__Employee___Emplo__29572725". The conflict occurred in database "Project_DB", table "dbo.Employee_Project", column 'Employee_ID'.

CREATE PROCEDURE spDeleteEmployee
	@eId int
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Employee  SET Employee_Status = 'Inactive' where Employee_ID = @eId;
END
GO

select * from Employee

exec spDeleteEmployee 1003; 
select * from employee;
select * from Attendance;


/*---------------------------Modify employee details -----------------------------*/

CREATE PROCEDURE spModifyEmployeeDetails
	@eId int,
	@Employee_Name NVARCHAR(50),
	@Employee_Email NVARCHAR(50) ,
	@Employee_Phone_Number NVARCHAR(13),
	@Employee_Role NVARCHAR(30),
	@Employee_Status NVARCHAR(10),
	@Employee_Password NVARCHAR(30) ,
	@Manager_ID INT,
	@Project_Id INT 
AS
BEGIN
	SET NOCOUNT OFF;
	update Employee set  Employee_Name=@Employee_Name,
	Employee_Email=@Employee_Email,
	Employee_Phone_Number=@Employee_Phone_Number,
	Employee_Role=@Employee_Role,
	Employee_Status = @Employee_Status,
	Employee_Password=@Employee_Password,
	Manager_ID=@Manager_ID,
	Project_Id=@Project_Id
	where Employee_ID = @eId;
END
GO

exec spModifyEmployeeDetails 
@eId = 1002,
	@Employee_Name ='dhara',
	@Employee_Email = 'radha@gmail.com' ,
	@Employee_Phone_Number= '4545676765',
	@Employee_Role ='manager',
	@Employee_Status = 'Active',
	@Employee_Password = 'asdasd' ,
	@Manager_ID =1001,
	@Project_Id =101; 


	select * from employee;

	/*--------------------------login logout ---------------------------*/



CREATE PROCEDURE spLoginEmployee
	@eId int,
	@password nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	select * from employee where Employee_ID = @eId and Employee_Password =@password;
END
GO

exec spLoginEmployee 1002, asdasd;


CREATE PROCEDURE spLoginAdmin
	@adminId int,
	@password nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Admin where Admin_ID = @adminId and Admin_Password = @password;
END
GO

exec spLoginAdmin 100001, password;





/*----------------------------------view employee details for one employee----------------------------*/

CREATE PROCEDURE spViewEmployeeDetail
	@eId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Employee where Employee_ID = @eId;
END
GO

select * from leave;
select * from employee;

exec spViewEmployeeDetail 1001;


/*--------------------------------list of holidays --------------------------------------*/

CREATE PROCEDURE spListOfHolidays
AS
BEGIN
	SET NOCOUNT OFF;
	select * from ListOfHolidays;
END
GO

exec spListOfHolidays

/*--------------------leave credit -----------------*/

CREATE PROCEDURE spLeaveCredit

AS
BEGIN
	SET NOCOUNT OFF;
	select LeaveCredit_ID as Month, LeaveCredit_Value from LeaveCredit;
END
GO

exec spLeaveCredit

/*-------------------list of all leaves for approve reject------------------------*/

CREATE PROCEDURE spListOfAllLeavesForAproveReject
@mid int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID= @mid and Leave_Status = 'Pending';
END
GO

exec spListOfAllLeavesForAproveReject 1007;



/*-------------------------leave count to calculate leave balance-----------------------*/

CREATE PROCEDURE spListOfAcceptedLeaveCount
@eId int
AS
BEGIN
	SET NOCOUNT OFF;
	select count(Leave_Status) as countLeave from leave where Leave_Status= 'Accepted' AND Employee_ID = @eId;
END
GO

spListOfAcceptedLeaveCount 1003
select * from leave


/*-------------------------approve leave request----------------------------*/

CREATE PROCEDURE spApproveLeaveRequest
@lId int
AS
BEGIN
	SET NOCOUNT OFF;
	update leave set Leave_Status = 'Accepted' where Leave_Request_ID=@lId;
	END
GO

exec spApproveLeaveRequest 40

select * from leave 

/*-------------------------reject leave request----------------------------*/

CREATE PROCEDURE spRejectLeaveRequest
@lId int
AS
BEGIN
	SET NOCOUNT OFF;
	update leave set Leave_Status = 'Rejected' where Leave_Request_ID=@lId;
	END
GO

exec spRejectLeaveRequest 49

select * from leave 

update leave set Leave_Status = 'Pending' where Leave_Request_ID=48;
update leave set Leave_Status = 'Pending' where Leave_Request_ID=49;
update leave set Leave_Status = 'Pending' where Leave_Request_ID=51;


/*------------------------HISTORY OF ALL EMPLOYEE here M for manager-------------*/

CREATE PROCEDURE spMLeaveHistory
@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID = @mId;
	END
GO

exec spMLeaveHistory 1007

/*------------------------------------approved leaves manager side-------------------*/



CREATE PROCEDURE spMAcceptedLeaveDetails
@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID = @mId and Leave_Status = 'Accepted' order by Employee_ID asc;
	END
GO

exec spMAcceptedLeaveDetails 1007


/*------------------------------------rejected leaves manager side-------------------*/



CREATE PROCEDURE spMRejectedLeaveDetails
@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID = 1007 and Leave_Status = 'Rejected' order by Employee_ID asc;
	END
GO
select * from leave
exec spMRejectedLeaveDetails 1007

/* -------------------------search filters------------------------*/

CREATE PROCEDURE spLeaveSearchByMonth
@month int,
@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID = @mid AND (month(Leave_Date_From) = @month or month(Leave_Date_To) = @month)
	END
GO

exec spLeaveSearchByMonth 10,1007

select * from leave

select * from employee

/*-------------------search leave details by year-------------------*/

CREATE PROCEDURE spLeaveSearchByYear
@Year int,
@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID = @mid AND (Year(Leave_Date_From) = @year or year(Leave_Date_To) = @year)
	END
GO

exec spLeaveSearchByYear 2021, 1007

/*-----------------search data between two days----------------*/

CREATE PROCEDURE spLeaveSearchByDateLimit
@mId int,
@startDate date,
@endDate date
AS
BEGIN
	SET NOCOUNT OFF;
	select * from leave where Manager_ID = @mId and Leave_Date_From between @startDate and @endDate;
	END
GO
select * from leave
exec spLeaveSearchByDateLimit 1007,'2020/11/11','2021/02/02';

/*----------------------------------view admin details by Id------------------*/
-- to save data in admin entity

CREATE PROCEDURE spViewAdminDetailsById
@aId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Admin where Admin_ID = @aId;
	END
GO
exec spViewAdminDetailsById 100001

exec spGetAllEmployee

/*-----------------------------------getall employee-------------*/

create Procedure spGetAllEmployee
	As
	Begin
	Set Nocount on;
	select * from Employee;
end
go

exec spGetAllEmployee

/*-----------------search employee------------*/

Create Procedure spSearchEmployee
	@eId int

As
Begin
	SET NOCOUNT ON;
	select * from employee where Employee_ID=@eid;
End
Go
exec spSearchEmployee 1008


/*------------------------------pending attendence admin side------------------*/

CREATE PROCEDURE spPendingAttendanceDetailsDisplay

AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance where Status_Of_Attendance like '%Pending%';
END
GO

exec spPendingAttendanceDetailsDisplay


/*--------------------------pending leaves admin side------------*/

CREATE PROCEDURE spPendingLeavesDetailsDisplay

AS
BEGIN
	SET NOCOUNT OFF;
	select * from Leave where Leave_Status like '%Pending%';
END
GO

exec spPendingLeavesDetailsDisplay
/*-----------------------------admin side show project manager----------*/



CREATE PROCEDURE spProjectManager

AS
BEGIN
	SET NOCOUNT OFF;
	select E.Manager_ID,P.Project_Id,P.Project_Name,P.Project_Details
	from Employee E inner join Project p
	on E.Project_Id = P.Project_ID
	where Manager_ID is not null
END
GO

exec spProjectManager

/*---------------checl date leave--------------*/



CREATE PROCEDURE spListPendingAttendance
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance where Manager_ID = @mId and Status_OF_Attendance = 'Pending';
END
GO
exec spListPendingAttendance 1001;
select * from Attendance


CREATE PROCEDURE spListApprovedAttendance
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance where Manager_ID = @mId and Status_OF_Attendance = 'Approved';
END
GO
exec spListApprovedAttendance 1002;
select * from Attendance

CREATE PROCEDURE spListRejectedAttendance
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance where Manager_ID = @mId and Status_OF_Attendance = 'Rejected';
END
GO
exec spListRejectedAttendance 1001;
select * from Attendance


CREATE procedure spApproveRejectPendingAttendance
	@Status_Of_Attendance nvarchar(10),
	@Status_Update_Date Date,
	@Status_Updated_By int,
	@aId int

as 
BeGIN
 SET NOCOUNT OFF;
	update Attendance set Status_Of_Attendance = @Status_Of_Attendance,
	Status_Update_Date= @Status_Update_Date,
	Status_Updated_By= @Status_Updated_By
	where Attendance_ID = @aId;
 END
 
 exec spApproveRejectPendingAttendance @Status_Of_Attendance = 'Approved', 
 @Status_Update_Date = '2020-10-03', 
 @Status_Updated_By = 1001, @aId = 15;

 select * from Attendance;




 
CREATE PROCEDURE spListProjectAttendance
	@pId int,
	@mid int
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance where @pId = Project_ID and @mid = Manager_ID;
END
GO

select * from Attendance
exec spListProjectAttendance @pId= 103, @mId = 1001;


CREATE PROCEDURE spAttendanceSearchByMonth
@pId int,
@month int,
@mId int
AS
BEGIN
SET NOCOUNT OFF;
select * from Attendance where Project_ID = @pId AND (month(Attedance_Date) = @month) AND Manager_ID = @mId 
END
GO

exec spAttendanceSearchByMonth @pId = 101, @mId = 1001, @month = 11;



CREATE PROCEDURE spAttendanceSearchByDay
@pId int,
@day date,
@mId int
AS
BEGIN
SET NOCOUNT OFF;
select * from Attendance where Project_ID = @pId AND Attedance_Date = @day AND Manager_ID = @mId 
END
GO

exec spAttendanceSearchByDay @pId = 101, @mId = 1001, @day = '2020-10-03';


CREATE PROCEDURE spAttendanceSearchBetweenDates
@mId int,
@pId int,
@startDate date,
@endDate date
AS
BEGIN
SET NOCOUNT OFF;
select * from Attendance where Manager_ID = @mId and Project_ID = @pId and Attedance_Date between @startDate and @endDate;
END
GO

exec spAttendanceSearchBetweenDates 1001,101, '2020/09/01','2020/10/02';



 