using MikeyaWarehouse.Domain.Common.Abstract;
using System.Text;

namespace MikeyaWarehouse.Domain.ShipmentAggregate.Enumerations;
public sealed class ShipmentStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly ShipmentStatus REQUESTED  = new(1, nameof(REQUESTED), "Запрошена");
    public static readonly ShipmentStatus REGISTERED = new(2, nameof(REGISTERED), "Зарегистрирована");
    public static readonly ShipmentStatus COMING     = new(3, nameof(COMING), "Ожидается");
    public static readonly ShipmentStatus PROCESSING = new(4, nameof(PROCESSING), "Обрабатывается");
    public static readonly ShipmentStatus FINISHED   = new(5, nameof(FINISHED), "Завершена");



}

