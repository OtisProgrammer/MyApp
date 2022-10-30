using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.Infrastructure.Persistence.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
        {
            builder.ToTable("User", "UserManagement");

            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Mobile)
                .IsRequired()
                .HasMaxLength(11);


            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(e => e.PassWord)
                .IsRequired()
                .HasMaxLength(300);


            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .IsRequired();

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .IsRequired(false);
        }
    }
}
