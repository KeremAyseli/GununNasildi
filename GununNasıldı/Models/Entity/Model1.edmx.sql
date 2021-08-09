
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2021 20:30:23
-- Generated from EDMX file: D:\Visual\GununNasıldı\GununNasıldı\Models\Entity\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gununnasildi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[kisiler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[kisiler];
GO
IF OBJECT_ID(N'[dbo].[yazilar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[yazilar];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'kisiler'
CREATE TABLE [dbo].[kisiler] (
    [kisiId] int IDENTITY(1,1) NOT NULL,
    [kisiIsim] nvarchar(55)  NOT NULL,
    [kisiSoyisim] nvarchar(55)  NULL,
    [kisiEposta] varchar(max)  NULL,
    [YaziId] int  NULL,
    [kisiResimAdres] varchar(max)  NULL,
    [sifre] nvarchar(20)  NULL
);
GO

-- Creating table 'yazilar'
CREATE TABLE [dbo].[yazilar] (
    [yaziId] varchar(20)  NOT NULL,
    [yaziIcerikAdres] varchar(max)  NOT NULL,
    [kisiId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [kisiId] in table 'kisiler'
ALTER TABLE [dbo].[kisiler]
ADD CONSTRAINT [PK_kisiler]
    PRIMARY KEY CLUSTERED ([kisiId] ASC);
GO

-- Creating primary key on [yaziId] in table 'yazilar'
ALTER TABLE [dbo].[yazilar]
ADD CONSTRAINT [PK_yazilar]
    PRIMARY KEY CLUSTERED ([yaziId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------