namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Xml.Serialization;

    #endregion

    [Serializable]
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Telephone { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }


        #region Foreign Key

        [XmlIgnore]
        public Guid AddressId { get; set; }
     
        #endregion

        #region Navigation Properties
        
        public Address Address { get; set; }
        
        #endregion
    }
}