-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 14 2024 г., 07:26
-- Версия сервера: 10.4.28-MariaDB
-- Версия PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `453_db`
--

-- --------------------------------------------------------

--
-- Структура таблицы `practice`
--

CREATE TABLE `practice` (
  `Id` int(11) NOT NULL,
  `Text` varchar(255) NOT NULL,
  `RightWord` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `practice`
--

INSERT INTO `practice` (`Id`, `Text`, `RightWord`) VALUES
(1, 'Вставьте недостающее _______', 'слово'),
(2, 'Пошло _____ как по маслу', 'дело'),
(3, 'Без труда, не выловишь ______ из пруда', 'рыбку'),
(4, 'Стучать ______', 'зубами');

-- --------------------------------------------------------

--
-- Структура таблицы `result`
--

CREATE TABLE `result` (
  `Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `TestScore` int(11) NOT NULL,
  `PracticeScore` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `result`
--

INSERT INTO `result` (`Id`, `IdUser`, `TestScore`, `PracticeScore`) VALUES
(1, 3, 2, 4),
(2, 5, 1, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `test`
--

CREATE TABLE `test` (
  `Id` int(11) NOT NULL,
  `QuestionText` varchar(100) NOT NULL,
  `AnswerText_1` varchar(100) NOT NULL,
  `AnswerText_2` varchar(100) NOT NULL,
  `AnswerText_3` varchar(100) NOT NULL,
  `AnswerText_4` varchar(100) NOT NULL,
  `RightAnswerNumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `test`
--

INSERT INTO `test` (`Id`, `QuestionText`, `AnswerText_1`, `AnswerText_2`, `AnswerText_3`, `AnswerText_4`, `RightAnswerNumber`) VALUES
(1, 'Текст вопроса №1', 'ответ №1', 'ответ №2', 'ответ №3', 'ответ №4', 1),
(2, 'Текст вопроса №2', 'ответ №1', 'ответ №2', 'ответ №3', 'ответ №4', 2),
(3, 'Текст вопроса №3', 'ответ №1', 'ответ №2', 'ответ №3', 'ответ №4', 3),
(4, 'Текст вопроса №4', 'ответ №1', 'ответ №2', 'ответ №3', 'ответ №4', 4);

-- --------------------------------------------------------

--
-- Структура таблицы `theory`
--

CREATE TABLE `theory` (
  `Id` int(11) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Text` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `theory`
--

INSERT INTO `theory` (`Id`, `Title`, `Text`) VALUES
(1, 'Теория 1', 'Текст теории 1'),
(2, 'Теория 2', 'Текст теории 2'),
(3, 'Теория 3', 'Текст теории 3'),
(4, 'Теория 4', 'Текст теории 4'),
(5, 'Теория 5', 'Текст теории 5'),
(6, 'Теория 6', 'Текст теории 6'),
(7, 'Теория 7', 'Текст теории 7'),
(8, 'Теория 8', 'Текст теории 8'),
(9, 'Теория 9', 'Текст теории 9'),
(10, 'Теория 10', 'Текст теории 10');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `Login` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Role` varchar(100) NOT NULL,
  `Fullname` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Phone` varchar(100) NOT NULL,
  `DateOfBirth` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`Id`, `Login`, `Password`, `Role`, `Fullname`, `Email`, `Phone`, `DateOfBirth`) VALUES
(1, 'admin', '1111', 'Admin', 'Администратор', 'admin@com.ru', '111-111', '01.01.1999'),
(2, 'edit1', '1111', 'Editor', 'ФИО 1', 'edit1@com.ru', '111-222', '14.06.2024'),
(3, 'log1', '1111', 'Student', 'ФИО 2', '1@mail.ru', '122121', '14.06.2024'),
(5, 'log2', '1111', 'Student', 'ФИО 3', '2@mail.ru', '12211221', '14.06.2024');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `practice`
--
ALTER TABLE `practice`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `result`
--
ALTER TABLE `result`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `test`
--
ALTER TABLE `test`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `theory`
--
ALTER TABLE `theory`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `practice`
--
ALTER TABLE `practice`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `result`
--
ALTER TABLE `result`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `test`
--
ALTER TABLE `test`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `theory`
--
ALTER TABLE `theory`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
