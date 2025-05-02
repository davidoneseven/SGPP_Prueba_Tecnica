CREATE TABLE [dbo].[ProveedorTieneProducto]
(
	[IdProveedor] INT NOT NULL FOREIGN KEY REFERENCES Proveedores([Id]),
	[IdProducto] INT NOT NULL FOREIGN KEY REFERENCES Productos([Id]),
	PRIMARY KEY ([IdProveedor],[IdProducto])
)
