using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MessagingToolkit.Service.Common.Models.Mapping
{
    public class AppConfigMap : EntityTypeConfiguration<AppConfig>
    {
        public AppConfigMap()
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

            this.Property(t => t.value)
                .HasMaxLength(2147483647);

            this.Property(t => t.module)
                .HasMaxLength(2147483647);

            this.Property(t => t.description)
                .HasMaxLength(2147483647);

            this.Property(t => t.date_created)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.date_modified)
                .IsRequired()
                .HasMaxLength(2147483647);

            // Table & Column Mappings
            this.ToTable("AppConfig");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.value).HasColumnName("value");
            this.Property(t => t.module).HasColumnName("module");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.configurable).HasColumnName("configurable");
            this.Property(t => t.date_created).HasColumnName("date_created");
            this.Property(t => t.date_modified).HasColumnName("date_modified");
        }
    }
}
