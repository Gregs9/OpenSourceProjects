-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: pizzaria
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
-- Table structure for table `bestelbonnen`
--

DROP TABLE IF EXISTS `bestelbonnen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bestelbonnen` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `datum` varchar(45) NOT NULL,
  `klant_id` int(11) DEFAULT NULL,
  `afleveradres` varchar(255) DEFAULT NULL,
  `opmerking` varchar(255) DEFAULT NULL,
  `verkoopprijs` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_klant_id` (`klant_id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bestellijnen`
--

DROP TABLE IF EXISTS `bestellijnen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bestellijnen` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bestelbon_id` int(11) NOT NULL,
  `pizza_id` int(11) NOT NULL,
  `aantal` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `bestelbon_id` (`bestelbon_id`),
  KEY `pizza_id` (`pizza_id`),
  CONSTRAINT `bestellijnen_ibfk_1` FOREIGN KEY (`bestelbon_id`) REFERENCES `bestelbonnen` (`id`),
  CONSTRAINT `bestellijnen_ibfk_2` FOREIGN KEY (`pizza_id`) REFERENCES `pizzas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pizzas`
--

DROP TABLE IF EXISTS `pizzas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pizzas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naam` varchar(50) NOT NULL,
  `prijs` float NOT NULL,
  `ingredienten` varchar(255) DEFAULT NULL,
  `allergenen` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `plaatsen`
--

DROP TABLE IF EXISTS `plaatsen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plaatsen` (
  `plaatsId` int(11) NOT NULL AUTO_INCREMENT,
  `postcode` varchar(4) NOT NULL,
  `plaats` varchar(45) NOT NULL,
  PRIMARY KEY (`plaatsId`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `familienaam` varchar(35) DEFAULT NULL,
  `voornaam` varchar(35) DEFAULT NULL,
  `adres` varchar(55) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `wachtwoord` varchar(500) DEFAULT NULL,
  `tel` varchar(12) DEFAULT NULL,
  `plaatsId` int(11) DEFAULT NULL,
  `kortingsTarief` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_plaatsId` (`plaatsId`),
  CONSTRAINT `fk_plaatsId` FOREIGN KEY (`plaatsId`) REFERENCES `plaatsen` (`plaatsId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-15 16:38:44
