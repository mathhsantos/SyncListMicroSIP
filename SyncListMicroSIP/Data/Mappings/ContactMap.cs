using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncListMicroSIP.Models;

namespace SyncListMicroSIP.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x => x.Number);

            builder.Property(x => x.Number)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Firstname)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Lastname)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Mobile)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Address)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.City)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.State)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Zip)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Comment)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Presence)
                .HasColumnType("int")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(x => x.Starred)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Info)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}
