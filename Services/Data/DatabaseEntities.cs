using Model;
using Services.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base(ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString)
        {
        }

        public IDbSet<Column> Columns { get; set; }
        public IDbSet<DataList> DataLists { get; set; }
        public IDbSet<Hiring> Hirings { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Shuffling> Shufflings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ColumnConfiguration());
            modelBuilder.Configurations.Add(new DataListConfiguration());
            modelBuilder.Configurations.Add(new HiringConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new ShufflingConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
