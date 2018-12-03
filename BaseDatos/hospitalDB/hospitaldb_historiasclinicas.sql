-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: hospitaldb
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `historiasclinicas`
--

DROP TABLE IF EXISTS `historiasclinicas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `historiasclinicas` (
  `id_historiaC` varchar(10) COLLATE utf8_spanish2_ci NOT NULL,
  `FechaApertura` datetime NOT NULL,
  `Peso` int(11) NOT NULL,
  `Talla` varchar(4) COLLATE utf8_spanish2_ci NOT NULL,
  `Dni` varchar(8) COLLATE utf8_spanish2_ci NOT NULL,
  `IdDiagnostico` varchar(4) COLLATE utf8_spanish2_ci NOT NULL,
  PRIMARY KEY (`id_historiaC`),
  KEY `FK_DniPaciente` (`Dni`),
  KEY `FK_IdDiagnostico` (`IdDiagnostico`),
  CONSTRAINT `FK_DniPaciente` FOREIGN KEY (`Dni`) REFERENCES `pacientes` (`dni`),
  CONSTRAINT `FK_IdDiagnostico` FOREIGN KEY (`IdDiagnostico`) REFERENCES `diagnosticos` (`iddiagnostico`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historiasclinicas`
--

LOCK TABLES `historiasclinicas` WRITE;
/*!40000 ALTER TABLE `historiasclinicas` DISABLE KEYS */;
/*!40000 ALTER TABLE `historiasclinicas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-29 22:00:08