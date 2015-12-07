

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "DataTemplate\App.config"
//     Connection String Name: "nini_dbEntities"
//     Connection String:      "server=.;UID=sa;PWD=1234;database=GanZhi"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Nini.Data;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace DataTemplate
{
    // ************************************************************************
    // Database context
    public partial class nini_dbEntities : DbContext, Inini_dbEntities
    {
        public IDbSet<Column> Columns { get; set; } // Column
        public IDbSet<DataList> DataLists { get; set; } // DataList
        public IDbSet<Hiring> Hirings { get; set; } // Hiring
        public IDbSet<Message> Messages { get; set; } // Message
        public IDbSet<Shuffling> Shufflings { get; set; } // Shuffling
        public IDbSet<User> Users { get; set; } // User

        static nini_dbEntities()
        {
            Database.SetInitializer<nini_dbEntities>(null);
        }

        public nini_dbEntities()
            : base("Name=nini_dbEntities")
        {
        InitializePartial();
        }

        public nini_dbEntities(string connectionString) : base(connectionString)
        {
        InitializePartial();
        }

        public nini_dbEntities(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        InitializePartial();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ColumnConfiguration());
            modelBuilder.Configurations.Add(new DataListConfiguration());
            modelBuilder.Configurations.Add(new HiringConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new ShufflingConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new ColumnConfiguration(schema));
            modelBuilder.Configurations.Add(new DataListConfiguration(schema));
            modelBuilder.Configurations.Add(new HiringConfiguration(schema));
            modelBuilder.Configurations.Add(new MessageConfiguration(schema));
            modelBuilder.Configurations.Add(new ShufflingConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }

    // ************************************************************************
    // POCO classes

    // Column
    public partial class Column
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public int? ParentId { get; set; } // Parent_Id
        public string Img { get; set; } // Img
        public string Url { get; set; } // Url
        public string TemplateBigIndex { get; set; } // Template_Big_Index
        public string TemplateBigList { get; set; } // Template_Big_List
        public string TemplateBigContent { get; set; } // Template_Big_Content
        public string TemplateSmallIndex { get; set; } // Template_Small_Index
        public string TemplateSmallList { get; set; } // Template_Small_List
        public string TemplateSmallContent { get; set; } // Template_Small_Content
        public string Introduce { get; set; } // Introduce
        public byte Type { get; set; } // Type
        public bool Show { get; set; } // Show
        public byte Sort { get; set; } // Sort
    }

    // DataList
    public partial class DataList
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Img { get; set; } // Img
        public int CreateUser { get; set; } // CreateUser
        public DateTime CreateTime { get; set; } // CreateTime
        public string Contents { get; set; } // Contents
        public int ColumnId { get; set; } // Column_Id
        public int? ColumnListId { get; set; } // Column_List_Id
        public byte Type { get; set; } // Type
        public string Describe { get; set; } // Describe
        public string Other { get; set; } // Other
    }

    // Hiring
    public partial class Hiring
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public int CreateUser { get; set; } // CreateUser
        public DateTime CreateDate { get; set; } // CreateDate
        public string Department { get; set; } // Department
        public string WorkType { get; set; } // WorkType
        public string Salary { get; set; } // Salary
        public string Introduction { get; set; } // Introduction
        public int ColumnId { get; set; } // ColumnId
        public string Describe { get; set; } // Describe
        public int PersonNum { get; set; } // PersonNum
        public string Address { get; set; } // Address
    }

    // Message
    public partial class Message
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Phone { get; set; } // Phone
        public string Email { get; set; } // Email
        public bool IsSee { get; set; } // Is_See
        public string Contents { get; set; } // Contents
        public DateTime CreateTime { get; set; } // CreateTime
    }

    // Shuffling
    public partial class Shuffling
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Introduce { get; set; } // Introduce
        public string Url { get; set; } // Url
        public string Img { get; set; } // Img
        public byte Sort { get; set; } // Sort
    }

    // User
    public partial class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string Username { get; set; } // Username
        public string Password { get; set; } // Password
        public string Name { get; set; } // Name
    }


    // ************************************************************************
    // POCO Configuration

    // Column
    internal partial class ColumnConfiguration : EntityTypeConfiguration<Column>
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // DataList
    internal partial class DataListConfiguration : EntityTypeConfiguration<DataList>
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Hiring
    internal partial class HiringConfiguration : EntityTypeConfiguration<Hiring>
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Message
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Shuffling
    internal partial class ShufflingConfiguration : EntityTypeConfiguration<Shuffling>
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // User
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

