namespace csci1260_lab_hierarchy;

// Base class containing the data and behavior shared by every inventory item.
public abstract class StockItem : IReportable
{
    private string _sku;
    private string _name;
    private decimal _unitPrice;
    private int _quantityOnHand;
    private List<StockMovement> _history;
    private int _nextSeq;

    public string Sku => _sku;
    public string Name => _name;
    public decimal UnitPrice => _unitPrice;
    public int QuantityOnHand => _quantityOnHand;
    public int MoveCount => _history.Count;

    protected StockItem(
        string sku,
        string name,
        decimal unitPrice,
        int quantityOnHand)
    {
        _sku = sku;
        _name = name;

        _unitPrice = unitPrice < 0 ? 0 : unitPrice;
        _quantityOnHand = quantityOnHand < 0 ? 0 : quantityOnHand;

        _history = new List<StockMovement>();
        _nextSeq = 1;
    }

    public abstract string Category();
    public abstract decimal HandlingFee();
    public decimal ExtendedValue()
    {
        return (UnitPrice + HandlingFee()) * QuantityOnHand;
    }

    public bool Receive(int count)
    {
        if (count <= 0)
        {
            return false;
        }

        _quantityOnHand += count;

        StockMovement movement =
            new StockMovement(_nextSeq, "Received", count);

        _history.Add(movement);
        _nextSeq++;

        return true;
    }

    public bool Release(int count)
    {
        if (count <= 0 || count > QuantityOnHand)
        {
            return false;
        }

        _quantityOnHand -= count;

        StockMovement movement =
            new StockMovement(_nextSeq, "Released", count);

        _history.Add(movement);
        _nextSeq++;

        return true;
    }

    public string MovementLines()
    {
        string result = "";

        foreach (StockMovement movement in _history)
        {
            if (result.Length > 0)
            {
                result += "\n";
            }

            result += movement.Describe();
        }

        return result;
    }

    public virtual string Describe()
    {
        return String.Format(
        "{0} {1} ({2})",
        Sku,
        Name,
        Category()
        );
    }

    public string ReportLine()
    {
        return String.Format(
            " {0,-7} {1,-21} {2,-10} {3,4} ${4,11:N2}",
            Sku,
            Name,
            Category(),
            QuantityOnHand,
            ExtendedValue()
            );
    }

    public override string ToString()
    {
        return Describe();
    }
}