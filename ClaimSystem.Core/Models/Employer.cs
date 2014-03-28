namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    #endregion

    [Serializable]
    public class Employer 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        #region Foreign Key

        [XmlIgnore]
        public Guid AddressId { get; set; }
    
        #endregion

        #region Navigation Properties

        public Address Address { get; set; }
       
        [XmlIgnore]
        public ICollection<PolicyHolder> PolicyHolders { get; set; }
        [XmlIgnore]
        public ICollection<Dependent> Dependents { get; set; }
        #endregion
    }
}