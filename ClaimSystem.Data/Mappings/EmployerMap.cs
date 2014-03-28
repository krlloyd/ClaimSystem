namespace ClaimSystem.Data.Mappings
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using ClaimSystem.Core.Models;

    #endregion

    public class EmployerMap : EntityTypeConfiguration<Employer>
    {
        public EmployerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Address).WithMany(x => x.Employers).WillCascadeOnDelete(false);
            HasMany(x => x.PolicyHolders).WithOptional(x => x.Employer).WillCascadeOnDelete(false);
            HasMany(x => x.Dependents).WithOptional(x => x.Employer).WillCascadeOnDelete(false);
        }
    }
}