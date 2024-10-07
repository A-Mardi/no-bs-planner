CREATE TABLE PlannerItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATETIME,
    isCompleted BIT
);