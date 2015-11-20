CREATE TABLE [dbo].[Answer] (
    [id]          INT  IDENTITY (1, 1) NOT NULL,
    [question_id] INT  NOT NULL,
    [answer]      TEXT NOT NULL,
    [is_right]    BIT  NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([question_id]) REFERENCES [dbo].[Question] ([id])
);

