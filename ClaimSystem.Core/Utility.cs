namespace ClaimSystem.Core
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using ClaimSystem.Core.Enums;
    using ClaimSystem.Core.Models;

    #endregion

    public class Utility
    {
        public static void WriteSampleClaimXml(string xmlFile, InternalClaim claim)
        {
            var writer = new XmlSerializer(typeof (InternalClaim));
            using (var file = new StreamWriter(xmlFile))
            {
                writer.Serialize(file, claim);
            }
        }
    }
}