
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2018 07:58:32
-- Generated from EDMX file: C:\Users\Pichau\source\repos\Teste\Teste\Models\TesteBanco.edmx
-- --------------------------------------------------

Create database [CONECTT_TESTE_INATAN]

SET QUOTED_IDENTIFIER OFF;
GO
USE [CONECTT_TESTE_INATAN];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pessoa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pessoa];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pessoa'
CREATE TABLE [dbo].[Pessoa] (
    [ID] int  NOT NULL IDENTITY,
    [Nome] varchar(50)  NOT NULL,
    [CPF] varchar(15)  NOT NULL,
    [Nascimento] datetime  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Empresa] varchar(50)  NULL,
    [TelefoneComercial] varchar(20)  NULL,
    [TelefoneCelular] varchar(20)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Pessoa'
ALTER TABLE [dbo].[Pessoa]
ADD CONSTRAINT [PK_Pessoa]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------