CREATE TABLE [dbo].[Productos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descripcion] VARCHAR(MAX) NOT NULL, 
    [UnidadDeMedida] VARCHAR(20) NOT NULL, 
    [PrecioUnitario] INT NOT NULL
)
