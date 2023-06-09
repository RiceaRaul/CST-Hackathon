USE [cst]
GO
/****** Object:  Table [dbo].[users]    Script Date: 4/2/2023 2:29:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[level] [int] NOT NULL,
	[exp] [bigint] NOT NULL,
	[needexp] [bigint] NOT NULL,
	[profileimg] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_level]  DEFAULT ((1)) FOR [level]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_exp]  DEFAULT ((0)) FOR [exp]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_needexp]  DEFAULT ((200)) FOR [needexp]
GO
