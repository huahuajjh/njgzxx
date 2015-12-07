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
    internal partial class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".User");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Username).HasColumnName("Username").IsOptional().HasMaxLength(100);
            Property(x => x.Password).HasColumnName("Password").IsOptional().HasMaxLength(100);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}
