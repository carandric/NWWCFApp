USE [NORTHWIND]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebTracker]') AND type in (N'U'))
	DROP TABLE [dbo].[WebTracker]
GO

CREATE TABLE [dbo].[WebTracker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[URLRequest] [nvarchar](500) NULL,
	[SourceIP] [nvarchar](30) NULL,
	[TimeOfAction] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


