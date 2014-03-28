namespace ClaimSystem.Data.DbInteractions
{
    #region

    using System.Data.Entity.Migrations;
    using ClaimSystem.Core.Models;

    #endregion

    public class ClaimDbConfiguration : DbMigrationsConfiguration<DataContext>
    {
        public ClaimDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            // If you want to seed the database uncomment
            //==================================================
            //var seeder = new DatabaseSeeder(context);
            //seeder.Seed();
        }
    }
}