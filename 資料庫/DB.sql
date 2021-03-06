USE [Poc_InsuranceSys]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2018/7/18 下午 04:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Custid] [int] NOT NULL,
	[CustCountry] [char](2) NULL,
	[ROCID] [varchar](10) NULL,
	[PASSPOART_CODE] [char](3) NULL,
	[PASSPOART_NO] [varchar](30) NULL,
	[Sex] [char](1) NOT NULL,
	[CustNameLocal] [nvarchar](50) NULL,
	[CustNameEn] [nvarchar](50) NULL,
 CONSTRAINT [Pk_Customer_Custid] PRIMARY KEY CLUSTERED 
(
	[Custid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDetail]    Script Date: 2018/7/18 下午 04:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetail](
	[Custid] [int] NOT NULL,
	[PhoneHomeAreaCode] [char](5) NULL,
	[PhoneHome] [char](10) NULL,
	[PhoneHomeExt] [char](5) NULL,
	[PhoneCorpAreaCode] [char](5) NULL,
	[PhoneCorp] [char](10) NULL,
	[PhoneCorpExt] [char](5) NULL,
	[PhoneMobileATW] [char](10) NULL,
	[AddressPermanent] [nvarchar](200) NULL,
	[AddressPermanentZipcode] [char](10) NULL,
	[AddressCorrespondence] [nvarchar](200) NULL,
	[AddressCorrespondenceZipcode] [char](10) NULL,
	[Email] [nvarchar](200) NULL,
 CONSTRAINT [Pk_CustomerDetail_Custid] PRIMARY KEY CLUSTERED 
(
	[Custid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysCode]    Script Date: 2018/7/18 下午 04:40:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysCode](
	[CodeId] [char](8) NOT NULL,
	[CodeKind] [char](20) NOT NULL,
	[CodeMsg] [nvarchar](100) NOT NULL,
	[CodeMsgLang] [char](8) NOT NULL,
 CONSTRAINT [Pk_SysCode_CodeId] PRIMARY KEY CLUSTERED 
(
	[CodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2018/7/18 下午 04:40:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[LoginID] [char](30) NOT NULL,
	[Password] [nvarchar](1024) NOT NULL,
	[Salt] [nvarchar](128) NOT NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[PhoneCorpAreaCode] [char](5) NULL,
	[PhoneCorp] [char](10) NULL,
	[PhoneCorpExt] [char](5) NULL,
	[Department] [char](10) NOT NULL,
	[SysRole] [char](10) NOT NULL,
 CONSTRAINT [Pk_UserInfo_LoginID] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([Custid], [CustCountry], [ROCID], [PASSPOART_CODE], [PASSPOART_NO], [Sex], [CustNameLocal], [CustNameEn]) VALUES (10000001, N'TW', N'A195947720', NULL, NULL, N'M', N'王小明', N'WANG MING')
INSERT [dbo].[Customer] ([Custid], [CustCountry], [ROCID], [PASSPOART_CODE], [PASSPOART_NO], [Sex], [CustNameLocal], [CustNameEn]) VALUES (10000002, N'TW', N'H272848778', NULL, NULL, N'F', N'林緻玲', N'LIN KITTY')
INSERT [dbo].[CustomerDetail] ([Custid], [PhoneHomeAreaCode], [PhoneHome], [PhoneHomeExt], [PhoneCorpAreaCode], [PhoneCorp], [PhoneCorpExt], [PhoneMobileATW], [AddressPermanent], [AddressPermanentZipcode], [AddressCorrespondence], [AddressCorrespondenceZipcode], [Email]) VALUES (10000001, N'02   ', N'22008938  ', NULL, NULL, NULL, NULL, N'0936879102', N'台北市中正區小明路1號', N'100       ', NULL, NULL, N'ming@happy.com.tw')
INSERT [dbo].[CustomerDetail] ([Custid], [PhoneHomeAreaCode], [PhoneHome], [PhoneHomeExt], [PhoneCorpAreaCode], [PhoneCorp], [PhoneCorpExt], [PhoneMobileATW], [AddressPermanent], [AddressPermanentZipcode], [AddressCorrespondence], [AddressCorrespondenceZipcode], [Email]) VALUES (10000002, N'03   ', N'3609830   ', NULL, N'03   ', N'3608739   ', N'789  ', N'0973987123', N'桃園市桃園區介壽路一段112號', N'330       ', NULL, NULL, N'lin@abc.com.tw')
ALTER TABLE [dbo].[CustomerDetail] ADD  CONSTRAINT [defo_CustomerDetail_PhoneMobileATW]  DEFAULT ('') FOR [PhoneMobileATW]
GO
ALTER TABLE [dbo].[CustomerDetail]  WITH CHECK ADD  CONSTRAINT [fk_customerd_customerd] FOREIGN KEY([Custid])
REFERENCES [dbo].[CustomerDetail] ([Custid])
GO
ALTER TABLE [dbo].[CustomerDetail] CHECK CONSTRAINT [fk_customerd_customerd]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [LoginID] CHECK  (([LoginID]>=(6) AND [LoginID]<=(30)))
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [LoginID]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Custid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶國家地區別\nISO 3166-1，兩碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'CustCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中國民國身分證、統一編號、統一證號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'ROCID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'護照國碼(外籍人士)，ISO 3166-1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'PASSPOART_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'護照號碼(外籍人士)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'PASSPOART_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性別\nM:男性\nF:女性\nA:無性別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶姓名(母語)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'CustNameLocal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶姓名(英文)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer', @level2type=N'COLUMN',@level2name=N'CustNameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶主檔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'Custid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'家中電話號碼，區碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneHomeAreaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'家中電話號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneHome'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'家中電話號碼，分機號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneHomeExt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司電話號碼，區碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneCorpAreaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司電話號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneCorp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司電話號碼，分機號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneCorpExt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行動電話，台灣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'PhoneMobileATW'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'戶籍地址(永久地址)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'AddressPermanent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'郵遞區號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'AddressPermanentZipcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通訊地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'AddressCorrespondence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'郵遞區號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail', @level2type=N'COLUMN',@level2name=N'AddressCorrespondenceZipcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客戶資料明細檔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三碼英文+5碼數字,比如:\nDEP00001' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysCode', @level2type=N'COLUMN',@level2name=N'CodeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CodeKind=''Department''  部門代碼對照' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysCode', @level2type=N'COLUMN',@level2name=N'CodeKind'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'當地語系訊息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysCode', @level2type=N'COLUMN',@level2name=N'CodeMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zh-TW:繁體中文，台灣\nzh-HK:繁體中文，香港特別行政區\nzh-MO:繁體中文，澳門特別行政區\nzh-CN:簡體中文，中國大陸\nen-US:英文，美國\nen-GB:英文，英國' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysCode', @level2type=N'COLUMN',@level2name=N'CodeMsgLang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統代碼對照表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登入ID，僅限英文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'LoginID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加密過的密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電子郵件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'EmailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司電話號碼，區碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PhoneCorpAreaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司電話號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PhoneCorp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司電話號碼，分機號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PhoneCorpExt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統操作權限\nUSER 一般使用者\nADMIN 系統管理者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'SysRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統使用者主檔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo'
GO
