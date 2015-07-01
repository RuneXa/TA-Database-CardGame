-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 01, 2015 at 01:52 PM
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

CREATE TABLE IF NOT EXISTS `tb_datamusuh` (
`id` int(11) NOT NULL,
  `nama` varchar(40) NOT NULL,
  `health` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `desc` text,
  `expVar` int(20) NOT NULL,
  `image` varchar(20) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_datamusuh`
--

INSERT INTO `tb_datamusuh` (`id`, `nama`, `health`, `attack`, `desc`, `expVar`, `image`) VALUES
(1, 'Tempura', 100, 10, 'Merupakan monster makanan yang bisa membuat lawan lapar dan tidak punya tenaga untuk melanjutkan permainan', 50, 'musuh1');

-- --------------------------------------------------------

--
-- Table structure for table `tb_deck`
--

CREATE TABLE IF NOT EXISTS `tb_deck` (
  `id_user` varchar(20) NOT NULL,
  `kode_kartu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_deck`
--

INSERT INTO `tb_deck` (`id_user`, `kode_kartu`) VALUES
('2', 1),
('2', 1),
('2', 1),
('2', 1),
('2', 2),
('2', 2),
('2', 2),
('2', 2),
('2', 2),
('2', 2),
('2', 2),
('2', 3),
('2', 4),
('2', 4),
('2', 4),
('2', 4),
('1', 1),
('1', 1),
('1', 1),
('1', 1),
('1', 1),
('1', 1),
('1', 1),
('1', 2),
('1', 2),
('1', 2),
('1', 2),
('1', 2),
('1', 3),
('1', 3),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 1),
('filbert', 2),
('filbert', 2),
('filbert', 2),
('filbert', 2),
('filbert', 2),
('filbert', 2),
('filbert', 2),
('filbert', 3),
('filbert', 3),
('filbert', 3),
('alvin', 1),
('alvin', 1),
('alvin', 1),
('alvin', 1),
('alvin', 1),
('alvin', 1),
('alvin', 1),
('alvin', 2),
('alvin', 2),
('alvin', 2),
('alvin', 3),
('alvin', 3),
('alvin', 3),
('alvin', 3),
('alvin', 4),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 1),
('test', 2),
('test', 2),
('test', 2),
('test', 2),
('test', 2),
('test', 3),
('test', 3),
('test', 3),
('test', 3),
('test', 3);

-- --------------------------------------------------------

--
-- Table structure for table `tb_kartu`
--

CREATE TABLE IF NOT EXISTS `tb_kartu` (
`kode_kartu` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `efek` text NOT NULL,
  `warna` varchar(20) NOT NULL,
  `attack` int(11) NOT NULL DEFAULT '0',
  `defend` int(11) NOT NULL DEFAULT '0',
  `heal` int(11) NOT NULL DEFAULT '0',
  `cost` int(11) NOT NULL DEFAULT '0',
  `image` varchar(20) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_kartu`
--

INSERT INTO `tb_kartu` (`kode_kartu`, `nama`, `efek`, `warna`, `attack`, `defend`, `heal`, `cost`, `image`) VALUES
(1, 'Api di lubang', 'ya gitu lah', 'red', 10, 0, 0, 3, 'atk0'),
(2, 'katanya sih batu', 'katanya', 'blue', 0, 5, 0, 2, 'def0'),
(3, 'obat ijo', 'katanya sih pait', 'green', 0, 0, 10, 5, 'heal0'),
(4, 'air panas', 'kalo disirem lumayan', 'red', 8, 0, 0, 4, 'atk1');

-- --------------------------------------------------------

--
-- Table structure for table `tb_user`
--

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
('1', '123456', 'player', 50),
('2', '0987654', 'Bukan Richie', 0),
('3', '987654', 'Bukan Evans', 0),
('alvin', 'bukanalvin', 'Katanya sih alvin', 0),
('cobalagi', 'kurangberuntung', 'yaaah', 0),
('filbert', 'bukanfilbert', 'Katanya sih Filbert', 0),
('tes', 'aaa', 'bbb', 0),
('test', 'baru', 'uji', 0),
('uji2', 'ujicoba', 'test', 0),
('uji4', 'coba', 'test', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tb_winrate`
--

CREATE TABLE IF NOT EXISTS `tb_winrate` (
  `id_user` varchar(20) NOT NULL,
  `win` int(11) NOT NULL,
  `loss` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_winrate`
--

INSERT INTO `tb_winrate` (`id_user`, `win`, `loss`) VALUES
('1', 1, 1),
('2', 1, 1),
('3', 5, 7);

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
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `tb_kartu`
--
ALTER TABLE `tb_kartu`
MODIFY `kode_kartu` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
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
