# Database Unit of Work

## Problem it solves
Often times developers will want to only do certain DB actions together as one atomic transaction. Either succeed together or fail together. 
The unit of work pattern helps wrap one or more database actions into a transaction easily across multiple repositories.

## Common Uses
If a user performs an action which will affect several entities\repos in the DB, it's best to make sure they are wrapped in a transaction. This pattern uses the unit of work to scope the items that need to work together or fail together.

## DB Schema
If you'd like to test this out live, you may want the schema below:

```GO
CREATE TABLE [dbo].[MyDbEntities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_MyDbEntity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MyOtherDbEntities]    Script Date: 5/29/2017 2:37:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyOtherDbEntities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [nchar](10) NULL,
 CONSTRAINT [PK_MyOtherDbEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
