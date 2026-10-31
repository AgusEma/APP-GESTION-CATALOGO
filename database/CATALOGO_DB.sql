-- Script de creación de la base de datos CATALOGO_DB
-- Ejecutar en SQL Server Management Studio

CREATE DATABASE CATALOGO_DB;
GO

USE CATALOGO_DB;
GO

CREATE TABLE MARCAS (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

CREATE TABLE CATEGORIAS (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

CREATE TABLE ARTICULOS (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Codigo      VARCHAR(50)    NULL,
    Nombre      VARCHAR(50)    NULL,
    Descripcion VARCHAR(150)   NULL,
    IdMarca     INT            NOT NULL REFERENCES MARCAS(Id),
    IdCategoria INT            NOT NULL REFERENCES CATEGORIAS(Id),
    ImagenUrl   VARCHAR(1000)  NULL,
    Precio      DECIMAL(18, 2) NULL
);
GO

-- Datos de ejemplo
INSERT INTO MARCAS (Descripcion) VALUES ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola');
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Celulares'), ('Televisores'), ('Media'), ('Audio');

INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES
('S01', 'Galaxy S10',    'Celular 128 GB',              1, 1, '', 69999),
('M03', 'Moto G Play 7', 'Celular 32 GB',               5, 1, '', 15699),
('S99', 'PlayStation 4', 'Consola de videojuegos',      3, 3, '', 35000),
('S56', 'Bravia 55',     'Televisor 4K de 55 pulgadas',3, 2, '', 49500),
('A23', 'Apple TV',      'Para ver series',            2, 3, '', 7850);
GO
