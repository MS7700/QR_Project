USE [master]
GO
/****** Object:  Database [DB_QR_P]    Script Date: 15/3/2021 5:57:38 p. m. ******/
CREATE DATABASE [DB_QR_P]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_QR_P', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_QR_P.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_QR_P_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_QR_P_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_QR_P] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_QR_P].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_QR_P] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_QR_P] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_QR_P] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_QR_P] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_QR_P] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_QR_P] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_QR_P] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_QR_P] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_QR_P] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_QR_P] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_QR_P] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_QR_P] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_QR_P] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_QR_P] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_QR_P] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_QR_P] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_QR_P] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_QR_P] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_QR_P] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_QR_P] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_QR_P] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DB_QR_P] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_QR_P] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_QR_P] SET  MULTI_USER 
GO
ALTER DATABASE [DB_QR_P] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_QR_P] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_QR_P] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_QR_P] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_QR_P] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_QR_P] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_QR_P', N'ON'
GO
ALTER DATABASE [DB_QR_P] SET QUERY_STORE = OFF
GO
USE [DB_QR_P]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Id_Tipo_Identificacion] [int] NULL,
	[Identificacion] [varchar](20) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Id_Estado_Cliente] [int] NULL,
	[Id_Direccion] [int] NULL,
	[Fecha_Ingreso] [date] NULL,
	[Telefono] [varchar](20) NULL,
	[Id_UserName] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[ID_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Id_Empleado_Representante] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[Id_Direccion] [int] IDENTITY(1,1) NOT NULL,
	[Provincia] [varchar](50) NULL,
	[Sector] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
	[Barrio] [varchar](50) NULL,
	[Direccion_1] [varchar](50) NULL,
	[Direccion_2] [varchar](50) NULL,
	[Id_Pais] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Id_Tipo_Identificacion] [int] NULL,
	[Identificacion] [varchar](20) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Id_Estado_Cliente] [int] NULL,
	[Id_Direccion] [int] NULL,
	[Fecha_Ingreso] [date] NULL,
	[Telefono] [varchar](20) NULL,
	[Id_UserName] [nvarchar](128) NULL,
	[Id_Sucursal] [int] NULL,
	[ID_Departamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Cliente]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Cliente](
	[Id_Estado_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Estado_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_QR]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_QR](
	[ID_Estado_QR] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estado_QR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Transaccion]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Transaccion](
	[ID_Estado_Transaccion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estado_Transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Pais] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Monto] [decimal](18, 0) NULL,
	[ID_Tipo_Producto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Queja]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queja](
	[ID_Queja] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cliente] [int] NULL,
	[Id_UserName] [nvarchar](128) NULL,
	[Id_Empleado] [int] NULL,
	[ID_Departamento] [int] NULL,
	[ID_Tipo_Queja] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
	[ID_Estado_QR] [int] NULL,
	[Comentario] [varchar](max) NULL,
	[ID_Sucursal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Queja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reclamacion]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reclamacion](
	[ID_Reclamacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cliente] [int] NULL,
	[Id_UserName] [nvarchar](128) NULL,
	[Id_Empleado] [int] NULL,
	[ID_Departamento] [int] NULL,
	[ID_Tipo_Reclamacion] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
	[ID_Estado_QR] [int] NULL,
	[Comentario] [varchar](max) NULL,
	[ID_Sucursal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Reclamacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rel_Transaccion_Producto]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rel_Transaccion_Producto](
	[ID_Transaccion] [int] NOT NULL,
	[ID_Producto] [int] NOT NULL,
	[Cantidad_Producto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Transaccion] ASC,
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta_Cliente]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta_Cliente](
	[ID_Respuesta_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Id_Queja] [int] NULL,
	[Id_Reclamacion] [int] NULL,
	[ID_Estado_Origen] [int] NULL,
	[ID_Estado_Destino] [int] NULL,
	[Valoracion] [int] NULL,
	[Fecha] [date] NULL,
	[Detalle] [varchar](max) NULL,
	[Hora] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Respuesta_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta_Empleado]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta_Empleado](
	[ID_Respuesta_QR] [int] IDENTITY(1,1) NOT NULL,
	[Id_Queja] [int] NULL,
	[Id_Reclamacion] [int] NULL,
	[ID_Empleado_Origen] [int] NULL,
	[ID_Empleado_Destino] [int] NULL,
	[ID_Departamento_Origen] [int] NULL,
	[ID_Departamento_Destino] [int] NULL,
	[ID_Estado_Origen] [int] NULL,
	[ID_Estado_Destino] [int] NULL,
	[Fecha] [date] NULL,
	[Detalle] [varchar](max) NULL,
	[Hora] [time](7) NULL,
	[ID_Sucursal_Origen] [int] NULL,
	[ID_Sucursal_Destino] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Respuesta_QR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[ID_Sucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Id_Empleado_Representante] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Identificacion]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Identificacion](
	[Id_Tipo_Identificacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Producto]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Producto](
	[ID_Tipo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Tipo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Queja]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Queja](
	[ID_Tipo_Queja] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Tipo_Queja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Reclamacion]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Reclamacion](
	[ID_Tipo_Reclamacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Tipo_Reclamacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 15/3/2021 5:57:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[ID_Transaccion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cliente] [int] NULL,
	[Fecha] [date] NULL,
	[ID_Estado_Transaccion] [int] NULL,
	[Monto] [decimal](18, 0) NULL,
	[Id_Empleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 15/3/2021 5:57:39 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 15/3/2021 5:57:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 15/3/2021 5:57:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 15/3/2021 5:57:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 15/3/2021 5:57:39 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 15/3/2021 5:57:39 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Id_Direccion])
REFERENCES [dbo].[Direccion] ([Id_Direccion])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Id_Estado_Cliente])
REFERENCES [dbo].[Estado_Cliente] ([Id_Estado_Cliente])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Id_Tipo_Identificacion])
REFERENCES [dbo].[Tipo_Identificacion] ([Id_Tipo_Identificacion])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Id_UserName])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK__Departame__Id_Em__5EBF139D] FOREIGN KEY([Id_Empleado_Representante])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK__Departame__Id_Em__5EBF139D]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD FOREIGN KEY([Id_Pais])
REFERENCES [dbo].[Pais] ([Id_Pais])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__ID_Dep__5BE2A6F2] FOREIGN KEY([ID_Departamento])
REFERENCES [dbo].[Departamento] ([ID_Departamento])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__ID_Dep__5BE2A6F2]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__Id_Dir__5AEE82B9] FOREIGN KEY([Id_Direccion])
REFERENCES [dbo].[Direccion] ([Id_Direccion])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__Id_Dir__5AEE82B9]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([Id_Estado_Cliente])
REFERENCES [dbo].[Estado_Cliente] ([Id_Estado_Cliente])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__Id_Suc__5CD6CB2B] FOREIGN KEY([Id_Sucursal])
REFERENCES [dbo].[Sucursal] ([ID_Sucursal])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__Id_Suc__5CD6CB2B]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([Id_Tipo_Identificacion])
REFERENCES [dbo].[Tipo_Identificacion] ([Id_Tipo_Identificacion])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__Id_Use__5812160E] FOREIGN KEY([Id_UserName])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__Id_Use__5812160E]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([ID_Tipo_Producto])
REFERENCES [dbo].[Tipo_Producto] ([ID_Tipo_Producto])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD FOREIGN KEY([ID_Departamento])
REFERENCES [dbo].[Departamento] ([ID_Departamento])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD FOREIGN KEY([ID_Estado_QR])
REFERENCES [dbo].[Estado_QR] ([ID_Estado_QR])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD FOREIGN KEY([ID_Tipo_Queja])
REFERENCES [dbo].[Tipo_Queja] ([ID_Tipo_Queja])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD FOREIGN KEY([Id_UserName])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Queja]  WITH CHECK ADD  CONSTRAINT [FK_QuejaSucursal] FOREIGN KEY([ID_Sucursal])
REFERENCES [dbo].[Sucursal] ([ID_Sucursal])
GO
ALTER TABLE [dbo].[Queja] CHECK CONSTRAINT [FK_QuejaSucursal]
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD FOREIGN KEY([ID_Departamento])
REFERENCES [dbo].[Departamento] ([ID_Departamento])
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD FOREIGN KEY([ID_Estado_QR])
REFERENCES [dbo].[Estado_QR] ([ID_Estado_QR])
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD FOREIGN KEY([ID_Tipo_Reclamacion])
REFERENCES [dbo].[Tipo_Reclamacion] ([ID_Tipo_Reclamacion])
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD FOREIGN KEY([Id_UserName])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reclamacion]  WITH CHECK ADD  CONSTRAINT [FK_ReclamacionSucursal] FOREIGN KEY([ID_Sucursal])
REFERENCES [dbo].[Sucursal] ([ID_Sucursal])
GO
ALTER TABLE [dbo].[Reclamacion] CHECK CONSTRAINT [FK_ReclamacionSucursal]
GO
ALTER TABLE [dbo].[Rel_Transaccion_Producto]  WITH CHECK ADD  CONSTRAINT [FK__Rel_Trans__ID_Pr__6EF57B66] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Producto] ([ID_Producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rel_Transaccion_Producto] CHECK CONSTRAINT [FK__Rel_Trans__ID_Pr__6EF57B66]
GO
ALTER TABLE [dbo].[Rel_Transaccion_Producto]  WITH CHECK ADD  CONSTRAINT [FK__Rel_Trans__ID_Tr__6E01572D] FOREIGN KEY([ID_Transaccion])
REFERENCES [dbo].[Transaccion] ([ID_Transaccion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rel_Transaccion_Producto] CHECK CONSTRAINT [FK__Rel_Trans__ID_Tr__6E01572D]
GO
ALTER TABLE [dbo].[Respuesta_Cliente]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_Es__123EB7A3] FOREIGN KEY([ID_Estado_Origen])
REFERENCES [dbo].[Estado_QR] ([ID_Estado_QR])
GO
ALTER TABLE [dbo].[Respuesta_Cliente] CHECK CONSTRAINT [FK__Respuesta__ID_Es__123EB7A3]
GO
ALTER TABLE [dbo].[Respuesta_Cliente]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_Es__1332DBDC] FOREIGN KEY([ID_Estado_Destino])
REFERENCES [dbo].[Estado_QR] ([ID_Estado_QR])
GO
ALTER TABLE [dbo].[Respuesta_Cliente] CHECK CONSTRAINT [FK__Respuesta__ID_Es__1332DBDC]
GO
ALTER TABLE [dbo].[Respuesta_Cliente]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__Id_Qu__10566F31] FOREIGN KEY([Id_Queja])
REFERENCES [dbo].[Queja] ([ID_Queja])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuesta_Cliente] CHECK CONSTRAINT [FK__Respuesta__Id_Qu__10566F31]
GO
ALTER TABLE [dbo].[Respuesta_Cliente]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__Id_Re__114A936A] FOREIGN KEY([Id_Reclamacion])
REFERENCES [dbo].[Reclamacion] ([ID_Reclamacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuesta_Cliente] CHECK CONSTRAINT [FK__Respuesta__Id_Re__114A936A]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_De__0A9D95DB] FOREIGN KEY([ID_Departamento_Origen])
REFERENCES [dbo].[Departamento] ([ID_Departamento])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__ID_De__0A9D95DB]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_De__0B91BA14] FOREIGN KEY([ID_Departamento_Destino])
REFERENCES [dbo].[Departamento] ([ID_Departamento])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__ID_De__0B91BA14]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_Em__08B54D69] FOREIGN KEY([ID_Empleado_Origen])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__ID_Em__08B54D69]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_Em__09A971A2] FOREIGN KEY([ID_Empleado_Destino])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__ID_Em__09A971A2]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_Es__0C85DE4D] FOREIGN KEY([ID_Estado_Origen])
REFERENCES [dbo].[Estado_QR] ([ID_Estado_QR])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__ID_Es__0C85DE4D]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__ID_Es__0D7A0286] FOREIGN KEY([ID_Estado_Destino])
REFERENCES [dbo].[Estado_QR] ([ID_Estado_QR])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__ID_Es__0D7A0286]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__Id_Qu__06CD04F7] FOREIGN KEY([Id_Queja])
REFERENCES [dbo].[Queja] ([ID_Queja])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__Id_Qu__06CD04F7]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Respuesta__Id_Re__07C12930] FOREIGN KEY([Id_Reclamacion])
REFERENCES [dbo].[Reclamacion] ([ID_Reclamacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK__Respuesta__Id_Re__07C12930]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaEmpleadoSucursalDestino] FOREIGN KEY([ID_Sucursal_Destino])
REFERENCES [dbo].[Sucursal] ([ID_Sucursal])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK_RespuestaEmpleadoSucursalDestino]
GO
ALTER TABLE [dbo].[Respuesta_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaEmpleadoSucursalOrigen] FOREIGN KEY([ID_Sucursal_Origen])
REFERENCES [dbo].[Sucursal] ([ID_Sucursal])
GO
ALTER TABLE [dbo].[Respuesta_Empleado] CHECK CONSTRAINT [FK_RespuestaEmpleadoSucursalOrigen]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD FOREIGN KEY([Id_Empleado_Representante])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD FOREIGN KEY([ID_Estado_Transaccion])
REFERENCES [dbo].[Estado_Transaccion] ([ID_Estado_Transaccion])
GO
USE [master]
GO
ALTER DATABASE [DB_QR_P] SET  READ_WRITE 
GO
