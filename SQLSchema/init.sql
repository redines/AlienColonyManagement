CREATE DATABASE IF NOT EXISTS `neighbours` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE neighbours;
-- neighbours.Buildings definition

CREATE TABLE IF NOT EXISTS `Buildings` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `BuildingNumber` bigint(20) NOT NULL,
  `TotNumberofTenants` bigint(20) DEFAULT 0,
  `LastTimeServiced` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- neighbours.Apartments definition

CREATE TABLE IF NOT EXISTS `Apartments` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ApartmentNumber` INT DEFAULT NULL,
  `LivingSize` int(11) DEFAULT NULL,
  `NumberOfRooms` int(20) DEFAULT NULL,
  `NumberofTenants` int(20) DEFAULT NULL,
  `MonthlyRent` bigint(20) DEFAULT NULL,
  `BuildingId` bigint(20)
  PRIMARY KEY (`Id`)
  FOREIGN KEY (BuildingId) REFERENCES Buildings(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- neighbours.Tenants definition

CREATE TABLE IF NOT EXISTS `Tenant` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Age` int(11) DEFAULT NULL,
  `IncomeYear` bigint(20) DEFAULT NULL,
  `IncomeMonth` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;