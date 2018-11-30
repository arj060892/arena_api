using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arena.Migrations
{
    public partial class sp_auth_player : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players_dtls",
                columns: table => new
                {
                    pd_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pd_name = table.Column<string>(maxLength: 50, nullable: false),
                    pd_email_id = table.Column<string>(maxLength: 50, nullable: false),
                    pd_mobile_no = table.Column<string>(maxLength: 10, nullable: false),
                    pd_user_name = table.Column<string>(maxLength: 50, nullable: false),
                    pd_password = table.Column<string>(maxLength: 100, nullable: false),
                    pd_created_on = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players_dtls", x => x.pd_id);
                });

            migrationBuilder.CreateTable(
                name: "slot_master",
                columns: table => new
                {
                    sm_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sm_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    sm_slot_1 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('3,0,0,3')"),
                    sm_slot_2 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('3,0,0,3')"),
                    sm_slot_3 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('3,0,0,3')"),
                    sm_slot_4 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_5 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_6 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_7 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_8 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_9 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_10 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_11 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_12 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_13 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('3,0,0,3')"),
                    sm_slot_14 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('3,0,0,3')"),
                    sm_slot_15 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('3,0,0,3')"),
                    sm_slot_16 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')"),
                    sm_slot_17 = table.Column<string>(unicode: false, maxLength: 7, nullable: false, defaultValueSql: "('0,0,3,3')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slot_master", x => x.sm_id);
                });

            migrationBuilder.CreateTable(
                name: "booking_master",
                columns: table => new
                {
                    bm_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bm_pd_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    bm_booking_type = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    bm_booking_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    bm_slot_mapper = table.Column<string>(unicode: false, nullable: true),
                    bm_booked_for = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    bm_booked_by = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    bm_booked_on = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_master", x => x.bm_id);
                    table.ForeignKey(
                        name: "FK__booking_m__bm_pd__4E53A1AA",
                        column: x => x.bm_pd_id,
                        principalTable: "players_dtls",
                        principalColumn: "pd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_master",
                columns: table => new
                {
                    gm_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gm_created_by = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    gm_name = table.Column<string>(maxLength: 50, nullable: false),
                    gm_count = table.Column<int>(nullable: true),
                    gm_created_on = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_master", x => x.gm_id);
                    table.ForeignKey(
                        name: "FK__group_mas__gm_cr__693CA210",
                        column: x => x.gm_created_by,
                        principalTable: "players_dtls",
                        principalColumn: "pd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_dtls",
                columns: table => new
                {
                    gd_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gd_gm_id = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    gd_member_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    gd_created_by = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_dtls", x => x.gd_id);
                    table.ForeignKey(
                        name: "FK__group_dtl__gd_gm__6E01572D",
                        column: x => x.gd_gm_id,
                        principalTable: "group_master",
                        principalColumn: "gm_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_master_bm_pd_id",
                table: "booking_master",
                column: "bm_pd_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_dtls_gd_gm_id",
                table: "group_dtls",
                column: "gd_gm_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_master_gm_created_by",
                table: "group_master",
                column: "gm_created_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking_master");

            migrationBuilder.DropTable(
                name: "group_dtls");

            migrationBuilder.DropTable(
                name: "slot_master");

            migrationBuilder.DropTable(
                name: "group_master");

            migrationBuilder.DropTable(
                name: "players_dtls");
        }
    }
}
