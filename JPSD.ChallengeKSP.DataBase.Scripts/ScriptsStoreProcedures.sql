/*=========== Creamos Stores Procedures de para operaciones CRUD de la tabla "Employees" ===========*/


/*INSERT EMPLOYEE*/
CREATE PROCEDURE EmployeesInsert
(
	@FullName nvarchar (50),
	@Work nvarchar (40),
	@Salary decimal,	
	@Status bit NULL ,
	@HireDate datetime NULL,	
	@PhotoPath nvarchar (255) NULL ,
	@Phone nvarchar (24) NULL 
)
AS
BEGIN

	INSERT INTO Employees (FullName, Work, Salary, Status, HireDate, PhotoPath, Phone)
	VALUES (@FullName, @Work, @Salary, @Status, @HireDate, @PhotoPath, @Phone)

END
GO


/*UPDATE EMPLOYEE*/
CREATE PROCEDURE EmployeesUpdate
(
	@EmployeeID int,
	@FullName nvarchar (50),
	@Work nvarchar (40),
	@Salary decimal,	
	@Status bit NULL ,
	@HireDate datetime NULL,	
	@PhotoPath nvarchar (255) NULL ,
	@Phone nvarchar (24) NULL 
)
AS
BEGIN
	UPDATE Employees
		SET
		FullName = @FullName,
		Work = @Work,
		Salary = @Salary,	
		Status = @Status,
		HireDate = @HireDate,	
		PhotoPath = @PhotoPath,
		Phone = @Phone
	WHERE EmployeeID = @EmployeeID
END
GO

/*DELETE EMPLOYEE*/
CREATE PROCEDURE EmployeesDelete
(
	@EmployeeID int
)
AS
BEGIN

    DELETE Employees
    WHERE EmployeeID = @EmployeeID

END
GO



/*SELECT Employees GetAll*/
CREATE PROCEDURE EmployeesGetAll
AS
BEGIN

    SELECT EmployeeID, FullName, Work, Salary, Status, HireDate, PhotoPath, Phone
    FROM Employees

END
GO


/*SELECT Employees GetByID*/
CREATE PROCEDURE EmployeesGetByID
(
	@EmployeeID int
)
AS
BEGIN

    SELECT EmployeeID, FullName, Work, Salary, Status, HireDate, PhotoPath, Phone
    FROM Employees
	WHERE EmployeeID = @EmployeeID

END
GO



/*=======================================================================================================*/





/*=========== Creamos Stores Procedures de para operaciones CRUD de la tabla "Beneficiaries" ===========*/


/*Insert Beneficiaries*/

CREATE PROCEDURE BeneficiariesInsert 
(
	@EmployeeID int,
	@FullName nvarchar(50),
	@Relationship nvarchar(20),
	@BirthDate datetime NULL,
	@Gender nvarchar (20) NULL
)
AS
BEGIN

	INSERT INTO Beneficiaries (EmployeeID, FullName, Relationship, BirthDate, Gender)
	VALUES (@EmployeeID,@FullName,@Relationship,@BirthDate,@Gender);
END
GO


/*UPDATE Beneficiaries*/
CREATE PROCEDURE
(
	@BeneficiaryID int,
	@EmployeeID int,
	@FullName nvarchar(50),
	@Relationship nvarchar(20),
	@BirthDate datetime NULL,
	@Gender nvarchar (20) NULL
)
AS
BEGIN
	UPDATE Beneficiaries
		SET
		EmployeeID = @EmployeeID, 
		FullName = @FullName, 
		Relationship = @Relationship, 
		BirthDate = @BirthDate, 
		Gender = @Gender
	WHERE BeneficiaryID = @BeneficiaryID
END
GO

/*DELETE Beneficiaries*/
CREATE PROCEDURE BeneficiariesDelete
(
	@BeneficiaryID int
)
AS
BEGIN

    DELETE Beneficiaries
    WHERE BeneficiaryID = @BeneficiaryID

END
GO


/*SELECT Beneficiaries GetAll*/
CREATE PROCEDURE BeneficiariesGetAll
AS
BEGIN
	SELECT BeneficiaryID, EmployeeID, FullName, Relationship, BirthDate, Gender
	FROM Beneficiaries
END
GO

/*SELECT Beneficiaries GetByID*/
CREATE PROCEDURE BeneficiariesGetByID
(
	@BeneficiaryID int
)
AS
BEGIN
	SELECT BeneficiaryID, EmployeeID, FullName, Relationship, BirthDate, Gender
	FROM Beneficiaries
	WHERE BeneficiaryID = @BeneficiaryID
END
GO

/*SELECT Beneficiaries GetByEmployeeID*/
CREATE PROCEDURE BeneficiariesGetByEmployeeID
(
	@EmployeeID int
)
AS
BEGIN
	SELECT BeneficiaryID, EmployeeID, FullName, Relationship, BirthDate, Gender       
	FROM Beneficiaries 
	WHERE EmployeeID = @EmployeeID
END
GO