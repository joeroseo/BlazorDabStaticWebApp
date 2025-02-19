/*
Create the free database in azure the username abd password are those of the SQL machine
In DBeaver create a connection String ait will initially connect to the master database
Right click on that and open a SQL editor window
Run the scripts below ..
*/ 



Create Schema BlazorSportsStore.dbo;



CREATE TABLE BlazorSportsStore.dbo.Users (
	Id int IDENTITY(1,1) NOT NULL,
	Email nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PasswordHash nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CreatedAt datetime DEFAULT getdate() NULL,
	CONSTRAINT PK__Users__3214EC072CA915AE PRIMARY KEY (Id),
	CONSTRAINT UQ__Users__A9D1053455645121 UNIQUE (Email)
);


CREATE TABLE BlazorSportsStore.dbo.carts (
	id int IDENTITY(1,1) NOT NULL,
	subtotal nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	tax nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	total nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_carts PRIMARY KEY (id)
);

CREATE TABLE BlazorSportsStore.dbo.orderinfos (
	id int IDENTITY(1,1) NOT NULL,
	email nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	fname nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	lname nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	street nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	city nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	state nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	zip nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	subtotal decimal(10,2) NULL,
	tax decimal(10,2) NULL,
	shipping decimal(10,2) NULL,
	total decimal(10,2) NULL,
	status nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT 'Pending' NULL,
	order_id nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	order_date varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT format(getdate(),'MM/dd/yyyy') NOT NULL,
	CONSTRAINT PK__orderinf__3213E83FA441CFFA PRIMARY KEY (id)
);

CREATE TABLE BlazorSportsStore.dbo.orders (
	id int IDENTITY(1,1) NOT NULL,
	item nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	price decimal(10,2) NULL,
	quantity int NULL,
	itemTotal decimal(10,2) NULL,
	order_id nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__orders__3213E83FB8070A5E PRIMARY KEY (id)
);

CREATE TABLE BlazorBlazorSportsStore.dbo.products (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT 'yes' NOT NULL,
	price int NOT NULL,
	category varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[image] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	isAvailable bit DEFAULT 1 NULL,
	CONSTRAINT PK_products PRIMARY KEY (id)
)

INSERT INTO BlazorBlazorSportsStore.dbo.products (name,price,category,[image],isAvailable) VALUES
	 (N'BaseBall',270,N'BaseBall',N'/img/uploads/BaseBall.jpg',1),
	 (N'Bat',220,N'BaseBall',N'/img/uploads/Bat.jpg',1),
	 (N'BaseballGlove',220,N'Baseba1l',N'/img/uploads/BaseBallGlove.jpg',1),
	 (N'BowlingBag',105,N'Bowling',N'/img/uploads/BowlingBag.jpg',1),
	 (N'BowlingBall',145,N'Bowling',N'/img/uploads/BowlingBall.jpg',1),
	 (N'BowlingShoes',460,N'Bowling',N'/img/uploads/BowlingShoes.jpg',1),
	 (N'Football',300,N'Football',N'/img/uploads/Football.jpg',1),
	 (N'FootballCleats',70,N'Football',N'/img/uploads/FootballCleats.jpg',1),
	 (N'FootballHelment',40,N'Football',N'/img/uploads/FootballHelment.jpg',1),
	 (N'GolfBag',270,N'Golf',N'/img/uploads/GolfBag.jpg',1);
INSERT INTO BlazorBlazorSportsStore.dbo.products (name,price,category,[image],isAvailable) VALUES
	 (N'GolfBalls',270,N'Golf',N'/img/uploads/GolfBalls.jpg',1),
	 (N'GolfGlove',270,N'Golf',N'/img/uploads/GolfGlove.jpg',1),
	 (N'SoccerGoal',50,N'Soccer',N'/img/uploads/SoccerGoal.jpg',1),
	 (N'SoccerBall',50,N'Soccer',N'/img/uploads/SoccerBall.jpg',1),
	 (N'SoccerCleats',120,N'Soccer',N'/img/uploads/SoccerCleats.jpg',1),
	 (N'SoccerFlags',120,N'Soccer',N'/img/uploads/SoccerFlags.jpg',1),
	 (N'TennisRacket',180,N'Tennis',N'/img/uploads/TennisRacket.jpg',1),
	 (N'TennisBalls',30,N'Tennis',N'/img/uploads/TennisBalls.jpg',1),
	 (N'TennisBagLarge',180,N'Tennis',N'/img/uploads/TennisBag.jpg',1);
