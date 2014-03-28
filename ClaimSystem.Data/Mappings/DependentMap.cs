namespace ClaimSystem.Data.Mappings
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using ClaimSystem.Core.Models;

    #endregion

    public class DependentMap : EntityTypeConfiguration<Dependent>
    {
        public DependentMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.Claims).WithOptional(x => x.Patient).HasForeignKey(x => x.PatientId);
            HasRequired(x => x.Address).WithMany(x => x.Dependents).WillCascadeOnDelete(false);
            HasOptional(x => x.Employer).WithMany(x => x.Dependents);
        }
    }
}