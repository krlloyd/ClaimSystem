namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    #endregion

    [Serializable]
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        [XmlIgnore]
        public ICollection<Employer> Employers { get; set; }
        [XmlIgnore]
        public ICollection<PolicyHolder> PolicyHolders { get; set; }
        [XmlIgnore]
        public ICollection<Dependent> Dependents { get; set; }
    }
}