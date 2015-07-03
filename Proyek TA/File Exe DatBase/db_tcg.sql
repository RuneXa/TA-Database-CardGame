-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 03, 2015 at 10:34 AM
-- Server version: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_tcg`
--
CREATE DATABASE IF NOT EXISTS `db_tcg` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `db_tcg`;

-- --------------------------------------------------------

--
-- Table structure for table `tb_datamusuh`
--

DROP TABLE IF EXISTS `tb_datamusuh`;
CREATE TABLE IF NOT EXISTS `tb_datamusuh` (
`id` int(11) NOT NULL,
  `nama` varchar(40) NOT NULL,
  `health` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `expVar` int(20) NOT NULL,
  `image` varchar(20) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_datamusuh`
--

INSERT INTO `tb_datamusuh` (`id`, `nama`, `health`, `attack`, `expVar`, `image`) VALUES
(1, 'Arumpmet', 70, 13, 30, 'musuh1'),
(2, 'Burbro', 100, 20, 70, 'musuh2'),
(3, 'RIPinpeperroni', 300, 5, 70, 'musuh3');

-- --------------------------------------------------------

--
-- Table structure for table `tb_deck`
--

DROP TABLE IF EXISTS `tb_deck`;
CREATE TABLE IF NOT EXISTS `tb_deck` (
  `id_user` varchar(20) NOT NULL,
  `kode_kartu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_deck`
--

INSERT INTO `tb_deck` (`id_user`, `kode_kartu`) VALUES
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 2),
('test', 2),
('test', 2),
('test', 7),
('test', 7),
('test', 7),
('test', 7);

-- --------------------------------------------------------

--
-- Table structure for table `tb_kartu`
--

DROP TABLE IF EXISTS `tb_kartu`;
CREATE TABLE IF NOT EXISTS `tb_kartu` (
`kode_kartu` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `warna` varchar(20) NOT NULL,
  `attack` int(11) NOT NULL DEFAULT '0',
  `defend` int(11) NOT NULL DEFAULT '0',
  `heal` int(11) NOT NULL DEFAULT '0',
  `cost` int(11) NOT NULL DEFAULT '0',
  `image` varchar(20) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_kartu`
--

INSERT INTO `tb_kartu` (`kode_kartu`, `nama`, `warna`, `attack`, `defend`, `heal`, `cost`, `image`) VALUES
(1, 'Pedang Api', 'red', 5, 0, 0, 2, 'atk0'),
(2, 'Kapak Besi', 'red', 17, 0, 0, 5, 'atk1'),
(3, 'Pistol Biasa', 'red', 3, 0, 0, 1, 'atk2'),
(4, 'Tombak Roda', 'red', 8, 0, 0, 3, 'atk3'),
(5, 'Pedang Kait', 'red', 10, 0, 0, 4, 'atk4'),
(6, 'Dua Tongkat', 'red', 2, 0, 0, 0, 'atk5'),
(7, 'Perisai Link', 'blue', 0, 10, 0, 2, 'def0'),
(8, 'Perisai Merah Biru', 'blue', 0, 5, 0, 1, 'def1'),
(9, 'Perisai P', 'blue', 0, 15, 0, 7, 'def2'),
(10, 'Perisai Rata', 'blue', 0, 7, 0, 2, 'def3'),
(11, 'Perisai Amerika', 'blue', 0, 20, 0, 10, 'def4'),
(12, 'Medicaid', 'green', 0, 0, 40, 10, 'heal0'),
(13, 'Ijo ijo', 'green', 0, 0, 5, 0, 'heal1'),
(14, 'Pot 1', 'green', 0, 0, 15, 2, 'heal2'),
(15, 'Pot 2', 'green', 0, 0, 17, 3, 'heal3'),
(16, 'Pot 3', 'green', 0, 0, 20, 4, 'heal4');

-- --------------------------------------------------------

--
-- Table structure for table `tb_user`
--

DROP TABLE IF EXISTS `tb_user`;
CREATE TABLE IF NOT EXISTS `tb_user` (
  `id_user` varchar(20) NOT NULL,
  `password` varchar(16) NOT NULL,
  `nama` varchar(40) NOT NULL,
  `exp` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_user`
--

INSERT INTO `tb_user` (`id_user`, `password`, `nama`, `exp`) VALUES
('test', 'test', 'test', 0);

--
-- Triggers `tb_user`
--
DROP TRIGGER IF EXISTS `ins_deck`;
DELIMITER //
CREATE TRIGGER `ins_deck` AFTER INSERT ON `tb_user`
 FOR EACH ROW Insert INTO tb_winrate (id_user,win,loss) Values(CONCAT(NEW.id_user),0,0)
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tb_winrate`
--

DROP TABLE IF EXISTS `tb_winrate`;
CREATE TABLE IF NOT EXISTS `tb_winrate` (
  `id_user` varchar(20) NOT NULL,
  `win` int(11) NOT NULL,
  `loss` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_winrate`
--

INSERT INTO `tb_winrate` (`id_user`, `win`, `loss`) VALUES
('test', 0, 1);

--
-- Triggers `tb_winrate`
--
DROP TRIGGER IF EXISTS `ins_deck1`;
DELIMITER //
CREATE TRIGGER `ins_deck1` AFTER INSERT ON `tb_winrate`
 FOR EACH ROW Insert INTO tb_deck (id_user,kode_kartu) Values(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),2),(CONCAT(NEW.id_user),2),(CONCAT(NEW.id_user),2),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),1),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),7),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13),(CONCAT(NEW.id_user),13)
//
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_datamusuh`
--
ALTER TABLE `tb_datamusuh`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tb_deck`
--
ALTER TABLE `tb_deck`
 ADD KEY `kodekartu` (`kode_kartu`), ADD KEY `id_user` (`id_user`);

--
-- Indexes for table `tb_kartu`
--
ALTER TABLE `tb_kartu`
 ADD UNIQUE KEY `kode_kartu` (`kode_kartu`), ADD KEY `kode_kartu_2` (`kode_kartu`);

--
-- Indexes for table `tb_user`
--
ALTER TABLE `tb_user`
 ADD UNIQUE KEY `id_user` (`id_user`), ADD UNIQUE KEY `passworrd` (`password`);

--
-- Indexes for table `tb_winrate`
--
ALTER TABLE `tb_winrate`
 ADD UNIQUE KEY `id_user` (`id_user`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_datamusuh`
--
ALTER TABLE `tb_datamusuh`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `tb_kartu`
--
ALTER TABLE `tb_kartu`
MODIFY `kode_kartu` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=17;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `tb_deck`
--
ALTER TABLE `tb_deck`
ADD CONSTRAINT `tb_deck_ibfk_2` FOREIGN KEY (`kode_kartu`) REFERENCES `tb_kartu` (`kode_kartu`),
ADD CONSTRAINT `tb_deck_ibfk_3` FOREIGN KEY (`id_user`) REFERENCES `tb_user` (`id_user`);

--
-- Constraints for table `tb_winrate`
--
ALTER TABLE `tb_winrate`
ADD CONSTRAINT `tb_winrate_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `tb_user` (`id_user`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
