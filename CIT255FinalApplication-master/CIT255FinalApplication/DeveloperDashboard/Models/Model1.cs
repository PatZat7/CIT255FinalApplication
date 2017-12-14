namespace DeveloperDashboard
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Browser> Browsers { get; set; }
        public virtual DbSet<DBengine> DBengines { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<FLA> FLAs { get; set; }
        public virtual DbSet<FLAtype> FLAtypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Paradigm> Paradigms { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Browser>()
                .Property(e => e.Browser1)
                .IsUnicode(false);

            modelBuilder.Entity<Browser>()
                .Property(e => e.ImgFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Browser>()
                .Property(e => e.UserShare)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DBengine>()
                .Property(e => e.ImgPath)
                .IsUnicode(false);

            modelBuilder.Entity<DBengine>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DBengine>()
                .Property(e => e.ImgFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<DBengine>()
                .Property(e => e.StackOverflow)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Device>()
                .Property(e => e.Device1)
                .IsUnicode(false);

            modelBuilder.Entity<DeviceType>()
                .Property(e => e.DeviceType1)
                .IsUnicode(false);

            modelBuilder.Entity<FLA>()
                .Property(e => e.flaName)
                .IsUnicode(false);

            modelBuilder.Entity<FLA>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FLA>()
                .Property(e => e.ImgFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<FLA>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<FLAtype>()
                .Property(e => e.FLAtype1)
                .IsUnicode(false);

            modelBuilder.Entity<FLAtype>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.LangName)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ImgFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.FileExtension)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.StackOverflow)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Language>()
                .Property(e => e.IEEE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Language>()
                .Property(e => e.PYPL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Paradigm>()
                .Property(e => e.Paradigm1)
                .IsUnicode(false);

            modelBuilder.Entity<Paradigm>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Paradigm>()
                .Property(e => e.CoreConcepts)
                .IsUnicode(false);

            modelBuilder.Entity<Platform>()
                .Property(e => e.Platform1)
                .IsUnicode(false);

            modelBuilder.Entity<Platform>()
                .Property(e => e.ImgFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Platform>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.imgFilePath)
                .IsUnicode(false);
        }
    }
}
