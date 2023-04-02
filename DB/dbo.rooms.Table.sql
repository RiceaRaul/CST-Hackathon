USE [cst]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 4/2/2023 10:25:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[roomcode] [varchar](50) NOT NULL,
	[status] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[rooms] ADD  CONSTRAINT [DF_rooms_status]  DEFAULT ((0)) FOR [status]
GO
