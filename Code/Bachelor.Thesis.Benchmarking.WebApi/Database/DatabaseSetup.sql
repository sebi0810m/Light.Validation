CREATE TABLE ParametersPrimitiveTwo (
    [Id] INT IDENTITY(1, 1) CONSTRAINT PK_ParametersPrimitiveTwo PRIMARY KEY,
    [Name] NVARCHAR(80) NOT NULL
);

CREATE TABLE ParametersPrimitiveAll (
    [Id] INT IDENTITY(1, 1) CONSTRAINT PK_ParametersPrimitiveAll PRIMARY KEY,
    [Guid] UNIQUEIDENTIFIER CONSTRAINT UQ_ParametersPrimitiveAll_Guid UNIQUE NOT NULL,
    [Name] NVARCHAR(80) NOT NULL,
    [Position] CHAR(1) NOT NULL,
    [Department] SMALLINT NOT NULL,
    [WeeklyWorkingHours] SMALLINT NOT NULL,
    [EmployeeId] BIGINT NOT NULL,
    [ProductivityScore] FLOAT NOT NULL,
    [OvertimeWorked] FLOAT NOT NULL,
    [HourlySalary] DECIMAL(5, 2) NOT NULL,
    [DateEmployed] SMALLDATETIME NOT NULL
);

CREATE TABLE ParametersComplexTwo (
    [Id] INT IDENTITY(1, 1) CONSTRAINT PK_ParametersComplexTwo PRIMARY KEY,
    [Guid] UNIQUEIDENTIFIER CONSTRAINT UQ_ParametersComplexTwo_Guid UNIQUE NOT NULL,
    [User] NVARCHAR(2048) NOT NULL,
    [Address] NVARCHAR(2048) NOT NULL
);

CREATE TABLE CollectionFlat (
    [Id] INT IDENTITY(1, 1) CONSTRAINT PK_CollectionFlat PRIMARY KEY,
    [Guid] UNIQUEIDENTIFIER CONSTRAINT UQ_CollectionFlat_Guid UNIQUE NOT NULL,
    [Names] NVARCHAR(2048) NOT NULL,
    [Availability] NVARCHAR(2048) NOT NULL
);

CREATE TABLE CollectionComplex (
    [Id] INT IDENTITY(1, 1) CONSTRAINT PK_CollectionComplex PRIMARY KEY,
    [Guid] UNIQUEIDENTIFIER CONSTRAINT UQ_CollectionComplex_Guid UNIQUE NOT NULL,
    [OrderDetailsList] NVARCHAR(2048) NOT NULL,
    [ArticleList] NVARCHAR(2048) NOT NULL
);


