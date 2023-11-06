-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: cursusphp
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.28-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `modules`
--

DROP TABLE IF EXISTS `modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modules` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `naam` varchar(50) NOT NULL,
  `prijs` float NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modules`
--

LOCK TABLES `modules` WRITE;
/*!40000 ALTER TABLE `modules` DISABLE KEYS */;
INSERT INTO `modules` VALUES (1,'Programmatielogica',75),(2,'Computers en netwerken',130),(4,'SQL',99.9),(5,'Objectgeoriënteerde principes',85),(6,'Javascript / DOM',140),(7,'JQuery',120),(8,'UML',90),(9,'PHP',140),(11,'XHTML/CSS',120);
/*!40000 ALTER TABLE `modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personen`
--

DROP TABLE IF EXISTS `personen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personen` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `familienaam` varchar(50) NOT NULL,
  `voornaam` varchar(30) NOT NULL,
  `geboortedatum` date NOT NULL,
  `geslacht` char(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personen`
--

LOCK TABLES `personen` WRITE;
/*!40000 ALTER TABLE `personen` DISABLE KEYS */;
INSERT INTO `personen` VALUES (1,'Peeters','Bram','1976-01-19','M'),(2,'Van Dessel','Rudy','1969-10-05','M'),(3,'Vereecken','Marie','1981-05-23','V'),(4,'Maes','Eveline','1983-08-16','V'),(5,'Vangeel','Joke','1976-05-22','V'),(6,'Van Heule','Pieter','1968-03-02','M'),(7,'Naessens','Katleen','1984-05-12','V'),(8,'Sleeuwaert','Koen','1957-02-25','M');
/*!40000 ALTER TABLE `personen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `punten`
--

DROP TABLE IF EXISTS `punten`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `punten` (
  `moduleID` int(10) NOT NULL,
  `persoonID` int(10) NOT NULL,
  `punt` int(11) DEFAULT NULL,
  PRIMARY KEY (`moduleID`,`persoonID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `punten`
--

LOCK TABLES `punten` WRITE;
/*!40000 ALTER TABLE `punten` DISABLE KEYS */;
INSERT INTO `punten` VALUES (1,1,20),(1,3,50),(1,4,100),(1,5,20),(1,7,15),(2,1,30),(2,2,1),(2,3,66),(2,4,78),(2,5,30),(2,7,20),(2,8,100),(4,2,1),(4,3,62),(4,4,50),(4,7,30),(5,1,3),(5,2,20),(5,3,48),(5,4,60),(5,5,0),(5,7,40),(6,3,49),(6,4,100),(6,7,50),(7,3,66),(7,4,20),(7,7,60),(8,3,58),(8,4,68),(8,7,70),(9,3,88),(9,4,75),(9,7,80),(11,3,17),(11,4,20),(11,7,90);
/*!40000 ALTER TABLE `punten` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-06 14:26:08
