using MikeyaWarehouse.Domain.Common.ValueObjects;

namespace MikeyaWarehouse.Domain.Common.Entities;

public readonly record struct ClimatRegime
{
    public TemperatureRange TemperatureRange { get; init; }
    public HumidityRange HumidityRange { get; init; }

}
