using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.Infrastructure.Persistence.EntityConfiguration
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<Domain.Entities.UserInfo>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.UserInfo> builder)
        {
            builder.ToTable("UserInfo", "UserManagement");

            builder.Property(e => e.Id)
                .HasColumnName("ID");



            builder.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(10);


            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(500);


            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .IsRequired();

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .IsRequired(false);

            builder
                .HasOne<Domain.Entities.User>(p => p.User)
                .WithMany(p => p.UserInfos)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
