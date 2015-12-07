using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.Configuration
{
    internal partial class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Message");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(100);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(100);
            Property(x => x.IsSee).HasColumnName("Is_See").IsRequired();
            Property(x => x.Contents).HasColumnName("Contents").IsOptional().HasMaxLength(2147483647);
            Property(x => x.CreateTime).HasColumnName("CreateTime").IsRequired();
        }
    }
}
