CREATE TABLE [dbo].[Game] (
    [id]                     INT      IDENTITY (1, 1) NOT NULL,
    [played_category_id]     INT      NOT NULL,
    [player_id]              INT      NOT NULL,
    [score]                  INT      NULL,
    [number_right_questions] INT      NULL,
    [played_date]            DATETIME NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Game_Category] FOREIGN KEY ([played_category_id]) REFERENCES [dbo].[Category] ([id]),
    CONSTRAINT [FK_Game_Player] FOREIGN KEY ([player_id]) REFERENCES [dbo].[Player] ([id])
);

