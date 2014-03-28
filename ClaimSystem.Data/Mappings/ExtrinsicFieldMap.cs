namespace ClaimSystem.Data.Mappings
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using ClaimSystem.Core.Models;

    #endregion

    public class ExtrinsicFieldMap : EntityTypeConfiguration<ExtrinsicField>
    {
        public ExtrinsicFieldMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.InternalClaim);
        }
    }
}