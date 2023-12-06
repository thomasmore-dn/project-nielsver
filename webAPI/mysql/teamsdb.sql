-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 06 dec 2023 om 14:29
-- Serverversie: 10.4.32-MariaDB
-- PHP-versie: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `teamsdb`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `players`
--

CREATE TABLE `players` (
  `PlayerId` int(11) NOT NULL,
  `TeamId` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `TotalPoints` int(11) NOT NULL,
  `GamesPlayed` int(11) NOT NULL,
  `Position` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `players`
--

INSERT INTO `players` (`PlayerId`, `TeamId`, `Name`, `TotalPoints`, `GamesPlayed`, `Position`) VALUES
(-4, 3, 'Godwin thimanga', 95, 10, 'Forward'),
(-3, 2, 'Andrej Cuyvers', 90, 10, 'Forward'),
(-2, 1, 'Sam Van Rossom', 80, 10, 'Guard'),
(-1, 1, 'Thibaut tsjienda baloji', 100, 10, 'Center'),
(1, 2, 'Evert Van Eyck', 5, 1, 'Guard'),
(2, 3, 'Junior bossenge', 25, 3, 'guard');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `teams`
--

CREATE TABLE `teams` (
  `TeamId` int(11) NOT NULL,
  `TeamName` longtext NOT NULL,
  `Wins` int(11) NOT NULL,
  `Losses` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `teams`
--

INSERT INTO `teams` (`TeamId`, `TeamName`, `Wins`, `Losses`) VALUES
(1, 'BC Oostende', 5, 5),
(2, 'Kangoeroes Mechelen', 8, 0),
(3, 'Circus Brussel', 7, 0);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231204172644_InitialMigration', '7.0.13');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`PlayerId`),
  ADD KEY `IX_Players_TeamId` (`TeamId`);

--
-- Indexen voor tabel `teams`
--
ALTER TABLE `teams`
  ADD PRIMARY KEY (`TeamId`);

--
-- Indexen voor tabel `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `players`
--
ALTER TABLE `players`
  MODIFY `PlayerId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT voor een tabel `teams`
--
ALTER TABLE `teams`
  MODIFY `TeamId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `FK_Players_Teams_TeamId` FOREIGN KEY (`TeamId`) REFERENCES `teams` (`TeamId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
