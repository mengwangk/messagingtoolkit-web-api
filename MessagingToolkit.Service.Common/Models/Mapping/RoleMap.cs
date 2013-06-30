using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MessagingToolkit.Service.Common.Models.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.description)
                .HasMaxLength(2147483647);

            // Table & Column Mappings
            this.ToTable("Role");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.can_be_deleted).HasColumnName("can_be_deleted");

            // Relationships
            this.HasMany(t => t.Users)
                .WithMany(t => t.Roles)
                .Map(m =>
                    {
                        m.ToTable("UserRole");
                        m.MapLeftKey("role_id");
                        m.MapRightKey("user_id");
                    });


        }
    }
}
