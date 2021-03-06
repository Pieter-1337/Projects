create database Bank
go
use Bank
go

CREATE TABLE [Klanten](
	[KlantNr] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
 CONSTRAINT [Klanten$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[KlantNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Klanten] ON
INSERT [Klanten] ([KlantNr], [Naam]) VALUES (1, N'Asterix')
INSERT [Klanten] ([KlantNr], [Naam]) VALUES (2, N'Obelix')
SET IDENTITY_INSERT [Klanten] OFF
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Rekeningen](
	[RekeningNr] [nvarchar](50) NOT NULL,
	[Klantnr] [int] NOT NULL,
	[Saldo] [money] NOT NULL,
 CONSTRAINT [Rekeningen$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[RekeningNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [Rekeningen] ([RekeningNr], [Klantnr], [Saldo]) VALUES (N'111-1111111-70', 1, 1000.00)
INSERT [Rekeningen] ([RekeningNr], [Klantnr], [Saldo]) VALUES (N'222-2222222-43', 1, 2000.00)
INSERT [Rekeningen] ([RekeningNr], [Klantnr], [Saldo]) VALUES (N'333-3333333-16', 2, 3000.00)
INSERT [Rekeningen] ([RekeningNr], [Klantnr], [Saldo]) VALUES (N'444-4444444-86', 2, 4000.00)
ALTER TABLE [Rekeningen] ADD  DEFAULT ((0)) FOR [Saldo]
GO
ALTER TABLE [Klanten]  WITH NOCHECK ADD  CONSTRAINT [SSMA_CC$Klanten$Naam$disallow_zero_length] CHECK  ((len([Naam])>(0)))
GO
ALTER TABLE [Klanten] CHECK CONSTRAINT [SSMA_CC$Klanten$Naam$disallow_zero_length]
GO
ALTER TABLE [Rekeningen]  WITH NOCHECK ADD  CONSTRAINT [SSMA_CC$Rekeningen$RekeningNr$disallow_zero_length] CHECK  ((len([RekeningNr])>(0)))
GO
ALTER TABLE [Rekeningen] CHECK CONSTRAINT [SSMA_CC$Rekeningen$RekeningNr$disallow_zero_length]
GO
ALTER TABLE [Rekeningen]  WITH NOCHECK ADD  CONSTRAINT [Rekeningen$KlantenRekeningen] FOREIGN KEY([Klantnr])
REFERENCES [Klanten] ([KlantNr])
GO
ALTER TABLE [Rekeningen] CHECK CONSTRAINT [Rekeningen$KlantenRekeningen]
GO
