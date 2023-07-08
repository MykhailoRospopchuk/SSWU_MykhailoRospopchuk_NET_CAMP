using System;
using CrudEF.Model;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Artisian",
               columns: new[] { "description" },
               values: new object[,]
               {
                    {"Blacksmith" },
                    {"Сeramist" },
                    {"Painter" },
               });
            migrationBuilder.InsertData(
               table: "Address",
               columns: new[] {"City", "State", "Country", "PostalCode" },
               values: new object[,]
               {
                    {"Kyiv", "Darnytsia", "Ukraine", "02068" },
                    {"Kyiv", "Dnipro", "Ukraine", "02125" },
                    {"Kyiv", "Obolon", "Ukraine", "04205" },
                    {"Lviv", "Sikhiv", "Ukraine", "79066" },
                    {"Lviv", "Shevchenko", "Ukraine", "79037" }
               });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] {"name", "description" },
                values: new object[,]
                {
                    {"Metal products", "Description 1" },
                    {"Ceramist  products", "Description 2" },
                    {"Pictures  products", "Description 3" }
                });
            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] {"method" },
                values: new object[,]
                {
                    {"Method 1" },
                    {"Method 2" },
                });
            migrationBuilder.InsertData(
                table: "CustomerDiscount",
                columns: new[] { "discount" },
                values: new object[,]
                {
                    {"10" },
                    {"15" },
                });
            migrationBuilder.InsertData(
               table: "Customer",
               columns: new[] { "name", "adressId"},
               values: new object[,]
               {
                    {"Borus", 1 },
                    {"Anton", 2 },
                    {"Oleg", 3 },
               });

            migrationBuilder.InsertData(
               table: "ContactCustomer",
               columns: new[] { "email", "phone", "customerId" },
               values: new object[,]
               {
                    {"borus@example.com", "1234567890", 1 },
                    {"anton@example.com", "9876543210", 2 },
                    {"oleg@example.com", "1231222230", 3 },
               });

            migrationBuilder.InsertData(
               table: "ProductCatalog",
               columns: new[] { "categoryId", "name", "description", "availability" },
               values: new object[,]
               {
                    {1, "Product Metal", true },
                    {2, "Ceramist product", true },
                    {3, "Pictures product", true },
               });
            migrationBuilder.InsertData(
               table: "ProductPrice",
               columns: new[] { "productId", "beginDate", "EndDate", "price" },
               values: new object[,]
               {
                    {1, DateTime.Today.AddMonths(-2), DateTime.Today.AddMonths(-1), 10.99m },
                    {1, DateTime.Now, DateTime.Today.AddMonths(1), 19.99m },
                    {2, DateTime.Now, DateTime.Today.AddMonths(3), 29.99m },
                    {3, DateTime.Now, DateTime.Today.AddMonths(2), 15.09m }
               });
            migrationBuilder.InsertData(
               table: "DeliveryProvider",
               columns: new[] {"name", "description" },
               values: new object[,]
               {
                    {"Nove Poshta", "Private carrier" },
                    {"UkrPoshta", "State carrier" }
               });
            migrationBuilder.InsertData(
                table: "DeiveryOrder",
                columns: new[] { "shippingAddressId", "deliveryAddressId", "comment", "deliveryProviderId" },
                values: new object[,]
                {
                    {1, 4, "Delivery order comment 1", 1},
                    {2, 5, "Delivery order comment 2", 2}
                });
            migrationBuilder.InsertData(
                table: "DataArtisian",
                columns: new[] { "artisianId", "description", "addressId", "name" },
                values: new object[,]
                {
                    {1, "Artisan 1", 1, "First Artisan 1" },
                    {2, "Artisan 2", 2, "Second Artisan 2" },
                    {3, "Artisan 3", 3, "Third Artisan 3" },
                });
            migrationBuilder.InsertData(
                table: "BankDetail",
                columns: new[] { "dataArtisianId", "accountCurrencyType", "accountNumber" },
                values: new object[,]
                {
                    {1, "MasterCard", "4476284580680822" },
                    {2, "Visa", "4476281466083444" },
                    {3, "Visa", "4476288780662563" },
                });
            migrationBuilder.InsertData(
                table: "NetworkArtisian",
                columns: new[] { "socialNetwork", "description", "dataArtisianId" },
                values: new object[,]
                {
                    {"instagram-url", "Instagram Page", 1 },
                    {"youtub-chanel-url", "YouTube Chanel", 1 },
                    {"telegram-url", "Telegram Chanel", 2 },
                    {"facebook-url", "Facebook Page", 3 },
                });
            migrationBuilder.InsertData(
                table: "ContactArtisian",
                columns: new[] { "email", "phone", "dataArtisianId" },
                values: new object[,]
                {
                    {"email1@example.com", "1234567890", 1 },
                    {"email2@example.com", "9876543210", 2 },
                    {"email3@example.com", "2342342310", 3 },
                });
            migrationBuilder.InsertData(
                table: "ManufactoryHub",
                columns: new[] { "artisianId", "addressId", "description" },
                values: new object[,]
                {
                    {1, "1234567890", 1, "First Artisian manufactory"},
                    {2, "9876543210", 2, "Second Artisian manufactory"},
                    {3, "2342342310", 3, "Third Artisian manufactory"},
                    {1, "1234567890", 2, "First Artisian manufactory"}
                });
            migrationBuilder.InsertData(
                table: "DepartmentManufactory",
                columns: new[] { "name", "manufactoryId", "description" },
                values: new object[,]
                {
                    {"First stage Blacksmith", 1, "First Artisian department"},
                    {"Second stage Blacksmith", 4, "First Artisian department"},
                    {"First stage Ceramist", 2, "Second Artisian department"},
                    {"First stage Painter", 3, "Third Artisian department"}
                });
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] {"name", "surname", "phone", "email", "departmentId"},
                values: new object[,]
                {
                    {"Ivan", "Svitailo", "9687745219", "ivan@example.com", 1 },
                    {"Vasya", "Lybka", "9232745219", "vasya@example.com", 2 },
                    {"Oleg", "Khachatryan", "3877745234", "oleg@example.com", 3 },
                    {"Ignat", "Sobko", "12232745255", "ignat@example.com", 4 }
                });
            migrationBuilder.InsertData(
                table: "DepartmentProduct",
                columns: new[] { "departmentId", "productId", "inProduces", "countProduct" },
                values: new object[,]
                {
                    {1, 1, "9687745219", true, 12 },
                    {2, 2, "9232745219", true, 223 },
                    {3, 2, "3877745234", true, 31 },
                    {4, 3, "12232745255", true, 434 }
                });
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] {"customerId", "orderDate", "deliveryId"},
                values: new object[,]
                {
                    {1, "First Order", 1 },
                    {2, "Second Order", 2 }
                });
            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "orderId", "productId", "quantity" },
                values: new object[,]
                {
                    {1, 1, 4 },
                    {1, 1, 4 },
                    {2, 3, 5 }
                });
            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] {"totalAmount", "CustomerDiscount", "amountToPay"},
                values: new object[,]
                {
                    {55, 1, 49.5 },
                    {147, 2, 124.95 }
                });
            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "date", "amount", "PaymentMethod", "isSuccessful", "receipId" },
                values: new object[,]
                {
                    {DateTime.Now, 49.5, 1, true, 1 },
                    {DateTime.Now, 124.95, 1, false, 2 },
                    {DateTime.Now, 124.95, 2, true, 2 }
                });
            migrationBuilder.InsertData(
                table: "Rewiew",
                columns: new[] {"productId", "customerId", "commnet"},
                values: new object[,]
                {
                    {1, 2, "Comment for the second product" },
                    {3, 1, "Comment for the third product" },
                    {2, 3, "Comment for the second product" },
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

           

            //migrationBuilder.Sql("TRUNCATE TABLE ContactArtisian");

            //migrationBuilder.Sql("TRUNCATE TABLE ContactCustomer");

            //migrationBuilder.Sql("TRUNCATE TABLE DepartmentProduct");

            //migrationBuilder.Sql("TRUNCATE TABLE Employee");

            //migrationBuilder.Sql("TRUNCATE TABLE NetworkArtisian");

            //migrationBuilder.Sql("TRUNCATE TABLE OrderItem");

            
            //migrationBuilder.Sql("TRUNCATE TABLE Payment");
            //migrationBuilder.Sql("TRUNCATE TABLE PaymentMethod");

            //migrationBuilder.Sql("TRUNCATE TABLE ProductPrice");

            //migrationBuilder.Sql("TRUNCATE TABLE Rewiew");

            

           

            

            

            //migrationBuilder.Sql("TRUNCATE TABLE ProductCatalog");

            //migrationBuilder.Sql("TRUNCATE TABLE ManufactoryHub");

            //migrationBuilder.Sql("TRUNCATE TABLE CustomerDiscount");

            //migrationBuilder.Sql("TRUNCATE TABLE Receipt");

            //migrationBuilder.Sql("TRUNCATE TABLE Order");

            //migrationBuilder.Sql("TRUNCATE TABLE Category");

            

            //migrationBuilder.Sql("TRUNCATE TABLE DeliveryOrder");

            //migrationBuilder.Sql("TRUNCATE TABLE Customer");



            //migrationBuilder.Sql("TRUNCATE TABLE Artisian");

            //migrationBuilder.Sql("TRUNCATE TABLE DeliveryProvider");

   

            //migrationBuilder.Sql("TRUNCATE TABLE DataArtisian");

            //migrationBuilder.Sql("TRUNCATE TABLE DepartmentManufactory");

            migrationBuilder.Sql("TRUNCATE TABLE Address");
        }
    }
}
