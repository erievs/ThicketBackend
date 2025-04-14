namespace ShittyVineRI {

    using Microsoft.EntityFrameworkCore;


    class ShittyVineRIDb : DbContext
    {


        public string DbPath { get; }

        public ShittyVineRIDb(DbContextOptions<ShittyVineRIDb> options)
            : base(options) {

                var appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "ShittyVineRI"
                );

                Directory.CreateDirectory(appDataPath);

                DbPath = System.IO.Path.Join(appDataPath, "vine.db");

             }
        
            protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Vine> Vines => Set<Vine>();



    }

}