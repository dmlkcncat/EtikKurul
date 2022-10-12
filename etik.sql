-- --------------------------------------------------------
-- Sunucu:                       127.0.0.1
-- Sunucu sürümü:                8.0.28 - MySQL Community Server - GPL
-- Sunucu İşletim Sistemi:       Win64
-- HeidiSQL Sürüm:               12.0.0.6468
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- etik için veritabanı yapısı dökülüyor
CREATE DATABASE IF NOT EXISTS `etik` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `etik`;

-- tablo yapısı dökülüyor etik.application
CREATE TABLE IF NOT EXISTS `application` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProjectNo` text NOT NULL,
  `ApplicationStatusId` int NOT NULL DEFAULT '0',
  `PrincipalInvestigatorId` int NOT NULL,
  `Kod` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ApplicationName` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ApplicationQualificationId` int NOT NULL,
  `StartedDate` datetime NOT NULL,
  `FinishedDate` datetime NOT NULL,
  `Location` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Show` tinyint NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_application_applicationstatus` (`ApplicationStatusId`),
  KEY `FK_application_applicationqualification` (`ApplicationQualificationId`),
  KEY `FK_application_user` (`PrincipalInvestigatorId`),
  CONSTRAINT `FK_application_applicationqualification` FOREIGN KEY (`ApplicationQualificationId`) REFERENCES `applicationqualification` (`Id`),
  CONSTRAINT `FK_application_applicationstatus` FOREIGN KEY (`ApplicationStatusId`) REFERENCES `applicationstatus` (`Id`),
  CONSTRAINT `FK_application_user` FOREIGN KEY (`PrincipalInvestigatorId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;

-- etik.application: ~6 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `application` (`Id`, `ProjectNo`, `ApplicationStatusId`, `PrincipalInvestigatorId`, `Kod`, `ApplicationName`, `ApplicationQualificationId`, `StartedDate`, `FinishedDate`, `Location`, `Show`) VALUES
	(1, '46364983403', 1, 18, '433545rtr', 'Hayvanları Koruma', 2, '2022-08-09 10:57:56', '2022-08-09 10:57:58', 'Zonguldak', 1),
	(2, '3434343', 2, 18, '343', 'Zonguldak kömürünün Önemi', 4, '2022-08-09 10:58:38', '2022-08-09 10:58:39', 'Zonguldak kömür ocakları', 0),
	(3, '23343434', 3, 18, '343434', 'Çevreye çöp atılmasın', 4, '2022-08-09 10:59:23', '2022-08-09 10:59:25', 'Ankara', 1),
	(4, '675646456', 3, 21, '46465', 'Çocuklarla İletim Kurma', 3, '2022-08-09 11:00:55', '2022-08-09 11:00:56', 'Kozlu', 0),
	(5, '3572782', 5, 21, '23232', 'Kafein Tüketimini Azaltma', 2, '2022-08-09 11:01:39', '2022-08-09 11:01:40', 'Edirne', 1),
	(6, '32323232', 6, 18, '6565', 'Deneme', 2, '2022-08-09 11:02:46', '2022-08-09 11:02:47', 'Deneme', 0);

-- tablo yapısı dökülüyor etik.applicationqualification
CREATE TABLE IF NOT EXISTS `applicationqualification` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Other` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;

-- etik.applicationqualification: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `applicationqualification` (`Id`, `Name`, `Other`) VALUES
	(2, 'Araştırma Projesi', NULL),
	(3, 'Doktora/Sanatta Yeterlilik Tezi', NULL),
	(4, 'Yüksek Lisans Tezi', NULL);

-- tablo yapısı dökülüyor etik.applicationstatus
CREATE TABLE IF NOT EXISTS `applicationstatus` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;

-- etik.applicationstatus: ~6 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `applicationstatus` (`Id`, `Name`) VALUES
	(1, 'Onay Bekleniyor'),
	(2, 'Düzeltme isteniyor'),
	(3, 'Başvuru Reddedildi'),
	(5, 'Başvuru Sekreteryada'),
	(6, 'Başvuru Onayı Tamamlandı'),
	(7, 'Başvuru Oluşturuldu');

-- tablo yapısı dökülüyor etik.assistantinvestigator
CREATE TABLE IF NOT EXISTS `assistantinvestigator` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL DEFAULT '0',
  `ApplicationId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK__user` (`UserId`),
  KEY `FK_assistantinvestigator_application` (`ApplicationId`),
  CONSTRAINT `FK__user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`),
  CONSTRAINT `FK_assistantinvestigator_application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;

-- etik.assistantinvestigator: ~6 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `assistantinvestigator` (`Id`, `UserId`, `ApplicationId`) VALUES
	(1, 20, 3),
	(2, 9, 2),
	(3, 12, 5),
	(4, 9, 1),
	(5, 8, 4),
	(6, 19, 5);

-- tablo yapısı dökülüyor etik.documentanswer
CREATE TABLE IF NOT EXISTS `documentanswer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `QuestionId` int NOT NULL,
  `Path` text NOT NULL,
  `ApplicationId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK__question` (`QuestionId`),
  KEY `FK_documentanswer_application` (`ApplicationId`),
  CONSTRAINT `FK__question` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`Id`),
  CONSTRAINT `FK_documentanswer_application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- etik.documentanswer: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor etik.documentfile
CREATE TABLE IF NOT EXISTS `documentfile` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Path` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ApplicationId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_file_application` (`ApplicationId`),
  CONSTRAINT `FK_file_application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- etik.documentfile: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor etik.option
CREATE TABLE IF NOT EXISTS `option` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `QuestionId` int NOT NULL DEFAULT '0',
  `Text` text NOT NULL,
  `SubQuestionId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_option_question` (`QuestionId`),
  KEY `FK_option_question_2` (`SubQuestionId`),
  CONSTRAINT `FK_option_question` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`Id`),
  CONSTRAINT `FK_option_question_2` FOREIGN KEY (`SubQuestionId`) REFERENCES `question` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- etik.option: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor etik.optionanswer
CREATE TABLE IF NOT EXISTS `optionanswer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OptionId` int NOT NULL,
  `ApplicationId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK__option` (`OptionId`),
  KEY `FK__application` (`ApplicationId`),
  CONSTRAINT `FK__application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`),
  CONSTRAINT `FK__option` FOREIGN KEY (`OptionId`) REFERENCES `option` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- etik.optionanswer: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor etik.question
CREATE TABLE IF NOT EXISTS `question` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `QuestionTypeId` int NOT NULL,
  `SubQuestionId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_question_questiontype` (`QuestionTypeId`),
  KEY `FK_question_question` (`SubQuestionId`),
  CONSTRAINT `FK_question_question` FOREIGN KEY (`SubQuestionId`) REFERENCES `question` (`Id`),
  CONSTRAINT `FK_question_questiontype` FOREIGN KEY (`QuestionTypeId`) REFERENCES `questiontype` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;

-- etik.question: ~7 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `question` (`Id`, `Title`, `QuestionTypeId`, `SubQuestionId`) VALUES
	(1, 'Veri Toplanması Planlanan Yerler/Mekanlar, Kurumlar ve Kuruluşlar:', 2, 1),
	(2, 'fddf', 1, NULL),
	(4, 'Veri Toplanması Planlanan Yerler/Mekanlar, Kurumlar ve Kuruluşlar:', 1, 1),
	(5, 'Veri Toplanması Planlanan Yerler/Mekanlar, Kurumlar ve Kuruluşlar:', 1, NULL),
	(6, 'tht', 1, 1),
	(7, 'dgfddgd', 2, 1),
	(8, 'hghg', 2, 2),
	(9, 'dfdfdf', 2, 1);

-- tablo yapısı dökülüyor etik.questiontype
CREATE TABLE IF NOT EXISTS `questiontype` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;

-- etik.questiontype: ~4 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `questiontype` (`Id`, `Name`) VALUES
	(1, 'Yes Or No'),
	(2, 'Answer Text'),
	(3, 'Yes Or No And Text'),
	(4, 'Document Answer');

-- tablo yapısı dökülüyor etik.redapplication
CREATE TABLE IF NOT EXISTS `redapplication` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int DEFAULT NULL,
  `ApplicationId` int DEFAULT NULL,
  `Description` text,
  PRIMARY KEY (`Id`),
  KEY `FK_redapplication_user` (`UserId`),
  KEY `FK_redapplication_application` (`ApplicationId`),
  CONSTRAINT `FK_redapplication_application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`),
  CONSTRAINT `FK_redapplication_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- etik.redapplication: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `redapplication` (`Id`, `UserId`, `ApplicationId`, `Description`) VALUES
	(1, 4, 3, 'Reddedildi');

-- tablo yapısı dökülüyor etik.role
CREATE TABLE IF NOT EXISTS `role` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- etik.role: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `role` (`Id`, `Name`) VALUES
	(1, 'Başkan'),
	(2, 'Kurul Uyesi'),
	(3, 'Sekreterya'),
	(4, 'Başvuran');

-- tablo yapısı dökülüyor etik.textanswer
CREATE TABLE IF NOT EXISTS `textanswer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `QuestionId` int NOT NULL,
  `Text` text NOT NULL,
  `ApplicationId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_textanswer_question` (`QuestionId`),
  KEY `FK_textanswer_application` (`ApplicationId`),
  CONSTRAINT `FK_textanswer_application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`),
  CONSTRAINT `FK_textanswer_question` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- etik.textanswer: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor etik.updateapplication
CREATE TABLE IF NOT EXISTS `updateapplication` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ApplicationId` int NOT NULL,
  `UserId` int NOT NULL,
  `Description` text NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_updateapplication_application` (`ApplicationId`),
  KEY `FK_updateapplication_user` (`UserId`),
  CONSTRAINT `FK_updateapplication_application` FOREIGN KEY (`ApplicationId`) REFERENCES `application` (`Id`),
  CONSTRAINT `FK_updateapplication_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- etik.updateapplication: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `updateapplication` (`Id`, `ApplicationId`, `UserId`, `Description`) VALUES
	(1, 2, 12, 'Bu iş böyle yapılmaz');

-- tablo yapısı dökülüyor etik.user
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` int NOT NULL DEFAULT '0',
  `FullName` text NOT NULL,
  `OfficePhone` text NOT NULL,
  `Phone` text NOT NULL,
  `Eposta` text NOT NULL,
  `Password` text NOT NULL,
  `Address` text NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_user_role` (`RoleId`),
  CONSTRAINT `FK_user_role` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb3;

-- etik.user: ~8 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `user` (`Id`, `RoleId`, `FullName`, `OfficePhone`, `Phone`, `Eposta`, `Password`, `Address`) VALUES
	(4, 2, 'Can Sarıhan', '3234353', '45454', 'can@gmail.com', '2323', 'demm'),
	(8, 2, 'Feyzanur', '5319521498', '5319521498', 'feyzanur@gmail.com', 'sdfahfYFSH', 'Bahçelievler mahallesi yıldız sokak emek özenç apartmanı no:13 daire:12'),
	(9, 2, 'Gizem ', '5319521498', '5319521498', 'gizem@gmail.com', 'sdfahfYFSH', 'Bahçelievler mahallesi yıldız sokak emek özenç apartmanı no:13 daire:12'),
	(12, 3, 'Damla', '5319521498', '5319521498', 'damla@gmail.com', 'sdfahfYFSH', 'Bahçelievler mahallesi yıldız sokak emek özenç apartmanı no:13 daire:12'),
	(18, 4, 'Esra', '434343434', '43343443', 'esra@gmail.com', '4343434', 'Kobizon'),
	(19, 4, 'Yağmur', '2323232', '232323', 'yagmur@gmail.com', '434343', 'Kobizon'),
	(20, 4, 'Bülent', '2324334', '34343443', 'bulent@gmail.com', '34343', 'KObizon'),
	(21, 4, 'Dilek', '45455445', '45544545', 'dilek@gmail.com', '45544554', 'Kozlu');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
