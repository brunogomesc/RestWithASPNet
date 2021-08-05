USE [rest_with_asp_net]
GO

/****** Object:  Table [dbo].[users]    Script Date: 04/08/2021 16:54:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[users] [varchar](255) NOT NULL,
	[pass] [varchar](100) NOT NULL,
	[full_name] [varchar](300) NOT NULL,
	[refresh_token] [varchar](500) NOT NULL,
	[refresh_token_expiry_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[users] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[users] ADD  DEFAULT ('0') FOR [users]
GO

ALTER TABLE [dbo].[users] ADD  DEFAULT ('0') FOR [pass]
GO

ALTER TABLE [dbo].[users] ADD  DEFAULT ('0') FOR [refresh_token]
GO

ALTER TABLE [dbo].[users] ADD  DEFAULT (NULL) FOR [refresh_token_expiry_time]
GO


