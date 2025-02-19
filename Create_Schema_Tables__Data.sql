-- DROP SCHEMA SportsStore;

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SportsStore')
    EXEC('CREATE SCHEMA SportsStore AUTHORIZATION SportsStore');

CREATE TABLE MyBlazorAppDB.SportsStore.carts (
	id int IDENTITY(1,1) NOT NULL,
	subtotal nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	tax nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	total nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_carts PRIMARY KEY (id)
);


-- MyBlazorAppDB.SportsStore.datainfos definition

-- Drop table

-- DROP TABLE MyBlazorAppDB.SportsStore.datainfos;

CREATE TABLE MyBlazorAppDB.SportsStore.datainfos (
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	value nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	model nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__datainfo__3213E83F184279C5 PRIMARY KEY (id)
);


-- MyBlazorAppDB.SportsStore.orderinfos definition

-- Drop table

-- DROP TABLE MyBlazorAppDB.SportsStore.orderinfos;

CREATE TABLE MyBlazorAppDB.SportsStore.orderinfos (
	id int IDENTITY(1,1) NOT NULL,
	email nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	fname nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	lname nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	street nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	city nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	state nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	zip nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	order_id nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	subtotal decimal(10,2) NULL,
	tax decimal(10,2) NULL,
	shipping decimal(10,2) NULL,
	total decimal(10,2) NULL,
	status nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__orderinf__3213E83FA441CFFA PRIMARY KEY (id)
);


-- MyBlazorAppDB.SportsStore.orders definition

-- Drop table

-- DROP TABLE MyBlazorAppDB.SportsStore.orders;

CREATE TABLE MyBlazorAppDB.SportsStore.orders (
	id int IDENTITY(1,1) NOT NULL,
	item nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	price decimal(10,2) NULL,
	quantity int NULL,
	itemTotal decimal(10,2) NULL,
	order_id nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__orders__3213E83FB8070A5E PRIMARY KEY (id)
);


-- MyBlazorAppDB.SportsStore.products definition

-- Drop table

-- MyBlazorAppDB.SportsStore.vehicleorderinfos definition

-- Drop table

-- DROP TABLE MyBlazorAppDB.SportsStore.vehicleorderinfos;

CREATE TABLE MyBlazorAppDB.SportsStore.vehicleorderinfos (
	id int IDENTITY(1,1) NOT NULL,
	email nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	fname nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	lname nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	street nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	city nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	state nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	zip nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	order_id nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	subtotal nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	tax nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	shipping nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	total nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	status nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__vehicleo__3213E83F8DB1BBD0 PRIMARY KEY (id)
);


-- MyBlazorAppDB.SportsStore.vehicleorders definition

-- Drop table

-- DROP TABLE MyBlazorAppDB.SportsStore.vehicleorders;

CREATE TABLE MyBlazorAppDB.SportsStore.vehicleorders (
	id int IDENTITY(1,1) NOT NULL,
	item nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	price nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	order_id nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__vehicleo__3213E83FB439B907 PRIMARY KEY (id)

);

-- DROP TABLE MyBlazorAppDB.SportsStore.products;

CREATE TABLE MyBlazorAppDB.SportsStore.products (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT 'yes' NULL,
	price int NOT NULL,
	category varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[image] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	isAvailable bit DEFAULT 1 NULL,
	CONSTRAINT PK_products PRIMARY KEY (id)
);

SET IDENTITY_INSERT [SportsStore].[products] ON
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (1, N'BaseBall', N'270.00', N'BaseBall', N'../img/uploads/BaseBall.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (2, N'Bat', N'220.00', N'BaseBall', N'../img/uploads/Bat.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (3, N'BaseballGlove', N'220.00', N'Baseba1l', N'../img/uploads/BaseBallGlove.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (4, N'BowlingBag', N'105.00', N'Bowling', N'../img/uploads/BowlingBag.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (5, N'BowlingBall', N'145.00', N'Bowling', N'../img/uploads/BowlingBall.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (6, N'BowlingShoes', N'460.00', N'Bowling', N'../img/uploads/BowlingShoes.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (7, N'Football', N'300.00', N'Football', N'../img/uploads/Football.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (8, N'FootballCleats', N'70.00', N'Football', N'../img/uploads/FootballCleats.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (9, N'FootballHelment', N'40.00', N'Football', N'../img/uploads/FootballHelment.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (10, N'GolfBag', N'270.00', N'Golf', N'../img/uploads/GolfBag.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (11, N'GolfBalls', N'270.00', N'Golf', N'../img/uploads/GolfBalls.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (12, N'GolfBag', N'270.00', N'Golf', N'../img/uploads/GolfBag.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (13, N'GolfGlove', N'270.00', N'Golf', N'../img/uploads/GolfGlove.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (14, N'SoccerGoal', N'50.00', N'Soccer', N'../img/uploads/SoccerGoal.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (15, N'SoccerBall', N'50.00', N'Soccer', N'../img/uploads/SoccerBall.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (16, N'SoccerCleats', N'120.00', N'Soccer', N'../img/uploads/SoccerCleats.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (17, N'SoccerFlags', N'120.00', N'Soccer', N'../img/uploads/SoccerFlags.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (18, N'TennisRacket', N'180.00', N'Tennis', N'../img/uploads/TennisRacket.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (19, N'TennisBalls', N'30.00', N'Tennis', N'../img/uploads/TennisBalls.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (20, N'TennisBag', N'180.00', N'Tennis', N'../img/uploads/TennisBag.jpg', N'yes')
INSERT INTO [SportsStore].[products] ([id], [name], [price], [category], [image], [isAvailable]) VALUES (21, N'TennisShoe', N'30.00', N'Tennis', N'../img/uploads/TennisShoe.jpg', N'yes')
SET IDENTITY_INSERT [SportsStore].[products] OFF
