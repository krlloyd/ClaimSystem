namespace ClaimSystem.Data.DbInteractions
{
    #region

    using System;
    using System.Collections.Generic;
    using ClaimSystem.Core.Enums;
    using ClaimSystem.Core.Models;

    #endregion

    internal class DatabaseSeeder
    {
        private readonly DataContext _context;
        private Dependent _child;

        // Infrastructore
        private Client _client;

        // Family 
        private PolicyHolder _policyHolder;
        private Employer _shopKo;
        private Dependent _spouse;

        // Employers
        private Employer _walmart;


        public DatabaseSeeder(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            Initialize();

            var newClaim = new InternalClaim
                {
                    ClaimId = "1230000",
                    Client = _client,
                    AccidentDescription = "Broke Left Arm",
                    CausedFromAutoAccident = true,
                    OccurredAtEmployment = false,
                    PolicyHolder = _policyHolder,
                    Patient = _child,
                    Extrinsics = new List<ExtrinsicField>
                        {
                            new ExtrinsicField {Name = "HasLifeInsurance", Value = "true", Type = "bool"},
                            new ExtrinsicField {Name = "Notes", Value = "This is a sample note.", Type = "string"},
                        }
                };


            _context.Set<InternalClaim>().Add(newClaim);
            _context.SaveChanges();
        }


        private void Initialize()
        {
            _client = new Client {Name = "SuperMedicalInsurace Inc."};
            _walmart = new Employer
                {
                    Name = "Walmart",
                    Address = new Address
                        {
                            Street = "4650 W North Ave",
                            City = "Chicago",
                            State = "IL",
                            Zipcode = "60639"
                        }
                };
            _shopKo = new Employer
                {
                    Name = "Shopko",
                    Address = new Address
                        {
                            Street = "2655 W Chicago Blvd",
                            City = "Chicago",
                            State = "IL",
                            Zipcode = "60639"
                        }
                };

            _policyHolder = new PolicyHolder
                {
                    FirstName = "John",
                    LastName = "Doe",
                    MiddleName = "Jay",
                    AccountNumber = "1005000",
                    Address = new Address
                        {
                            Street = "1 Apple Rd",
                            City = "Chicago",
                            State = "IL",
                            Zipcode = "60630"
                        },
                    DateOfBirth = DateTime.Parse("10/01/1965"),
                    EffectiveDate = DateTime.Parse("03/01/2013"),
                    Employer = _walmart
                };

            _spouse = new Dependent
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    MiddleName = "Emily",
                    IsEmployed = true,
                    WasEmployedPastYear = true,
                    HasMedicare = false,
                    HasAnotherPlan = true,
                    SocialSecurityNumber = "330-01-0015",
                    NameOfInsuranceCompany = "Chicago Medical Ins Inc.",
                    PolicyNumber = "333423A",
                    EffectiveDate = DateTime.Parse("01/01/2010"),
                    PlanType = "HMO",
                    Address = new Address
                        {
                            Street = "1 Apple Rd",
                            City = "Chicago",
                            State = "IL",
                            Zipcode = "60630"
                        },
                    DateOfBirth = DateTime.Parse("10/01/1965"),
                    Employer = _shopKo,
                    RelationShip = RelationShip.SPOUSE
                };
            _child = new Dependent
                {
                    FirstName = "Molly",
                    LastName = "Doe",
                    MiddleName = "Sally",
                    SocialSecurityNumber = "330-01-0010",
                    IsEmployed = false,
                    WasEmployedPastYear = false,
                    HasMedicare = false,
                    HasAnotherPlan = false,
                    Address = new Address
                        {
                            Street = "1 Apple Rd",
                            City = "Chicago",
                            State = "IL",
                            Zipcode = "60630"
                        },
                    DateOfBirth = DateTime.Parse("10/01/1985"),
                    RelationShip = RelationShip.CHILD
                };
        }
    }
}