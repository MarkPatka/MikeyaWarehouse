namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public readonly record struct Dimensions 
{
    public double Length { get; init; }
    public double Width  { get; init; }
    public double Height { get; init; }
    public double Weight { get; init; }

    public readonly double Volume => Length * Width * Height;
}
