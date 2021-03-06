USE [master]
GO
/****** Object:  Database [WebSeries]    Script Date: 9/25/2020 9:33:39 AM ******/
CREATE DATABASE [WebSeries]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebSeries', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WebSeries.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebSeries_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WebSeries_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebSeries] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebSeries].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebSeries] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebSeries] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebSeries] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebSeries] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebSeries] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebSeries] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WebSeries] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebSeries] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebSeries] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebSeries] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebSeries] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebSeries] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebSeries] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebSeries] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebSeries] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WebSeries] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebSeries] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebSeries] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebSeries] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebSeries] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebSeries] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebSeries] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebSeries] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebSeries] SET  MULTI_USER 
GO
ALTER DATABASE [WebSeries] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebSeries] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebSeries] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebSeries] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WebSeries] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WebSeries]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustID] [int] IDENTITY(101,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Phone] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RentId] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NULL,
	[CustID] [int] NULL,
	[RentedDate] [varchar](100) NULL,
	[ReturnDate] [varchar](100) NULL,
	[TotalRent] [int] NULL,
 CONSTRAINT [PK__RentedMo__783D47F5A31EEEC8] PRIMARY KEY CLUSTERED 
(
	[RentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebSeries]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebSeries](
	[MovieID] [int] IDENTITY(1001,1) NOT NULL,
	[Title] [varchar](500) NULL,
	[Year] [varchar](25) NULL,
	[RentalCost] [int] NULL,
	[Genre] [varchar](50) NULL,
	[Rating] [float] NULL,
 CONSTRAINT [PK__Movies__4BD2943AF0411E1B] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustID], [Name], [Address], [Phone]) VALUES (101, N'gurlal', N'nz', 78945612)
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [Phone]) VALUES (102, N'mohit', N'delhi', 45612348)
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [Phone]) VALUES (103, N'kanupriya', N'australia', 112234455)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RentId], [MovieID], [CustID], [RentedDate], [ReturnDate], [TotalRent]) VALUES (1, 1003, 101, N'9/13/2020', N'9/15/2020', 4)
INSERT [dbo].[RentedMovies] ([RentId], [MovieID], [CustID], [RentedDate], [ReturnDate], [TotalRent]) VALUES (2, 1001, 101, N'9/13/2020', N'9/17/2020', 20)
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
SET IDENTITY_INSERT [dbo].[WebSeries] ON 

INSERT [dbo].[WebSeries] ([MovieID], [Title], [Year], [RentalCost], [Genre], [Rating]) VALUES (1001, N'breathe', N'2020', 5, N'crime', 8)
INSERT [dbo].[WebSeries] ([MovieID], [Title], [Year], [RentalCost], [Genre], [Rating]) VALUES (1002, N'away', N'2020', 5, N'fiction', 7)
INSERT [dbo].[WebSeries] ([MovieID], [Title], [Year], [RentalCost], [Genre], [Rating]) VALUES (1003, N'orange is new black', N'1995', 2, N'crime', 7)
SET IDENTITY_INSERT [dbo].[WebSeries] OFF
/****** Object:  Index [UQ__Customer__5C7E359E7E06B631]    Script Date: 9/25/2020 9:33:39 AM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RentedMovies]  WITH CHECK ADD  CONSTRAINT [FK__RentedMov__CustI__3C69FB99] FOREIGN KEY([CustID])
REFERENCES [dbo].[Customer] ([CustID])
GO
ALTER TABLE [dbo].[RentedMovies] CHECK CONSTRAINT [FK__RentedMov__CustI__3C69FB99]
GO
ALTER TABLE [dbo].[RentedMovies]  WITH CHECK ADD  CONSTRAINT [FK__RentedMov__Movie__3E52440B] FOREIGN KEY([MovieID])
REFERENCES [dbo].[WebSeries] ([MovieID])
GO
ALTER TABLE [dbo].[RentedMovies] CHECK CONSTRAINT [FK__RentedMov__Movie__3E52440B]
GO
/****** Object:  StoredProcedure [dbo].[prcCustWhoBorrowMostMovies]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE proc [dbo].[prcCustWhoBorrowMostMovies]
	as
	SELECT 
    rm.CustID,
	name as CustomerName,
    COUNT(*) occurrences
FROM RentedMovies rm join customer cc on cc.custid = rm.custid
GROUP BY
    rm.CustID, name
  
HAVING 
    COUNT(*) >1;

GO
/****** Object:  StoredProcedure [dbo].[prcDelCust]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[prcDelCust](@custId int)
  as
  delete customer where custId=@custId

GO
/****** Object:  StoredProcedure [dbo].[prcMostPopularMovies]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[prcMostPopularMovies]
 as
SELECT 
    rm.MovieID,title, COUNT(*) occurrences
FROM RentedMovies rm join WebSeries m on m.movieid = rm.movieid
GROUP BY
    rm.MovieID, title
  
HAVING 
    COUNT(*) >1;

GO
/****** Object:  StoredProcedure [dbo].[prcRentMovie]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[prcRentMovie](@MovieID int,@CustID int,@RentDate varchar(100), @ReturnDate varchar(100),@TotalRent int)
  as
  insert into RentedMovies(MovieID,CustID,RentedDate,ReturnDate,TotalRent) values(@MovieID,@CustID,@RentDate,@ReturnDate,@TotalRent)

GO
/****** Object:  StoredProcedure [dbo].[prcReturnMovie]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prcReturnMovie](@MovieID int,@CustID int)
  as
  delete from RentedMovies where MovieID=@MovieID and CustID= @CustID;

GO
/****** Object:  StoredProcedure [dbo].[ShowRentedData]    Script Date: 9/25/2020 9:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[ShowRentedData]
  as
  select RentId, name as CustomerName, Address, Title as MovieTitle,RentalCost,RentedDate,ReturnDate,TotalRent from RentedMovies rm join Customer c on c.CustID = rm.CustID join WebSeries m on m.MovieID= rm.MovieID
  order by RentedDate desc

GO
USE [master]
GO
ALTER DATABASE [WebSeries] SET  READ_WRITE 
GO
