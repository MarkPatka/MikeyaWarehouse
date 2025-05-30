﻿using MikeyaWarehouse.Domain.PalletAggregate.Entities;

namespace MikeyaWarehouse.Wpf.Models.Domain;

public record ProductModel
{
    public int Id              { get; }
    public int InStock         { get; }
    public string BarCode      { get; }
    public string Dimensions   { get; }
    public string Status       { get; }
    public string Name         { get; }
    public double Volume       { get; }
    public double Weight       { get; }
    public DateOnly Expires    { get; }
    public DateOnly Production { get; }

    public ProductModel(Product product)
    {
        Id = product.Id.Value;
        Name = product.Name;
        InStock = product.InStock;
        Production = product.Production;
        Expires = product.Expires;
        BarCode = product.BarCode.Text;
        Dimensions = $"{product.Dimensions.Length}" +
                    $"x{product.Dimensions.Width}" +
                    $"x{product.Dimensions.Height}";
        Status = product.Status.Name;
        
        Volume = product.Dimensions.Volume;
        Weight = product.Dimensions.Weight;
    }
}
