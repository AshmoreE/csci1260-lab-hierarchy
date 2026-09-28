namespace csci1260_lab_hierarchy;

// Represents a service inventory item that can qualify for sale pricing.
public class ServiceItem : StockItem, IDiscountable
{
    private double _laborHours;

    public double LaborHours => _laborHours;

    public bool IsOnSale => LaborHours >= 2.0;

    public ServiceItem(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double laborHours)
        : base(sku, name, unitPrice, quantityOnHand)
    {
        _laborHours = laborHours;
    }

    public override string Category()
    {
        return "Service";
    }

    public override decimal HandlingFee()
    {
        return 0m;
    }

    public decimal SalePrice()
    {
        if (IsOnSale)
        {
            return UnitPrice * 0.85m;
        }

        return UnitPrice;
    }

    public override string Describe()
    {
        return base.Describe()
            + String.Format(", {0:N1} labor hours", LaborHours);
    }
}