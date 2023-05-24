USE [Neighbours]
GO

INSERT INTO [dbo].[Buildings]
           ([BuildingNumber]
           ,[BuildingLetter]
           ,[LastTimeServiced])
     VALUES
           (1,'A',null),
		   (1,'B',null),
		   (1,'C',null),
		   (2,'A',null),
		   (2,'B',null),
		   (2,'C',null),
		   (3,'A',null),
		   (3,'B',null),
		   (3,'C',null)


INSERT INTO dbo.Apartments
(ApartmentNumber, LivingSize, NumberOfRooms, NumberofTenants, MonthlyRent, BuildingNumber, BuildingLetter)
VALUES
(1001, 50, 2, 5, 7000, 1, 'A'),
(1002, 110, 4, 3, 11000, 2, 'B'),
(1002, 110, 4, 3, 11000, 3, 'C');

INSERT INTO dbo.Tenant
([Name], Age, IncomeYear, IncomeMonth, ApartmentId)
VALUES
('Nisse', 50, 500000, 50000, 1),
('Pelle', 25, 100000, 12000, 1),
('Kalle', 12, 0, 0, 1)

GO