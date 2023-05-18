CREATE OR REPLACE USER mymy IDENTIFIED BY 'passw0rd';
CREATE DATABASE IF NOT EXISTS `neighbours`;
/*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */

USE `neighbours`;

-- neighbours.Buildings definition
CREATE TABLE `Buildings` (
  `BuildingNumber` BIGINT NOT NULL,
  `BuildingLetter` VARCHAR(5) NOT NULL,
  `LastTimeServiced` datetime DEFAULT NULL,
  PRIMARY KEY (`BuildingNumber`,`BuildingLetter`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- neighbours.Apartments definition

CREATE TABLE `Apartments` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ApartmentNumber` INT DEFAULT NULL,
  `LivingSize` int(11) DEFAULT NULL,
  `NumberOfRooms` int(20) DEFAULT NULL,
  `NumberofTenants` int(20) DEFAULT NULL,
  `MonthlyRent` bigint(20) DEFAULT NULL,
  `BuildingNumber` BIGINt NOT NULL,
  `BuildingLetter` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`Id`),
  FOREIGN KEY (`BuildingNumber`, `BuildingLetter`) REFERENCES Buildings(`BuildingNumber`, `BuildingLetter`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- neighbours.Tenants definition

CREATE TABLE `Tenant` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Age` int(11) DEFAULT NULL,
  `ProfilePicture` BLOB DEFAULT NULL,
  `IncomeYear` bigint(20) DEFAULT NULL,
  `IncomeMonth` bigint(20) DEFAULT NULL,
  `ApartmentId` bigint(20),
  PRIMARY KEY (`Id`),
  FOREIGN KEY (ApartmentId) REFERENCES Apartments(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- neighbours.Apartments definition

CREATE TABLE `TenantStorage` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `StorageSize` INT DEFAULT NULL,
  `BuildingId` bigint(20),
  `ApartmentId` bigint(20),
  PRIMARY KEY (`Id`),
  FOREIGN KEY (BuildingId) REFERENCES Buildings(Id),
  FOREIGN KEY (ApartmentId) REFERENCES Apartments(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;