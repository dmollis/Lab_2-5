-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Мар 26 2025 г., 14:08
-- Версия сервера: 8.0.17
-- Версия PHP: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `budmayster`
--

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateMaterialsPercentages` ()  BEGIN
    UPDATE materials
    SET 
        `%_zakup` = CASE 
                        WHEN price_zakup = 0 THEN 0
                        WHEN price_opt = 0 THEN 0
                        ELSE (price_opt - price_zakup) / price_zakup * 100
                    END,
        `%_opt` = CASE 
                        WHEN price_zakup = 0 THEN 0
                        WHEN price_prod = 0 THEN 0
                        ELSE (price_prod - price_zakup) / price_zakup * 100
                    END;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `categories`
--

INSERT INTO `categories` (`id`, `name`) VALUES
(9, 'Газобетон'),
(12, 'Гіпсокартон'),
(8, 'Двері'),
(3, 'Зенит'),
(6, 'Клей'),
(1, 'КНАУФ'),
(5, 'Полімін'),
(7, 'Полісан'),
(4, 'Утеплювачі'),
(11, 'Фарби'),
(2, 'Церезит'),
(10, 'Шпаклівка');

-- --------------------------------------------------------

--
-- Структура таблицы `categories_materials`
--

CREATE TABLE `categories_materials` (
  `categories_id` int(11) NOT NULL,
  `material_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `categories_materials`
--

INSERT INTO `categories_materials` (`categories_id`, `material_id`, `name`) VALUES
(1, 1, 'Ґрунт'),
(1, 2, 'Ґрунт'),
(1, 3, 'Ґрунт'),
(1, 4, 'Ґрунт'),
(1, 5, 'Ґрунт'),
(1, 6, 'Ґрунт'),
(1, 7, 'Ґрунт'),
(1, 8, 'Ґрунт'),
(1, 9, 'Ґрунт');

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `contact_info` varchar(255) DEFAULT NULL,
  `idKontrAg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`id`, `name`, `contact_info`, `idKontrAg`) VALUES
(1, 'Акімова Олена Михайлівна', '050 203 71 32', 3),
(2, 'Кулешов Олег Вікторович', '050 935 99 98', 3),
(3, 'Гончаров Павло Максимович', '050 110 71 52', 3),
(4, 'Васильев Георгій Іванович', '066 935 13 98', 3),
(5, 'Покупець', '', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `fillials`
--

CREATE TABLE `fillials` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `idKontrAg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `fillials`
--

INSERT INTO `fillials` (`id`, `name`, `idKontrAg`) VALUES
(1, 'МЕГА Строй', 2),
(2, 'Каштан', 2),
(3, 'ЕвроДекор', 2),
(4, 'Металлобаза', 2),
(5, 'Авен Буд', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `kontragents`
--

CREATE TABLE `kontragents` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `kontragents`
--

INSERT INTO `kontragents` (`id`, `name`) VALUES
(1, 'Постачальники'),
(2, 'Філліали'),
(3, 'Покупці');

-- --------------------------------------------------------

--
-- Структура таблицы `materials`
--

CREATE TABLE `materials` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `price_zakup` decimal(10,2) NOT NULL,
  `%_zakup` decimal(5,1) NOT NULL,
  `price_opt` decimal(10,2) NOT NULL,
  `%_opt` decimal(5,1) NOT NULL,
  `price_prod` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `materials`
--

INSERT INTO `materials` (`id`, `name`, `supplier_id`, `price_zakup`, `%_zakup`, `price_opt`, `%_opt`, `price_prod`, `quantity`) VALUES
(1, 'Базисґрунт 5кг', 3, '92.85', '9.9', '102.00', '20.6', '112.00', 5),
(2, 'Базисґрунт 10кг', 3, '163.55', '10.1', '180.00', '21.1', '198.00', 4),
(3, 'Ґрунт Бетоконтакт 5кг', 3, '270.00', '0.0', '0.00', '3.7', '280.00', 1),
(4, 'Ґрунт Бетоконтакт 20кг', 3, '924.50', '9.8', '1015.00', '21.1', '1120.00', 0),
(5, 'Ґрунт Тифенґрунт 5кг', 3, '169.00', '9.5', '185.00', '10.7', '187.00', 163),
(6, 'Ґрунт Тифенґрунт 10кг', 3, '312.00', '9.9', '343.00', '20.2', '375.00', 106),
(7, 'Ґрунт Хафґрунт 5кг', 3, '149.50', '10.0', '164.50', '15.1', '172.00', 1),
(8, 'Ґрунт Тифенґрунт 10кг', 3, '312.00', '9.9', '343.00', '20.2', '375.00', 106),
(9, 'Ґрунт Хафґрунт 10кг', 3, '282.70', '10.0', '311.00', '19.9', '339.00', 33);

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `order_number` int(11) NOT NULL,
  `client_id` int(11) DEFAULT NULL,
  `order_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `payment_method_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`id`, `order_number`, `client_id`, `order_date`, `payment_method_id`) VALUES
(1, 11, 5, '2025-03-25 09:46:55', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `order_materials`
--

CREATE TABLE `order_materials` (
  `order_id` int(11) NOT NULL,
  `material_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `order_materials`
--

INSERT INTO `order_materials` (`order_id`, `material_id`, `quantity`) VALUES
(1, 1, 2);

--
-- Триггеры `order_materials`
--
DELIMITER $$
CREATE TRIGGER `AfterOrderMaterialInsert` AFTER INSERT ON `order_materials` FOR EACH ROW BEGIN
    DECLARE current_quantity INT;

    SELECT quantity INTO current_quantity
    FROM materials
    WHERE id = NEW.material_id;

    IF current_quantity >= NEW.quantity THEN
        UPDATE materials
        SET quantity = quantity - NEW.quantity
        WHERE id = NEW.material_id;
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Недостатньо товару на складі для цього замовлення';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `AfterOrderMaterialUpdate` AFTER UPDATE ON `order_materials` FOR EACH ROW BEGIN
    DECLARE current_quantity INT;

    SELECT quantity INTO current_quantity
    FROM materials
    WHERE id = NEW.material_id;

    IF current_quantity >= NEW.quantity THEN
        UPDATE materials
        SET quantity = quantity - NEW.quantity
        WHERE id = NEW.material_id;
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Недостатньо товару на складі для цього замовлення';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `paymentmethods`
--

CREATE TABLE `paymentmethods` (
  `id` int(11) NOT NULL,
  `method` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `paymentmethods`
--

INSERT INTO `paymentmethods` (`id`, `method`) VALUES
(1, 'Готівка'),
(3, 'Переказ на карту'),
(2, 'Термінал');

-- --------------------------------------------------------

--
-- Структура таблицы `suppliers`
--

CREATE TABLE `suppliers` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `contact_info` varchar(255) DEFAULT NULL,
  `idKontrAg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `suppliers`
--

INSERT INTO `suppliers` (`id`, `name`, `contact_info`, `idKontrAg`) VALUES
(1, 'Альфа-Профіль', NULL, 1),
(2, 'Амадео', NULL, 1),
(3, 'КНАУФ', '099 04 10 159', 1),
(4, 'Сен-Гобен', '050 106 34 39', 1),
(5, 'Полісан', NULL, 1),
(6, 'Робфіл', NULL, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `temp_categories`
--

CREATE TABLE `temp_categories` (
  `id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `temp_categories`
--

INSERT INTO `temp_categories` (`id`, `name`) VALUES
(1, 'КНАУФ'),
(2, 'Церезит'),
(3, 'Зенит'),
(4, 'Утеплювачі'),
(5, 'Полімін'),
(6, 'Клей'),
(7, 'Полісан'),
(8, 'Двері'),
(9, 'Газобетон'),
(10, 'Шпаклівка'),
(11, 'Фарби'),
(12, 'Гіпсокартон');

-- --------------------------------------------------------

--
-- Структура таблицы `warehouse_transactions`
--

CREATE TABLE `warehouse_transactions` (
  `id` int(11) NOT NULL,
  `material_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `transaction_type` enum('incoming','outgoing') NOT NULL,
  `transaction_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `warehouse_transactions`
--

INSERT INTO `warehouse_transactions` (`id`, `material_id`, `quantity`, `transaction_type`, `transaction_date`) VALUES
(2, 1, 1, 'incoming', '2025-03-25 10:09:19'),
(3, 5, 2, 'outgoing', '2025-03-25 10:10:01');

--
-- Триггеры `warehouse_transactions`
--
DELIMITER $$
CREATE TRIGGER `AfterWarehouseTransactionInsert` AFTER INSERT ON `warehouse_transactions` FOR EACH ROW BEGIN
    IF NEW.transaction_type = 'incoming' THEN
        UPDATE materials
        SET quantity = quantity + NEW.quantity
        WHERE id = NEW.material_id;
    ELSEIF NEW.transaction_type = 'outgoing' THEN
        UPDATE materials
        SET quantity = quantity - NEW.quantity
        WHERE id = NEW.material_id;
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `AfterWarehouseTransactionUpdate` AFTER UPDATE ON `warehouse_transactions` FOR EACH ROW BEGIN
    IF NEW.transaction_type = 'incoming' THEN
        UPDATE materials
        SET quantity = quantity + NEW.quantity
        WHERE id = NEW.material_id;
    ELSEIF NEW.transaction_type = 'outgoing' THEN
        UPDATE materials
        SET quantity = quantity - NEW.quantity
        WHERE id = NEW.material_id;
    END IF;
END
$$
DELIMITER ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `categories_materials`
--
ALTER TABLE `categories_materials`
  ADD PRIMARY KEY (`categories_id`,`material_id`),
  ADD KEY `material_id` (`material_id`);

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idKontrAg` (`idKontrAg`);

--
-- Индексы таблицы `fillials`
--
ALTER TABLE `fillials`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `idKontrAg` (`idKontrAg`);

--
-- Индексы таблицы `kontragents`
--
ALTER TABLE `kontragents`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id` (`id`);

--
-- Индексы таблицы `materials`
--
ALTER TABLE `materials`
  ADD PRIMARY KEY (`id`),
  ADD KEY `supplier_id` (`supplier_id`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `order_number` (`order_number`),
  ADD KEY `client_id` (`client_id`),
  ADD KEY `payment_method_id` (`payment_method_id`);

--
-- Индексы таблицы `order_materials`
--
ALTER TABLE `order_materials`
  ADD PRIMARY KEY (`order_id`,`material_id`),
  ADD KEY `material_id` (`material_id`);

--
-- Индексы таблицы `paymentmethods`
--
ALTER TABLE `paymentmethods`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `method` (`method`);

--
-- Индексы таблицы `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`),
  ADD KEY `idKontrAg` (`idKontrAg`);

--
-- Индексы таблицы `warehouse_transactions`
--
ALTER TABLE `warehouse_transactions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `material_id` (`material_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `materials`
--
ALTER TABLE `materials`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `paymentmethods`
--
ALTER TABLE `paymentmethods`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `warehouse_transactions`
--
ALTER TABLE `warehouse_transactions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `categories_materials`
--
ALTER TABLE `categories_materials`
  ADD CONSTRAINT `categories_materials_ibfk_1` FOREIGN KEY (`categories_id`) REFERENCES `categories` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `categories_materials_ibfk_2` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `clients`
--
ALTER TABLE `clients`
  ADD CONSTRAINT `clients_ibfk_1` FOREIGN KEY (`idKontrAg`) REFERENCES `kontragents` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `fillials`
--
ALTER TABLE `fillials`
  ADD CONSTRAINT `fillials_ibfk_1` FOREIGN KEY (`idKontrAg`) REFERENCES `kontragents` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE SET NULL,
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`payment_method_id`) REFERENCES `paymentmethods` (`id`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `order_materials`
--
ALTER TABLE `order_materials`
  ADD CONSTRAINT `order_materials_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `order_materials_ibfk_2` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `suppliers`
--
ALTER TABLE `suppliers`
  ADD CONSTRAINT `suppliers_ibfk_1` FOREIGN KEY (`idKontrAg`) REFERENCES `kontragents` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `warehouse_transactions`
--
ALTER TABLE `warehouse_transactions`
  ADD CONSTRAINT `warehouse_transactions_ibfk_1` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
