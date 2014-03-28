namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    #endregion

    [Serializable]
    public class InternalClaim
    {
        private List<ExtrinsicField> _extrinsics;
 
        public InternalClaim()
        {
            _extrinsics = new List<ExtrinsicField>();
        }
        public Guid Id { get; set; }
        public string ClaimId { get; set; }
        public bool OccurredAtEmployment { get; set; }
        public bool CausedFromAutoAccident { get; set; }
        public string AccidentDescription { get; set; }


        public virtual List<ExtrinsicField> Extrinsics
        {
            get { return _extrinsics; }
            set { _extrinsics = value; }
        }

        #region Foreign Keys
        
        [XmlIgnore]
        public Guid ClientId { get; set; }
        [XmlIgnore]
        public Guid CustomerId { get; set; }
        [XmlIgnore]
        public Guid? PatientId { get; set; }
    
        #endregion

        #region Navigation Properties
       
        public Client Client { get; set; }
        public PolicyHolder PolicyHolder { get; set; }
        public Dependent Patient { get; set; }
       
        #endregion
        
    }
}