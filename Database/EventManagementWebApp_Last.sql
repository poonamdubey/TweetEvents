USE [master]
GO
/****** Object:  Database [EventManagementWebApp_Last]    Script Date: 5/4/2016 10:20:39 PM ******/
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'EventManagementWebApp_Last') 
BEGIN

DROP DATABASE [EventManagementWebApp_Last]
END;
ELSE
PRINT 'NOT EXISTS'
CREATE DATABASE EventManagementWebApp_Last
GO


 
 
USE EventManagementWebApp_Last
GO



/****** Object:  Table [dbo].[Caterers]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Caterers](
	[CatererID] [int] IDENTITY(1,1) NOT NULL,
	[CatererName] [varchar](100) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailID] [varchar](50) NOT NULL,
	[PhoneNo1] [char](10) NOT NULL,
	[PhoneNo2] [char](10) NULL,
	[Address1] [varchar](100) NOT NULL,
	[Address2] [varchar](50) NULL,
	[PostalCode] [char](5) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
 CONSTRAINT [pk_Caterers] PRIMARY KEY CLUSTERED 
(
	[CatererID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailID] [varchar](50) NOT NULL,
	[PhoneNo1] [char](10) NOT NULL,
	[PhoneNo2] [char](10) NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NULL,
	[PostalCode] [char](5) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [pk_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventBookings]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventBookings](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeID] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[EventDate] [date] NOT NULL,
	[VenueID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CatererID] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [pk_EventBookings_BookingID] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventStatus]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventStatus](
	[EventStatusID] [int] IDENTITY(10,1) NOT NULL,
	[EventStatus] [varchar](50) NOT NULL,
	[StatusDesciption] [varchar](100) NOT NULL,
 CONSTRAINT [PK_EventStatus] PRIMARY KEY CLUSTERED 
(
	[EventStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [varchar](100) NOT NULL,
	[EventTypeDescription] [varchar](250) NULL,
 CONSTRAINT [pk_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(50,1) NOT NULL,
	[EventStatusID] [int] NOT NULL,
	[BookingID] [int] NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[PaidAmount] [decimal](10, 2) NOT NULL,
	[DueAmount] [decimal](10, 2) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(100,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[RoleDescription] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1000,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [varchar](200) NOT NULL,
	[LastName] [varchar](200) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[City] [nvarchar](20) NULL,
	[Zip] [nvarchar](10) NULL,
	[State] [nvarchar](30) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleID] [int] IDENTITY(20,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venue]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venue](
	[VenueID] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [varchar](100) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[PostalCode] [char](5) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
	[Capacity] [smallint] NOT NULL,
	[ContactPersonName] [varchar](50) NOT NULL,
	[ContactPersonNum] [char](10) NOT NULL,
 CONSTRAINT [pk_Venue] PRIMARY KEY CLUSTERED 
(
	[VenueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Caterers] ON 

GO
INSERT [dbo].[Caterers] ([CatererID], [CatererName], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State]) VALUES (1, N'Indian Cuisine', N'Rakesh', N'Mishra', N'rakeshmishra@indiancuisine.com', N'3193134422', N'3145556754', N'1060 Old Marion Rd NE', NULL, N'52402', N'Cedar Rapids', N'IA')
GO
INSERT [dbo].[Caterers] ([CatererID], [CatererName], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State]) VALUES (2, N'Maxican Grill', N'George', N'Lopez', N'gorgelopez@maxicangrill.com', N'3193780034', NULL, N'2833 Blairs Ferry Rd NE', NULL, N'52402', N'Cedar Rapids', N'IA')
GO
INSERT [dbo].[Caterers] ([CatererID], [CatererName], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State]) VALUES (3, N'Sushi House', N'Lei', N'Mai', N'leimai@shushihouse.com', N'3195408805', NULL, N'2665 Edgewood Pkwy SW', N'Ste 100', N'52404', N'Cedar Rapids', N'IA')
GO
INSERT [dbo].[Caterers] ([CatererID], [CatererName], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State]) VALUES (4, N'Italian Food', N'Givanni', N'Fablo', N'givannifablo@wedgepizzeria.com', N'3193376677', NULL, N'517 S Riverside Dr', NULL, N'52246', N'Iowa City', N'IA')
GO
INSERT [dbo].[Caterers] ([CatererID], [CatererName], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State]) VALUES (5, N'Thai Cusine', N'Phu', N'Chi', N'phuchi@thaicuisine.com', N'3193907747', N'3192221111', N'4362 16th Ave SW', NULL, N'52404', N'Cedar Rapids', N'IA')
GO
SET IDENTITY_INSERT [dbo].[Caterers] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (1, N'george', N'Smith', N'georgesmith@hotmail.com', N'12345678  ', N'          ', N'123 1st ST SE', N'', N'52463', N'Mumbai', N'MN', 0)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (2, N'John', N'Doe', N'piknkitty@snail.com', N'9527652345', N'9534678765', N'234 2nd Ave NE', N'Suit 10', N'55425', N'minneapolis', N'MN', 0)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (3, N'Jennifer', N'Lopez', N'fuzzybunny@slippers.com', N'3196562345', N'3197693421', N'3021 74th ST NE', NULL, N'52403', N'Cedar Rapids', N'IA', 0)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (4, N'Kyle', N'Gorrel', N'kylegorrel@tiger.com', N'3199085343', NULL, N'421 3rd Ave  NE', N'Apt 2', N'52402', N'Hiawatha', N'IA', 0)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (5, N'Chase', N'Simpson', N'test@gmail.com', N'4258790232', N'3193434868', N'3131 New Castle Rd', NULL, N'52405', N'Marion', N'IA', 0)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (6, N'Catherine', N'Abel', N'catherineabel@email.com', N'2198886776', N'3198879876', N'1970 Napa Ct.', N'', N'52240', N'Iowa City', N'IA', 1)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (7, N'Poonam', N'Dubey', N'pdubey@email.com', N'3196515119', N'          ', N'400 1st', N'', N'52401', N'Cedar Rapids', N'IA', 1)
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [EmailID], [PhoneNo1], [PhoneNo2], [Address1], [Address2], [PostalCode], [City], [State], [IsDeleted]) VALUES (8, N'Poonam', N'Dubey', N'pdubey@gmail.com', N'123456789 ', N'1234567890', N'400 1st street', N'SE', N'52401', N'Cedar Rapids', N'IA', 0)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[EventBookings] ON 

GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (1, 1, CAST(N'15:00:00' AS Time), CAST(N'20:00:00' AS Time), CAST(N'2015-05-25' AS Date), 1, 1, 1, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (2, 2, CAST(N'10:30:00' AS Time), CAST(N'14:30:00' AS Time), CAST(N'2015-06-01' AS Date), 3, 2, 2, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (3, 3, CAST(N'14:30:00' AS Time), CAST(N'18:30:00' AS Time), CAST(N'2015-08-15' AS Date), 2, 3, 3, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (4, 4, CAST(N'18:00:00' AS Time), CAST(N'20:30:00' AS Time), CAST(N'2015-07-09' AS Date), 4, 4, 4, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (5, 5, CAST(N'12:00:00' AS Time), CAST(N'16:30:00' AS Time), CAST(N'2015-10-10' AS Date), 5, 5, 2, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (6, 6, CAST(N'18:00:00' AS Time), CAST(N'20:30:00' AS Time), CAST(N'2015-07-22' AS Date), 1, 5, 1, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (7, 5, CAST(N'18:00:00' AS Time), CAST(N'20:30:00' AS Time), CAST(N'2015-07-09' AS Date), 5, 2, 2, 1001)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (1010, 1, CAST(N'12:00:00' AS Time), CAST(N'18:00:00' AS Time), CAST(N'2016-12-12' AS Date), 3, 1, 3, 1000)
GO
INSERT [dbo].[EventBookings] ([BookingID], [EventTypeID], [StartTime], [EndTime], [EventDate], [VenueID], [CustomerID], [CatererID], [UserID]) VALUES (2013, 3, CAST(N'01:00:00' AS Time), CAST(N'02:00:00' AS Time), CAST(N'2016-05-05' AS Date), 3, 4, 4, 1000)
GO
SET IDENTITY_INSERT [dbo].[EventBookings] OFF
GO
SET IDENTITY_INSERT [dbo].[EventStatus] ON 

GO
INSERT [dbo].[EventStatus] ([EventStatusID], [EventStatus], [StatusDesciption]) VALUES (10, N'NotPaid', N'Completed but not paid')
GO
INSERT [dbo].[EventStatus] ([EventStatusID], [EventStatus], [StatusDesciption]) VALUES (11, N'Paid', N'Completed and Paid')
GO
INSERT [dbo].[EventStatus] ([EventStatusID], [EventStatus], [StatusDesciption]) VALUES (12, N'Registered', N'Event is registered')
GO
INSERT [dbo].[EventStatus] ([EventStatusID], [EventStatus], [StatusDesciption]) VALUES (13, N'Cancelled', N'Event is cancelled')
GO
SET IDENTITY_INSERT [dbo].[EventStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[EventType] ON 

GO
INSERT [dbo].[EventType] ([EventTypeID], [EventType], [EventTypeDescription]) VALUES (1, N'Birthday-Girl', N'Girl Frozen Birthday Party ')
GO
INSERT [dbo].[EventType] ([EventTypeID], [EventType], [EventTypeDescription]) VALUES (2, N'Birthday-Boy', N'Boy Elmo Birthday Party')
GO
INSERT [dbo].[EventType] ([EventTypeID], [EventType], [EventTypeDescription]) VALUES (3, N'Baby Shower-Girl', N'For Girl, Pink Baby Shower')
GO
INSERT [dbo].[EventType] ([EventTypeID], [EventType], [EventTypeDescription]) VALUES (4, N'Baby Shower-Boy', N'For Boy, Blue Baby Shower')
GO
INSERT [dbo].[EventType] ([EventTypeID], [EventType], [EventTypeDescription]) VALUES (5, N'Bridal Shower', N'Flora Theme Bridal Shower')
GO
INSERT [dbo].[EventType] ([EventTypeID], [EventType], [EventTypeDescription]) VALUES (6, N'Gradutaion Party', N'Star Theme Graduation Party')
GO
SET IDENTITY_INSERT [dbo].[EventType] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (100, N'Staff', N'Employee')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (101, N'Admin', N'Employee Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (102, N'Accountant', N' Accountant')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1000, N'SDubey', N's12dubey', N'Shrihan', N'Dubey', NULL, N'sdubey@email.com', 1, N'319-693-5555', N'400 1st Street SE', N'Cedar Rapids', N'52401', N'IA', 0)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1001, N'PMishra', N'p23mishra', N'Pavitraa', N'Mishra', NULL, N'pmishra@email.com', 1, N'319-693-5555', N'400 1st Street SE', N'Cedar Rapids', N'52401', N'IA', 0)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1002, N'RMishra', N'r34mishra', N'Rahul', N'Mishra', N'Kumar', N'rmishra@email.com', 1, N'319-693-5555', N'400 1st Street SE', N'Cedar Rapids', N'52401', N'IA', 0)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1004, N'kganesan                                                                                            ', N'test123', N'karthik', N'Ganesan', N'', N'kganesan@yahoo.com', 1, N'3196937844                                        ', N'400 1st street', N'Cedar Rapids', N'52401', N'IA', 1)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1005, N'kganesan                                                                                            ', N'test123', N'Karthik', N'Ganesan', N'', N'kganesan@yahoo.com', 0, N'3196937844                                        ', N'400 2nd street', N'Cedar Rapids', N'52401', N'IA', 1)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1006, N'kganesan                                                                                            ', N'test123', N'Karthik', N'Ganesan', N'', N'kg@email.com', 0, N'3198883333                                        ', N'123 4th ST SE ', N'Cedar Rapids', N'52401', N'IA', NULL)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1007, N'sMishra                                                                                             ', N's78Mishra', N'Shikha', N'Mishra', N'', N'smishra@yahoo.com', 1, N'                                                  ', N'', N'', N'', N'', NULL)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1008, N'Poodu                                                                                               ', N'Test1234', N'Poo', N'Du', N'', N'poodu@yahoo.com', 1, N'                                                  ', N'', N'', N'', N'', NULL)
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Password], [FirstName], [LastName], [MiddleName], [EmailAddress], [IsActive], [Phone], [Address], [City], [Zip], [State], [IsDeleted]) VALUES (1009, N'tcase                                                                                               ', N'testcase123', N'Test', N'Case', N'', N'testcase@email.com', 1, N'                                                  ', N'', N'', N'', N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (20, 1000, 101)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (21, 1001, 102)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (22, 1002, 100)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (24, 1004, 102)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (25, 1005, 102)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (26, 1006, 100)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (27, 1007, 100)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (28, 1008, 100)
GO
INSERT [dbo].[UserRole] ([UserRoleID], [UserId], [RoleId]) VALUES (29, 1009, 100)
GO
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Venue] ON 

GO
INSERT [dbo].[Venue] ([VenueID], [BuildingName], [Address], [PostalCode], [City], [State], [Capacity], [ContactPersonName], [ContactPersonNum]) VALUES (1, N'Hiawatha Community Hall', N'100 Emmons ST', N'52423', N'Hiawatha', N'IA', 100, N'Rachel Spark', N'3193939348')
GO
INSERT [dbo].[Venue] ([VenueID], [BuildingName], [Address], [PostalCode], [City], [State], [Capacity], [ContactPersonName], [ContactPersonNum]) VALUES (2, N'Lowes Park Marion', N'4500 N 10th St', N'52302', N'Marion', N'IA', 200, N'Sharon Robbins', N'3194473590')
GO
INSERT [dbo].[Venue] ([VenueID], [BuildingName], [Address], [PostalCode], [City], [State], [Capacity], [ContactPersonName], [ContactPersonNum]) VALUES (3, N'Grand Reserve Club House', N'6214 Rockwell Dr NE', N'52402', N'Cedar Rapids', N'IA', 50, N'Brita Hopkins', N'3193959676')
GO
INSERT [dbo].[Venue] ([VenueID], [BuildingName], [Address], [PostalCode], [City], [State], [Capacity], [ContactPersonName], [ContactPersonNum]) VALUES (4, N'The Ponte Club House', N'4025 Sherman St NE', N'52402', N'Cedar Rapids', N'IA', 100, N'Jesse Hart', N'3193950660')
GO
INSERT [dbo].[Venue] ([VenueID], [BuildingName], [Address], [PostalCode], [City], [State], [Capacity], [ContactPersonName], [ContactPersonNum]) VALUES (5, N'A Touch of Class', N'5977 Mt. Vernon Road SE', N'52403', N'Cedar Rapids', N'IA', 200, N'Gilbert Francis', N'3192610345')
GO
SET IDENTITY_INSERT [dbo].[Venue] OFF
GO
ALTER TABLE [dbo].[EventBookings]  WITH CHECK ADD  CONSTRAINT [fk_CatererID] FOREIGN KEY([CatererID])
REFERENCES [dbo].[Caterers] ([CatererID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventBookings] CHECK CONSTRAINT [fk_CatererID]
GO
ALTER TABLE [dbo].[EventBookings]  WITH CHECK ADD  CONSTRAINT [fk_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventBookings] CHECK CONSTRAINT [fk_CustomerID]
GO
ALTER TABLE [dbo].[EventBookings]  WITH CHECK ADD  CONSTRAINT [fk_EventTypeID] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventType] ([EventTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventBookings] CHECK CONSTRAINT [fk_EventTypeID]
GO
ALTER TABLE [dbo].[EventBookings]  WITH CHECK ADD  CONSTRAINT [fk_VenueID] FOREIGN KEY([VenueID])
REFERENCES [dbo].[Venue] ([VenueID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventBookings] CHECK CONSTRAINT [fk_VenueID]
GO
USE [EventManagementWebApp_Last]
GO
/****** Object:  StoredProcedure [dbo].[sp_CaterersUpdate]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
			
----------------------------------------------------------------------------------------------------------------------------------------------------------------


--Store Procedure 3
--To update Caterers information by CaterersID

----- EXEC sp_CaterersUpdate 5,'Thai Cusine', 'Phu','Chi','phuchi@thaicuisine.com','3193908888','3192221111','4362 16th Ave SW', NULL,'52404','Cedar Rapids','IA'

CREATE PROC [dbo].[sp_CaterersUpdate] 
	(
		  @CatererID	INT,
		  @CatererName	varchar(100),
		  @FirstName	varchar(50),
		  @LastName		varchar(50),
		  @EmailID		varchar(50),
		  @PhoneNo1		char(10),
		  @PhoneNo2		char(10),
		  @Address1		varchar(100),
		  @Address2		varchar(50),
		  @PostalCode	char(5),
		  @City			varchar(50),
		  @State		char(2)


	)
AS
		  
	UPDATE Caterers
	  SET CatererName = @CatererName,	

		  FirstName	= @FirstName,	
		  
		  LastName	= @LastName,		
		  
		  EmailID	= @EmailID,		
		  
		  PhoneNo1	= @PhoneNo1,		
		  
		  PhoneNo2	= @PhoneNo2,		
		  
		  Address1	= @Address1,		
		  
		  Address2	= @Address2,		
		  
		  PostalCode = @PostalCode,	
		  
		  City		= @City,			
		  
		 [State]	= @State		
	 
	 WHERE CatererID = @CatererID

GO
/****** Object:  StoredProcedure [dbo].[sp_CustomerDelete]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------

----Store Procedure 4
---Delete customer Information from Customer table
----- EXEC sp_CustomerDelete 2;

CREATE PROC [dbo].[sp_CustomerDelete]
		@CustomerID INT
AS
	
	Update Customers 
		SET [IsDeleted] = 1
	WHERE CustomerID = @CustomerID; 

--DELETE FROM Customers WHERE CustomerID = @CustomerID; 


GO
/****** Object:  StoredProcedure [dbo].[sp_CustomerGetByCustomerID]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CustomerGetByCustomerID]
	@customerID int

AS
	SELECT CustomerID, FirstName, LastName, EmailID, PhoneNo1, Address1, PostalCode, City, [State]
	FROM Customers 
	WHERE CustomerID = @customerID
GO
/****** Object:  StoredProcedure [dbo].[sp_CustomersGetAll]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CustomersGetAll]  

AS
	SELECT CustomerID, FirstName, LastName, EmailID, PhoneNo1, Address1, PostalCode, City, [State]
	FROM Customers
	WHERE IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_CustomersInsert]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--To inssert Customer's information by customerID

---EXEC sp_CustomersInsert


CREATE PROC [dbo].[sp_CustomersInsert] 
	(
		@FirstName		VARCHAR(50),
		@LastName		VARCHAR(50),
		@EmailID		VARCHAR(50),
		@PhoneNo1		CHAR(10),
		@PhoneNo2		CHAR(10),
		@Address1		VARCHAR(50),			
		@Address2		VARCHAR(50),			
		@PostalCode		CHAR(5),			
		@City			VARCHAR(50),			
		@State			CHAR(2)
	)
AS
	BEGIN
		INSERT INTO Customers(FirstName, LastName, EmailID, PhoneNo1, PhoneNo2, Address1, Address2, PostalCode, City, [State],[IsDeleted])
		VALUES (@FirstName, @LastName, @EmailID, @PhoneNo1, @PhoneNo2, @Address1, @Address2, @PostalCode, @City, @State,0)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CustomersUpdate]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
-------------------------------------------------------------------------------------------------------------------------------------------------


--Store Procedure 2
--To update Customer's information by customerID

---EXEC sp_CustomersUpdate
----  3,'Jennifer','Lopez','fuzzybunny@slippers.com', '3196562345', '3197222421', '3021 74th ST NE', NULL, '52402', 'Cedar Rapids', 'IA'

CREATE PROC [dbo].[sp_CustomersUpdate] 
	(
		@CustomerID		INT,
		@FirstName		VARCHAR(50),
		@LastName		VARCHAR(50),
		@EmailID		VARCHAR(50),
		@PhoneNo1		CHAR(10),
		@PhoneNo2		CHAR(10),
		@Address1		VARCHAR(50),			
		@Address2		VARCHAR(50),			
		@PostalCode		CHAR(5),			
		@City			VARCHAR(50),			
		@State			CHAR(2)
	)
AS
	UPDATE Customers
		SET FirstName = @FirstName,		
			LastName  =	@LastName,		
			EmailID	  =	@EmailID,		
			PhoneNo1  =	@PhoneNo1,		
			PhoneNo2  =	@PhoneNo2,		
			Address1  =	@Address1,		
			Address2  =	@Address2,		
			PostalCode= @PostalCode,			
			City	  =	@City,			
			[State]	  =	@State

		WHERE CustomerID = @CustomerID


GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@UserID INT
AS
BEGIN


	UPDATE UserProfile 
	SET IsDeleted = 1
	WHERE UserId = @UserID

END

GO
/****** Object:  StoredProcedure [dbo].[sp_EventBookingsGetAll]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_EventBookingsGetAll]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--BookingID, EventTypeID, StartTime, EndTime, EventDate, VenueID, CustomerID, CatererID, UserID

	
	
	SELECT  dbo.EventBookings.BookingID, dbo.EventType.EventTypeID, dbo.EventBookings.StartTime, dbo.EventBookings.EndTime, dbo.EventBookings.EventDate, dbo.Venue.VenueID, dbo.Customers.CustomerID, 
             dbo.Caterers.CatererID, dbo.UserProfile.UserId
	FROM     dbo.EventBookings INNER JOIN
                         dbo.EventType ON dbo.EventBookings.EventTypeID = dbo.EventType.EventTypeID INNER JOIN
                         dbo.Customers ON dbo.EventBookings.CustomerID = dbo.Customers.CustomerID INNER JOIN
                         dbo.Caterers ON dbo.EventBookings.CatererID = dbo.Caterers.CatererID INNER JOIN
                         dbo.UserProfile ON dbo.EventBookings.UserID = dbo.UserProfile.UserId INNER JOIN
                         dbo.Venue ON dbo.EventBookings.VenueID = dbo.Venue.VenueID
	WHERE dbo.Customers.IsDeleted = 0


--SELECT  BookingID, EventTypeID, StartTime, EndTime, EventDate, VenueID, CustomerID, CatererID, UserId	FROM     dbo.EventBookings
    
		

END

GO
/****** Object:  StoredProcedure [dbo].[sp_EventBookingsGetAllDetails]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_EventBookingsGetAllDetails]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

/*
	//BookingID,StartTime,EndTime,EventDate,
	//EventTypeID,EventType,EventTypeDescription,
	//VenueID,BuildingName,
	//CustomerID,FirstName,LastName,
	//CatererID,CatererName,
	//UserID,UserName
*/

    
	SELECT  
			dbo.EventBookings.BookingID, 
			dbo.EventBookings.StartTime, 
			dbo.EventBookings.EndTime, 
			dbo.EventBookings.EventDate,
			 
			dbo.EventType.EventTypeID, 
			dbo.EventType.EventType, 
			dbo.EventType.EventTypeDescription, 

			dbo.Venue.VenueID, 
			dbo.Venue.BuildingName, 

			dbo.Customers.CustomerID, 
			dbo.Customers.FirstName, 
			dbo.Customers.LastName, 
			
			dbo.Caterers.CatererID, 
			dbo.Caterers.CatererName, 

			dbo.UserProfile.UserId,
			dbo.UserProfile.UserName

	FROM     dbo.EventBookings INNER JOIN
                         dbo.EventType ON dbo.EventBookings.EventTypeID = dbo.EventType.EventTypeID INNER JOIN
                         dbo.Customers ON dbo.EventBookings.CustomerID = dbo.Customers.CustomerID INNER JOIN
                         dbo.Caterers ON dbo.EventBookings.CatererID = dbo.Caterers.CatererID INNER JOIN
                         dbo.UserProfile ON dbo.EventBookings.UserID = dbo.UserProfile.UserId INNER JOIN
                         dbo.Venue ON dbo.EventBookings.VenueID = dbo.Venue.VenueID

		

END

GO
/****** Object:  StoredProcedure [dbo].[sp_EventBookingsInsert]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--To inssert Event Bookings

---EXEC sp_EventBookingsInsert


CREATE PROC [dbo].[sp_EventBookingsInsert] 
	(
			@EventTypeID INT ,
            @StartTime TIME,
            @EndTime TIME,
            @EventDate DATETIME,
            @VenueID INT,
            @CustomerID INT,
            @CatererID INT,
            @UserID INT
	)

AS
	BEGIN
		
		INSERT INTO [dbo].[EventBookings]
           ([EventTypeID]
           ,[StartTime]
           ,[EndTime]
           ,[EventDate]
           ,[VenueID]
           ,[CustomerID]
           ,[CatererID]
           ,[UserID])
     VALUES
           (@EventTypeID ,
            @StartTime ,
            @EndTime ,
            @EventDate ,
            @VenueID ,
            @CustomerID ,
            @CatererID ,
            @UserID 
			)


	END
GO
/****** Object:  StoredProcedure [dbo].[sp_EventBookingsUpdate]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--To Update Event Bookings

---EXEC sp_EventBookinsUpdate


CREATE PROC [dbo].[sp_EventBookingsUpdate] 
	(
			@BookingID			INT,
			@EventTypeID	    INT ,
            @StartTime			TIME,
            @EndTime			TIME,
            @EventDate			DATETIME,
            @VenueID			INT,
            @CustomerID		    INT,
            @CatererID			INT,
            @UserID				INT
	)

AS
	UPDATE EventBookings
	SET 
		EventTypeID = @EventTypeID,
		StartTime   = @StartTime,
		EndTime     = @EndTime,
		EventDate   = @EventDate,
		VenueID     = @VenueID,
		CustomerID  = @CustomerID,
		CatererID   = @CatererID,
		UserID      = @UserID

	WHERE BookingID = @BookingID

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCustomersEventInfo]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetAllCustomersEventInfo]
	AS
		SELECT FirstName,LastName, EventType AS EventName, EmailID,  StartTime, EndTime, EventDate, BuildingName
		FROM  Customers as C JOIN EventBookings as B 
		ON C.CustomerID = B.CustomerID
		JOIN EventType AS ET
		ON B.EventTypeID = ET.EventTypeID
		JOIN Venue AS V
		ON B.VenueID = V.VenueID
		where C.IsDeleted = 0
	


GO
/****** Object:  StoredProcedure [dbo].[sp_GetBookingDetails]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Poonam Dubey
-- Create date: Apr-26-2016
-- Description:	Stored Procedure to fetch Booking details based on Booking Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetBookingDetails] 
	-- Add the parameters for the stored procedure here
	@BookingId int = 0 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT BookingID, EventTypeID, StartTime, EndTime, EventDate, VenueID, CustomerID, CatererID 
	FROM EventBookings
	WHERE BookingID = @BookingId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoles]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetRoles]
AS
BEGIN
	
	SET NOCOUNT ON;

   SELECT RoleId,
	      RoleName,
		  RoleDescription 
   FROM Roles
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserProfileDetailsByUserId]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================



-- Author:		Poonam Dubey



-- Create date: Apr.20th.2016



-- Description:	<Description,,>



-- =============================================



CREATE PROCEDURE [dbo].[sp_GetUserProfileDetailsByUserId]



	-- Add the parameter for the stored procedure here

	@UserID INT
AS



BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from



	-- interfering with SELECT statements.



	SET NOCOUNT ON;







    SELECT UP.UserId,



		   UP.UserName,



		   UP.FirstName,



		   UP.LastName,



		   UP.MiddleName,



		   UP.EmailAddress,



		   UP.IsActive,



		   R.RoleName,
		   UP.Phone,
		   UP.Address,
		   UP.City,
		   UP.Zip,
		   UP.State



	FROM UserProfile UP



	INNER JOIN UserRole UR ON UP.UserId = UR.UserId



	INNER JOIN Roles R ON UR.RoleId = R.RoleId 



	WHERE UP.UserId = @UserID



		  AND ISNULL(IsDeleted,0) = 0



END




GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserRoleByUserId]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Author:		Poonam Dubey

-- Create date: Apr.20th.2016

-- Description:	<Description,,>

-- =============================================

CREATE PROCEDURE [dbo].[sp_GetUserRoleByUserId]

	-- Add the parameter for the stored procedure here
	@UserID INT


AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;



    SELECT UP.UserId,

		   UP.UserName,

		   UP.FirstName,

		   UP.LastName,

		   UP.MiddleName,

		   UP.EmailAddress,

		   UP.IsActive,

		   R.RoleName

	FROM UserProfile UP

	INNER JOIN UserRole UR ON UP.UserId = UR.UserId

	INNER JOIN Roles R ON UR.RoleId = R.RoleId 

	WHERE UP.UserId = @UserID

		  AND ISNULL(IsDeleted,0) = 0

END



GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserRoleDetailByUserId]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================



-- Author:		<Author,,Name>



-- Create date: <Create Date,,>



-- Description:	<Description,,>



-- =============================================



CREATE PROCEDURE [dbo].[sp_GetUserRoleDetailByUserId]



	-- Add the parameters for the stored procedure here



	@username VARCHAR(100),



	@password NVARCHAR(50)



AS



BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from



	-- interfering with SELECT statements.



	SET NOCOUNT ON;







    SELECT UP.UserName,



		   UP.FirstName,



		   UP.LastName,



		   UP.MiddleName,



		   UP.EmailAddress,



		   UP.IsActive,



		   R.RoleName



	FROM UserProfile UP



	INNER JOIN UserRole UR ON UP.UserId = UR.UserId



	INNER JOIN Roles R ON UR.RoleId = R.RoleId 



	WHERE UserName = @username 



		  AND 



		  [Password] = @password



		  AND 



		  ISNULL(IsDeleted,0) = 0



END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateUser]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertUpdateUser] 
	@IsInsert BIT,
	@UserId INT,
	@UserName VARCHAR(100),
	@Password NVARCHAR(50),
	@FirstName VARCHAR(200),
	@LastName VARCHAR(200),
	@MiddleName VARCHAR(50),
	@EmailAddress NVARCHAR(200),
	@IsActive BIT,
	@Phone NVARCHAR(50),
	@Address NVARCHAR(100),
	@City NVARCHAR(20),
	@Zip NVARCHAR(10),
	@State NVARCHAR(30),
	@RoleName VARCHAR(50)

AS
BEGIN

			DECLARE @RoleID INT = 0
			SET @RoleID = (SELECT RoleId FROM Roles WHERE RoleName = @RoleName)
	IF(@IsInsert = 1)
		BEGIN

		
			DECLARE @NewUserID INT = 0



			INSERT INTO UserProfile (UserName, [Password], FirstName, LastName, MiddleName, EmailAddress, IsActive, Phone, [Address], City, Zip, [State])
			VALUES (@UserName,@Password,@FirstName,@LastName,@MiddleName,@EmailAddress,@IsActive,@Phone,@Address, @City, @Zip,@State)

			SET @NewUserID = (SELECT @@IDENTITY)
			

			INSERT INTO UserRole(UserId, RoleId)
			VALUES (@NewUserID, @RoleID)

		END

		ELSE

		BEGIN
			UPDATE UserProfile 
			SET UserName =@UserName,
			 FirstName = @FirstName,
			  LastName = @LastName, 
			  MiddleName = @MiddleName, 
			  EmailAddress = @EmailAddress,  
			  IsActive = @IsActive, 
			  Phone = @Phone, 
			  [Address] = @Address, 
			  City = @City, 
			  Zip = @Zip, 
			  [State] = @State
			  WHERE UserId = @UserId


			  UPDATE UserRole
			  SET RoleId = @RoleID
			  Where UserId = @UserId
		END
	
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertVenue]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


-----------------------------------------------------------------------------------------------------------------------------------------------------------

----Store Procedure- 6------

--- Insert New Venue to the Venue Table 
	--EXEC sp_InsertVenue 'Bellatorianna Gourmet Cupcakery', '2515 8th ave', '52402', 'Marion', 'IA', 150, 'Bruce Francis', '3193731087'	

CREATE PROC [dbo].[sp_InsertVenue]
	@BuildingName		VARCHAR(100),
	@Address			VARCHAR(50),
	@PostalCode			CHAR(5),
	@City			    VARCHAR(50),
	@State				CHAR(2),
	@Capacity			SMALLINT,
	@ContactPersonName	VARCHAR(50),
	@ContactPersonNum	CHAR(10)

AS
	IF @BuildingName IS NULL
		THROW 50001, 'Building name cannot be null!!', 1;
	IF @Address IS NULL
		THROW 50001, 'Address cannot be null!!', 1;
	IF @PostalCode IS NULL
	THROW 50001, 'Postal Code cannot be null!!', 1;
	IF @City IS NULL
		THROW 50001, 'City cannot be null!!', 1;
	IF @State IS NULL
		THROW 50001, 'State cannot be null!!', 1;
	IF @Capacity IS NULL
		THROW 50001, 'Capacity cannot be null!!', 1;
	IF @ContactPersonName IS NULL
		THROW 50001, 'ConatctPersonName cannot be null!!', 1;
	IF @ContactPersonNum IS NULL
		THROW 50001, 'ConatctPersonNumbercannot be null!!', 1;
	ELSE
		BEGIN
			IF (NOT EXISTS (SELECT * FROM Venue WHERE BuildingName = @BuildingName AND [Address] = @Address ))
				BEGIN
					INSERT INTO Venue(BuildingName, [Address], PostalCode, City, [State], Capacity, ContactPersonName, ContactPersonNum)
					VALUES (@BuildingName, @Address, @PostalCode, @City, @State, @Capacity, @ContactPersonName, @ContactPersonNum)
				END
		END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCustomerEmailIDValidate]    Script Date: 5/4/2016 10:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------

----Store Procedure 5
---Update Email address with validation
--- EXEC sp_UpdateCustomerEmailIDValidate 1,'abc@abc.com'

CREATE PROC [dbo].[sp_UpdateCustomerEmailIDValidate]
	@CustomerID INT,
	@EmailID	VARCHAR(50)
AS
	IF @EmailID IS NULL
		THROW 50001,'Email Address can not be null!!',1
		 
	ELSE
	UPDATE Customers
	SET  EmailID = @EmailID
	WHERE CustomerID = @CustomerID

