CREATE DATABASE `jonah_johansen`;
USE `jonah_johansen`;
CREATE TABLE `stylists` (`StylistId` int NOT NULL AUTO_INCREMENT,`Name` varchar(255) NOT NULL,`StartDate` varchar(255) NOT NULL,`CustomerCount` int NOT NULL DEFAULT '0',`Notes` text,PRIMARY KEY (`StylistId`));
CREATE TABLE `clients` (`ClientId` int NOT NULL AUTO_INCREMENT,`Name` varchar(255) NOT NULL,`StylistId` int NOT NULL,`Notes` text,PRIMARY KEY (`ClientId`));