namespace ClaimSystem.Core.Models
{
    #region

    using System;
   
    #endregion

    [Serializable]
    public class Client 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}