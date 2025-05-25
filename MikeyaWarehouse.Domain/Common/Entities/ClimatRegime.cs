using MikeyaWarehouse.Domain.Common.ValueObjects;

namespace MikeyaWarehouse.Domain.Common.Entities;


public class ClimatRegime
{
    public TemperatureRange TemperatureRange { get; set; }
    public HumidityRange HumidityRange { get; set; }

    private ClimatRegime() { }

    public ClimatRegime(TemperatureRange temperatureRange, HumidityRange humidityRange)
    {
        TemperatureRange = temperatureRange;
        HumidityRange = humidityRange;
    }
}


