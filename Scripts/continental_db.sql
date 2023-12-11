-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.17 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para bancocontinental
CREATE DATABASE IF NOT EXISTS `bancocontinental` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bancocontinental`;

-- Volcando estructura para tabla bancocontinental.accountmovements
CREATE TABLE IF NOT EXISTS `accountmovements` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Credit` decimal(18,2) NOT NULL,
  `Debit` decimal(18,2) NOT NULL,
  `BankId` bigint(20) NOT NULL,
  `FDateTime` datetime(6) NOT NULL,
  `Concept` longtext NOT NULL,
  `UserAccountId` bigint(20) NOT NULL,
  `Method` int(11) NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AccountMovements_BankId` (`BankId`),
  KEY `IX_AccountMovements_UserAccountId` (`UserAccountId`),
  CONSTRAINT `FK_AccountMovements_Banks_BankId` FOREIGN KEY (`BankId`) REFERENCES `banks` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AccountMovements_UserAccounts_UserAccountId` FOREIGN KEY (`UserAccountId`) REFERENCES `useraccounts` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla bancocontinental.accountmovements: ~0 rows (aproximadamente)
DELETE FROM `accountmovements`;

-- Volcando estructura para tabla bancocontinental.banks
CREATE TABLE IF NOT EXISTS `banks` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `BankName` varchar(50) NOT NULL,
  `CurrencyId` bigint(20) NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Banks_CurrencyId` (`CurrencyId`),
  CONSTRAINT `FK_Banks_Currencies_CurrencyId` FOREIGN KEY (`CurrencyId`) REFERENCES `currencies` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla bancocontinental.banks: ~0 rows (aproximadamente)
DELETE FROM `banks`;
INSERT INTO `banks` (`Id`, `BankName`, `CurrencyId`, `IsDelete`) VALUES
	(1, 'Banco Itau Paraguay', 1, 0),
	(2, 'Banco Familiar SAECA', 1, 0),
	(3, 'Banco Familiar SAECA DOLAR', 2, 0),
	(4, 'Banco Continental SAECA', 1, 0),
	(5, 'Banco Continental SAECA Dolar', 2, 0);

-- Volcando estructura para tabla bancocontinental.currencies
CREATE TABLE IF NOT EXISTS `currencies` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(10) NOT NULL,
  `Symbol` varchar(2) NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla bancocontinental.currencies: ~2 rows (aproximadamente)
DELETE FROM `currencies`;
INSERT INTO `currencies` (`Id`, `Name`, `Symbol`, `IsDelete`) VALUES
	(1, 'Guaranies', '₲', 0),
	(2, ' Dolares A', '$', 0);

-- Volcando estructura para tabla bancocontinental.useraccounts
CREATE TABLE IF NOT EXISTS `useraccounts` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `FoundInAccount` decimal(18,2) NOT NULL,
  `BankId` bigint(20) NOT NULL,
  `DocumentNumber` longtext NOT NULL,
  `UserName` longtext,
  `NormalizedUserName` longtext,
  `Email` longtext,
  `NormalizedEmail` longtext,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `DocumentType` int(11) NOT NULL DEFAULT '0',
  `FullName` longtext NOT NULL,
  `AccountNumber` varchar(40) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_UserAccounts_BankId` (`BankId`),
  CONSTRAINT `FK_UserAccounts_Banks_BankId` FOREIGN KEY (`BankId`) REFERENCES `banks` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla bancocontinental.useraccounts: ~0 rows (aproximadamente)
DELETE FROM `useraccounts`;
INSERT INTO `useraccounts` (`Id`, `FoundInAccount`, `BankId`, `DocumentNumber`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `DocumentType`, `FullName`, `AccountNumber`) VALUES
	(1, 0.00, 4, '7228498', 'Daniel25A', 'DANIEL25A', 'gomezoscar089@gmail.com', 'GOMEZOSCAR089@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEBegu3FSThspIKuDajJhBj4WTZFUwCOMw2Mjsmpe2AmO1mpCI5HlqZZtoFJb7X11HQ==', 'H3CXIOKRI6QTINWV2WM5WC2TIXA45ISJ', '77bbf605-5279-4893-babf-be16a92a77d2', NULL, 0, 0, NULL, 1, 0, 1, 'Oscar Daniel Gomez Reyes', '0023023213'),
	(2, 0.00, 4, '5273441', 'Cintya', 'CINTYA', 'cintya.maidana@gmail.com', 'CINTYA.MAIDANA@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEMOmyyZSrYweSSTKh2mpTooX40r4rqGTa3EqoPuzjPErfxd4MGHoFFUxG2ATqR3OZQ==', 'HSXO55HQGI4SWJBW7GU7TGXYYGYMUIMN', '47e47206-fde5-4075-adb8-1d975c173067', NULL, 0, 0, NULL, 1, 0, 1, 'Cintya Figueredo Maidana', '0032323123');

-- Volcando estructura para tabla bancocontinental.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla bancocontinental.__efmigrationshistory: ~2 rows (aproximadamente)
DELETE FROM `__efmigrationshistory`;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20231211141438_FirstMigration', '7.0.14'),
	('20231211150130_UpdateAnyFields', '7.0.14'),
	('20231211173317_UpdateAnyFieldsTwo', '7.0.14');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
