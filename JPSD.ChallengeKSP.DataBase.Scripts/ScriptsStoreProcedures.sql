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
CREATE PROCEDURE BeneficiariesUpdate
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



