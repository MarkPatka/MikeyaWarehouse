using MikeyaWarehouse.Domain.Common.ValueObjects;

namespace MikeyaWarehouse.Domain.Common.Entities;


public class ClimatRegime
{
    public TemperatureRange TemperatureRange { get; set; }
    public HumidityRange HumidityRange { get; set; }

#pragma warning disable CS8618
    private ClimatRegime() { }
#pragma warning restore CS8618


    public ClimatRegime(TemperatureRange temperatureRange, HumidityRange humidityRange)
    {
        TemperatureRange = temperatureRange;
        HumidityRange = humidityRange;
    }
}


