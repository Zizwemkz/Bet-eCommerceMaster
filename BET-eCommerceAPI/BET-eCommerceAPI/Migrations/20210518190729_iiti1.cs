using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BET_eCommerceAPI.Migrations
{
    public partial class iiti1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cart_id = table.Column<string>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 35, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Department_Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_ID = table.Column<string>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    shipped = table.Column<bool>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    packed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_Email",
                        column: x => x.Email,
                        principalTable: "Customers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Department_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_ID);
                    table.ForeignKey(
                        name: "FK_Categories_Department_Department_ID",
                        column: x => x.Department_ID,
                        principalTable: "Department",
                        principalColumn: "Department_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Address_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    street_number = table.Column<int>(nullable: false),
                    street_name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Building_Name = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Contact_Number = table.Column<string>(nullable: true),
                    Address_Type = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Order_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Address_ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Orders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Trackings",
                columns: table => new
                {
                    tracking_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_ID = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Trackings", x => x.tracking_ID);
                    table.ForeignKey(
                        name: "FK_Order_Trackings_Orders_order_ID",
                        column: x => x.order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    payment_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AmountPaid = table.Column<double>(nullable: false),
                    PaymentFor = table.Column<string>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: false),
                    Order_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.payment_ID);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_Email",
                        column: x => x.Email,
                        principalTable: "Customers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category_ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    QuantityInStock = table.Column<int>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                    table.ForeignKey(
                        name: "FK_Items_Categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Items",
                columns: table => new
                {
                    cart_item_id = table.Column<string>(nullable: false),
                    cart_id = table.Column<string>(nullable: true),
                    item_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Items", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "FK_Cart_Items_Carts_cart_id",
                        column: x => x.cart_id,
                        principalTable: "Carts",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Items_Items_item_id",
                        column: x => x.item_id,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    Order_Item_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order_id = table.Column<string>(nullable: true),
                    item_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    replied = table.Column<bool>(nullable: false),
                    date_replied = table.Column<DateTime>(nullable: true),
                    accepted = table.Column<bool>(nullable: false),
                    date_accepted = table.Column<DateTime>(nullable: true),
                    shipped = table.Column<bool>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    date_shipped = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.Order_Item_id);
                    table.ForeignKey(
                        name: "FK_Order_Items_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items_Items_item_id",
                        column: x => x.item_id,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Order_ID",
                table: "Addresses",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_cart_id",
                table: "Cart_Items",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_item_id",
                table: "Cart_Items",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Department_ID",
                table: "Categories",
                column: "Department_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category_ID",
                table: "Items",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_Order_id",
                table: "Order_Items",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_item_id",
                table: "Order_Items",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Trackings_order_ID",
                table: "Order_Trackings",
                column: "order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Email",
                table: "Orders",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Email",
                table: "Payments",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Order_ID",
                table: "Payments",
                column: "Order_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cart_Items");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Order_Trackings");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
