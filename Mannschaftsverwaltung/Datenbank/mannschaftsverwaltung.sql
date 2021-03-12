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
-- Datenbank: `mannschaftsverwaltung`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `ID` int(11) NOT NULL,
  `Mannschaftsname` varchar(45) DEFAULT NULL,
  `Sportart` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `mannschaft`
--

INSERT INTO `mannschaft` (`ID`, `Mannschaftsname`, `Sportart`) VALUES
(1, '1.Fc Koeln', 'Fußball'),
(2, 'TC Grün-Weiß', 'Tennis'),
(3, 'TSV 1860 Spandau', 'Handball'),
(14, '1.Fc Bonn', 'Fußball');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaftsverwaltung`
--

CREATE TABLE `mannschaftsverwaltung` (
  `ID` int(11) NOT NULL,
  `Mannschaft_id` int(11) DEFAULT NULL,
  `Person_id` int(11) DEFAULT NULL,
  `person_name` varchar(45) DEFAULT NULL,
  `person_Einsatzsbereich` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `mannschaftsverwaltung`
--

INSERT INTO `mannschaftsverwaltung` (`ID`, `Mannschaft_id`, `Person_id`, `person_name`, `person_Einsatzsbereich`) VALUES
(35, 1, 4, 'Korfant', 'Physiotherapeut'),
(36, 2, 3, 'Haidar', 'Spieler'),
(37, 3, 2, 'Wansidler', 'Spieler'),
(38, 14, 3, 'Haidar', 'Spieler');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `mannschaftsverwaltung`
--
ALTER TABLE `mannschaftsverwaltung`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Mannschaft_id` (`Mannschaft_id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT für Tabelle `mannschaftsverwaltung`
--
ALTER TABLE `mannschaftsverwaltung`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `mannschaftsverwaltung`
--
ALTER TABLE `mannschaftsverwaltung`
  ADD CONSTRAINT `mannschaftsverwaltung_ibfk_1` FOREIGN KEY (`Mannschaft_id`) REFERENCES `mannschaft` (`ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
