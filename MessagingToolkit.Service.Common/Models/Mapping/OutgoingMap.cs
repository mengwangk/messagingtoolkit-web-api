using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MessagingToolkit.Service.Common.Models.Mapping
{
    public class OutgoingMap : EntityTypeConfiguration<Outgoing>
    {
        public OutgoingMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.msg_content)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.msg_type)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.status)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.date_created)
                .IsRequired()
                .HasMaxLength(2147483647);

            this.Property(t => t.date_modified)
                .IsRequired()
                .HasMaxLength(2147483647);

            // Table & Column Mappings
            this.ToTable("Outgoing");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.msg_content).HasColumnName("msg_content");
            this.Property(t => t.msg_type).HasColumnName("msg_type");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.date_created).HasColumnName("date_created");
            this.Property(t => t.date_modified).HasColumnName("date_modified");
        }
    }
}
