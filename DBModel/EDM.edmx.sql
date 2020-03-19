
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2020 10:12:14
-- Generated from EDMX file: E:\Capstone\CapstoneRepo\CapstoneProject\DBModel\EDM.edmx
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
IF OBJECT_ID(N'[dbo].[FK_PathCourse_Path]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PathCourse] DROP CONSTRAINT [FK_PathCourse_Path];
GO
IF OBJECT_ID(N'[dbo].[FK_PathCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PathCourse] DROP CONSTRAINT [FK_PathCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseSkillBadge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_CourseSkillBadge];
GO
IF OBJECT_ID(N'[dbo].[FK_SkillBadgeProfile_SkillBadge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkillBadgeProfile] DROP CONSTRAINT [FK_SkillBadgeProfile_SkillBadge];
GO
IF OBJECT_ID(N'[dbo].[FK_SkillBadgeProfile_Profile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkillBadgeProfile] DROP CONSTRAINT [FK_SkillBadgeProfile_Profile];
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
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Paths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paths];
GO
IF OBJECT_ID(N'[dbo].[SkillBadges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkillBadges];
GO
IF OBJECT_ID(N'[dbo].[SystemQuestions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemQuestions];
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
IF OBJECT_ID(N'[dbo].[PathCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PathCourse];
GO
IF OBJECT_ID(N'[dbo].[SkillBadgeProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkillBadgeProfile];
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
    [experience] nvarchar(max)  NOT NULL,
    [careerPath] nvarchar(max)  NOT NULL,
    [skillBadges] nvarchar(max)  NOT NULL,
    [careerPathCompletion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [courseId] int IDENTITY(1,1) NOT NULL,
    [courseCode] nvarchar(max)  NOT NULL,
    [courseTitle] nvarchar(max)  NOT NULL,
    [learningHours] int  NOT NULL,
    [SkillBadge_skillBadgeId] int  NOT NULL
);
GO

-- Creating table 'Paths'
CREATE TABLE [dbo].[Paths] (
    [pathId] int IDENTITY(1,1) NOT NULL,
    [pathType] nvarchar(max)  NOT NULL,
    [courses] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [PathAdmin_userID] int  NOT NULL
);
GO

-- Creating table 'SkillBadges'
CREATE TABLE [dbo].[SkillBadges] (
    [skillBadgeId] int IDENTITY(1,1) NOT NULL,
    [skillCode] nvarchar(max)  NOT NULL,
    [skillName] nvarchar(max)  NOT NULL,
    [skillDescription] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SystemQuestions'
CREATE TABLE [dbo].[SystemQuestions] (
    [questions] nvarchar(max)  NOT NULL,
    [answers] nvarchar(max)  NOT NULL,
    [score] int  NOT NULL,
    [Path_pathId] int  NOT NULL,
    [Profile_profileId] int  NOT NULL,
    [questionSetId] int  NOT NULL
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

-- Creating table 'PathCourse'
CREATE TABLE [dbo].[PathCourse] (
    [Paths_pathId] int  NOT NULL,
    [Courses_courseId] int  NOT NULL
);
GO

-- Creating table 'SkillBadgeProfile'
CREATE TABLE [dbo].[SkillBadgeProfile] (
    [SkillBadges_skillBadgeId] int  NOT NULL,
    [Profiles_profileId] int  NOT NULL
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

-- Creating primary key on [courseId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([courseId] ASC);
GO

-- Creating primary key on [pathId] in table 'Paths'
ALTER TABLE [dbo].[Paths]
ADD CONSTRAINT [PK_Paths]
    PRIMARY KEY CLUSTERED ([pathId] ASC);
GO

-- Creating primary key on [skillBadgeId] in table 'SkillBadges'
ALTER TABLE [dbo].[SkillBadges]
ADD CONSTRAINT [PK_SkillBadges]
    PRIMARY KEY CLUSTERED ([skillBadgeId] ASC);
GO

-- Creating primary key on [questionSetId] in table 'SystemQuestions'
ALTER TABLE [dbo].[SystemQuestions]
ADD CONSTRAINT [PK_SystemQuestions]
    PRIMARY KEY CLUSTERED ([questionSetId] ASC);
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

-- Creating primary key on [Paths_pathId], [Courses_courseId] in table 'PathCourse'
ALTER TABLE [dbo].[PathCourse]
ADD CONSTRAINT [PK_PathCourse]
    PRIMARY KEY CLUSTERED ([Paths_pathId], [Courses_courseId] ASC);
GO

-- Creating primary key on [SkillBadges_skillBadgeId], [Profiles_profileId] in table 'SkillBadgeProfile'
ALTER TABLE [dbo].[SkillBadgeProfile]
ADD CONSTRAINT [PK_SkillBadgeProfile]
    PRIMARY KEY CLUSTERED ([SkillBadges_skillBadgeId], [Profiles_profileId] ASC);
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

-- Creating foreign key on [Paths_pathId] in table 'PathCourse'
ALTER TABLE [dbo].[PathCourse]
ADD CONSTRAINT [FK_PathCourse_Path]
    FOREIGN KEY ([Paths_pathId])
    REFERENCES [dbo].[Paths]
        ([pathId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Courses_courseId] in table 'PathCourse'
ALTER TABLE [dbo].[PathCourse]
ADD CONSTRAINT [FK_PathCourse_Course]
    FOREIGN KEY ([Courses_courseId])
    REFERENCES [dbo].[Courses]
        ([courseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PathCourse_Course'
CREATE INDEX [IX_FK_PathCourse_Course]
ON [dbo].[PathCourse]
    ([Courses_courseId]);
GO

-- Creating foreign key on [SkillBadge_skillBadgeId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_CourseSkillBadge]
    FOREIGN KEY ([SkillBadge_skillBadgeId])
    REFERENCES [dbo].[SkillBadges]
        ([skillBadgeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseSkillBadge'
CREATE INDEX [IX_FK_CourseSkillBadge]
ON [dbo].[Courses]
    ([SkillBadge_skillBadgeId]);
GO

-- Creating foreign key on [SkillBadges_skillBadgeId] in table 'SkillBadgeProfile'
ALTER TABLE [dbo].[SkillBadgeProfile]
ADD CONSTRAINT [FK_SkillBadgeProfile_SkillBadge]
    FOREIGN KEY ([SkillBadges_skillBadgeId])
    REFERENCES [dbo].[SkillBadges]
        ([skillBadgeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Profiles_profileId] in table 'SkillBadgeProfile'
ALTER TABLE [dbo].[SkillBadgeProfile]
ADD CONSTRAINT [FK_SkillBadgeProfile_Profile]
    FOREIGN KEY ([Profiles_profileId])
    REFERENCES [dbo].[Profiles]
        ([profileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SkillBadgeProfile_Profile'
CREATE INDEX [IX_FK_SkillBadgeProfile_Profile]
ON [dbo].[SkillBadgeProfile]
    ([Profiles_profileId]);
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