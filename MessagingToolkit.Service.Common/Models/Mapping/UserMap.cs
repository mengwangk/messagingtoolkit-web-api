using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MessagingToolkit.Service.Common.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.common_name)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.mobtel)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.login_name)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.password)
                .IsRequired()
                .HasMaxLength(2147483647);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.common_name).HasColumnName("common_name");
            this.Property(t => t.mobtel).HasColumnName("mobtel");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.login_name).HasColumnName("login_name");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.can_be_deleted).HasColumnName("can_be_deleted");
        }
    }
}
