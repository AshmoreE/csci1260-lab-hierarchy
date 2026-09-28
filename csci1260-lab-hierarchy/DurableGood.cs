namespace csci1260_lab_hierarchy;

// Represents a physical inventory item that includes a warranty.
public class DurableGood : PhysicalGood
{
    private int _warrantyMonths;

    public int WarrantyMonths => _warrantyMonths;

    public DurableGood(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double weightPounds,
        int warrantyMonths)
        : base(sku, name, unitPrice, quantityOnHand, weightPounds)
    {
        _warrantyMonths = warrantyMonths;
    }

    public override string Category()
    {
        return "Durable";
    }

    public override decimal HandlingFee()
    {
        return ShippingCost();
    }

    public override string Describe()
    {
        return base.Describe()
            + String.Format(", {0} month warranty", WarrantyMonths);
    }
}