-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: broodjesbar
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
-- Table structure for table `bestellingen`
--

DROP TABLE IF EXISTS `bestellingen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bestellingen` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `klant_ID` int(11) NOT NULL,
  `broodje_ID` int(11) NOT NULL,
  `datum_bestelling` datetime NOT NULL,
  `status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `klant_ID` (`klant_ID`),
  KEY `broodje_ID` (`broodje_ID`),
  CONSTRAINT `bestellingen_ibfk_1` FOREIGN KEY (`klant_ID`) REFERENCES `gebruikers` (`ID`),
  CONSTRAINT `bestellingen_ibfk_2` FOREIGN KEY (`broodje_ID`) REFERENCES `broodjes` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bestellingen`
--

LOCK TABLES `bestellingen` WRITE;
/*!40000 ALTER TABLE `bestellingen` DISABLE KEYS */;
INSERT INTO `bestellingen` VALUES (30,8,1,'2023-11-06 10:10:43','afgewerkt'),(31,8,1,'2023-11-06 10:11:32','afgewerkt'),(32,8,6,'2023-11-06 10:11:35','besteld'),(33,8,11,'2023-11-06 10:11:37','besteld'),(34,8,3,'2023-11-06 10:11:38','besteld'),(35,8,2,'2023-11-06 10:11:40','besteld'),(36,8,9,'2023-11-06 10:11:43','besteld'),(37,8,10,'2023-11-06 10:11:45','besteld'),(38,8,11,'2023-11-06 10:11:47','besteld'),(39,8,4,'2023-11-06 10:11:48','besteld'),(40,8,4,'2023-11-06 10:11:50','besteld');
/*!40000 ALTER TABLE `bestellingen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `broodjes`
--

DROP TABLE IF EXISTS `broodjes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `broodjes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` varchar(50) NOT NULL,
  `Omschrijving` varchar(500) NOT NULL,
  `Prijs` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `broodjes`
--

LOCK TABLES `broodjes` WRITE;
/*!40000 ALTER TABLE `broodjes` DISABLE KEYS */;
INSERT INTO `broodjes` VALUES (1,'Kaas','Broodje met jonge kaas',1.90),(2,'Ham','Broodje met natuurham',1.90),(3,'Kaas en ham','Broodje met kaas en ham',2.10),(4,'Fitness kip','kip natuur, yoghurtdressing, perzik, tuinkers, tomaat en komkommer',3.50),(5,'Broodje Sombrero','kip natuur, andalousesaus, rode paprika, maïs, sla, komkommer, tomaat, ei en ui ',3.70),(6,'Broodje americain-tartaar','americain, tartaarsaus, ui, komkommer, ei en tuinkers ',3.50),(7,'Broodje Indian kip','kip natuur, ananas, tuinkers, komkommer en curry dressing',4.00),(8,'Grieks broodje','feta, tuinkers, komkommer, tomaat en olijventapenade',3.90),(9,'Tonijntino','tonijn pikant, ui, augurk, martinosaus en (tabasco)',2.60),(10,'Wrap exotisch','kip natuur, cocktailsaus, sla, tomaat, komkommer, ei en ananas',3.70),(11,'Wrap kip/spek','Kip natuur, spek, BBQ saus, sla, tomaat en komkommer',4.00);
/*!40000 ALTER TABLE `broodjes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gebruikers`
--

DROP TABLE IF EXISTS `gebruikers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gebruikers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Wachtwoord` varchar(100) DEFAULT NULL,
  `Status` varchar(15) NOT NULL,
  `Type` varchar(15) NOT NULL,
  `Creatie` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gebruikers`
--

LOCK TABLES `gebruikers` WRITE;
/*!40000 ALTER TABLE `gebruikers` DISABLE KEYS */;
INSERT INTO `gebruikers` VALUES (1,'admin','admin@admin.admin','$2y$10$opRIX3FiBL8jeGxiD.UON.BDp7iPAL0PpGnvC8ywMUmbMFI6VhPBi','actief','medewerker','2023-11-06 10:06:50'),(8,'Greg','hermgreg00@gmail.com','$2y$10$5sFCjsXZyJCMd5aLohIE8.orb07kgEc0YlivfURaiLlqOxgGt3zT2','actief','klant','2023-11-06 10:08:47'),(9,'Spammer McSpam','spam@spam.spam','$2y$10$.bIW57ifvmN2Qxog/TUTKu3U6PAy9MJyHYNNrm59bBJqVKhvyZT9q','geblokkeerd','klant','2023-11-06 10:12:44'),(10,'Eric','eric@prydz.com','$2y$10$mAJU.zYufoSZqEeB9tzPeeVhl8dScJV3M/QPGeH1Ko2YVoE3oSXZ6','actief','klant','2023-11-06 10:15:39'),(11,'Lara','lara@croft.com','$2y$10$yEHbcyvenGyK4uVnlGiCkOC4m8l8yf/v9EDAmxmQQOa0Pg2VumHUO','actief','klant','2023-11-06 10:16:13');
/*!40000 ALTER TABLE `gebruikers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-06 10:34:38
