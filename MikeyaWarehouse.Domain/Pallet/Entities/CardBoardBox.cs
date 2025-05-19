using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Pallet.ValueObjects;
using MikeyaWarehouse.Domain.Product;

namespace MikeyaWarehouse.Domain.Pallet.Entities;

public class CardBoardBox : Entity<CardBoardBoxId>
{
    private readonly List<ProductItem> _boxedProducts = [];

    public Dimensions Dimensions { get; }
    public DateTime Expire { get; }
    public DateTime Production { get; }
    public BarCode Code { get; }

}
