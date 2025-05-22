using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Domain.ContractorsAggregate;
using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class PalletsTableConfiguration 
    : IEntityTypeConfiguration<Pallet>
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        ConfigurePalletTable(builder);
        ConfigureProductBoxTable(builder);
    }

    private void ConfigureProductBoxTable(
        EntityTypeBuilder<Pallet> builder)
    {
    }

    private void ConfigurePalletTable(
        EntityTypeBuilder<Pallet> builder)
    {

    }
}
