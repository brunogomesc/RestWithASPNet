CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[username] [varchar](255) NOT NULL DEFAULT '0' UNIQUE,
	[pass] [varchar](100) NOT NULL DEFAULT '0',
	[full_name] [varchar](300) NOT NULL,
	[refresh_token] [varchar](500) NULL DEFAULT '0',
	[refresh_token_expiry_time] [datetime] NULL DEFAULT NULL
)