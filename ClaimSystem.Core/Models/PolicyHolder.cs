namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using ClaimSystem.Core.Enums;

    #endregion

    /// <summary>
    /// Represents the person in which the medical insurance belongs too
    /// </summary>
    [Serializable]
    public class PolicyHolder : Person
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime? EffectiveDate { get; set; }

        [XmlIgnore]
        public ICollection<InternalClaim> Claims { get; set; }

        #region Foreign Keys
        [XmlIgnore]
        public Guid? EmployerId { get; set; }
        #endregion

        #region Navigation Properties
        public Employer Employer { get; set; }
        #endregion
    }
}