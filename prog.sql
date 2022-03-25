-- MySQL Script generated by MySQL Workbench
-- Thu Mar 24 23:26:27 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema segundoexamen
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema segundoexamen
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `segundoexamen` DEFAULT CHARACTER SET utf8 ;
USE `segundoexamen` ;

-- -----------------------------------------------------
-- Table `segundoexamen`.`pedidos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `segundoexamen`.`pedidos` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IdentidadCliente` VARCHAR(20) NULL DEFAULT NULL,
  `Cliente` VARCHAR(45) NULL DEFAULT NULL,
  `Fecha` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `segundoexamen`.`producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `segundoexamen`.`producto` (
  `Codigo` VARCHAR(45) NOT NULL,
  `Descripcion` VARCHAR(45) NULL DEFAULT NULL,
  `Precio` DECIMAL NULL DEFAULT NULL,
  `Existencia` INT NULL DEFAULT NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `segundoexamen`.`detallepedidos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `segundoexamen`.`detallepedidos` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IdPedidos` INT NULL DEFAULT NULL,
  `CodigoProducto` VARCHAR(45) NULL DEFAULT NULL,
  `Descripcion` VARCHAR(45) NULL DEFAULT NULL,
  `Cantidad` INT NULL DEFAULT NULL,
  `Precio` DECIMAL NULL DEFAULT NULL,
  `Total` DECIMAL NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_detalleproducto_pedidos_idx` (`IdPedidos` ASC) VISIBLE,
  INDEX `FK_detalleproducto_producto_idx` (`CodigoProducto` ASC) VISIBLE,
  CONSTRAINT `FK_detalleproducto_pedidos`
    FOREIGN KEY (`IdPedidos`)
    REFERENCES `segundoexamen`.`pedidos` (`Id`),
  CONSTRAINT `FK_detalleproducto_producto`
    FOREIGN KEY (`CodigoProducto`)
    REFERENCES `segundoexamen`.`producto` (`Codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `segundoexamen`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `segundoexamen`.`usuario` (
  `Codigo` VARCHAR(15) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Clave` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;