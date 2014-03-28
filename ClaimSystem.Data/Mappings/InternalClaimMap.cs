namespace ClaimSystem.Data.Mappings
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using ClaimSystem.Core.Models;

    #endregion

    public class InternalClaimMap : EntityTypeConfiguration<InternalClaim>
    {
        public InternalClaimMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Client);
            HasRequired(x => x.PolicyHolder).WithMany(x => x.Claims);

            // Optional because we do not want to create a record if patient is the same as the policy holder.
            HasOptional(x => x.Patient).WithMany(x => x.Claims);
           
            HasMany(x => x.Extrinsics).WithRequired(x => x.InternalClaim);
        }
    }
}