USE [ClaimManagement]
GO

/****** Object:  Table [dbo].[MediClaim]    Script Date: 9/6/2022 10:31:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MediClaim](
	[Id] [int] NOT NULL,
	[PatientName] [varchar](100) NULL,
	[Age] [int] NULL,
	[ClaimCause] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

