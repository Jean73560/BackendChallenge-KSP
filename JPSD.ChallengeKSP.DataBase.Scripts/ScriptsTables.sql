/*===== Creamos la base de datos "ChallengeKSP" =========*/
CREATE DATABASE ChallengeKSP;
USE ChallengeKSP;

/*========= Creamos la Tabla "Employees" =========*/
CREATE TABLE "Employees" (
	"EmployeeID" "int" IDENTITY (1, 1) NOT NULL ,
	"FullName" nvarchar (50) NOT NULL ,
	"Work" nvarchar (50) NOT NULL,
	"Salary" decimal NOT NULL,	
	"Status" bit NULL ,
	"HireDate" "datetime" NULL,	
	"PhotoPath" nvarchar (255) NULL ,
	"Phone" nvarchar (24) NULL ,

	CONSTRAINT "PK_Employees" PRIMARY KEY  CLUSTERED 
	(
		"EmployeeID"
	)
)
GO
 CREATE  INDEX "FullName" ON "dbo"."Employees"("FullName")
GO
 CREATE  INDEX "Work" ON "dbo"."Employees"("Work")
GO


/*========= Creamos la Tabla "Beneficiaries" =========*/

CREATE TABLE "Beneficiaries" (
	"BeneficiaryID" "int" IDENTITY (1,1) NOT NULL,
	"EmployeeID" "int" NOT NULL,
	"FullName" nvarchar (50) NOT NULL ,
	"Relationship" nvarchar (20) NOT NULL,
	"BirthDate" "datetime" NULL,
	"Gender" nvarchar (20) NULL,

	CONSTRAINT "PK_Beneficiaries" PRIMARY KEY CLUSTERED
	(
		"BeneficiaryID"
	),
	CONSTRAINT "FK_Beneficiaries_Employees" FOREIGN KEY 
	(
		"EmployeeID"
	) REFERENCES "dbo"."Employees" (
		"EmployeeID"
	)
) 
GO
 CREATE  INDEX "FullName" ON "dbo"."Beneficiaries"("FullName")
GO
 CREATE  INDEX "Relationship" ON "dbo"."Beneficiaries"("Relationship")
GO



/*INSERTS A LAS TABLAS EMPLOYEES Y BENEFICIARIES*/
INSERT INTO Employees ([FullName] ,[Work] ,[Salary] ,[Status] ,[HireDate] ,[PhotoPath] ,[Phone])
VALUES('Jean Pierre Soto Delgado', '.NET Full Stack Developer', 25000, 1, '2020/12/15', 'https://ksp.storage.com/001.jpg','9982212701')
GO

INSERT INTO Beneficiaries ([EmployeeID] ,[FullName] ,[Relationship] ,[BirthDate] ,[Gender])
     VALUES( 1, 'Vicente Gutierrez Reyes', 'Padre', '1958-01-03', 'M')
GO