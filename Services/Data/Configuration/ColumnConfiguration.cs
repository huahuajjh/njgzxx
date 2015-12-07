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
    internal class ColumnConfiguration : EntityTypeConfiguration<Column>
    {
        public ColumnConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Column");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.ParentId).HasColumnName("Parent_Id").IsOptional();
            Property(x => x.Img).HasColumnName("Img").IsOptional().HasMaxLength(100);
            Property(x => x.Url).HasColumnName("Url").IsOptional().HasMaxLength(100);
            Property(x => x.TemplateBigIndex).HasColumnName("Template_Big_Index").IsOptional().HasMaxLength(100);
            Property(x => x.TemplateBigList).HasColumnName("Template_Big_List").IsOptional().HasMaxLength(100);
            Property(x => x.TemplateBigContent).HasColumnName("Template_Big_Content").IsOptional().HasMaxLength(100);
            Property(x => x.TemplateSmallIndex).HasColumnName("Template_Small_Index").IsOptional().HasMaxLength(100);
            Property(x => x.TemplateSmallList).HasColumnName("Template_Small_List").IsOptional().HasMaxLength(100);
            Property(x => x.TemplateSmallContent).HasColumnName("Template_Small_Content").IsOptional().HasMaxLength(100);
            Property(x => x.Introduce).HasColumnName("Introduce").IsOptional().HasMaxLength(2147483647);
            Property(x => x.Type).HasColumnName("Type").IsRequired();
            Property(x => x.Show).HasColumnName("Show").IsRequired();
            Property(x => x.Sort).HasColumnName("Sort").IsRequired();
        }
    }
}
