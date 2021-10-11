# ProjetoDesenvolvimento

 Banco de dados
 
USE [master]
GO
CREATE DATABASE ProjetoDevOxxy


USE ProjetoDevOxxy
GO
CREATE TABLE dbo.Produtos(
	Id int IDENTITY(1,1) NOT NULL,
	Placa nvarchar(8) NOT NULL,
	Renavan nvarchar(11) NOT NULL,
	Nome nvarchar(150) NOT NULL,
	Cpf nvarchar(11) NOT NULL,
	Imagem nvarchar(500) NULL,
CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
