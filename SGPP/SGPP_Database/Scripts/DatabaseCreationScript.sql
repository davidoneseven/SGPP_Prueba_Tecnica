-- Creación y asignación de la base
CREATE DATABASE SGPP_Database;
GO

USE SGPP_Database;
GO

-- Definición de tablas
CREATE TABLE Proveedores
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(50) NOT NULL, 
    Email VARCHAR(50) NOT NULL UNIQUE, 
    Direccion VARCHAR(MAX) NOT NULL, 
    Telefono VARCHAR(50) NOT NULL
)

CREATE TABLE Productos
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Descripcion VARCHAR(MAX) NOT NULL, 
    UnidadDeMedida VARCHAR(20) NOT NULL, 
    PrecioUnitario INT NOT NULL
)

CREATE TABLE ProveedorTieneProducto
(
	IdProveedor INT NOT NULL FOREIGN KEY REFERENCES Proveedores(Id),
	IdProducto INT NOT NULL FOREIGN KEY REFERENCES Productos(Id),
	PRIMARY KEY (IdProveedor,IdProducto)
)

GO

-- Post-despliegue, populación de datos
INSERT INTO Proveedores (Nombre, Email, Direccion, Telefono) VALUES 
('EPA','negocios@epa.co.cr','San José, Tibás. 300 metros oeste del cruce de Llorente.','22920909'),
('Mugui','recepcion@mugui.co.cr','San José, Goicoechea. 200m este del Walmart de Guadalupe.	','25843560'),
('IKEA','business@ikea.com','Delft, Países Bajos. Olof Palmestraat 1, 2616 LN.','22604240');

INSERT INTO Productos (Descripcion, UnidadDeMedida, PrecioUnitario) VALUES 
('Tarima de pino','m2',21900),
('Escritorio de melamina','unidad',42750),
('Silla ejecutiva con respaldo','unidad',55900),
('Sofá de 3 plazas','unidad',374400),
('Varilla deformada','in',2795);

INSERT INTO ProveedorTieneProducto (IdProveedor, IdProducto) VALUES 
(1,3),
(2,3);

GO
