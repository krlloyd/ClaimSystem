namespace ClaimSystem.Tests.Importer
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClaimSystem.Core.Models;
    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Importer;
    using ClaimSystem.Importer.Converters.MinistryHealth;
    using NUnit.Framework;
    using Rhino.Mocks;

    #endregion

    [TestFixture]
    public class MinistryImporterTests
    {
        [Test]
        public void SomeTest()
        {
            var mockUnitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            var mockClaimRepository = MockRepository.GenerateMock<IInternalClaimRepository>();
            var mockClientRepository = MockRepository.GenerateMock<IClientRepository>();
            var mockConverter = MockRepository.GenerateMock<IMinistryHealthConverter>();

            mockClientRepository.Expect(x => x.GetByClientName(Arg<string>.Is.Anything)).WhenCalled(
                (i) => i.ReturnValue = new Client {Id = new Guid(), Name = i.Arguments.First().ToString()});

            mockClaimRepository.Expect(x => x.Create(Arg<InternalClaim>.Is.Anything)).WhenCalled(
                (i) => i.ReturnValue = i.Arguments.First());

            mockConverter.Expect(x => x.Process(Arg<string>.Is.Anything, Arg<Client>.Is.Anything)).WhenCalled(
                (i) => i.ReturnValue = new List<InternalClaim>
                    {
                        new InternalClaim
                            {
                                ClaimId = "10000",
                                Client = (Client) i.Arguments.First(x => x.GetType() == typeof (Client)),
                                AccidentDescription = "Test Accident",
                                CausedFromAutoAccident = true,
                                PolicyHolder = new PolicyHolder
                                    {
                                        AccountNumber = "9999",
                                        FirstName = "Chris",
                                        LastName = "Gierke",
                                        DateOfBirth = DateTime.Parse("10/16/1980"),
                                        EffectiveDate = DateTime.Parse("01/01/2012"),
                                        Address = new Address
                                            {
                                                Street = "101 Maple Ave",
                                                City = "Appletone",
                                                State = "WI",
                                                Zipcode = "54111"
                                            }
                                    }
                            }
                    });

            var importer = new MinistryImporter(mockUnitOfWork, mockClaimRepository, mockClientRepository);
            importer.Import(mockConverter, @"doesn't matter");


            // Basically we will verify that all the dependecies did there job in the importer.
            // Essentially the importer relies on the converter and calls create on claims repostitory
            // .. this verifies that.
            mockClientRepository.VerifyAllExpectations();
            mockClaimRepository.VerifyAllExpectations();
            mockConverter.VerifyAllExpectations();
        }
    }
}