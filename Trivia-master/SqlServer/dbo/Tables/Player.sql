CREATE TABLE [dbo].[Player] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [username]          VARCHAR (100) NOT NULL,
    [email]             VARCHAR (150) NOT NULL,
    [password]          VARCHAR (100) NOT NULL,
    [registration_date] DATETIME      NOT NULL,
    [image]             VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([id] ASC)
);

