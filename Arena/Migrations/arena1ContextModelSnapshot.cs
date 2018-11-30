﻿// <auto-generated />
using System;
using Arena.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arena.Migrations
{
    [DbContext(typeof(arena1Context))]
    partial class arena1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arena.Models.DB.BookingMaster", b =>
                {
                    b.Property<decimal>("BmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bm_id")
                        .HasColumnType("numeric(6, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BmBookedBy")
                        .HasColumnName("bm_booked_by")
                        .HasColumnType("numeric(6, 0)");

                    b.Property<decimal?>("BmBookedFor")
                        .HasColumnName("bm_booked_for")
                        .HasColumnType("numeric(6, 0)");

                    b.Property<DateTime?>("BmBookedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bm_booked_on")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("BmBookingDate")
                        .HasColumnName("bm_booking_date")
                        .HasColumnType("datetime");

                    b.Property<string>("BmBookingType")
                        .IsRequired()
                        .HasColumnName("bm_booking_type")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<decimal>("BmPdId")
                        .HasColumnName("bm_pd_id")
                        .HasColumnType("numeric(6, 0)");

                    b.Property<string>("BmSlotMapper")
                        .HasColumnName("bm_slot_mapper")
                        .IsUnicode(false);

                    b.HasKey("BmId");

                    b.HasIndex("BmPdId");

                    b.ToTable("booking_master");
                });

            modelBuilder.Entity("Arena.Models.DB.GroupDtls", b =>
                {
                    b.Property<decimal>("GdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gd_id")
                        .HasColumnType("numeric(6, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GdCreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gd_created_by")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("GdGmId")
                        .HasColumnName("gd_gm_id")
                        .HasColumnType("numeric(6, 0)");

                    b.Property<string>("GdMemberName")
                        .IsRequired()
                        .HasColumnName("gd_member_name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("GdId");

                    b.HasIndex("GdGmId");

                    b.ToTable("group_dtls");
                });

            modelBuilder.Entity("Arena.Models.DB.GroupMaster", b =>
                {
                    b.Property<decimal>("GmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gm_id")
                        .HasColumnType("numeric(6, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GmCount")
                        .HasColumnName("gm_count");

                    b.Property<decimal>("GmCreatedBy")
                        .HasColumnName("gm_created_by")
                        .HasColumnType("numeric(6, 0)");

                    b.Property<DateTime?>("GmCreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gm_created_on")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("GmName")
                        .IsRequired()
                        .HasColumnName("gm_name")
                        .HasMaxLength(50);

                    b.HasKey("GmId");

                    b.HasIndex("GmCreatedBy");

                    b.ToTable("group_master");
                });

            modelBuilder.Entity("Arena.Models.DB.PlayersDtls", b =>
                {
                    b.Property<decimal>("PdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pd_id")
                        .HasColumnType("numeric(6, 0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("PdCreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pd_created_on")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PdEmailId")
                        .IsRequired()
                        .HasColumnName("pd_email_id")
                        .HasMaxLength(50);

                    b.Property<string>("PdMobileNo")
                        .IsRequired()
                        .HasColumnName("pd_mobile_no")
                        .HasMaxLength(10);

                    b.Property<string>("PdName")
                        .IsRequired()
                        .HasColumnName("pd_name")
                        .HasMaxLength(50);

                    b.Property<string>("PdPassword")
                        .IsRequired()
                        .HasColumnName("pd_password")
                        .HasMaxLength(100);

                    b.Property<string>("PdUserName")
                        .IsRequired()
                        .HasColumnName("pd_user_name")
                        .HasMaxLength(50);

                    b.HasKey("PdId");

                    b.ToTable("players_dtls");
                });

            modelBuilder.Entity("Arena.Models.DB.SlotMaster", b =>
                {
                    b.Property<int>("SmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("SmDate")
                        .HasColumnName("sm_date")
                        .HasColumnType("datetime");

                    b.Property<string>("SmSlot1")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_1")
                        .HasDefaultValueSql("('3,0,0,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot10")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_10")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot11")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_11")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot12")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_12")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot13")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_13")
                        .HasDefaultValueSql("('3,0,0,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot14")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_14")
                        .HasDefaultValueSql("('3,0,0,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot15")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_15")
                        .HasDefaultValueSql("('3,0,0,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot16")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_16")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot17")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_17")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot2")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_2")
                        .HasDefaultValueSql("('3,0,0,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot3")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_3")
                        .HasDefaultValueSql("('3,0,0,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot4")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_4")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot5")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_5")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot6")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_6")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot7")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_7")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot8")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_8")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("SmSlot9")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sm_slot_9")
                        .HasDefaultValueSql("('0,0,3,3')")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.HasKey("SmId");

                    b.ToTable("slot_master");
                });

            modelBuilder.Entity("Arena.Models.DB.BookingMaster", b =>
                {
                    b.HasOne("Arena.Models.DB.PlayersDtls", "BmPd")
                        .WithMany("BookingMaster")
                        .HasForeignKey("BmPdId")
                        .HasConstraintName("FK__booking_m__bm_pd__4E53A1AA");
                });

            modelBuilder.Entity("Arena.Models.DB.GroupDtls", b =>
                {
                    b.HasOne("Arena.Models.DB.GroupMaster", "GdGm")
                        .WithMany("GroupDtls")
                        .HasForeignKey("GdGmId")
                        .HasConstraintName("FK__group_dtl__gd_gm__6E01572D");
                });

            modelBuilder.Entity("Arena.Models.DB.GroupMaster", b =>
                {
                    b.HasOne("Arena.Models.DB.PlayersDtls", "GmCreatedByNavigation")
                        .WithMany("GroupMaster")
                        .HasForeignKey("GmCreatedBy")
                        .HasConstraintName("FK__group_mas__gm_cr__693CA210");
                });
#pragma warning restore 612, 618
        }
    }
}
