-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: tecsupdb
-- ------------------------------------------------------
-- Server version	8.0.13

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
-- Table structure for table `tmatricula`
--

DROP TABLE IF EXISTS `tmatricula`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tmatricula` (
  `IdMatricula` int(11) NOT NULL AUTO_INCREMENT,
  `IdAlumno` int(11) NOT NULL,
  `IdCurso` int(11) NOT NULL,
  `FechaMatricula` datetime DEFAULT NULL,
  `IdUsuario` varchar(20) NOT NULL,
  PRIMARY KEY (`IdMatricula`),
  KEY `FK_tmatricula_talumnos_idx` (`IdAlumno`),
  KEY `FK_tmatricula_tcursos_idx` (`IdCurso`),
  KEY `FK_tmatricula_tusuarios_idx` (`IdUsuario`),
  CONSTRAINT `FK_tmatricula_talumnos` FOREIGN KEY (`IdAlumno`) REFERENCES `talumnos` (`idalumno`),
  CONSTRAINT `FK_tmatricula_tcursos` FOREIGN KEY (`IdCurso`) REFERENCES `tcursos` (`idcurso`),
  CONSTRAINT `FK_tmatricula_tusuarios` FOREIGN KEY (`IdUsuario`) REFERENCES `tusuarios` (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmatricula`
--

LOCK TABLES `tmatricula` WRITE;
/*!40000 ALTER TABLE `tmatricula` DISABLE KEYS */;
INSERT INTO `tmatricula` VALUES (1,12,1,'2018-11-22 00:00:00','admin'),(2,12,2,'2018-11-22 00:00:00','admin'),(3,12,3,'2018-11-22 00:00:00','admin'),(4,13,1,'2018-11-22 00:00:00','admin'),(5,13,2,'2018-11-22 00:00:00','admin');
/*!40000 ALTER TABLE `tmatricula` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-22 10:56:46
