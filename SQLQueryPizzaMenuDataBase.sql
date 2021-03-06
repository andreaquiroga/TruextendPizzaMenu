USE [PizzaPlace]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 6/2/2019 11:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizza]    Script Date: 6/2/2019 11:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Pizza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaIngredient]    Script Date: 6/2/2019 11:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaIngredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PizzaId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
 CONSTRAINT [PK_PizzaIngredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PizzaIngredient]  WITH CHECK ADD  CONSTRAINT [FK_PizzaIngredient_Ingredient] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredient] ([Id])
GO
ALTER TABLE [dbo].[PizzaIngredient] CHECK CONSTRAINT [FK_PizzaIngredient_Ingredient]
GO
ALTER TABLE [dbo].[PizzaIngredient]  WITH CHECK ADD  CONSTRAINT [FK_PizzaIngredient_Pizza1] FOREIGN KEY([PizzaId])
REFERENCES [dbo].[Pizza] ([Id])
GO
ALTER TABLE [dbo].[PizzaIngredient] CHECK CONSTRAINT [FK_PizzaIngredient_Pizza1]
GO

INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Traditional')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Chicago')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Greek')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('4 Seasons')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Mushrooms')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Marguerita')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Mediterrean')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('Neapelitan')
INSERT INTO [dbo].[Pizza]([Name]) VALUES ('New York-Style')

GO
