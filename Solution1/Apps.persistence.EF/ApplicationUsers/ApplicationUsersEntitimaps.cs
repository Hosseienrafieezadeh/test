using Apps.Entitis.ApplicationUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.persistence.EF.ApplicationUsers
{
   public class ApplicationUsersEntitimaps :IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // تعریف نام جدول
            builder.ToTable("ApplicationUsers");

            // تعریف کلید اصلی (Primary Key)
            builder.HasKey(u => u.Id);

            // مشخص کردن طول و اجباری بودن ستون‌ها
            builder.Property(u => u.FirstName)
                   .HasMaxLength(50)
                   .IsRequired(); // FirstName الزامی

            builder.Property(u => u.LastName)
                   .HasMaxLength(50)
                   .IsRequired(); // LastName الزامی

            builder.Property(u => u.Email)
                   .HasMaxLength(100)
                   .IsRequired(); // Email الزامی

            builder.Property(u => u.PhoneNumber)
                   .HasMaxLength(15);

            // سایر خصوصیات پیش‌فرض IdentityUser به صورت اتوماتیک نگاشت می‌شوند
        }

    }
}
