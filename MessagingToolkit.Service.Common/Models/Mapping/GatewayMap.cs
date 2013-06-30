using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MessagingToolkit.Service.Common.Models.Mapping
{
    public class GatewayMap : EntityTypeConfiguration<Gateway>
    {
        public GatewayMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.gw_name)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.gw_config)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.smsc_no)
                .HasMaxLength(2147483647);

            this.Property(t => t.date_created)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.date_modified)
                .IsRequired()
                .HasMaxLength(2147483647);

            // Table & Column Mappings
            this.ToTable("Gateway");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.gw_name).HasColumnName("gw_name");
            this.Property(t => t.gw_type).HasColumnName("gw_type");
            this.Property(t => t.gw_config).HasColumnName("gw_config");
            this.Property(t => t.smsc_no).HasColumnName("smsc_no");
            this.Property(t => t.auto_start).HasColumnName("auto_start");
            this.Property(t => t.initialize).HasColumnName("initialize");
            this.Property(t => t.date_created).HasColumnName("date_created");
            this.Property(t => t.date_modified).HasColumnName("date_modified");
        }
    }
}
