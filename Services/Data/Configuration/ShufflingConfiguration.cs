using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Services.Data.Configuration
{
    internal partial class ShufflingConfiguration : EntityTypeConfiguration<Model.Shuffling>
    {
        public ShufflingConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Shuffling");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.Introduce).HasColumnName("Introduce").IsOptional().HasMaxLength(300);
            Property(x => x.Url).HasColumnName("Url").IsOptional().HasMaxLength(100);
            Property(x => x.Img).HasColumnName("Img").IsOptional().HasMaxLength(100);
            Property(x => x.Sort).HasColumnName("Sort").IsRequired();
        }
    }
}
