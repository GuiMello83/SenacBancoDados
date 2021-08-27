-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 21-Ago-2021 às 15:08
-- Versão do servidor: 10.4.20-MariaDB
-- versão do PHP: 7.4.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `senactur`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pacotesturisticos`
--

CREATE TABLE `pacotesturisticos` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(100) DEFAULT NULL,
  `Origem` varchar(100) DEFAULT NULL,
  `Destino` varchar(200) DEFAULT NULL,
  `Atrativos` varchar(200) DEFAULT NULL,
  `Saida` datetime DEFAULT NULL,
  `Retorno` datetime DEFAULT NULL,
  `Usuario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `pacotesturisticos`
--

INSERT INTO `pacotesturisticos` (`Id`, `Nome`, `Origem`, `Destino`, `Atrativos`, `Saida`, `Retorno`, `Usuario`) VALUES
(5, 'Euro10', 'São Paulo', 'Paris', 'Visitar vários países', '2021-08-21 00:00:00', '2021-09-20 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(200) NOT NULL,
  `Login` varchar(20) DEFAULT NULL,
  `Senha` varchar(20) DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Login`, `Senha`, `DataNascimento`) VALUES
(1, 'Gui1', 'Gui1', '123', '2021-08-12 00:00:00'),
(3, 'Gui12', 'Gui1', '123', '2021-08-12 00:00:00'),
(4, 'GuiMello', 'GuiMello', 'GM', '2021-08-21 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Usuario` (`Usuario`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD CONSTRAINT `pacotesturisticos_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
