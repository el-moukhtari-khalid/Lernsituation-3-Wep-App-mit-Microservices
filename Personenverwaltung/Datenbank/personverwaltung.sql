-- phpMyAdmin SQL Dump
-- version 4.7.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Erstellungszeit: 12. Mrz 2021 um 08:41
-- Server-Version: 5.6.34
-- PHP-Version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `personverwaltung`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `personverwaltung`
--

CREATE TABLE `personverwaltung` (
  `ID` int(11) NOT NULL,
  `Name` varchar(30) DEFAULT NULL,
  `Geburtsdatum` varchar(15) DEFAULT NULL,
  `Einsatzbereich` varchar(45) DEFAULT NULL,
  `Position` varchar(45) DEFAULT NULL,
  `Sportart` varchar(45) DEFAULT NULL,
  `AnzahlSpiele` varchar(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `personverwaltung`
--

INSERT INTO `personverwaltung` (`ID`, `Name`, `Geburtsdatum`, `Einsatzbereich`, `Position`, `Sportart`, `AnzahlSpiele`) VALUES
(1, 'Acikgoez', '2001-12-05', 'Spieler', 'Stürmer', 'Fußball', '5'),
(2, 'Wansidler', '1995-05-02', 'Spieler', 'Torwart', 'Handball', '500'),
(3, 'Haidar', '2001-01-16', 'Spieler', '', 'Tennis', '555'),
(4, 'Korfant', '2002-05-01', 'Physiotherapeut', NULL, NULL, NULL),
(5, 'Foutih', '1975-10-02', 'Physiotherapeut', NULL, NULL, NULL);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `personverwaltung`
--
ALTER TABLE `personverwaltung`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `personverwaltung`
--
ALTER TABLE `personverwaltung`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
