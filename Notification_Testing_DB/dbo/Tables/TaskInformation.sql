CREATE TABLE [dbo].[TaskInformation] (
    [id]                INT              IDENTITY (1, 1) NOT NULL,
    [CreatedTime]       DATETIME         NULL,
    [Guid]              UNIQUEIDENTIFIER NULL,
    [ServiceTaskName]   NVARCHAR (MAX)   NULL,
    [TimeToComplete]    DECIMAL (18)     NULL,
    [CompletionSuccess] BIT              NULL,
    [ExceptionMessage]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_TaskInformation] PRIMARY KEY CLUSTERED ([id] ASC)
);

