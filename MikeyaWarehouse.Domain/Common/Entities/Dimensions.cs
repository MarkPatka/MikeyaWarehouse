namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public record Dimensions 
{
    public double Length { get; init; }
    public double Width  { get; init; }
    public double Height { get; init; }
    public double Weight { get; init; }

    public double Volume => Length * Width * Height;
}
