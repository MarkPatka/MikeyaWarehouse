using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MikeyaWarehouse.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ContractorId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorId);
                });

            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "ContractorsAdresses",
                columns: table => new
                {
                    ContractorAdressId = table.Column<int>(type: "integer", nullable: false),
                    ContractorId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorsAdresses", x => new { x.ContractorAdressId, x.ContractorId });
                    table.ForeignKey(
                        name: "FK_ContractorsAdresses_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => new { x.ShipmentId, x.ContractorId });
                    table.ForeignKey(
                        name: "FK_Shipments_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBoxes",
                columns: table => new
                {
                    ProductBoxId = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Expire = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Production = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BarCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBoxes", x => new { x.ProductBoxId, x.PalletId });
                    table.ForeignKey(
                        name: "FK_ProductBoxes_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageZones",
                columns: table => new
                {
                    StorageZoneId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    MinTemperatureRegime = table.Column<double>(type: "double precision", nullable: false),
                    MaxTemperatureRegime = table.Column<double>(type: "double precision", nullable: false),
                    MinHumidityRegime = table.Column<double>(type: "double precision", nullable: false),
                    MaxHumidityRegime = table.Column<double>(type: "double precision", nullable: false),
                    Code = table.Column<char>(type: "char(1)", fixedLength: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageZones", x => new { x.StorageZoneId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_StorageZones_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseAdresses_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseBufferZones",
                columns: table => new
                {
                    BufferZoneId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    LoadCapacity_MaxWeight = table.Column<double>(type: "double precision", nullable: false),
                    LoadCapacity_MaxVolume = table.Column<double>(type: "double precision", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseBufferZones", x => new { x.BufferZoneId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_WarehouseBufferZones_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehousePalletIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehousePalletIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehousePalletIds_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseRamps",
                columns: table => new
                {
                    RampId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    Gate = table.Column<char>(type: "char(1)", fixedLength: true, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseRamps", x => new { x.RampId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_WarehouseRamps_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentPalletIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorId = table.Column<int>(type: "integer", nullable: true),
                    ShipmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentPalletIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentPalletIds_Shipments_ShipmentId_ContractorId",
                        columns: x => new { x.ShipmentId, x.ContractorId },
                        principalTable: "Shipments",
                        principalColumns: new[] { "ShipmentId", "ContractorId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductBoxId = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Production = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BarCode = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.ProductId, x.ProductBoxId, x.PalletId });
                    table.ForeignKey(
                        name: "FK_Products_ProductBoxes_ProductBoxId_PalletId",
                        columns: x => new { x.ProductBoxId, x.PalletId },
                        principalTable: "ProductBoxes",
                        principalColumns: new[] { "ProductBoxId", "PalletId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseRacks",
                columns: table => new
                {
                    StorageRackId = table.Column<int>(type: "integer", nullable: false),
                    StorageZoneId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    LoadCapacity_MaxWeight = table.Column<double>(type: "double precision", nullable: false),
                    LoadCapacity_MaxVolume = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseRacks", x => new { x.StorageRackId, x.StorageZoneId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_WarehouseRacks_StorageZones_StorageZoneId_WarehouseId",
                        columns: x => new { x.StorageZoneId, x.WarehouseId },
                        principalTable: "StorageZones",
                        principalColumns: new[] { "StorageZoneId", "WarehouseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RackSections",
                columns: table => new
                {
                    StorageSectionId = table.Column<int>(type: "integer", nullable: false),
                    StorageRackId = table.Column<int>(type: "integer", nullable: false),
                    StorageZoneId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackSections", x => new { x.StorageSectionId, x.StorageRackId, x.StorageZoneId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_RackSections_WarehouseRacks_StorageRackId_StorageZoneId_War~",
                        columns: x => new { x.StorageRackId, x.StorageZoneId, x.WarehouseId },
                        principalTable: "WarehouseRacks",
                        principalColumns: new[] { "StorageRackId", "StorageZoneId", "WarehouseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionBins",
                columns: table => new
                {
                    StorageBinId = table.Column<int>(type: "integer", nullable: false),
                    StorageSectionId = table.Column<int>(type: "integer", nullable: false),
                    StorageRackId = table.Column<int>(type: "integer", nullable: false),
                    StorageZoneId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    BinBarCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    LoadCapacity_MaxWeight = table.Column<double>(type: "double precision", nullable: false),
                    LoadCapacity_MaxVolume = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionBins", x => new { x.StorageBinId, x.StorageSectionId, x.StorageRackId, x.StorageZoneId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_SectionBins_RackSections_StorageSectionId_StorageRackId_Sto~",
                        columns: x => new { x.StorageSectionId, x.StorageRackId, x.StorageZoneId, x.WarehouseId },
                        principalTable: "RackSections",
                        principalColumns: new[] { "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageBinBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoxId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageBinId = table.Column<int>(type: "integer", nullable: false),
                    StorageRackId = table.Column<int>(type: "integer", nullable: true),
                    StorageSectionId = table.Column<int>(type: "integer", nullable: true),
                    StorageZoneId = table.Column<int>(type: "integer", nullable: true),
                    WarehouseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageBinBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageBinBoxes_SectionBins_StorageBinId_StorageSectionId_S~",
                        columns: x => new { x.StorageBinId, x.StorageSectionId, x.StorageRackId, x.StorageZoneId, x.WarehouseId },
                        principalTable: "SectionBins",
                        principalColumns: new[] { "StorageBinId", "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageBinPallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageBinId = table.Column<int>(type: "integer", nullable: false),
                    StorageRackId = table.Column<int>(type: "integer", nullable: true),
                    StorageSectionId = table.Column<int>(type: "integer", nullable: true),
                    StorageZoneId = table.Column<int>(type: "integer", nullable: true),
                    WarehouseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageBinPallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageBinPallets_SectionBins_StorageBinId_StorageSectionId~",
                        columns: x => new { x.StorageBinId, x.StorageSectionId, x.StorageRackId, x.StorageZoneId, x.WarehouseId },
                        principalTable: "SectionBins",
                        principalColumns: new[] { "StorageBinId", "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractorsAdresses_ContractorId",
                table: "ContractorsAdresses",
                column: "ContractorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBoxes_PalletId",
                table: "ProductBoxes",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBoxId_PalletId",
                table: "Products",
                columns: new[] { "ProductBoxId", "PalletId" });

            migrationBuilder.CreateIndex(
                name: "IX_RackSections_StorageRackId_StorageZoneId_WarehouseId",
                table: "RackSections",
                columns: new[] { "StorageRackId", "StorageZoneId", "WarehouseId" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionBins_StorageSectionId_StorageRackId_StorageZoneId_Wa~",
                table: "SectionBins",
                columns: new[] { "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentPalletIds_ShipmentId_ContractorId",
                table: "ShipmentPalletIds",
                columns: new[] { "ShipmentId", "ContractorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ContractorId",
                table: "Shipments",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageBinBoxes_StorageBinId_StorageSectionId_StorageRackId~",
                table: "StorageBinBoxes",
                columns: new[] { "StorageBinId", "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId" });

            migrationBuilder.CreateIndex(
                name: "IX_StorageBinPallets_StorageBinId_StorageSectionId_StorageRack~",
                table: "StorageBinPallets",
                columns: new[] { "StorageBinId", "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageZones_WarehouseId",
                table: "StorageZones",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseAdresses_WarehouseId",
                table: "WarehouseAdresses",
                column: "WarehouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseBufferZones_WarehouseId",
                table: "WarehouseBufferZones",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePalletIds_WarehouseId",
                table: "WarehousePalletIds",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseRacks_StorageZoneId_WarehouseId",
                table: "WarehouseRacks",
                columns: new[] { "StorageZoneId", "WarehouseId" });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseRamps_WarehouseId",
                table: "WarehouseRamps",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorsAdresses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShipmentPalletIds");

            migrationBuilder.DropTable(
                name: "StorageBinBoxes");

            migrationBuilder.DropTable(
                name: "StorageBinPallets");

            migrationBuilder.DropTable(
                name: "WarehouseAdresses");

            migrationBuilder.DropTable(
                name: "WarehouseBufferZones");

            migrationBuilder.DropTable(
                name: "WarehousePalletIds");

            migrationBuilder.DropTable(
                name: "WarehouseRamps");

            migrationBuilder.DropTable(
                name: "ProductBoxes");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "SectionBins");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "RackSections");

            migrationBuilder.DropTable(
                name: "WarehouseRacks");

            migrationBuilder.DropTable(
                name: "StorageZones");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
