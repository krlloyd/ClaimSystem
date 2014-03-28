namespace ClaimSystem.Sandbox
{
    #region

    using System;
    using System.Data.Entity.Migrations;
    using ClaimSystem.Data;
    using ClaimSystem.Data.DbInteractions;

    #endregion

    public static class Installer
    {
        public static void Run()
        {
            ConsoleLogger.Information("Installing Database");
            using (var context = new DataContext())
            {
                try
                {
                    ConsoleLogger.Information("  Dropping database...");
                    context.Database.Delete();
                }
                catch (Exception ex)
                {
                    ConsoleLogger.Error("  Error: Could not drop database! " + ex);
                }

                try
                {
                    ConsoleLogger.Information("  Creating database...");
                    var migrator = new DbMigrator(new ClaimDbConfiguration());
                    migrator.Update();
                }
                catch (Exception ex)
                {
                    ConsoleLogger.Error("  Error: Could not create database! " + ex);
                }
            }

            ConsoleLogger.Information("Database Installed!");
        }
    }
}