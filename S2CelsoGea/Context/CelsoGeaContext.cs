namespace S2CelsoGea
{
    using Context.ContextModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class S2CelsoGeaContext : DbContext
    {
        // Your context has been configured to use a 'S2CelsoGeaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'S2CelsoGea.S2CelsoGeaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'S2CelsoGeaContext' 
        // connection string in the application configuration file.
        public S2CelsoGeaContext()
            : base("name=S2CelsoGeaContext")
        {
            Database.CommandTimeout = 9600;
            Database.Log = s => System.Diagnostics.Debug.Write(s);
            //Database.SetInitializer<S2CelsoGeaContext>(new DropCreateDatabaseAlways<S2CelsoGeaContext>());
            Database.SetInitializer<S2CelsoGeaContext>(new CreateDatabaseIfNotExists<S2CelsoGeaContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<S2CelsoGeaContext, Migrations.Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Jogo> Jogos { get; set; }
        public virtual DbSet<Amigo> Amigos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<DateTime>()
            .Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Properties<DateTime?>()
              .Configure(c => c.HasColumnType("datetime2"));

        }
    }
    
}