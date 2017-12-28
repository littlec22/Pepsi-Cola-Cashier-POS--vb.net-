-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 28, 2017 at 01:24 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 5.6.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pctsodatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `account_number_table`
--

CREATE TABLE `account_number_table` (
  `check_Payers_Id` int(11) NOT NULL,
  `account_Num_Id` int(11) NOT NULL,
  `owners_Name` varchar(150) NOT NULL,
  `account_Num` varchar(25) NOT NULL,
  `app_Check_Limit` double NOT NULL,
  `bank_Name` varchar(100) NOT NULL,
  `branch_Address` varchar(100) NOT NULL,
  `approved_Date` varchar(25) NOT NULL,
  `remarks` varchar(100) NOT NULL,
  `date_Input` varchar(25) NOT NULL,
  `status` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `account_number_table`
--

INSERT INTO `account_number_table` (`check_Payers_Id`, `account_Num_Id`, `owners_Name`, `account_Num`, `app_Check_Limit`, `bank_Name`, `branch_Address`, `approved_Date`, `remarks`, `date_Input`, `status`) VALUES
(1, 1, 'Jocelyn Asor', '00233-8006307', 0, 'BDO', 'Makro EDSa', '', 'LOW ADB/Delinquent acccount - - ', '2017-05-03 07:56:21', '1'),
(2, 2, 'Marilyn Capumpue', '0511-035737-001', 20000, 'Security Bank', 'Paseo Makati', '', 'Inactive customer - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(3, 3, 'Wilhelmina Badulis / George Badulis', '33004227', 40000, 'Citibank', 'Sta. Lucia East Grand Mall', '', 'Transferred to Sumulong - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(3, 4, 'Wilhelmina Badulis', '001-01-3169-1', 40000, 'Insular Saving Bank', 'Intramuros Manila', '', 'Transferred to Sumulong - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(4, 5, 'Esmeralda Catangay', '007284809595', 15000, 'Metro Bank', 'Wilson ST. Bgy Addition Hills San Juan City', '', 'Delinquent Account - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(5, 6, 'Ma. C. Evangelista', '002-00-001768-2', 15000, 'PBB', 'Las PiÃ±as', '', 'Delinquent Account - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(6, 7, 'Ma. Therese Cutodio', '007-271-80333-4', 10000, 'Metrobank', 'Pasay Rotonda', '', 'Inactive customer - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(7, 8, 'Ma. Teresa Pangan', '11-001-000284-2/12-001-00', 12000, 'LBC BANK', 'HEAD OFFICE, MAKATI', '', 'Inactive customer - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(8, 9, 'Corazon Sison', '4908003046', 30000, 'Banco De Oro', 'ROCKWELL CENTER MAKATI', '', 'Inactive customer - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:22', '1'),
(9, 10, 'Ricardo Velasco', '270-200-167-9', 50000, 'Eastwest Bank', 'St. Ignatius Village Quezon City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(10, 11, 'Ethelbert Fainsan / Grace Fainsan', '3071-0700-92', 100000, 'BPI', 'Polaris Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(11, 12, 'Catherine Senga', '0295-2846-41', 30000, 'BPI', 'Forbes Park Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(11, 13, 'Catherine Senga', '110-02-0009796', 30000, 'Union Bank', 'JP Rizal Marikina', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(11, 14, 'Catherine Senga', '5538003192', 30000, 'Banco De Oro', 'MC Home Depot', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(12, 15, 'Gloria Sohrabi Langroudi', '0821028574', 15000, 'BPI', 'Serendra Global Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(13, 16, 'Lizabeth Lu', '007-081-50565-5', 50000, 'Metro Bank', 'DOÃ‘A SOLEDAD AVE. BIC.', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(14, 17, 'Trinidad Garbo / Josefina Sacapanio', '1682-1012-50 / 1682-1009-', 50000, 'Land Bank', 'Fort Bonifacio Taguig', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(15, 18, 'Ma. Sotera Magadia', '47-02-00186-8', 50000, 'Eastwest Bank', '140 Valero St. Makati', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(16, 19, 'Ramon Philip Abadicio', '1610-0063-68', 25000, 'BPI', 'Market Market', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(17, 20, 'Ma. Estrella Venadas', '00673-5-01502-6', 30000, 'BPIFSB', '104 Amorsolo St. Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(18, 21, 'Celso Reodica/Felicidad', '4588002371', 10000, 'BDO', 'Taft Ave., Vito Cruz Manila', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(19, 22, 'Ma. Angela Reforma', '370069609', 100000, 'BDO', 'Buenbia LRT Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(19, 23, 'Ma. Angela Reforma', '378008401', 100000, 'Banco De Oro', 'Buenbia LRT Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(20, 24, 'Victoria Saldivar / Niel Apollo Peralta', '112-003008-3 / 112-185341', 100000, 'UCPB', 'F.B. Harisson Pasay City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(21, 25, 'Clarisel Calaycay', '00-259-810811-3', 35000, 'PNB', 'Shangrila Plaza Br-G Shaw Blvd.', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:23', '1'),
(22, 26, 'Avelina Garcia', '1210-07446-8', 5000, 'Allied Bank', 'San Pedro Laguna', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(23, 27, 'Sinto Uy / John Paul''s Commercial Place', '201-030322-001', 50000, 'Security Bank', 'Pasay Macapagal Ave', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(24, 28, 'Raquel Betito', '0021-01464-9', 5000, 'RCBC ', '2350 Taft Ave. Pasay', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(25, 29, 'Ma. Marissa R. Viri/Ma. Josephine Horlador', '0021-016688-001', 100000, 'Security Bank', 'Libertad Cor. Colayco St. Pasay', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(26, 30, 'Susan T. Dy', '1621017619', 40000, 'Allied Bank', 'Sucat Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(27, 31, 'Edmund Dela Fuente', '133331000591', 10000, 'PS Bank', 'Pasong Tamo', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(28, 32, 'Ma. Teresita Dellosa', '2658009323', 20000, 'BDO', 'Washington- Gil Puyat Makati', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(28, 33, 'Ma. Teresita Dellosa', '7018-52132-2 / 7018-53050', 10000, 'Metro Bank', 'Pasong Tamo Makati', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(28, 34, 'Ma. Teresita Dellosa', '2658009455', 20000, 'Banco De Oro', 'Washington- Gil Puyat Makati', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(29, 35, 'Soraya Salamat', '2128012016', 15000, 'Banco De Oro', 'Gil Puyat', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(30, 36, 'Joseph Catmonan', '110-23-000013-1', 20000, 'RB', 'SALCEDO VILLAGE MAKATI', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(31, 37, 'GLORIA C. SOHRABI LANGROUI', '0821-0286-12', 100000, 'BPI', 'FORT SEREDIA BRANCH', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(32, 38, 'Eizebel Trojillo/Erwin Orocio/Shirley Tobias/Nanette Hernandez', '5440000160', 50000, 'BDO', 'BDO-Villar Salcedo Villar St. Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(32, 39, 'Eizebel Trojillo/Erwin Orocio/Shirley Tobias/Nanette Hernandez', '5440000160', 100000, 'BDO', 'BDO-Villar Salcedo Villar St. Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(33, 40, 'Carmelita Lising', '143-082101-0', 50000, 'China Bank', 'Dian Cor., Buendia Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:24', '1'),
(34, 41, 'Amorlaida Gatdula', '406-367-000012', 9000, 'PNB', 'FTI Taguig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(35, 42, 'GLORIA C. SOHRABI LANGROUI', '153-055761-1', 15000, 'China Bank', 'Makati Avenue Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(36, 43, 'Ana Recto', '007-044-51851.8', 10000, 'Metro Bank', 'U.N. Avenue', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(36, 44, 'Ana Recto', '00188-001075-9', 10000, 'UCPB', 'CHINO ROCES ', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(37, 45, 'Manolo Subingsubing', '00-217-000188-3', 15000, 'Union Bank', 'Makati Ave., Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(38, 46, 'Celina Almazora', '0091-01125-1', 20000, 'Allied Bank', 'Paseo Legaspi Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(38, 47, 'Celina Almazora', '1661-0117-49', 20000, 'BPI', 'Paseo Legaspi Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(38, 48, 'Celina Almazora', '211-6014311', 100000, 'Export & Industry', 'G/F Pacific Star Bldg. Sen. Gil Puyat Ave., Cor. Makati Ave., Makati City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(39, 49, 'Rolando Mendoza Jr.', '0311-02120-7', 10000, 'Allied Bank', '865 M. Naval St. Navotas M. M.', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(40, 50, 'Jay Correa', '007-070-57953-3', 50000, 'Banco De Oro', 'Redemptorist Baclaran Branch', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(41, 51, 'Bernadeth U. Pimenteel/Renato D. Pimentel', '007-168-529-429', 30000, 'MBTC', 'Sea Front  Branch Roxas Boulevard', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(42, 52, 'Lilibeth Salansang', '007-227-51326-4', 10000, 'Metro Bank', 'Dian Cor., Buendia Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(43, 53, 'Cynthia Aguilar', '461-158017-001', 10000, 'Security Bank', 'EDSA Central, Mandaluyong', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(44, 54, 'Michael Angelo Mahinay', '00048-001065-1', 20000, 'Union Bank', 'West Ave. Quezon City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(45, 55, 'Maria Ana Ochoa', '2420-0014-12', 50000, 'BPI', 'Mandaluyong', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(46, 56, 'Analiza Poblador', '112-128-161-3', 12000, 'CBC', 'Mall of Asia Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:25', '1'),
(47, 57, 'Julieta Tenoria', '00-26280020-78', 50000, 'BDO', 'Leveriza St. Pasay City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(48, 58, 'Jocelyn Gillego', '012-0000617-5', 100000, 'Rural Bank of Cardona Inc.', 'Taytay Rizal', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(49, 59, 'LOUIE B. ESTUPIGAN', '8151-0030-02', 10000, 'BPI', 'Bicutan', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(50, 60, 'Margaret Avenir/FE/Winfred Zosa', '300-00-0100060 / 300-00-0', 20000, 'Manila Bank', 'G/F Padilla Bldg. Emerald Ave. Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(51, 61, 'Angel Navarro', '142-0018106', 50000, 'BDO', 'Meralco Compound Ortigas Pasig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(52, 62, 'Amie Mariano', '5548004350', 10000, 'Banco De Oro', 'Shangrila Plaza Br-G Shaw Blvd.', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(53, 63, 'Mary Grace Yap', '2868009681', 30000, 'BDO', 'Strata, Ortigas Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(54, 64, 'Edna L. Almazan', '191-000765-4', 10000, 'UCPB', 'Acropolis Libis', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(55, 65, 'Emelinda M. Tan', '12010000691', 20000, 'China Trust', 'G/F Prestige Tower Ortigas Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(56, 66, 'Edgardo Diaz', '125-063761-7', 20000, 'China Bank', 'Ortigas Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(57, 67, 'Ruby Co/Jocelyn Poon', '151-800-2500', 10000, 'BDO', 'LIBIS Q.C.', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(58, 68, 'Crispin Tuazon', '0679-05-13193-9', 100000, 'BPI Family', 'Emerald Ortigas Pasig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(59, 69, 'Arturo Dy', '257-7-257-80839-0', 10000, 'MBTC', 'Shaw Blvd Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(60, 70, 'Donnabel Roque', '003531-00746-1', 10000, 'Allied Bank', 'Aguilar Ave. Las PiÃ±as', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(61, 71, 'Michael Icasiano', '6268000543', 20000, 'BDO', 'C5 Taguig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(62, 72, 'Edna Ordonia', '0391-327651-001', 15000, 'Security Bank', 'Sitio Simona Brgy. San Isidro Taytay Rizal', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:26', '1'),
(63, 73, 'Josephine P. Inocencio', '20107-000326-8', 50000, 'UCPB', 'Pasig City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(63, 74, 'John Inocencio', '0131-051401-0', 70000, 'China Bank', 'Pasig', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(64, 75, 'Arturo G. Legarde/Lucille E. Legarde', '003418009841', 100000, 'BDO', 'Pasig Boulevard Extension - Rosario', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(65, 76, 'Enrique Store', '0305-2356-01', 12000, 'BPI', 'Harrison Buendia Pasay', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(66, 77, 'Ricardo Octavo Jr. / Alicia Octavo', '292-7-29250208-3', 50000, 'MBTC', 'G/F PS BankCenter Paseo de Roxas Makati City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(67, 78, 'Enlio O. Leonor', '007-2347-0338-9', 50000, 'MBTC', 'J.P. Rizal St. Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(68, 79, 'Rustomer Valero', '003091-00665-3', 20000, 'Allied Bank', 'Pasay Road Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(68, 80, 'Rustomer Valero', '3091-01266-1', 10000, 'Allied Bank', 'Pasay Road Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(69, 81, 'Raul Mendoza/Manzel Mendoza', '007-231-50676-0', 80000, 'Metro Bank', 'P. Gil St. Sta. Ana Manila', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(70, 82, 'Michael Castillo', '21002572', 5000, 'First Macro Bank', '#8 Gen. Santos Ave. Lower Bicutan Taguig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(71, 83, 'Az-Hamir O. Maidin', '7342-009707', 70000, 'MBTC', 'FTI Taguig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(72, 84, 'Ernesto S. Rodriguez', '302-021691-0', 40000, 'CBC', '6/F DHI Bldg. No. 2 Lapu-lapu Ave. Cor. Edsa, Magallanes Village Makati Cit', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(73, 85, 'Rolito Cusi', '5945050286', 2000, 'BPI Family Bank', 'Libertad Pasay', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(74, 86, 'Myrna Yaplag', '10-076-570001-4', 10000, 'PNB', 'Harrizon Plaza', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:27', '1'),
(75, 87, 'Roanne Lynne P. See', '0211-04289-5', 200000, 'Allied Bank', 'Rosario Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(76, 88, 'Margarita Tan', '188-001214-8', 30000, 'UCPB', 'Global City Taguig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(77, 89, 'R.B. Caballero', '206-095951-3', 20000, 'CBC', 'Pasig-Santolan', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(78, 90, 'Rodolfo Sulibio Jr.', '206-109-581-2', 30000, 'China Bank', 'Santolan Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(79, 91, 'Amanda Pathac', '1455994', 500000, 'BDO', '', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(79, 92, 'Amanda Pathac', '9671000622', 500000, 'BPI', 'Vito Cruz Ext. Pasong Tamo Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(80, 93, 'Fernando Parial', '3140-0131-52', 5000, 'BPI', 'Kamuning ', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(81, 94, 'Eduardo Encallado', '008100-0000-76', 50000, 'BPI', 'Units 1 & 2 Prudential Bank Bldg. U.N. Ave. cor M.H. Del Pilar St. Ermita Manila', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(82, 95, 'Gloria Catapang', '670-127-698 / 678-011-101', 10000, 'BDO', 'North Edsa', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(83, 96, 'Renato Santos', '730-153558-5', 200000, 'Metro Bank', 'F.B. Harisson Cor Buendia Pasay', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(84, 97, 'Elizabeth Pomposo', '0002-50002791-6', 90000, 'May Bank', 'Villamor Air Base Pasay', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(85, 98, 'Diane De Leon', '001421-01403-1', 50000, 'Equitable PCI Bank', '118 Alfaro St. Salcedo Village Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(86, 99, 'Tristan Choa', '3771-0057-48', 100000, 'BPI', 'Salcedo Village Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:28', '1'),
(87, 100, 'Edna Cruz', '6375004516', 30000, 'BPI Family Bank', '77 P. Burgos St. Cainta Rizal', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(88, 101, 'Rosemarie Colegio', '122-208091-7', 10000, 'China Bank', 'China Bank Bldg. SM Megamall', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(89, 102, 'Elvira de la Cruz', '0017-00045-5', 10000, 'RCBC', 'layunan Binagnonan Rizal', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(90, 103, 'Emma T. Caramat', '00-031-0026428', 250000, 'Union Bank', 'GF Kimeswood Arcade Vito Cruz Cor. Pasong Tamo St. Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(91, 104, 'Milagros Koh', '0180-0039-75', 70000, 'BPI', 'Shaw Blvd', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(92, 105, 'Dietrich Romualdez', '0472-36448-3001', 75000, 'Security Bank', 'Amang Rodriguez Cor. Evangelista St. Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(93, 106, 'Florencio B. Buentipo', '00-229-8504963', 20000, 'BDO', 'San Pedro National H-Way Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(94, 107, 'Anrabella Wisniewski', '008-03-0004184', 100000, 'International Exchange Bank', 'Madrigal Bldg. Ayala Ave. Makati City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(95, 108, 'Gerry Bautista', '00114-003334-0', 5000, 'UCPB', 'Shaw Blvd', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(96, 109, 'Caroline  Dizon ', '1378-03866-5', 80000, 'Equitable PCI Bank', 'Robinson Tower', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(97, 110, 'Marlyn Alimpolos', '207-8117128', 25000, 'PNB', 'Fairview Center Mall Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(98, 111, 'Juan Miguel Laurel', '429-800-6988', 100000, 'BDO', 'Makati Square Branch Pasong Tamo Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(99, 112, 'Alice Chua', '110-02-0-00888-9', 100000, 'International Exchange Bank', '233 J.P. Rizal Cor. Sta. Ines Marikina', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(100, 113, 'Jose Laxa', '034-111-0117-7', 10000, 'Global Bank', 'Shaw Blvd. Pasig City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(101, 114, 'Maricel Sina', '007-004-51847-7', 50000, 'Metro Bank', '446 East Ave. Extra Caloocan City Rizal', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(102, 115, 'Loreta Vargas', '7-178-50621-4', 15000, 'Metro Bank', 'Lores Country Homes Antipolo City', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(103, 116, 'Reynold Tamayo', '0405-0821-01', 100000, 'BPI', 'Aurora Blvd. New Manila', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(104, 117, 'Manuella M. Yamat', '140-5072000-26', 20000, 'PNB', 'Ever Gotesco Ortigas Pasig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:29', '1'),
(105, 118, 'Carlito Soliman / Remedios Suntay', '000-0996-0', 100000, 'RCBC', 'RCBC Plaza Ayala Ave., Makati City', '', 'CHARGE ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(106, 119, 'Maribel Cruz', '0103-01-01323-3', 5000, 'Premier Bank', '137 Rizal Ave., Taytay Rizal', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(107, 120, 'Raquel Dayao', '043-8006720', 10000, 'BDO', 'Metropolitan Branch Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(108, 121, 'Marlene De Guzman', '427-8000-602', 15000, 'BDO', 'E.Rodriguez Ugong Pasig', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(109, 122, 'Katy Go/Nelson T. Lao/Nancy Uy', '0288-80367-6', 200000, 'RCBC ', 'Pasong Tamo Extension Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(110, 123, 'Wilson Go', '001181-00887-5', 100000, 'Allied Bank', 'Ongpin Sta Cruz', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(111, 124, 'Adrian Martinez / Pilar Arroyo', '730-951074-3', 100000, 'MBTC', 'Kalayaan Ave. Makati ', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(112, 125, 'Sophia Solon', '163-002052-7', 80000, 'UCPB', 'Shangrila', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(113, 126, 'Rolando Caballero / Rosario Caballero', '2060959513', 15000, 'China Bank', 'Santolan Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(114, 127, 'Joseph Jericho Sebastian', '5202005545', 200000, 'East West Bank', 'E. Rodriguez Sr. Ave, New Manila Q.C.', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(115, 128, 'LALAINE TUNGOL', '5378015436', 50000, 'BDO', 'RADA COR DELA ROSA', '', 'CHARGE ACCOUNT - - 9/12/12', '2017-05-03 07:56:30', '1'),
(116, 129, 'Edmund Souza / Joan Souza', '229-80001-86', 50000, 'BDO', 'San Pedro National H-Way Branch', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(117, 130, 'LINO C. LACANLALE/RAFFY SOLIS', '223-088881-2', 50000, 'China Bank', 'E. RODRIGUEZ QUEZON CITY', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(118, 131, 'Marissa Ramirez', '077-7077503117', 5000, 'MBTC', 'Taft Avenue/ Roxas Blvd', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:30', '1'),
(119, 132, 'Tristan A. Choa', '046-802-146-0', 25000, 'BDO', 'Equitable Bank Tower,8751 Pase De Roxas Makati', '', 'CASH ACCOUNT - - Cancelled 4/2013 due to inactive account', '2017-05-03 07:56:31', '1'),
(120, 133, 'Freddie Dela PeÃ±a', '4902-012-821', 5000, 'Eastwest Bank', 'Tekfile Bldg. Ortigas Pasig City', '', 'CASH ACCOUNT - - Cancelled 10/2013 due to series of returned check', '2017-05-03 07:56:31', '1'),
(120, 134, 'Freddie Dela PeÃ±a', '1960010004', 50000, 'UCPB', 'Tekfile Bldg. Ortigas Pasig City', '', 'CASH ACCOUNT - - Cancelled 10/2013 due to series of returned check', '2017-05-03 07:56:31', '1'),
(121, 135, 'HERACLEO ALVAREZ', '9875001784', 50000, 'BPI', 'ASEANA MACAPAGAL', '', 'CASH ACCOUNT - - Cancelled 10/2013 due to series of returned check', '2017-05-03 07:56:31', '1'),
(122, 136, 'Christopher James Escudero', '2880-18008-9', 100000, 'BDO', 'Eastwood IBM Plaza', '', 'CASH ACCOUNT - - ', '2017-05-03 07:56:31', '1'),
(123, 137, 'Ervin Soriano', '0273-495603-001', 12000, 'Security Bank', 'Grd. Flr. East Tower PSECC Ortigas', '', 'CHARGE ACCOUNT - - Closed account as of 12/16/13', '2017-05-03 07:56:31', '1'),
(124, 138, 'RODOLFO MANDAP', '87331001423', 0, 'PS Bank', 'Ortigas Branch', '', ' - - DISAPPROVED 3/24/15 DUE TO 4 COUNTS OF BC', '2017-05-03 07:56:31', '1'),
(125, 139, 'Gerry Reyes Santillan', '0291-0328-42', 100000, 'BPI', 'FORBES PARK SAN ANTONIO PLAZA', '', 'CASH ACCOUNT/ with GM''s Exemption approval Dec 2013 - - inactive as of July 2016', '2017-05-03 07:56:31', '1'),
(126, 140, 'Vissia Arana', '03601-000113-1', 40000, 'PVB', 'VETERANS TAGUIG', '', 'CASH ACCOUNT/ with GM''s Exemption approval Dec 2013 - - ', '2017-05-03 07:56:31', '1'),
(127, 141, 'JORGE HUIDEM', '0062-5504-0225', 50000, 'BPI', 'DONA SOLEDAD', '', 'CASH ACCOUNT - - 8/17/16', '2017-05-03 07:56:31', '1'),
(128, 142, 'NELSON MENDOZA', '8180005537', 150000, 'BPI', 'KABIHASNAN PQUE ', '', 'CASH ACCOUNT - - 12/8/15', '2017-05-03 07:56:31', '1'),
(129, 143, 'Alerix G. Florano', '258-0246612', 80000, 'CBC', 'SM City Marikina', '', 'CASH ACCOUNT - - 10/8/12', '2017-05-03 07:56:31', '1'),
(130, 144, 'JORGE HUIDEM', '073-01-001070-5', 150000, 'Asia United Bank', 'DONA SOLEDA D', '', 'Exemption approval due to instances of returned check - - 10/11/16', '2017-05-03 07:56:32', '1'),
(131, 145, 'JOSEFINA AGUAS', '543-8000912', 100000, 'BDO', 'Alfaro St. Salcedo Village Makati', '', 'caSH ACCOUNT - - 6/20/13', '2017-05-03 07:56:32', '1'),
(131, 146, 'JOSEFINA AGUAS', '7968-0012-03', 50000, 'BDO', 'CHINO ROCES', '', 'CHARGE ACCOUNT - - 10/21/13', '2017-05-03 07:56:32', '1'),
(131, 147, 'JOSEFINA AGUAS', '8320-0088-25', 150000, 'BPI', 'TUNASAN', '', 'CHARGE ACCOUNT - - 1/22/15', '2017-05-03 07:56:32', '1');

-- --------------------------------------------------------

--
-- Table structure for table `check_payers_table`
--

CREATE TABLE `check_payers_table` (
  `check_Payers_Id` int(11) NOT NULL,
  `business_Name` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `check_payers_table`
--

INSERT INTO `check_payers_table` (`check_Payers_Id`, `business_Name`) VALUES
(1, 'Jocelyn Asor'),
(2, '5TH AVE. PIZZA PARLOR'),
(3, 'KARWAJE FOOD SERV.'),
(4, 'ORANGE & CHERRY FOOD SERVICE'),
(5, 'MTE K+B11:B23TTE'),
(6, 'T-10 CONVIIENCE'),
(7, 'UNCLE BO''S ENT.'),
(8, 'MAKATI CHEF ATENEO'),
(9, 'EXCELLENT MART'),
(10, 'GOLDEN FAMOSA IN''L CORP.'),
(11, 'BURNT MILK CAFÃ‰'),
(12, 'HOSSEIN RESTAURANT'),
(13, 'KAPITAN RUFO'),
(14, 'NAMRIA MULTI PURPOSE COOP.'),
(15, 'SMBN COMM''L'),
(16, 'VALUABLE GOURMET ENT'),
(17, '918 PHARMACY BOTIKA NG BAYAN'),
(18, 'A. MABINI H.S.'),
(19, 'APPLE TREAT MART'),
(20, 'DFA MULTI PURPOSE COOP'),
(21, 'HK SUN PLAZA'),
(22, 'LRTA EMP. MULTI PURPOSE COOP'),
(23, 'MADONNA''S CUISINE'),
(24, 'RAQUEL STORE'),
(25, 'ST. MARY''S ACADEMY'),
(26, 'UNI TRUST ENT.'),
(27, '1085 WINES & SPIRIT'),
(28, '4M-J FASTFOOD & BILLIARDS'),
(29, 'CAFE JOSEFINAS'),
(30, 'CATER PRO-SHELL'),
(31, 'PERSIAN KEBAB INC.'),
(32, 'KABIBI CONSUMER''S COOP'),
(33, 'KAPAMPANGAN FAST FOOD'),
(34, 'KENIRYL GAZ & GEN. MERCHANDISE'),
(35, 'PERSIAN KEBAB '),
(36, 'POWERSMASH INC.'),
(37, 'QUICK 24 MART'),
(38, 'SWEET IDEAS BREADS & CAKE CORP'),
(39, 'WHITE THUMB CAKES, P'),
(40, 'JAY''S LECHON'),
(41, 'JOY OF LIFE'),
(42, 'SPICES CAFÃ‰'),
(43, 'BREADSTOP'),
(44, 'RITE BUDGET SHOPMART INC.'),
(45, 'TRUE PRICE ROBINSON'),
(46, '6 ELEVEN COPY SHOP'),
(47, 'FRIENDLY MOTORISTS CALTEX SERVICE STATION'),
(48, 'JOCELYN STORE'),
(49, 'MTG CONVINIENCE STORE'),
(50, '627 FOODMART'),
(51, 'AL NAVARRO CASSEROLES FOOD SERVICE'),
(52, 'BALIKATAN COOP'),
(53, 'CLIQUE & EASY CONV. STORE'),
(54, 'EDNA''S CATERING SERVICES'),
(55, 'OAK BARN FOOD EXPRESS'),
(56, 'PENDONG CONVENIENCE STORE'),
(57, 'SAVANNAH MOON'),
(58, 'TUAZON KITCHENETTE'),
(59, 'WOK INN RESTAURANT'),
(60, '3RD''S RESTAURANT'),
(61, 'ADSIA CANTEEN'),
(62, 'EDNA STORE'),
(63, 'FARMACIA PERALTA'),
(64, 'LOLO ART''S CHICKEN SARAP'),
(65, 'IKE LOU STORE'),
(66, 'LAZARUS MKTG.'),
(67, 'LEONORE LOGISTICS &'),
(68, 'ROSTUM STORE'),
(69, 'RYAN JOHN TRADING'),
(70, 'CASTILLO STORE'),
(71, 'FANTASTIC  EGG STORE'),
(72, 'JROD MARKETING'),
(73, 'LEXIAN CANTTEN'),
(74, 'MYRNALENE CANTEEN'),
(75, 'INTERFOOD EXPORT-IMPORT CORP.'),
(76, 'MCT O8'),
(77, 'CABALLERO SOFTDRINK DEALER'),
(78, 'JAS U & ME GEN. MDSE.'),
(79, 'PHIL-EM ENTERPRISES'),
(80, 'F. C. PARIAL JR SOFTDRINK DEALER'),
(81, '15th STATION GRILL & CAFÃ‰'),
(82, 'AMIGO STEEL'),
(83, 'BEER AND BEVERAGE TRADE'),
(84, 'BETH POMPY CONV'),
(85, 'BTC-ALPAR LOUNGE'),
(86, 'BIKRAM YOGA MANILA'),
(87, 'EDNA CRUZ'),
(88, 'ELEVEN TWELVE CONV'),
(89, 'ELVIE STORE'),
(90, 'EMMAFLOR PRIME'),
(91, 'EXPRESS LUGAWAN'),
(92, 'FINACONDA METAL'),
(93, 'FIRST ROAD GEN. MDSE.'),
(94, 'FOOD PARKS RAIN TREE'),
(95, 'GER''S BAR & REST.'),
(96, 'GLOBAL BISTRO INC.'),
(97, 'JAKODS SARI SARI STORE'),
(98, 'JAYMI"S GRILL / MINIFORT VENTURES INC.'),
(99, 'KABANYA REST'),
(100, 'LAXA STORE'),
(101, 'LIME POP MINI MART'),
(102, 'LORIES BAKERY'),
(103, 'LUCATA TRADING'),
(104, 'M.M YAMAT MOTORIST CENTER'),
(105, 'MAKATI MEDICAL CENTER'),
(106, 'MARIE STORE'),
(107, 'MARJ FOOD SERVICE'),
(108, 'MARLREY STORE'),
(109, 'MEGALICIOUS FOOD CORPORATION / COUNTRY STYLE'),
(110, 'MEMPHIS KITCHEN'),
(111, 'PACIFICA BANDINI CORP.'),
(112, 'RACE FOODS CO. INC.'),
(113, 'RC CABALLERO ENT.'),
(114, 'RJJ DISTRIBUTION'),
(115, 'AKUNG ENTERPRISE'),
(116, 'SARETH CARINDERIA'),
(117, 'ST. LUKES MEDICAL INC'),
(118, 'YJK STORE'),
(119, 'YOGA WORKS INC.'),
(120, 'DELA PEÃ‘A COPY sYSTEM & GEN. MDSE.'),
(121, 'HERABEL ENTERPRISE'),
(122, 'IL MERCANTI'),
(123, 'BREN-VIN CAFÃ‰'),
(124, 'EMLOS FOOD PRODUCTS'),
(125, 'COLEGIO SAN AGUSTIN'),
(126, 'TEAM PACIFIC COOP.'),
(127, 'JHH ENTERPRISES'),
(128, 'N.M.M MARKETING'),
(129, 'ALERIX GENERAL MERCHANDISE'),
(130, 'JHH 318 ENTERPRISES'),
(131, 'MHANNAH  ENTERPRISES');

-- --------------------------------------------------------

--
-- Table structure for table `transaction_details_table`
--

CREATE TABLE `transaction_details_table` (
  `trans_Id` int(11) NOT NULL,
  `trans_Key_Id` varchar(25) NOT NULL,
  `teller_Id` int(5) NOT NULL,
  `pd_Number` varchar(20) NOT NULL,
  `settler_Name` varchar(100) NOT NULL,
  `date` varchar(25) NOT NULL,
  `payment_Type` int(11) NOT NULL,
  `active` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction_details_table`
--

INSERT INTO `transaction_details_table` (`trans_Id`, `trans_Key_Id`, `teller_Id`, `pd_Number`, `settler_Name`, `date`, `payment_Type`, `active`) VALUES
(1, '1', 1, 'sdasd', 'asd', '5/2/2017', 0, 1),
(2, '2', 1, 'dasd', 'sd', '5/2/2017', 0, 1),
(3, '3', 1, 'asdasd', 'asdasdas', '5/8/2017', 0, 1),
(4, '4', 1, 'kjmhb', 'kjhb', '5/10/2017', 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `transaction_key_table`
--

CREATE TABLE `transaction_key_table` (
  `Id` int(11) NOT NULL,
  `trans_Id` varchar(20) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction_key_table`
--

INSERT INTO `transaction_key_table` (`Id`, `trans_Id`, `status`) VALUES
(1, '2017-1', 1),
(2, '2017-2', 1),
(3, '2017-3', 1),
(4, '2017-4', 1);

-- --------------------------------------------------------

--
-- Table structure for table `trans_payment_cash`
--

CREATE TABLE `trans_payment_cash` (
  `cash_Payment_Id` int(11) NOT NULL,
  `trans_ID` int(11) NOT NULL,
  `1000` double NOT NULL,
  `500` double NOT NULL,
  `200` double NOT NULL,
  `100` double NOT NULL,
  `50` double NOT NULL,
  `20` double NOT NULL,
  `10` double NOT NULL,
  `5` double NOT NULL,
  `1` double NOT NULL,
  `.25` double NOT NULL,
  `.10` double NOT NULL,
  `other` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trans_payment_cash`
--

INSERT INTO `trans_payment_cash` (`cash_Payment_Id`, `trans_ID`, `1000`, `500`, `200`, `100`, `50`, `20`, `10`, `5`, `1`, `.25`, `.10`, `other`) VALUES
(1, 1, 44, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(2, 2, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 3, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 4, 1, 76, 6, 4, 3, 5, 7, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `trans_payment_check`
--

CREATE TABLE `trans_payment_check` (
  `check_Payment_Id` int(11) NOT NULL,
  `trans_Id` int(11) NOT NULL,
  `account_Num` varchar(50) NOT NULL,
  `account_Num_Info` varchar(150) NOT NULL,
  `account_num_series` varchar(25) NOT NULL,
  `account_Limit` varchar(150) NOT NULL,
  `amount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trans_payment_check`
--

INSERT INTO `trans_payment_check` (`check_Payment_Id`, `trans_Id`, `account_Num`, `account_Num_Info`, `account_num_series`, `account_Limit`, `amount`) VALUES
(1, 3, '21002572', 'FIRST MACRO BANK - CASTILLO STORE', '', '5000', 5000),
(2, 4, '206-095951-3', 'CBC - caBALLERO SOFTDRINK DEALER', '', '20000', 3000),
(3, 4, '206-095951-3', 'CBC - caBALLERO SOFTDRINK DEALER', '', '20000', 3000),
(4, 4, '206-095951-3', 'CBC - caBALLERO SOFTDRINK DEALER', '', '20000', 3000);

-- --------------------------------------------------------

--
-- Table structure for table `user_table`
--

CREATE TABLE `user_table` (
  `userId` int(11) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `middleName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `userName` varchar(50) NOT NULL,
  `passWord` varchar(50) NOT NULL,
  `dateOfBirth` varchar(50) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `userType` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  `officeIdNum` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_table`
--

INSERT INTO `user_table` (`userId`, `firstName`, `middleName`, `lastName`, `userName`, `passWord`, `dateOfBirth`, `gender`, `userType`, `status`, `officeIdNum`) VALUES
(1, 'Carl', 'I.', 'Villar', 'admin', 'admin', '2017-02-12', 'Male', 'Admin', 'Active', '123456789'),
(2, 'Jasmine', 'G', 'Octaviano', 'staff', 'staff', '1998-04-23', 'Female', 'Staff', 'Active', '4'),
(3, 'asdjk', 'asdas', 'asdas', 'encoder', 'encoder', '1990-01-31', 'Female', 'Encoder', 'Active', '123456');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account_number_table`
--
ALTER TABLE `account_number_table`
  ADD PRIMARY KEY (`account_Num_Id`),
  ADD KEY `check_Payers_Id` (`check_Payers_Id`);

--
-- Indexes for table `check_payers_table`
--
ALTER TABLE `check_payers_table`
  ADD PRIMARY KEY (`check_Payers_Id`);

--
-- Indexes for table `transaction_details_table`
--
ALTER TABLE `transaction_details_table`
  ADD PRIMARY KEY (`trans_Id`),
  ADD KEY `teller_Id` (`teller_Id`);

--
-- Indexes for table `transaction_key_table`
--
ALTER TABLE `transaction_key_table`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `trans_payment_cash`
--
ALTER TABLE `trans_payment_cash`
  ADD PRIMARY KEY (`cash_Payment_Id`);

--
-- Indexes for table `trans_payment_check`
--
ALTER TABLE `trans_payment_check`
  ADD PRIMARY KEY (`check_Payment_Id`);

--
-- Indexes for table `user_table`
--
ALTER TABLE `user_table`
  ADD PRIMARY KEY (`userId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account_number_table`
--
ALTER TABLE `account_number_table`
  MODIFY `account_Num_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=148;
--
-- AUTO_INCREMENT for table `check_payers_table`
--
ALTER TABLE `check_payers_table`
  MODIFY `check_Payers_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=132;
--
-- AUTO_INCREMENT for table `transaction_details_table`
--
ALTER TABLE `transaction_details_table`
  MODIFY `trans_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `transaction_key_table`
--
ALTER TABLE `transaction_key_table`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `trans_payment_cash`
--
ALTER TABLE `trans_payment_cash`
  MODIFY `cash_Payment_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `trans_payment_check`
--
ALTER TABLE `trans_payment_check`
  MODIFY `check_Payment_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `user_table`
--
ALTER TABLE `user_table`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
