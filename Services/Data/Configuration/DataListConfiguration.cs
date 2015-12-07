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
    internal class DataListConfiguration : EntityTypeConfiguration<DataList>
    {
        public DataListConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".DataList");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.Img).HasColumnName("Img").IsOptional().HasMaxLength(100);
            Property(x => x.CreateUser).HasColumnName("CreateUser").IsRequired();
            Property(x => x.CreateTime).HasColumnName("CreateTime").IsRequired();
            Property(x => x.Contents).HasColumnName("Contents").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ColumnId).HasColumnName("Column_Id").IsRequired();
            Property(x => x.ColumnListId).HasColumnName("Column_List_Id").IsOptional();
            Property(x => x.Type).HasColumnName("Type").IsRequired();
            Property(x => x.Describe).HasColumnName("Describe").IsOptional().HasMaxLength(300);
            Property(x => x.Other).HasColumnName("Other").IsOptional().HasMaxLength(2147483647);
        }
    }
}
