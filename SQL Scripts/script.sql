USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 12/9/2016 4:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 12/9/2016 4:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (179, N'Uncle Fester', 258)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (180, N'Pugsley Addams', 258)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (181, N'Wednesday Addams', 259)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (182, N'Cousin Itt', 259)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (258, N'Gomez Addams')
INSERT [dbo].[stylists] ([id], [name]) VALUES (259, N'Morticia Addams')
INSERT [dbo].[stylists] ([id], [name]) VALUES (260, N'Thing')
SET IDENTITY_INSERT [dbo].[stylists] OFF
