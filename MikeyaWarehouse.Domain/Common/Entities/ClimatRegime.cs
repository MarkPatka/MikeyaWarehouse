using MikeyaWarehouse.Domain.Common.ValueObjects;

namespace MikeyaWarehouse.Domain.Common.Entities;

public record ClimatRegime(
    int Id,
    TemperatureRange TemperatureRange,
    HumidityRange HumidityRange);

