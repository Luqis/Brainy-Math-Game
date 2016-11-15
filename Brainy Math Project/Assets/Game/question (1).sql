-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 12, 2016 at 10:28 AM
-- Server version: 10.1.10-MariaDB
-- PHP Version: 7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `game`
--

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

CREATE TABLE `question` (
  `title_ID` varchar(500) NOT NULL,
  `title` varchar(200) NOT NULL,
  `choice1` varchar(20) NOT NULL,
  `choice2` varchar(20) NOT NULL,
  `choice3` varchar(20) NOT NULL,
  `choice4` varchar(20) NOT NULL,
  `correctAns` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `question`
--

INSERT INTO `question` (`title_ID`, `title`, `choice1`, `choice2`, `choice3`, `choice4`, `correctAns`) VALUES
('E1', '1+1=?', '1', '2', '3', '4', 'B'),
('E10', 'Round Off 15 is ___', '10', '15', '20', '25', 'C'),
('E2', '2+2=?', '1', '2', '3', '4', 'D'),
('E3', '1+3=?', '1', '2', '3', '4', 'D'),
('E4', '5 x 5 =?', '20', '10', '15', '25', 'D'),
('E5', '20 ÷ 4 = ?', '2', '5', '6', '2', 'B'),
('E6', '3+5+10=?', '32', '12', '18', '22', 'C'),
('E7', '1 + 1 x 0 = ?', '0', '1', '2', '3', 'B'),
('E8', 'Round Off 5 is ___', '2', '0', '5', '10', 'D'),
('E9', 'Round of 14 is ___', '10', '11', '12', '20', 'A');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `question`
--
ALTER TABLE `question`
  ADD PRIMARY KEY (`title_ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
