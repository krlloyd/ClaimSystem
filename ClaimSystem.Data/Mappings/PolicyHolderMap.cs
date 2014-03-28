namespace ClaimSystem.Data.Mappings
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using ClaimSystem.Core.Models;

    #endregion

    public class PolicyHolderMap : EntityTypeConfiguration<PolicyHolder>
    {
        public PolicyHolderMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.Claims).WithRequired(x => x.PolicyHolder);
            HasRequired(x => x.Address).WithMany(x => x.PolicyHolders).WillCascadeOnDelete(false);
            HasOptional(x => x.Employer).WithMany(x => x.PolicyHolders);
        }
    }
}