CREATE TABLE [Users] (
  [UserID] VARCHAR(10) PRIMARY KEY,
  [User_Name] VARCHAR(100) NOT NULL,
  [Password] VARCHAR(100) NOT NULL,
  [Fullname] NVARCHAR(100) NOT NULL,
  [Address] NVARCHAR(100),
  [Phone] VARCHAR(12) NOT NULL,
  [RoleID] VARCHAR(10) NOT NULL
)
GO

CREATE TABLE [Role] (
  [RoleID] VARCHAR(10) PRIMARY KEY,
  [RoleName] NVARCHAR(255) NOT NULL
)
GO

CREATE TABLE [Subject] (
  [SubjectID] VARCHAR(10) PRIMARY KEY,
  [Subject_Name] NVARCHAR(100) NOT NULL,
  [TeachingUnit] INT NOT NULL,
  [Credits] INT NOT NULL
)
GO

CREATE TABLE [Student] (
  [StudentID] VARCHAR(10) PRIMARY KEY,
  [Student_Name] NVARCHAR(100) NOT NULL,
  [BirthDay] DATETIME NOT NULL,
  [SexID] INT NOT NULL,
  [Address] NVARCHAR(200) NOT NULL,
  [ClassID] VARCHAR(10) NOT NULL
)
GO

CREATE TABLE [Sex] (
  [SexID] INT PRIMARY KEY IDENTITY(1, 1),
  [Sex_Name] NVARCHAR(10)
)
GO

CREATE TABLE [Department] (
  [DepartmentID] VARCHAR(10) PRIMARY KEY,
  [Department_Name] NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE [Class] (
  [ClassID] VARCHAR(10) PRIMARY KEY,
  [Class_Name] NVARCHAR(100) NOT NULL,
  [DepartmentID] VARCHAR(10) NOT NULL
)
GO

CREATE TABLE [Mark] (
  [MarkID] INT PRIMARY KEY IDENTITY(1, 1),
  [SubjectID] VARCHAR(10) NOT NULL,
  [StudentID] VARCHAR(10) NOT NULL,
  [Semester] INT NOT NULL,
  [Note] NVARCHAR(200),
  [MidtermScore] FLOAT NOT NULL,
  [FinalScore] FLOAT NOT NULL,
  [FinalGrade] FLOAT NOT NULL
)
GO

CREATE TABLE [Teacher] (
  [TeacherID] VARCHAR(10) PRIMARY KEY,
  [Teacher_Name] NVARCHAR(100) NOT NULL,
  [SexID] INT NOT NULL,
  [DepartmentID] VARCHAR(10) NOT NULL,
  [Email] VARCHAR(100) NOT NULL,
  [Phone] VARCHAR(12) NOT NULL,
  [HomeTown] NVARCHAR(100),
  [Address] NVARCHAR(255) NOT NULL,
  [Image] TEXT
)
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([RoleID]) REFERENCES [Role] ([RoleID])
GO

ALTER TABLE [Student] ADD FOREIGN KEY ([SexID]) REFERENCES [Sex] ([SexID])
GO

ALTER TABLE [Student] ADD FOREIGN KEY ([ClassID]) REFERENCES [Class] ([ClassID])
GO

ALTER TABLE [Class] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID])
GO

ALTER TABLE [Mark] ADD FOREIGN KEY ([SubjectID]) REFERENCES [Subject] ([SubjectID])
GO

ALTER TABLE [Mark] ADD FOREIGN KEY ([StudentID]) REFERENCES [Student] ([StudentID])
GO

ALTER TABLE [Teacher] ADD FOREIGN KEY ([SexID]) REFERENCES [Sex] ([SexID])
GO

ALTER TABLE [Teacher] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID])
GO

ALTER TABLE [Teacher] ADD Note NVARCHAR(200)
GO

ALTER TABLE [Student] ADD DepartmentID VARCHAR(10)
GO

SELECT TeacherID,Teacher_Name,Sex_Name,Department_Name,Email,Phone,HomeTown,Address,Image,Note FROM Teacher,Department,Sex WHERE Teacher.DepartmentID = Department.DepartmentID AND Sex.SexID = Teacher.SexID AND Teacher.Teacher_Name = N'Nguyễn Quốc Phương';

