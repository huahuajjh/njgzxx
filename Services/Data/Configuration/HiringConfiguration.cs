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
    internal class HiringConfiguration : EntityTypeConfiguration<Hiring>
    {
        public HiringConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Hiring");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.CreateUser).HasColumnName("CreateUser").IsRequired();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.Department).HasColumnName("Department").IsOptional().HasMaxLength(100);
            Property(x => x.WorkType).HasColumnName("WorkType").IsOptional().HasMaxLength(100);
            Property(x => x.Salary).HasColumnName("Salary").IsOptional().HasMaxLength(100);
            Property(x => x.Introduction).HasColumnName("Introduction").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ColumnId).HasColumnName("ColumnId").IsRequired();
            Property(x => x.Describe).HasColumnName("Describe").IsOptional().HasMaxLength(300);
            Property(x => x.PersonNum).HasColumnName("PersonNum").IsRequired();
            Property(x => x.Address).HasColumnName("Address").IsOptional().HasMaxLength(100);
        }
    }
}
