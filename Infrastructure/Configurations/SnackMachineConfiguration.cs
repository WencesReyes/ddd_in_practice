using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SnackMachineConfiguration : IEntityTypeConfiguration<SnackMachine>
    {
        public void Configure(EntityTypeBuilder<SnackMachine> builder)
        {
            builder.ToTable("SnackMachines").HasKey(sm => sm.Id);

            builder.Ignore(a => a.MoneyInTransaction);

            builder
              .OwnsOne(sm => sm.MoneyInside, navigationBuilder =>
              {
                  navigationBuilder.Property(money => money.OneCentCount).HasColumnName("OneCentCount");
                  navigationBuilder.Property(money => money.TenCentCount).HasColumnName("TenCentCount");
                  navigationBuilder.Property(money => money.QuarterCount).HasColumnName("QuarterCount");
                  navigationBuilder.Property(money => money.OneDollarCount).HasColumnName("OneDollarCount");
                  navigationBuilder.Property(money => money.FiveDollarCount).HasColumnName("FiveDollarCount");
                  navigationBuilder.Property(money => money.TwentyDollarCount).HasColumnName("TwentyDollarCount");
              });

            builder.Metadata.FindNavigation("MoneyInside")
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
