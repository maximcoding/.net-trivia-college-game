CREATE TABLE [dbo].[Category] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [category_name]   VARCHAR (100) NOT NULL,
    [number_qustions] INT           NULL,
    [picture]         VARCHAR (50)  NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([id] ASC)
);

