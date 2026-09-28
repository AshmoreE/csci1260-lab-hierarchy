namespace csci1260_lab_hierarchy;

// Contract for inventory items that are eligible for sale pricing.
public interface IDiscountable
{
    bool IsOnSale { get; }
    decimal SalePrice();
}