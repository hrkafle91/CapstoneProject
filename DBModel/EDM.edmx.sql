
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/16/2020 16:06:24
-- Generated from EDMX file: C:\Users\Elizabeth\source\repos\CapstoneProject\DBModel\EDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CapstoneModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT [FK_AccountProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgePath_Badge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BadgePath] DROP CONSTRAINT [FK_BadgePath_Badge];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgePath_Path]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BadgePath] DROP CONSTRAINT [FK_BadgePath_Path];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgeSkills]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Skills] DROP CONSTRAINT [FK_BadgeSkills];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgeSystemQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemQuestions] DROP CONSTRAINT [FK_BadgeSystemQuestions];
GO
IF OBJECT_ID(N'[dbo].[FK_PathAdmin_inherits_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_PathAdmin] DROP CONSTRAINT [FK_PathAdmin_inherits_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_PathAdminPath]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Paths] DROP CONSTRAINT [FK_PathAdminPath];
GO
IF OBJECT_ID(N'[dbo].[FK_PathSkill_Path]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PathSkill] DROP CONSTRAINT [FK_PathSkill_Path];
GO
IF OBJECT_ID(N'[dbo].[FK_PathSkill_Skill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PathSkill] DROP CONSTRAINT [FK_PathSkill_Skill];
GO
IF OBJECT_ID(N'[dbo].[FK_PathSystemQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemQuestions] DROP CONSTRAINT [FK_PathSystemQuestions];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfileSystemQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemQuestions] DROP CONSTRAINT [FK_ProfileSystemQuestions];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Accounts_PathAdmin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts_PathAdmin];
GO
IF OBJECT_ID(N'[dbo].[BadgePath]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BadgePath];
GO
IF OBJECT_ID(N'[dbo].[Badges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Badges];
GO
IF OBJECT_ID(N'[dbo].[Paths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paths];
GO
IF OBJECT_ID(N'[dbo].[PathSkill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PathSkill];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO
IF OBJECT_ID(N'[dbo].[Skills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skills];
GO
IF OBJECT_ID(N'[dbo].[SystemQuestions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemQuestions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [userID] int IDENTITY(1,1) NOT NULL,
    [userName] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [firstName] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL,
    [emailID] nvarchar(max)  NOT NULL,
    [userType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [profileId] int IDENTITY(1,1) NOT NULL,
    [careerPath] nvarchar(max)  NULL,
    [careerPathCompletion] nvarchar(max)  NULL,
    [trailHeadUrl] nvarchar(max)  NULL,
    [Account_userID] int  NOT NULL
);
GO

-- Creating table 'Badges'
CREATE TABLE [dbo].[Badges] (
    [badgeId] int IDENTITY(1,1) NOT NULL,
    [badgeTitle] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Paths'
CREATE TABLE [dbo].[Paths] (
    [pathId] int IDENTITY(1,1) NOT NULL,
    [pathType] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [PathAdmin_userID] int  NOT NULL
);
GO

-- Creating table 'SystemQuestions'
CREATE TABLE [dbo].[SystemQuestions] (
    [skill] nvarchar(max)  NOT NULL,
    [userLevel] nvarchar(max)  NOT NULL,
    [Path_pathId] int  NOT NULL,
    [Profile_profileId] int  NOT NULL,
    [Badge_badgeId] int  NOT NULL,
    [skill_id] int  NOT NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [skillId] int IDENTITY(1,1) NOT NULL,
    [skillName] nvarchar(max)  NOT NULL,
    [Badge_badgeId] int  NOT NULL
);
GO

-- Creating table 'Accounts_PathAdmin'
CREATE TABLE [dbo].[Accounts_PathAdmin] (
    [pathAdminId] int IDENTITY(1,1) NOT NULL,
    [pathType] nvarchar(max)  NOT NULL,
    [userID] int  NOT NULL
);
GO

-- Creating table 'BadgePath'
CREATE TABLE [dbo].[BadgePath] (
    [Badges_badgeId] int  NOT NULL,
    [Paths_pathId] int  NOT NULL
);
GO

-- Creating table 'PathSkill'
CREATE TABLE [dbo].[PathSkill] (
    [Paths_pathId] int  NOT NULL,
    [Skills_skillId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [userID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- Creating primary key on [profileId] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([profileId] ASC);
GO

-- Creating primary key on [badgeId] in table 'Badges'
ALTER TABLE [dbo].[Badges]
ADD CONSTRAINT [PK_Badges]
    PRIMARY KEY CLUSTERED ([badgeId] ASC);
GO

-- Creating primary key on [pathId] in table 'Paths'
ALTER TABLE [dbo].[Paths]
ADD CONSTRAINT [PK_Paths]
    PRIMARY KEY CLUSTERED ([pathId] ASC);
GO

-- Creating primary key on [skill_id] in table 'SystemQuestions'
ALTER TABLE [dbo].[SystemQuestions]
ADD CONSTRAINT [PK_SystemQuestions]
    PRIMARY KEY CLUSTERED ([skill_id] ASC);
GO

-- Creating primary key on [skillId] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [PK_Skills]
    PRIMARY KEY CLUSTERED ([skillId] ASC);
GO

-- Creating primary key on [userID] in table 'Accounts_PathAdmin'
ALTER TABLE [dbo].[Accounts_PathAdmin]
ADD CONSTRAINT [PK_Accounts_PathAdmin]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- Creating primary key on [Badges_badgeId], [Paths_pathId] in table 'BadgePath'
ALTER TABLE [dbo].[BadgePath]
ADD CONSTRAINT [PK_BadgePath]
    PRIMARY KEY CLUSTERED ([Badges_badgeId], [Paths_pathId] ASC);
GO

-- Creating primary key on [Paths_pathId], [Skills_skillId] in table 'PathSkill'
ALTER TABLE [dbo].[PathSkill]
ADD CONSTRAINT [PK_PathSkill]
    PRIMARY KEY CLUSTERED ([Paths_pathId], [Skills_skillId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Path_pathId] in table 'SystemQuestions'
ALTER TABLE [dbo].[SystemQuestions]
ADD CONSTRAINT [FK_PathSystemQuestions]
    FOREIGN KEY ([Path_pathId])
    REFERENCES [dbo].[Paths]
        ([pathId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PathSystemQuestions'
CREATE INDEX [IX_FK_PathSystemQuestions]
ON [dbo].[SystemQuestions]
    ([Path_pathId]);
GO

-- Creating foreign key on [Profile_profileId] in table 'SystemQuestions'
ALTER TABLE [dbo].[SystemQuestions]
ADD CONSTRAINT [FK_ProfileSystemQuestions]
    FOREIGN KEY ([Profile_profileId])
    REFERENCES [dbo].[Profiles]
        ([profileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfileSystemQuestions'
CREATE INDEX [IX_FK_ProfileSystemQuestions]
ON [dbo].[SystemQuestions]
    ([Profile_profileId]);
GO

-- Creating foreign key on [PathAdmin_userID] in table 'Paths'
ALTER TABLE [dbo].[Paths]
ADD CONSTRAINT [FK_PathAdminPath]
    FOREIGN KEY ([PathAdmin_userID])
    REFERENCES [dbo].[Accounts_PathAdmin]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PathAdminPath'
CREATE INDEX [IX_FK_PathAdminPath]
ON [dbo].[Paths]
    ([PathAdmin_userID]);
GO

-- Creating foreign key on [Badges_badgeId] in table 'BadgePath'
ALTER TABLE [dbo].[BadgePath]
ADD CONSTRAINT [FK_BadgePath_Badge]
    FOREIGN KEY ([Badges_badgeId])
    REFERENCES [dbo].[Badges]
        ([badgeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Paths_pathId] in table 'BadgePath'
ALTER TABLE [dbo].[BadgePath]
ADD CONSTRAINT [FK_BadgePath_Path]
    FOREIGN KEY ([Paths_pathId])
    REFERENCES [dbo].[Paths]
        ([pathId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BadgePath_Path'
CREATE INDEX [IX_FK_BadgePath_Path]
ON [dbo].[BadgePath]
    ([Paths_pathId]);
GO

-- Creating foreign key on [Badge_badgeId] in table 'SystemQuestions'
ALTER TABLE [dbo].[SystemQuestions]
ADD CONSTRAINT [FK_BadgeSystemQuestions]
    FOREIGN KEY ([Badge_badgeId])
    REFERENCES [dbo].[Badges]
        ([badgeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BadgeSystemQuestions'
CREATE INDEX [IX_FK_BadgeSystemQuestions]
ON [dbo].[SystemQuestions]
    ([Badge_badgeId]);
GO

-- Creating foreign key on [Badge_badgeId] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [FK_BadgeSkills]
    FOREIGN KEY ([Badge_badgeId])
    REFERENCES [dbo].[Badges]
        ([badgeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BadgeSkills'
CREATE INDEX [IX_FK_BadgeSkills]
ON [dbo].[Skills]
    ([Badge_badgeId]);
GO

-- Creating foreign key on [Paths_pathId] in table 'PathSkill'
ALTER TABLE [dbo].[PathSkill]
ADD CONSTRAINT [FK_PathSkill_Path]
    FOREIGN KEY ([Paths_pathId])
    REFERENCES [dbo].[Paths]
        ([pathId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Skills_skillId] in table 'PathSkill'
ALTER TABLE [dbo].[PathSkill]
ADD CONSTRAINT [FK_PathSkill_Skill]
    FOREIGN KEY ([Skills_skillId])
    REFERENCES [dbo].[Skills]
        ([skillId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PathSkill_Skill'
CREATE INDEX [IX_FK_PathSkill_Skill]
ON [dbo].[PathSkill]
    ([Skills_skillId]);
GO

-- Creating foreign key on [Account_userID] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_AccountProfile]
    FOREIGN KEY ([Account_userID])
    REFERENCES [dbo].[Accounts]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountProfile'
CREATE INDEX [IX_FK_AccountProfile]
ON [dbo].[Profiles]
    ([Account_userID]);
GO

-- Creating foreign key on [userID] in table 'Accounts_PathAdmin'
ALTER TABLE [dbo].[Accounts_PathAdmin]
ADD CONSTRAINT [FK_PathAdmin_inherits_Account]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Accounts]
        ([userID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------