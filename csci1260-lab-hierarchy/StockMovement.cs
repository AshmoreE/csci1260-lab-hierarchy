namespace csci1260_lab_hierarchy;

// Stores information about one completed invetory movement.
public class StockMovement
{
    private int _seq;
    private string _kind;
    private int _count;

    public int Seq => _seq;
    public string Kind => _kind;
    public int Count => _count;

    public StockMovement(int seq, string kind, int count)
    {
        _seq = seq;
        _kind = kind;
        _count = count;
    }

    public string Describe()
    {
        return String.Format("   move {0}: {1} {2}", Seq, Kind, Count);
    }
}