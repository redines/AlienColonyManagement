-- Adminer 4.8.1 MySQL 5.5.5-10.6.12-MariaDB-log dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

USE `AlienColony`;

SET NAMES utf8mb4;

DROP TABLE IF EXISTS `Colony`;
CREATE TABLE `Colony` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ColonyName` varchar(255) NOT NULL,
  `MaxPopulation` bigint(20) NOT NULL,
  `WaterConsumption` bigint(20) DEFAULT NULL,
  `EnergyConsumption` bigint(20) DEFAULT NULL,
  `FoodConsumption` bigint(20) DEFAULT NULL,
  `Income` bigint(20) DEFAULT NULL,
  `Outcome` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


DROP TABLE IF EXISTS `Companies`;
CREATE TABLE `Companies` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ColonyId` bigint(20) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `NumbEmployees` int(10) unsigned DEFAULT NULL,
  `Income` bigint(20) unsigned DEFAULT NULL,
  `Outcome` bigint(20) unsigned DEFAULT NULL,
  `TypeofCompany` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ColonyId` (`ColonyId`),
  KEY `TypeofCompany` (`TypeofCompany`),
  CONSTRAINT `Companies_ibfk_1` FOREIGN KEY (`ColonyId`) REFERENCES `Colony` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `Companies_ibfk_2` FOREIGN KEY (`TypeofCompany`) REFERENCES `TypeofCompany` (`Id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


DROP TABLE IF EXISTS `Population`;
CREATE TABLE `Population` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ColonyId` bigint(20) DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  `Age` int(11) NOT NULL,
  `Occupation` varchar(255) DEFAULT NULL,
  `Income` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ColonyId` (`ColonyId`),
  CONSTRAINT `Population_ibfk_1` FOREIGN KEY (`ColonyId`) REFERENCES `Colony` (`Id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


DROP TABLE IF EXISTS `TypeofCompany`;
CREATE TABLE `TypeofCompany` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Type` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


-- 2023-06-17 16:56:36