using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Arena.Models.DB
{
    public partial class arena1Context : DbContext
    {
        public arena1Context()
        {
        }

        public arena1Context(DbContextOptions<arena1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingMaster> BookingMaster { get; set; }
        public virtual DbSet<GroupDtls> GroupDtls { get; set; }
        public virtual DbSet<GroupMaster> GroupMaster { get; set; }
        public virtual DbSet<PlayersDtls> PlayersDtls { get; set; }
        public virtual DbSet<SlotMaster> SlotMaster { get; set; }
        public virtual DbSet<AuthPlayer> AuthPlayer { get; set; }
        public virtual DbSet<PlayerDtls> PlayerDtls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Initial Catalog=arena1;Persist Security Info=False;User ID=arena1;Password=By0WnpnmBF_-;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingMaster>(entity =>
            {
                entity.HasKey(e => e.BmId);

                entity.ToTable("booking_master");

                entity.Property(e => e.BmId)
                    .HasColumnName("bm_id")
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BmBookedBy)
                    .HasColumnName("bm_booked_by")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.BmBookedFor)
                    .HasColumnName("bm_booked_for")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.BmBookedOn)
                    .HasColumnName("bm_booked_on")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BmBookingDate)
                    .HasColumnName("bm_booking_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BmBookingType)
                    .IsRequired()
                    .HasColumnName("bm_booking_type")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BmPdId)
                    .HasColumnName("bm_pd_id")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.BmSlotMapper)
                    .HasColumnName("bm_slot_mapper")
                    .IsUnicode(false);

                entity.HasOne(d => d.BmPd)
                    .WithMany(p => p.BookingMaster)
                    .HasForeignKey(d => d.BmPdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__booking_m__bm_pd__4E53A1AA");
            });

            modelBuilder.Entity<GroupDtls>(entity =>
            {
                entity.HasKey(e => e.GdId);

                entity.ToTable("group_dtls");

                entity.Property(e => e.GdId)
                    .HasColumnName("gd_id")
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GdCreatedBy)
                    .HasColumnName("gd_created_by")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GdGmId)
                    .HasColumnName("gd_gm_id")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.GdMemberName)
                    .IsRequired()
                    .HasColumnName("gd_member_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GdGm)
                    .WithMany(p => p.GroupDtls)
                    .HasForeignKey(d => d.GdGmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group_dtl__gd_gm__6E01572D");
            });

            modelBuilder.Entity<GroupMaster>(entity =>
            {
                entity.HasKey(e => e.GmId);

                entity.ToTable("group_master");

                entity.Property(e => e.GmId)
                    .HasColumnName("gm_id")
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GmCount).HasColumnName("gm_count");

                entity.Property(e => e.GmCreatedBy)
                    .HasColumnName("gm_created_by")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.GmCreatedOn)
                    .HasColumnName("gm_created_on")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GmName)
                    .IsRequired()
                    .HasColumnName("gm_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.GmCreatedByNavigation)
                    .WithMany(p => p.GroupMaster)
                    .HasForeignKey(d => d.GmCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__group_mas__gm_cr__693CA210");
            });

            modelBuilder.Entity<PlayersDtls>(entity =>
            {
                entity.HasKey(e => e.PdId);

                entity.ToTable("players_dtls");

                entity.Property(e => e.PdId)
                    .HasColumnName("pd_id")
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PdCreatedOn)
                    .HasColumnName("pd_created_on")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PdEmailId)
                    .IsRequired()
                    .HasColumnName("pd_email_id")
                    .HasMaxLength(50);

                entity.Property(e => e.PdMobileNo)
                    .IsRequired()
                    .HasColumnName("pd_mobile_no")
                    .HasMaxLength(10);

                entity.Property(e => e.PdName)
                    .IsRequired()
                    .HasColumnName("pd_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PdPassword)
                    .IsRequired()
                    .HasColumnName("pd_password")
                    .HasMaxLength(100);

                entity.Property(e => e.PdUserName)
                    .IsRequired()
                    .HasColumnName("pd_user_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SlotMaster>(entity =>
            {
                entity.HasKey(e => e.SmId);

                entity.ToTable("slot_master");

                entity.Property(e => e.SmId).HasColumnName("sm_id");

                entity.Property(e => e.SmDate)
                    .HasColumnName("sm_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmSlot1)
                    .IsRequired()
                    .HasColumnName("sm_slot_1")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('3,0,0,3')");

                entity.Property(e => e.SmSlot10)
                    .IsRequired()
                    .HasColumnName("sm_slot_10")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot11)
                    .IsRequired()
                    .HasColumnName("sm_slot_11")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot12)
                    .IsRequired()
                    .HasColumnName("sm_slot_12")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot13)
                    .IsRequired()
                    .HasColumnName("sm_slot_13")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('3,0,0,3')");

                entity.Property(e => e.SmSlot14)
                    .IsRequired()
                    .HasColumnName("sm_slot_14")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('3,0,0,3')");

                entity.Property(e => e.SmSlot15)
                    .IsRequired()
                    .HasColumnName("sm_slot_15")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('3,0,0,3')");

                entity.Property(e => e.SmSlot16)
                    .IsRequired()
                    .HasColumnName("sm_slot_16")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot17)
                    .IsRequired()
                    .HasColumnName("sm_slot_17")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot2)
                    .IsRequired()
                    .HasColumnName("sm_slot_2")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('3,0,0,3')");

                entity.Property(e => e.SmSlot3)
                    .IsRequired()
                    .HasColumnName("sm_slot_3")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('3,0,0,3')");

                entity.Property(e => e.SmSlot4)
                    .IsRequired()
                    .HasColumnName("sm_slot_4")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot5)
                    .IsRequired()
                    .HasColumnName("sm_slot_5")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot6)
                    .IsRequired()
                    .HasColumnName("sm_slot_6")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot7)
                    .IsRequired()
                    .HasColumnName("sm_slot_7")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot8)
                    .IsRequired()
                    .HasColumnName("sm_slot_8")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");

                entity.Property(e => e.SmSlot9)
                    .IsRequired()
                    .HasColumnName("sm_slot_9")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0,0,3,3')");
            });
        }
    }
}
