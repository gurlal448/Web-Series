USE [master]
GO
/****** Object:  Database [WebSeries]    Script Date: 14/08/2020 13:27:47 ******/
CREATE DATABASE [WebSeries]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebSeries', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebSeries.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebSeries_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebSeries_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebSeries] SET COMPATIBILITY_LEVEL = 140
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
ALTER DATABASE [WebSeries] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [WebSeries] SET RECOVERY FULL 
GO
ALTER DATABASE [WebSeries] SET  MULTI_USER 
GO
ALTER DATABASE [WebSeries] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebSeries] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebSeries] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebSeries] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebSeries] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebSeries', N'ON'
GO
ALTER DATABASE [WebSeries] SET QUERY_STORE = OFF
GO
USE [WebSeries]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 14/08/2020 13:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustID] [int] IDENTITY(101,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Phone] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 14/08/2020 13:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[WebSeries]    Script Date: 14/08/2020 13:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[prcCustWhoBorrowMostMovies]    Script Date: 14/08/2020 13:27:47 ******/
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
/****** Object:  StoredProcedure [dbo].[prcDelCust]    Script Date: 14/08/2020 13:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[prcDelCust](@custId int)
  as
  delete customer where custId=@custId
GO
/****** Object:  StoredProcedure [dbo].[prcMostPopularMovies]    Script Date: 14/08/2020 13:27:47 ******/
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
/****** Object:  StoredProcedure [dbo].[prcRentMovie]    Script Date: 14/08/2020 13:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[prcRentMovie](@MovieID int,@CustID int,@RentDate varchar(100), @ReturnDate varchar(100),@TotalRent int)
  as
  insert into RentedMovies(MovieID,CustID,RentedDate,ReturnDate,TotalRent) values(@MovieID,@CustID,@RentDate,@ReturnDate,@TotalRent)
GO
/****** Object:  StoredProcedure [dbo].[prcReturnMovie]    Script Date: 14/08/2020 13:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prcReturnMovie](@MovieID int,@CustID int)
  as
  delete from RentedMovies where MovieID=@MovieID and CustID= @CustID;
GO
/****** Object:  StoredProcedure [dbo].[ShowRentedData]    Script Date: 14/08/2020 13:27:47 ******/
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
