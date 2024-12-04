public class BackPackingSolverSmart : BackPackingSolverSmartBase
{
    public BackPackingSolverSmart(List<BackPackItem> items, double capacity)
        : base(items, capacity)
    {
    }
    

    protected override double ActualItemValue(BackPackItem item)
    {
        return item.Value / item.Weight;
    }
}

