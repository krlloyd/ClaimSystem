namespace ClaimSystem.Core.Models
{
    #region

    using System;
    using System.Xml.Serialization;

    #endregion

    [Serializable]
    public class ExtrinsicField 
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the custom field
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of this field
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The data type of the field
        /// </summary>
        public string Type { get; set; }



        #region Foreign Key
        
        [XmlIgnore]
        public int InternalClaimId { get; set; }

        #endregion


        #region Navigation Properties

        [XmlIgnore]
        public InternalClaim InternalClaim { get; set; }


        #endregion
    }
}