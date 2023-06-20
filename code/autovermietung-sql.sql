CREATE TABLE Cars (
    CarId INT PRIMARY KEY,
    Brand VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    DailyRate DECIMAL(10, 2) NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    LicenseNumber VARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Rentals (
    RentalId INT PRIMARY KEY,
    CarId INT,
    CustomerId INT,
    StartDate DATE,
    EndDate DATE,
    TotalCost DECIMAL(10, 2),
    FOREIGN KEY (CarId) REFERENCES Cars(CarId),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Features (
    FeatureId INT PRIMARY KEY,
    CarId INT,
    Feature VARCHAR(100) NOT NULL,
    FOREIGN KEY (CarId) REFERENCES Cars(CarId)
);
