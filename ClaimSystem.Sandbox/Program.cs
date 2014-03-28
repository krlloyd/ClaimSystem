namespace ClaimSystem.Sandbox
{
    #region

    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using ClaimSystem.Core;
    using ClaimSystem.Core.Models;
    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Data;
    using ClaimSystem.Data.DbInteractions;
    using ClaimSystem.Data.Repository;
    using ClaimSystem.Importer;
    using ClaimSystem.Importer.Converters.MinistryHealth;
    using Microsoft.Practices.Unity;

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {


            ConsoleLogger.Information(@"   _____ _       _              _____           _                 ");
            ConsoleLogger.Information(@"  / ____| |     (_)            / ____|         | |                ");
            ConsoleLogger.Information(@" | |    | | __ _ _ _ __ ___   | (___  _   _ ___| |_ ___ _ __ ___  ");
            ConsoleLogger.Information(@" | |    | |/ _` | | '_ ` _ \   \___ \| | | / __| __/ _ \ '_ ` _ \ ");
            ConsoleLogger.Information(@" | |____| | (_| | | | | | | |  ____) | |_| \__ \ ||  __/ | | | | |");
            ConsoleLogger.Information(@"  \_____|_|\__,_|_|_| |_| |_| |_____/ \__, |___/\__\___|_| |_| |_|");
            ConsoleLogger.Information(@"                                      __/ |                      ");
            ConsoleLogger.Information(@"                                     |___/                       ");
            ConsoleLogger.Information(@" By Kelly Lloyd                                                   ");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ConsoleLogger.Information("Bootstrapping Claim System...");
            var ioc = Bootstrapper.Initialize();

            #region Install Code

            /* Uncomment this to reset database to a clean database or if you have never installed the database */
            Installer.Run();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region How to retrieve data

            // Use ioc to grab an instance of IInternalClaimRepository
            //var claimRepository = ioc.Resolve<IInternalClaimRepository>();

            // Grab first claim in database
            // var claim = claimRepository.GetAll().FirstOrDefault();

            //// Output results
            //if (claim != null)
            //{
            //    ConsoleLogger.Information("Found a claim with the id of " + claim.Id);
            //    ConsoleLogger.Information(claim.Client.Name);
            //}

            #endregion

        
            /* SCENARIO: Ministry Health Care wants to do business with us. So they send us a xml file which represents their specifications.
               
             * ACTION 1: Use visual studios xsd.exe tool to quickly create a dataset class based on the xml document. (See HowTo.txt in importer project)
             * ACTION 2: Write a converter for Ministry that will take it's document and convert it into our internal claim object.
             * ACTION 3: Write an import class that will use read ministry xml feed and persist as internal claims in the database
             * ACTION 4: Run test query to find the document.
            */



            /* ========= Code if you had to  instantiate without IoC ================ */
            //var dbFactory = new DbFactory();
            //var uow = new UnitOfWork(dbFactory);

            //var claimRepository = new InternalClaimRepository(dbFactory);
            //var clientRepository = new ClientRepository(dbFactory);

            //var converter = new MinistryHealthConverter();
            //var importer = new MinistryImporter(uow, claimRepository, clientRepository);

            
            var claimRepository = ioc.Resolve<IInternalClaimRepository>();
            var converter = ioc.Resolve<IMinistryHealthConverter>();
            var importer = ioc.Resolve<IMinistryImporter>();

            
            ConsoleLogger.Information("Importing Ministry Claims...");
            importer.Import(converter, @"Converters/MinistryHealth/CustomerSpec.xml");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ConsoleLogger.Information("Query for newly created Ministry Claims.");
            ConsoleLogger.Information("========================================\r\n");

            var ministryClaims = claimRepository.GetAll();
            foreach (var claim in ministryClaims)
            {
                ConsoleLogger.Information("Found a claim! Ministry Claim Id = " + claim.ClaimId);
                Console.WriteLine();
             }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleLogger.Information("Press <ENTER> key exit!");
            Console.ReadLine();
        }

       
    }
}