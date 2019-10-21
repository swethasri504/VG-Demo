using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mBark demo.Models
{
    public partial class EmbarkDemoContext : DbContext
    {
        public EmbarkDemoContext()
        {
        }

        public EmbarkDemoContext(DbContextOptions<EmbarkDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ManifestResp> ManifestResp { get; set; }

        // Unable to generate entity type for table 'dbo.checkInParameters'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Countries'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Questions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Usersloginreq'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=VGPCDOTNET-02;Database=EmbarkDemo;user id = sa;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManifestResp>(entity =>
            {
                entity.HasKey(e => e.BookingNo);

                entity.Property(e => e.BookingNo)
                    .HasColumnName("bookingNo")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthNo)
                    .IsRequired()
                    .HasColumnName("authNo")
                    .HasMaxLength(450);

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode")
                    .HasMaxLength(450);

                entity.Property(e => e.CabinCategory)
                    .IsRequired()
                    .HasColumnName("cabinCategory")
                    .HasMaxLength(450);

                entity.Property(e => e.CcExpiry)
                    .IsRequired()
                    .HasColumnName("ccExpiry")
                    .HasMaxLength(450);

                entity.Property(e => e.CcHolderName)
                    .IsRequired()
                    .HasColumnName("ccHolderName")
                    .HasMaxLength(450);

                entity.Property(e => e.CcMaskedNo)
                    .IsRequired()
                    .HasColumnName("ccMaskedNo")
                    .HasMaxLength(450);

                entity.Property(e => e.CcToken)
                    .IsRequired()
                    .HasColumnName("ccToken")
                    .HasMaxLength(450);

                entity.Property(e => e.CcType)
                    .IsRequired()
                    .HasColumnName("ccType")
                    .HasMaxLength(450);

                entity.Property(e => e.CheckInStatus)
                    .IsRequired()
                    .HasColumnName("checkInStatus")
                    .HasMaxLength(450);

                entity.Property(e => e.CheckInWindow)
                    .IsRequired()
                    .HasColumnName("checkInWindow")
                    .HasMaxLength(450);

                entity.Property(e => e.CheckoutDate)
                    .IsRequired()
                    .HasColumnName("checkoutDate")
                    .HasMaxLength(450);

                entity.Property(e => e.ChkInDateTime)
                    .IsRequired()
                    .HasColumnName("chkInDateTime")
                    .HasMaxLength(450);

                entity.Property(e => e.DateofBirth)
                    .IsRequired()
                    .HasColumnName("dateofBirth")
                    .HasMaxLength(450);

                entity.Property(e => e.DepartTime)
                    .IsRequired()
                    .HasColumnName("departTime")
                    .HasMaxLength(450);

                entity.Property(e => e.DocExpiryDate)
                    .IsRequired()
                    .HasColumnName("docExpiryDate")
                    .HasMaxLength(450);

                entity.Property(e => e.DocIssueCountry)
                    .IsRequired()
                    .HasColumnName("docIssueCountry")
                    .HasMaxLength(450);

                entity.Property(e => e.DocIssueDate)
                    .IsRequired()
                    .HasColumnName("docIssueDate")
                    .HasMaxLength(450);

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasColumnName("docNumber")
                    .HasMaxLength(450);

                entity.Property(e => e.DocType)
                    .IsRequired()
                    .HasColumnName("docType")
                    .HasMaxLength(450);

                entity.Property(e => e.EmbarkationDate)
                    .IsRequired()
                    .HasColumnName("embarkationDate")
                    .HasMaxLength(450);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .IsUnicode(false);

                entity.Property(e => e.FlagStatus)
                    .IsRequired()
                    .HasColumnName("flagStatus")
                    .HasMaxLength(450);

                entity.Property(e => e.Folio)
                    .IsRequired()
                    .HasColumnName("folio")
                    .HasMaxLength(450);

                entity.Property(e => e.GQuestionRes1)
                    .IsRequired()
                    .HasColumnName("gQuestionRes1")
                    .HasMaxLength(450);

                entity.Property(e => e.GQuestionRes2)
                    .IsRequired()
                    .HasColumnName("gQuestionRes2")
                    .HasMaxLength(450);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(450);

                entity.Property(e => e.GuestId)
                    .IsRequired()
                    .HasColumnName("guestId")
                    .HasMaxLength(450);

                entity.Property(e => e.GuestImage)
                    .IsRequired()
                    .HasColumnName("guestImage")
                    .HasMaxLength(450);

                entity.Property(e => e.GuestStatus)
                    .IsRequired()
                    .HasColumnName("guestStatus")
                    .HasMaxLength(450);

                entity.Property(e => e.GuestType)
                    .IsRequired()
                    .HasColumnName("guestType")
                    .HasMaxLength(450);

                entity.Property(e => e.IsCheckedIn)
                    .IsRequired()
                    .HasColumnName("isCheckedIn")
                    .HasMaxLength(450);

                entity.Property(e => e.IsOlc)
                    .IsRequired()
                    .HasColumnName("isOLC")
                    .HasMaxLength(450);

                entity.Property(e => e.IsResponsible)
                    .IsRequired()
                    .HasColumnName("isResponsible")
                    .HasMaxLength(450);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .IsUnicode(false);

                entity.Property(e => e.Loyalty)
                    .IsRequired()
                    .HasColumnName("loyalty")
                    .HasMaxLength(450);

                entity.Property(e => e.MusterStation)
                    .IsRequired()
                    .HasColumnName("musterStation")
                    .HasMaxLength(450);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnName("nationality")
                    .HasMaxLength(450);

                entity.Property(e => e.OnboardStatus)
                    .IsRequired()
                    .HasColumnName("onboardStatus")
                    .HasMaxLength(450);

                entity.Property(e => e.PQuestionRes1)
                    .IsRequired()
                    .HasColumnName("pQuestionRes1")
                    .HasMaxLength(450);

                entity.Property(e => e.PQuestionRes2)
                    .IsRequired()
                    .HasColumnName("pQuestionRes2")
                    .HasMaxLength(450);

                entity.Property(e => e.PictureType)
                    .IsRequired()
                    .HasColumnName("pictureType")
                    .HasMaxLength(450);

                entity.Property(e => e.PlaceofBirth)
                    .IsRequired()
                    .HasColumnName("placeofBirth")
                    .HasMaxLength(450);

                entity.Property(e => e.PurposeofVisit)
                    .IsRequired()
                    .HasColumnName("purposeofVisit")
                    .HasMaxLength(450);

                entity.Property(e => e.RequestedBy)
                    .IsRequired()
                    .HasColumnName("requestedBy")
                    .HasMaxLength(450);

                entity.Property(e => e.RequestorName)
                    .IsRequired()
                    .HasColumnName("requestorName")
                    .HasMaxLength(450);

                entity.Property(e => e.SailDate)
                    .IsRequired()
                    .HasColumnName("sailDate")
                    .HasMaxLength(450);

                entity.Property(e => e.SeqNo).HasColumnName("seqNo");

                entity.Property(e => e.ShipCode)
                    .IsRequired()
                    .HasColumnName("shipCode")
                    .HasMaxLength(450);

                entity.Property(e => e.ShipName)
                    .IsRequired()
                    .HasColumnName("shipName")
                    .IsUnicode(false);

                entity.Property(e => e.StateRoom)
                    .IsRequired()
                    .HasColumnName("stateRoom")
                    .HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(450);

                entity.Property(e => e.VoyNo)
                    .IsRequired()
                    .HasColumnName("voyNo")
                    .HasMaxLength(450);

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasColumnName("zone")
                    .HasMaxLength(450);
            });
        }
    }
}
