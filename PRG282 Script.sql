Create database Students

use Students 



Create Table ModuleDetails 
(	ModuleCode int Primary key identity(1000,1),
	ModuleName nvarchar(50) not null,
	ModuleDescription nvarchar(100),
	ModuleLink nvarchar(200)
)
Create Table StudentDetails
(	StudentNumber int Primary key identity(1,1),
	StudentName nvarchar(50) not null,
	StudentSurname nvarchar(50) not null,
	StudentImage image,
	StudentDOB datetime not null,
	StudentGender nvarchar(30) not null,
	StudentPhone nvarchar(10) not null unique,
	StudentAddress nvarchar(80) not null
)

Create Table StudentModules
(	ModuleCode int foreign key references ModuleDetails(ModuleCode),
	StudentNumber int foreign key references StudentDetails(StudentNumber),
	PRIMARY KEY(StudentNumber, ModuleCode)		
)

Insert into ModuleDetails (ModuleName, ModuleDescription, ModuleLink) Values ('PRG181', 'Intro to the basics of programming', 'https://www.youtube.com/watch?v=zOjov-2OZ0E')
Insert into ModuleDetails (ModuleName, ModuleDescription, ModuleLink) Values ('MAT181', 'Basics of linear algebra and pre-calculus', 'https://www.youtube.com/watch?v=JrWJnwCMlP0')
Insert into ModuleDetails (ModuleName, ModuleDescription, ModuleLink) Values ('LPR181', 'Intro to optimization linear programming', 'https://www.youtube.com/watch?v=Bzzqx1F23a8&t=1213s')
Insert into ModuleDetails (ModuleName, ModuleDescription, ModuleLink) Values ('WPR181', 'Intro to the basics of web programming (HTML+CSS)', 'https://www.youtube.com/watch?v=ysEN5RaKOlA&t=63s')
Insert into ModuleDetails (ModuleName, ModuleDescription, ModuleLink) Values ('STA181', 'Intro to university-level statistics and probability', 'https://www.youtube.com/watch?v=SkidyDQuupA')

Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Luan', 'Hietbrink', cast('2002-07-23' as datetime), 'Male','0839471642', '31 16th Ave, Menlo Park, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Gale', 'Boetticher', cast('2000-11-16' as datetime), 'Male','0754879651', '6353 Juan Tabo, Lynnwood, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Walter', 'White', cast('2001-10-18' as datetime), 'Male','098746135', '308 Negra Arroyo Lane, Queenswood, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Jesse', 'Pinkman', cast('1999-11-07' as datetime), 'Male','0654321987', '64 Dawg Str, Montana, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Hank', 'Schrader', cast('1997-12-01' as datetime), 'Male','0764891542', '544 Yo Mama Ave, Waterkloof, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Mike', 'Ehrmantraut', cast('1998-07-09' as datetime), 'Male','0736458912', '12 45th Ave, Nina Park, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Marie', 'Schrader', cast('2002-08-31' as datetime), 'Female','0864579215', '1212 1st Ave, Wierdapark, Pretoria')
Insert into StudentDetails (StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress) values ('Anna', 'Gunn', cast('2003-04-01' as datetime), 'Female','0884665731', '31 16th Ave, Menlo Park, Pretoria')


Insert into StudentModules (StudentNumber, ModuleCode) values (1,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (2,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (3,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (4,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (5,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (6,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (7,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (8,1000)
Insert into StudentModules (StudentNumber, ModuleCode) values (1,1001)
Insert into StudentModules (StudentNumber, ModuleCode) values (1,1003)
Insert into StudentModules (StudentNumber, ModuleCode) values (3,1003)
Insert into StudentModules (StudentNumber, ModuleCode) values (2,1002)
Insert into StudentModules (StudentNumber, ModuleCode) values (6,1004)
Insert into StudentModules (StudentNumber, ModuleCode) values (2,1003)
Insert into StudentModules (StudentNumber, ModuleCode) values (7,1003)
Insert into StudentModules (StudentNumber, ModuleCode) values (3,1004)
Insert into StudentModules (StudentNumber, ModuleCode) values (3,1002)
Insert into StudentModules (StudentNumber, ModuleCode) values (3,1001)
Insert into StudentModules (StudentNumber, ModuleCode) values (2,1004)
Insert into StudentModules (StudentNumber, ModuleCode) values (5,1001)

go 
