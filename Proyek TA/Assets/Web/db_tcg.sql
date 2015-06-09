-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 09, 2015 at 05:41 PM
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
  `desc` text
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_datamusuh`
--

INSERT INTO `tb_datamusuh` (`id`, `nama`, `health`, `attack`, `desc`) VALUES
(1, 'Tempura', 100, 10, 'Merupakan monster makanan yang bisa membuat lawan lapar dan tidak punya tenaga untuk melanjutkan permainan');

-- --------------------------------------------------------

--
-- Table structure for table `tb_deck`
--

CREATE TABLE IF NOT EXISTS `tb_deck` (
  `id_user` int(11) NOT NULL,
  `kode_kartu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_deck`
--

INSERT INTO `tb_deck` (`id_user`, `kode_kartu`) VALUES
(1, 1),
(1, 1),
(1, 1),
(1, 1),
(1, 2),
(1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `tb_kartu`
--

CREATE TABLE IF NOT EXISTS `tb_kartu` (
`kode_kartu` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `efek` text NOT NULL,
  `warna` varchar(20) NOT NULL,
  `attack` int(11) NOT NULL,
  `cost` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_kartu`
--

INSERT INTO `tb_kartu` (`kode_kartu`, `nama`, `efek`, `warna`, `attack`, `cost`) VALUES
(1, 'Api di lubang', 'ya gitu lah', 'red', 10, 3),
(2, 'katanya sih batu', 'katanya', 'blue', 0, 2),
(3, 'obat ijo', 'katanya sih pait', 'green', 0, 5),
(4, 'air panas', 'kalo disirem lumayan', 'red', 8, 4);

-- --------------------------------------------------------

--
-- Table structure for table `tb_user`
--

CREATE TABLE IF NOT EXISTS `tb_user` (
`id_user` int(11) NOT NULL,
  `password` varchar(16) NOT NULL,
  `nama` varchar(40) NOT NULL,
  `exp` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_user`
--

INSERT INTO `tb_user` (`id_user`, `password`, `nama`, `exp`) VALUES
(1, '123456', 'player', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tb_winrate`
--

CREATE TABLE IF NOT EXISTS `tb_winrate` (
`id` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `win` int(11) NOT NULL,
  `loss` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
 ADD KEY `kode_kartu_2` (`kode_kartu`);

--
-- Indexes for table `tb_user`
--
ALTER TABLE `tb_user`
 ADD UNIQUE KEY `id_user` (`id_user`), ADD UNIQUE KEY `passworrd` (`password`);

--
-- Indexes for table `tb_winrate`
--
ALTER TABLE `tb_winrate`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `id_user` (`id_user`);

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
-- AUTO_INCREMENT for table `tb_user`
--
ALTER TABLE `tb_user`
MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `tb_winrate`
--
ALTER TABLE `tb_winrate`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `tb_deck`
--
ALTER TABLE `tb_deck`
ADD CONSTRAINT `tb_deck_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `tb_user` (`id_user`),
ADD CONSTRAINT `tb_deck_ibfk_2` FOREIGN KEY (`kode_kartu`) REFERENCES `tb_kartu` (`kode_kartu`);

--
-- Constraints for table `tb_winrate`
--
ALTER TABLE `tb_winrate`
ADD CONSTRAINT `tb_winrate_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `tb_user` (`id_user`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
