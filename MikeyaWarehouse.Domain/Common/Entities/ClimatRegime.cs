using MikeyaWarehouse.Domain.Common.ValueObjects;

namespace MikeyaWarehouse.Domain.Common.Entities;

public record ClimatRegime(
    TemperatureRange TemperatureRange,
    HumidityRange HumidityRange);

