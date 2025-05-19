using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Pallet.Entities;
using MikeyaWarehouse.Domain.Pallet.Enumerations;
using MikeyaWarehouse.Domain.Product.ValueObjects;

namespace MikeyaWarehouse.Domain.Product;

public sealed class Pallet : AggregateRoot<PalletId>
{
    private readonly List<CardBoardBox> _boxes = [];
    private readonly List<ProductItem> _rowItems = [];// to store the items without a box (like a large ones)
    
    public PalletType Type { get; }
    public Dimensions Dimensions { get; }
    
}
