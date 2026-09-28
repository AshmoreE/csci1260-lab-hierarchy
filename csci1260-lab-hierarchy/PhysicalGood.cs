namespace csci1260_lab_hierarchy;

// Base class for inventory items that have physical weight.
public abstract class PhysicalGood : StockItem
{
    private double _weightPounds;

    public const decimal HandlingRate = 0.60m;

    public double WeightPounds => _weightPounds;

    protected PhysicalGood(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double weightPounds)
        : base(sku, name, unitPrice, quantityOnHand)
    {
        _weightPounds = weightPounds < 0 ? 0 : weightPounds;
    }

    public decimal ShippingCost()
    {
        return (decimal)WeightPounds * HandlingRate;
    }

    public override string Describe()
    {
        return base.Describe()
            + String.Format(", {0:N1} lb", WeightPounds);
    }
}