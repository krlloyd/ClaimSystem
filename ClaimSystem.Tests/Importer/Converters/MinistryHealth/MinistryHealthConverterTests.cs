using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimSystem.Tests.Importer.Converters.MinistryHealth
{
    using ClaimSystem.Core.Models;
    using ClaimSystem.Importer.Converters.MinistryHealth;
    using NUnit.Framework;

    [TestFixture]
    public class MinistryHealthConverterTests
    {
        [Test] 
        public void Properly_Converts_Xml_To_One_InternalClaims()
        {
            // SETUP
            var converter = new MinistryHealthConverter();
            var mockClient = new Client {Name = "Ministry Health Care"};
            var results = converter.Process(@"Importer/Converters/MinistryHealth/MinistrySampleClaim.xml", mockClient);

            // Assert we have only one internal claim converted
            Assert.That(results.Count(),Is.EqualTo(1));

        }

        [Test]
        public void Converted_Ministry_Claim_Has_Corrent_Data()
        {
            // SETUP
            var converter = new MinistryHealthConverter();
            var mockClient = new Client { Name = "Ministry Health Care" };
            var results = converter.Process(@"Importer/Converters/MinistryHealth/MinistrySampleClaim.xml", mockClient);

            var claim = results.FirstOrDefault();

            // Assert various data point to ensure it maps correctly. Could add each point from file to 
            // Build comprehensive test.
            Assert.That(claim.ClaimId, Is.EqualTo("1230000"));
            Assert.That(claim.AccidentDescription, Is.EqualTo("Broke Left Arm"));
    
        }
    }
}
