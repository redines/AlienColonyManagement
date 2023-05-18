-- Create buildings

INSERT INTO neighbours.Buildings (BuildingNumber, BuildingLetter, LastTimeServiced)
VALUES 
(1,'A',NOW()), 
(1,'B',NOW()), 
(1,'C',NOW()),
(2,'A',NOW()), 
(2,'B',NOW()), 
(2,'C',NOW());

INSERT INTO neighbours.Apartments
(ApartmentNumber, LivingSize, NumberOfRooms, NumberofTenants, MonthlyRent, BuildingNumber, BuildingLetter)
VALUES
(1001, 50, 2, 5, 7000, 1, 'A'),
(1002, 110, 4, 3, 11000, 1, 'A')
(1002, 110, 4, 3, 11000, 1, 'B');


