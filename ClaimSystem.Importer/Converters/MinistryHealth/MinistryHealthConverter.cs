namespace ClaimSystem.Importer.Converters.MinistryHealth
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClaimSystem.Core.Models;
    using ClaimSystem.Importer.Converters.Base;

    #endregion

    public interface IMinistryHealthConverter
    {
        IEnumerable<InternalClaim> Process(string feedPath, Client client);
    }

    public class MinistryHealthConverter : XmlConverterBase<InternalClaim, Claims>, IMinistryHealthConverter
    {
        private Client _client;

        public IEnumerable<InternalClaim> Process(string feedPath, Client client)
        {
            _client = client;
            return Process(feedPath);
        }

        /// <summary>
        /// You implement this method for each specific customer. This is where things get mapped.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected override IEnumerable<InternalClaim> MapSourceToModel(Claims source)
        {
            ConvertionResults = new List<InternalClaim>();

            foreach (var claimDocument in source.ClaimDocument)
            {
                var internalClaim = new InternalClaim
                    {
                        ClaimId = claimDocument.ClaimId,
                        Client = _client,
                        AccidentDescription = claimDocument.Description,
                        CausedFromAutoAccident = claimDocument.IsAutoAccident == "true"
                    };

                var customer = claimDocument.GetCustomerRows().FirstOrDefault();
                var patient = claimDocument.GetPatientRows().FirstOrDefault();

                if (customer != null)
                {
                    internalClaim.PolicyHolder = new PolicyHolder
                        {
                            FirstName = customer.First,
                            LastName = customer.Last,
                            MiddleName = customer.Middle,
                            DateOfBirth = DateTime.Parse(customer.DOB),
                            AccountNumber = customer.PolicyNumber,
                            Address = new Address
                                {
                                    Street = customer.Address1,
                                    City = customer.City,
                                    State = customer.State,
                                    Zipcode = customer.PostalCode
                                },
                            Employer = new Employer
                                {
                                    Name = customer.Employer,
                                    Address = new Address
                                        {
                                            Street = customer.EmployerAddress1,
                                            City = customer.EmployerCity,
                                            State = customer.EmployerState,
                                            Zipcode = customer.EmployerPostal
                                        }
                                }
                        };
                }
                if (patient != null)
                {
                    internalClaim.Patient = new Dependent
                        {
                            FirstName = patient.First,
                            LastName = patient.Last,
                            MiddleName = patient.Middle,
                            DateOfBirth = DateTime.Parse(patient.DOB),
                            IsEmployed = patient.IsEmployed == "true",
                            Address = new Address
                                {
                                    Street = patient.Address1,
                                    City = patient.City,
                                    State = patient.State,
                                    Zipcode = patient.PostalCode
                                }
                        };
                }

                ConvertionResults.Add(internalClaim);
            }

            return ConvertionResults;
        }
    }
}