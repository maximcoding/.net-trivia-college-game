CREATE TABLE [dbo].[Question] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [category_id]   INT           NOT NULL,
    [question_type] VARCHAR (50)  NULL,
    [question]      TEXT          NULL,
    [image]         VARCHAR (100) NULL,
    [points]        INT           NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Question_Category] FOREIGN KEY ([category_id]) REFERENCES [dbo].[Category] ([id])
);

