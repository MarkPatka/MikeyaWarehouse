namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public record Dimensions 
{
    public double Length { get; set; }
    public double Width  { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }

    public double Volume => Length * Width * Height;
}
