USE [Artisian]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[State] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
	[PostalCode] [varchar](255) NOT NULL,
 CONSTRAINT [address_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artisian]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artisian](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NOT NULL,
 CONSTRAINT [artisian_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankDetail]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dataArtisianId] [int] NOT NULL,
	[accountCurrencyType] [nvarchar](50) NOT NULL,
	[accountNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BankDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
 CONSTRAINT [category_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactArtisian]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactArtisian](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phone] [varchar](255) NOT NULL,
	[dataArtisianId] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [contactartisian_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactCustomer]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactCustomer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phone] [varchar](255) NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [contactcustomer_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[addressId] [int] NOT NULL,
 CONSTRAINT [customer_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataArtisian]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataArtisian](
	[artisianId] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](250) NULL,
	[addressId] [int] NOT NULL,
 CONSTRAINT [dataartisian_id_primary] PRIMARY KEY CLUSTERED 
(
	[artisianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryOrder]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shippingAddressId] [int] NOT NULL,
	[deliveryAddressId] [int] NOT NULL,
	[comment] [varchar](255) NULL,
	[deliveryProviderId] [int] NOT NULL,
 CONSTRAINT [pk_DeliveryOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryProvider]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryProvider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [varchar](250) NULL,
 CONSTRAINT [PK_DeliveryProvider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentManufactory]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentManufactory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[manufactoryId] [int] NOT NULL,
	[description] [nvarchar](150) NULL,
 CONSTRAINT [PK_DepartmentManufactory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentProduct]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentProduct](
	[departmentId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[inProduces] [bit] NOT NULL,
 CONSTRAINT [PK_DepartmentProduct] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC,
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[departmentId] [int] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManufactoryHub]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManufactoryHub](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NumberEmployees] [int] NOT NULL,
	[artisianId] [int] NOT NULL,
	[addressId] [int] NOT NULL,
	[description] [varchar](250) NOT NULL,
 CONSTRAINT [manufactoryhub_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NetworkArtisian]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NetworkArtisian](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[socialNetwork] [nvarchar](500) NULL,
	[descriptioon] [nvarchar](500) NULL,
	[dataArtisianId] [int] NOT NULL,
 CONSTRAINT [PK_NetworkArtisian] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[orderDate] [varchar](255) NOT NULL,
	[totalAmount] [decimal](8, 2) NOT NULL,
	[deliveryId] [int] NOT NULL,
 CONSTRAINT [order_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [smallint] NOT NULL,
 CONSTRAINT [orderitem_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[amount] [decimal](8, 2) NOT NULL,
	[paymentMethodId] [int] NOT NULL,
	[isSuccessful] [bit] NOT NULL,
 CONSTRAINT [payment_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[method] [varchar](255) NOT NULL,
 CONSTRAINT [paymentmethod_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCatalog]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatalog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoryId] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[price] [decimal](8, 2) NOT NULL,
	[availability] [bit] NOT NULL,
 CONSTRAINT [product_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rewiew]    Script Date: 28.06.2023 14:40:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewiew](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[customerId] [int] NOT NULL,
	[rating] [int] NOT NULL,
	[comment] [varchar](255) NOT NULL,
 CONSTRAINT [rewiew_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DepartmentProduct] ADD  CONSTRAINT [DF_DepartmentProduct_produces]  DEFAULT ((0)) FOR [inProduces]
GO
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [DF_Payment_isSuccessful]  DEFAULT ((0)) FOR [isSuccessful]
GO
ALTER TABLE [dbo].[BankDetail]  WITH CHECK ADD  CONSTRAINT [FK_BankDetail_DataArtisian] FOREIGN KEY([dataArtisianId])
REFERENCES [dbo].[DataArtisian] ([artisianId])
GO
ALTER TABLE [dbo].[BankDetail] CHECK CONSTRAINT [FK_BankDetail_DataArtisian]
GO
ALTER TABLE [dbo].[ContactArtisian]  WITH CHECK ADD  CONSTRAINT [FK_ContactArtisian_DataArtisian] FOREIGN KEY([dataArtisianId])
REFERENCES [dbo].[DataArtisian] ([artisianId])
GO
ALTER TABLE [dbo].[ContactArtisian] CHECK CONSTRAINT [FK_ContactArtisian_DataArtisian]
GO
ALTER TABLE [dbo].[ContactCustomer]  WITH CHECK ADD  CONSTRAINT [customerId] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[ContactCustomer] CHECK CONSTRAINT [customerId]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [customer_addressid_foreign] FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [customer_addressid_foreign]
GO
ALTER TABLE [dbo].[DataArtisian]  WITH CHECK ADD  CONSTRAINT [FK_DataArtisian_Address] FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[DataArtisian] CHECK CONSTRAINT [FK_DataArtisian_Address]
GO
ALTER TABLE [dbo].[DataArtisian]  WITH CHECK ADD  CONSTRAINT [FK_DataArtisian_Artisian] FOREIGN KEY([artisianId])
REFERENCES [dbo].[Artisian] ([id])
GO
ALTER TABLE [dbo].[DataArtisian] CHECK CONSTRAINT [FK_DataArtisian_Artisian]
GO
ALTER TABLE [dbo].[DeliveryOrder]  WITH CHECK ADD  CONSTRAINT [fk_deliveryorder_address_delivery] FOREIGN KEY([deliveryAddressId])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[DeliveryOrder] CHECK CONSTRAINT [fk_deliveryorder_address_delivery]
GO
ALTER TABLE [dbo].[DeliveryOrder]  WITH CHECK ADD  CONSTRAINT [fk_deliveryorder_address_shipping] FOREIGN KEY([shippingAddressId])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[DeliveryOrder] CHECK CONSTRAINT [fk_deliveryorder_address_shipping]
GO
ALTER TABLE [dbo].[DeliveryOrder]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryProvider_DeliveryOrder] FOREIGN KEY([deliveryProviderId])
REFERENCES [dbo].[DeliveryProvider] ([id])
GO
ALTER TABLE [dbo].[DeliveryOrder] CHECK CONSTRAINT [FK_DeliveryProvider_DeliveryOrder]
GO
ALTER TABLE [dbo].[DepartmentManufactory]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentManufactory_ManufactoryHub] FOREIGN KEY([manufactoryId])
REFERENCES [dbo].[ManufactoryHub] ([id])
GO
ALTER TABLE [dbo].[DepartmentManufactory] CHECK CONSTRAINT [FK_DepartmentManufactory_ManufactoryHub]
GO
ALTER TABLE [dbo].[DepartmentProduct]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentProduct_DepartmentManufactory] FOREIGN KEY([departmentId])
REFERENCES [dbo].[DepartmentManufactory] ([id])
GO
ALTER TABLE [dbo].[DepartmentProduct] CHECK CONSTRAINT [FK_DepartmentProduct_DepartmentManufactory]
GO
ALTER TABLE [dbo].[DepartmentProduct]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentProduct_ProductCatalog] FOREIGN KEY([productId])
REFERENCES [dbo].[ProductCatalog] ([id])
GO
ALTER TABLE [dbo].[DepartmentProduct] CHECK CONSTRAINT [FK_DepartmentProduct_ProductCatalog]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_DepartmentManufactory] FOREIGN KEY([departmentId])
REFERENCES [dbo].[DepartmentManufactory] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Table_1_DepartmentManufactory]
GO
ALTER TABLE [dbo].[ManufactoryHub]  WITH CHECK ADD  CONSTRAINT [manufactoryhub_addressid_foreign] FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[ManufactoryHub] CHECK CONSTRAINT [manufactoryhub_addressid_foreign]
GO
ALTER TABLE [dbo].[ManufactoryHub]  WITH CHECK ADD  CONSTRAINT [manufactoryhub_artisianid_foreign] FOREIGN KEY([artisianId])
REFERENCES [dbo].[Artisian] ([id])
GO
ALTER TABLE [dbo].[ManufactoryHub] CHECK CONSTRAINT [manufactoryhub_artisianid_foreign]
GO
ALTER TABLE [dbo].[NetworkArtisian]  WITH CHECK ADD  CONSTRAINT [FK_NetworkArtisian_DataArtisian] FOREIGN KEY([dataArtisianId])
REFERENCES [dbo].[DataArtisian] ([artisianId])
GO
ALTER TABLE [dbo].[NetworkArtisian] CHECK CONSTRAINT [FK_NetworkArtisian_DataArtisian]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_DeliveryOrder] FOREIGN KEY([deliveryId])
REFERENCES [dbo].[DeliveryOrder] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_DeliveryOrder]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [order_customerid_foreign] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [order_customerid_foreign]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_ProductCatalog] FOREIGN KEY([productId])
REFERENCES [dbo].[ProductCatalog] ([id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_ProductCatalog]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [orderitem_orderid_foreign] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [orderitem_orderid_foreign]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [payment_paymentmethodid_foreign] FOREIGN KEY([paymentMethodId])
REFERENCES [dbo].[PaymentMethod] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [payment_paymentmethodid_foreign]
GO
ALTER TABLE [dbo].[ProductCatalog]  WITH CHECK ADD  CONSTRAINT [product_categoryid_foreign] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[ProductCatalog] CHECK CONSTRAINT [product_categoryid_foreign]
GO
ALTER TABLE [dbo].[Rewiew]  WITH CHECK ADD  CONSTRAINT [rewiew_customerid_foreign] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Rewiew] CHECK CONSTRAINT [rewiew_customerid_foreign]
GO
ALTER TABLE [dbo].[Rewiew]  WITH CHECK ADD  CONSTRAINT [rewiew_prodictid_foreign] FOREIGN KEY([productId])
REFERENCES [dbo].[ProductCatalog] ([id])
GO
ALTER TABLE [dbo].[Rewiew] CHECK CONSTRAINT [rewiew_prodictid_foreign]
GO
