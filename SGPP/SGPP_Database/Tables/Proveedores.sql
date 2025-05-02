CREATE TABLE [dbo].[Proveedores]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL UNIQUE, 
    [Direccion] VARCHAR(MAX) NOT NULL, 
    [Telefono] VARCHAR(50) NOT NULL
)
