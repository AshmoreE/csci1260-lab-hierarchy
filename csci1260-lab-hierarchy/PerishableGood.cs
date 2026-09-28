namespace csci1260_lab_hierarchy;

// Represents a physical inventory item that can expire and qualify for sale pricing.
public class PerishableGood : PhysicalGood, IDiscountable
{
    private int _shelfLifeDays;

    public const decimal SurchargeFee = 0.40m;

    public int ShelfLifeDays => _shelfLifeDays;

    public bool IsOnSale => ShelfLifeDays <= 3;

    public PerishableGood(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand,
        double weightPounds,
        int shelfLifeDays)
        : base(sku, name, unitPrice, quantityOnHand, weightPounds)
    {
        _shelfLifeDays = shelfLifeDays;
    }

    public override string Category()
    {
        return "Perishable";
    }

    public override decimal HandlingFee()
    {
        return ShippingCost() + SurchargeFee;
    }

    public decimal SalePrice()
    {
        if (IsOnSale)
        {
            return UnitPrice * 0.70m;
        }

        return UnitPrice;
    }

    public override string Describe()
    {
        return base.Describe()
            + String.Format(", {0} days left", ShelfLifeDays);
    }
}