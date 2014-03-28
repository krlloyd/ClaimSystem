namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using ClaimSystem.Core.Enums;

    #endregion

    [Serializable]
    public class Dependent : Person
    {
        public Guid Id { get; set; }
        public RelationShip RelationShip { get; set; }
        public bool IsEmployed { get; set; }
        public bool WasEmployedPastYear { get; set; }
        public bool HasAnotherPlan { get; set; }
        public bool HasMedicare { get; set; }
        public string NameOfInsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PlanType { get; set; }
        
        
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