
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/28/2020 22:04:01
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

IF OBJECT_ID(N'[dbo].[FK_HiringManagerJobPosting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobPostings] DROP CONSTRAINT [FK_HiringManagerJobPosting];
GO
IF OBJECT_ID(N'[dbo].[FK_ApplicationJobPosting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_ApplicationJobPosting];
GO
IF OBJECT_ID(N'[dbo].[FK_ApplicationProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_ApplicationProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PathSystemQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemQuestions] DROP CONSTRAINT [FK_PathSystemQuestions];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfileSystemQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemQuestions] DROP CONSTRAINT [FK_ProfileSystemQuestions];
GO
IF OBJECT_ID(N'[dbo].[FK_ApplicantProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_Applicant] DROP CONSTRAINT [FK_ApplicantProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PathAdminPath]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Paths] DROP CONSTRAINT [FK_PathAdminPath];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgePath_Badge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BadgePath] DROP CONSTRAINT [FK_BadgePath_Badge];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgePath_Path]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BadgePath] DROP CONSTRAINT [FK_BadgePath_Path];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgeSystemQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemQuestions] DROP CONSTRAINT [FK_BadgeSystemQuestions];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgeSkills]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Skills] DROP CONSTRAINT [FK_BadgeSkills];
GO
IF OBJECT_ID(N'[dbo].[FK_HiringManager_inherits_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_HiringManager] DROP CONSTRAINT [FK_HiringManager_inherits_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_Applicant_inherits_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_Applicant] DROP CONSTRAINT [FK_Applicant_inherits_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_PathAdmin_inherits_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_PathAdmin] DROP CONSTRAINT [FK_PathAdmin_inherits_Account];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[JobPostings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobPostings];
GO
IF OBJECT_ID(N'[dbo].[Applications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Applications];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO
IF OBJECT_ID(N'[dbo].[Badges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Badges];
GO
IF OBJECT_ID(N'[dbo].[Paths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paths];
GO
IF OBJECT_ID(N'[dbo].[SystemQuestions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemQuestions];
GO
IF OBJECT_ID(N'[dbo].[Skills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skills];
GO
IF OBJECT_ID(N'[dbo].[Accounts_HiringManager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts_HiringManager];
GO
IF OBJECT_ID(N'[dbo].[Accounts_Applicant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts_Applicant];
GO
IF OBJECT_ID(N'[dbo].[Accounts_PathAdmin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts_PathAdmin];
GO
IF OBJECT_ID(N'[dbo].[BadgePath]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BadgePath];
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

-- Creating table 'JobPostings'
CREATE TABLE [dbo].[JobPostings] (
    [jobId] int IDENTITY(1,1) NOT NULL,
    [Property1] nvarchar(max)  NOT NULL,
    [jobTitle] nvarchar(max)  NOT NULL,
    [jobDescription] nvarchar(max)  NOT NULL,
    [jobSalary] nvarchar(max)  NOT NULL,
    [numOfPositions] nvarchar(max)  NOT NULL,
    [HiringManager_userID] int  NOT NULL
);
GO

-- Creating table 'Applications'
CREATE TABLE [dbo].[Applications] (
    [appId] int IDENTITY(1,1) NOT NULL,
    [profileId] nvarchar(max)  NOT NULL,
    [status] nvarchar(max)  NOT NULL,
    [JobPosting_jobId] int  NOT NULL,
    [Profile_profileId] int  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [profileId] int IDENTITY(1,1) NOT NULL,
    [careerPath] nvarchar(max)  NOT NULL,
    [careerPathCompletion] nvarchar(max)  NOT NULL
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

-- Creating table 'Accounts_HiringManager'
CREATE TABLE [dbo].[Accounts_HiringManager] (
    [HiringManagerId] int IDENTITY(1,1) NOT NULL,
    [companyName] nvarchar(max)  NOT NULL,
    [position] nvarchar(max)  NOT NULL,
    [userID] int  NOT NULL
);
GO

-- Creating table 'Accounts_Applicant'
CREATE TABLE [dbo].[Accounts_Applicant] (
    [ApplicantId] int IDENTITY(1,1) NOT NULL,
    [TrailHeadUrl] nvarchar(max)  NOT NULL,
    [userID] int  NOT NULL,
    [Profile_profileId] int  NOT NULL
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [userID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- Creating primary key on [jobId] in table 'JobPostings'
ALTER TABLE [dbo].[JobPostings]
ADD CONSTRAINT [PK_JobPostings]
    PRIMARY KEY CLUSTERED ([jobId] ASC);
GO

-- Creating primary key on [appId] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [PK_Applications]
    PRIMARY KEY CLUSTERED ([appId] ASC);
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

-- Creating primary key on [userID] in table 'Accounts_HiringManager'
ALTER TABLE [dbo].[Accounts_HiringManager]
ADD CONSTRAINT [PK_Accounts_HiringManager]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- Creating primary key on [userID] in table 'Accounts_Applicant'
ALTER TABLE [dbo].[Accounts_Applicant]
ADD CONSTRAINT [PK_Accounts_Applicant]
    PRIMARY KEY CLUSTERED ([userID] ASC);
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HiringManager_userID] in table 'JobPostings'
ALTER TABLE [dbo].[JobPostings]
ADD CONSTRAINT [FK_HiringManagerJobPosting]
    FOREIGN KEY ([HiringManager_userID])
    REFERENCES [dbo].[Accounts_HiringManager]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HiringManagerJobPosting'
CREATE INDEX [IX_FK_HiringManagerJobPosting]
ON [dbo].[JobPostings]
    ([HiringManager_userID]);
GO

-- Creating foreign key on [JobPosting_jobId] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_ApplicationJobPosting]
    FOREIGN KEY ([JobPosting_jobId])
    REFERENCES [dbo].[JobPostings]
        ([jobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicationJobPosting'
CREATE INDEX [IX_FK_ApplicationJobPosting]
ON [dbo].[Applications]
    ([JobPosting_jobId]);
GO

-- Creating foreign key on [Profile_profileId] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_ApplicationProfile]
    FOREIGN KEY ([Profile_profileId])
    REFERENCES [dbo].[Profiles]
        ([profileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicationProfile'
CREATE INDEX [IX_FK_ApplicationProfile]
ON [dbo].[Applications]
    ([Profile_profileId]);
GO

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

-- Creating foreign key on [Profile_profileId] in table 'Accounts_Applicant'
ALTER TABLE [dbo].[Accounts_Applicant]
ADD CONSTRAINT [FK_ApplicantProfile]
    FOREIGN KEY ([Profile_profileId])
    REFERENCES [dbo].[Profiles]
        ([profileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicantProfile'
CREATE INDEX [IX_FK_ApplicantProfile]
ON [dbo].[Accounts_Applicant]
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

-- Creating foreign key on [userID] in table 'Accounts_HiringManager'
ALTER TABLE [dbo].[Accounts_HiringManager]
ADD CONSTRAINT [FK_HiringManager_inherits_Account]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Accounts]
        ([userID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [userID] in table 'Accounts_Applicant'
ALTER TABLE [dbo].[Accounts_Applicant]
ADD CONSTRAINT [FK_Applicant_inherits_Account]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Accounts]
        ([userID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
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