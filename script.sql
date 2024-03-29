USE [Warehouse]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 27.07.2022 0:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderContent]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderContent](
	[ContentID] [int] IDENTITY(1,1) NOT NULL,
	[ProductListID] [int] NULL,
	[ProductAmount] [int] NULL,
	[OrderID] [int] NULL,
	[PriceForUnit] [money] NULL,
	[TotalAmount] [money] NULL,
 CONSTRAINT [PK_OrderContent] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderList]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderList](
	[OrderListID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[ManagerID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalValue] [money] NULL,
 CONSTRAINT [PK_OrderList] PRIMARY KEY CLUSTERED 
(
	[OrderListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UnitOfMeasurement] [nvarchar](50) NOT NULL,
	[PriceForUnit] [money] NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductList]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductList](
	[ProductListID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Amount] [int] NULL,
	[CurrentAmount] [int] NULL,
 CONSTRAINT [PK_ProductList] PRIMARY KEY CLUSTERED 
(
	[ProductListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLoginPass]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLoginPass](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserLogin] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
	[UserRole] [int] NULL,
 CONSTRAINT [PK_UserLoginPass] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleDictionary]    Script Date: 27.07.2022 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleDictionary](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserRoleDictionary] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (1, N'Спальня')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (2, N'Гостинная')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (3, N'Кухня')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (4, N'Прихожая')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (5, N'Детская')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (1, N'ИП Морозов Константин Николаевич', N'+7(951)116-40-05', N'г.Екатеринбург ул. Ленина 36')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (2, N'ООО "Кристалл"', N'+7(512)483-69-14', N'г.Екатеринбург ул. Черепанова 27')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (3, N'ОАО "Омега"', N'+7(520)272-35-26', N'г.Первоуральск просп. Ильича, 15')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (4, N'АО "РоботИмпериал"', N'+7(995)006-46-26', N'Саратовская область, город Орехово-Зуево, шоссе Бухарестская, 36')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (5, N'ООО "Талин"', N'+7(995)795-34-20', N'Тамбовская область, город Раменское, пер. Ленина, 34')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (1006, N'ЖК "Нагорный"', N'+7(992)120-42-13', N'Свердловская область, Екатеринбург, ул.Татищева 18')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (1007, N'ИП Михайленко Георгий Александрович', N'+7(343)189-20-53', N'г.Екатеринбург ул.Машинная 92')
INSERT [dbo].[Client] ([ClientID], [Name], [Phone], [Address]) VALUES (1008, N'ЖКХ "Святогор"', N'+7(920)132-12-49', N'г.Екатеринбург ул. Расточная, 17/3')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderContent] ON 

INSERT [dbo].[OrderContent] ([ContentID], [ProductListID], [ProductAmount], [OrderID], [PriceForUnit], [TotalAmount]) VALUES (7075, 2, 5, 8072, 26600.0000, 133000.0000)
INSERT [dbo].[OrderContent] ([ContentID], [ProductListID], [ProductAmount], [OrderID], [PriceForUnit], [TotalAmount]) VALUES (7076, 3, 3, 8072, 8200.1000, 24600.3000)
SET IDENTITY_INSERT [dbo].[OrderContent] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderList] ON 

INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6076, 2, 1, CAST(N'2021-01-16T18:20:13.630' AS DateTime), 82246.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6077, 1006, 1, CAST(N'2022-01-16T23:20:26.453' AS DateTime), 122645.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6078, 4, 1, CAST(N'2022-01-16T23:21:02.167' AS DateTime), 100600.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6080, 2, 1, CAST(N'2022-01-18T17:51:24.293' AS DateTime), 51500.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6081, 5, 2, CAST(N'2022-01-18T17:52:42.143' AS DateTime), 47400.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6082, 1008, 2, CAST(N'2022-01-18T17:52:55.870' AS DateTime), 31600.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6083, 1007, 2, CAST(N'2022-01-18T17:53:05.077' AS DateTime), 42400.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6084, 4, 2, CAST(N'2022-01-18T17:53:35.387' AS DateTime), 42780.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6085, 3, 2, CAST(N'2022-01-18T17:54:00.870' AS DateTime), 59800.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6086, 4, 1, CAST(N'2022-01-18T21:02:26.477' AS DateTime), 139000.6000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (6087, 1, 2, CAST(N'2022-01-19T20:08:28.450' AS DateTime), 63200.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (7072, 1, 1, CAST(N'2022-01-25T14:42:54.293' AS DateTime), 121400.0000)
INSERT [dbo].[OrderList] ([OrderListID], [ClientID], [ManagerID], [OrderDate], [TotalValue]) VALUES (8072, 1, 1, CAST(N'2022-04-21T02:44:51.347' AS DateTime), 157600.3000)
SET IDENTITY_INSERT [dbo].[OrderList] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (2, N'"Капелла" Шкаф-купе', N'Система раздвижных подвесных дверей «MЕРА» (мепа) с шарикоподшипниковыми роликами закрытого типа для шкафов-купе, характеризуется плавностью и бесшумностью хода. Эта система предназначена для тяжёлых раздвижных дверей, максимальная нагрузочная способность 80 кг на дверь.', N'шт', 59800.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (3, N'Гостиная "Бостон"', NULL, N'шт', 35700.0000, 2)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (4, N'"Элен" Кровать с мягкой спинкой 1,6', NULL, N'шт', 26600.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (5, N'"Каллисто 2" – Стол журнальный (стекло)', N'', N'шт', 8200.1000, 2)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (7, N'Кухонный уголок КУ 20 terra 116', NULL, N'шт', 19815.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (8, N'Кухня Монс графит', NULL, N'шт', 56170.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (9, N'Тумба прикроватная ТП 8 МС Шарм', NULL, N'шт', 2160.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (10, N'Кровать Стелла', NULL, N'шт', 24090.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (11, N'Гостиная Соло', NULL, N'шт', 65380.1000, 2)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (16, N'Софинг', N'', N'шт', 1200.0000, 2)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (19, N'Обеденный стол "Уют"', N'Удобный стол с ножкой в центре, которая не мешает сидящим за ним.', N'шт', 13000.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1019, N'Стул барный "Стиль"', NULL, N'шт', 5600.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1020, N'Вешалка "Лось"', NULL, N'шт', 5600.0000, 4)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1021, N'Кровать детская КР-07 Трио', NULL, N'шт', 12670.0000, 5)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1022, N'Шкаф Мика СТЛ.165.08', NULL, N'шт', 7600.0000, 5)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1023, N'Детский гарнитур Буратино розовый', NULL, N'шт', 42780.0000, 5)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1024, N'Тумба для обуви Лайт 08-56 ', NULL, N'шт', 3990.0000, 4)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1025, N'Прихожая 3 Вешалка с зеркалом 1200 мм', NULL, N'шт', 9523.0000, 4)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1026, N'Модульная кухня Авенза Гриджио', NULL, N'комплект', 112574.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1027, N'Синий кухонный гарнитур Мыло 1600', NULL, N'шт', 36592.0000, 3)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1028, N'Спальня Тиффани 2', NULL, N'комплект', 32230.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1029, N'Спальня Аврора венге/дуб молочный', NULL, N'комплект', 42926.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1030, N'Шкаф Смарт', NULL, N'шт', 5200.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1031, N'Шкаф 2-х створчатый Луиза', NULL, N'шт', 8548.0000, 1)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1032, N'Стенка Интеро', NULL, N'шт', 6970.0000, 2)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (1033, N'Тумба ТВ Арчи 10-85', NULL, N'шт', 4760.0000, 2)
INSERT [dbo].[Product] ([ProductID], [Title], [Description], [UnitOfMeasurement], [PriceForUnit], [Category]) VALUES (2019, N'Короб с подъемным механизмом 1.4 "Беатрис"', NULL, N'шт', 15800.0000, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductList] ON 

INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (2, 4, 0, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (3, 5, 0, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (4, 3, 4, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (5, 2, 74, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (9, 7, 11, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (10, 8, 2, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (11, 9, 8, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (12, 10, 18, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (13, 11, 10, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (14, 16, 0, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (15, 19, 4, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (16, 1019, 13, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (17, 1020, 0, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (18, 1021, 0, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (19, 1022, 15, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (20, 1023, 23, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (21, 1024, 7, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (22, 1025, 8, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (23, 1026, 0, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (24, 1027, 5, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (25, 1028, 31, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (26, 1029, 23, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (27, 1030, 58, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (28, 1031, 12, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (29, 1032, 2, 0)
INSERT [dbo].[ProductList] ([ProductListID], [ProductID], [Amount], [CurrentAmount]) VALUES (30, 1033, 0, 0)
SET IDENTITY_INSERT [dbo].[ProductList] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLoginPass] ON 

INSERT [dbo].[UserLoginPass] ([UserID], [UserName], [UserLogin], [UserPassword], [UserRole]) VALUES (1, N'Данилов А.А.', N'Admin', N'1234', 1)
INSERT [dbo].[UserLoginPass] ([UserID], [UserName], [UserLogin], [UserPassword], [UserRole]) VALUES (2, N'Иванов И.Г.', N'Manager', N'5678', 2)
INSERT [dbo].[UserLoginPass] ([UserID], [UserName], [UserLogin], [UserPassword], [UserRole]) VALUES (3, N'Иванов А.А.', N'IvanovAAdmin', N'0000', 1)
INSERT [dbo].[UserLoginPass] ([UserID], [UserName], [UserLogin], [UserPassword], [UserRole]) VALUES (8, N'Николай М.С.', N'Nikolay', N'1234', 2)
SET IDENTITY_INSERT [dbo].[UserLoginPass] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoleDictionary] ON 

INSERT [dbo].[UserRoleDictionary] ([UserRoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRoleDictionary] ([UserRoleID], [RoleName]) VALUES (2, N'Manager')
SET IDENTITY_INSERT [dbo].[UserRoleDictionary] OFF
GO
ALTER TABLE [dbo].[OrderContent]  WITH CHECK ADD  CONSTRAINT [FK_OrderContent_OrderList] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderList] ([OrderListID])
GO
ALTER TABLE [dbo].[OrderContent] CHECK CONSTRAINT [FK_OrderContent_OrderList]
GO
ALTER TABLE [dbo].[OrderContent]  WITH CHECK ADD  CONSTRAINT [FK_OrderContent_ProductList] FOREIGN KEY([ProductListID])
REFERENCES [dbo].[ProductList] ([ProductListID])
GO
ALTER TABLE [dbo].[OrderContent] CHECK CONSTRAINT [FK_OrderContent_ProductList]
GO
ALTER TABLE [dbo].[OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[OrderList] CHECK CONSTRAINT [FK_OrderList_Client]
GO
ALTER TABLE [dbo].[OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_UserLoginPass] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[UserLoginPass] ([UserID])
GO
ALTER TABLE [dbo].[OrderList] CHECK CONSTRAINT [FK_OrderList_UserLoginPass]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductList]  WITH CHECK ADD  CONSTRAINT [FK_ProductList_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductList] CHECK CONSTRAINT [FK_ProductList_Product]
GO
ALTER TABLE [dbo].[UserLoginPass]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginPass_UserRoleDictionary] FOREIGN KEY([UserRole])
REFERENCES [dbo].[UserRoleDictionary] ([UserRoleID])
GO
ALTER TABLE [dbo].[UserLoginPass] CHECK CONSTRAINT [FK_UserLoginPass_UserRoleDictionary]
GO
