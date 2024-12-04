

public abstract class BackPackingSolverSmartBase : BackPackingSolverBase
{
    protected BackPackingSolverSmartBase(List<BackPackItem> items, double capacity)
        : base(items, capacity)
    {
    }
    public override void Solve(ItemVault theItemVault, BackPack theBackPack)
    {
        string description = PickNextItemFromVault(theItemVault, theBackPack.WeightCapacityLeft);
        if (description != string.Empty)
        {
            BackPackItem item = theItemVault.RemoveItem(description);
            theBackPack.AddItem(item);
            Solve(theItemVault, theBackPack);
        }
    }

    private string PickNextItemFromVault(ItemVault theItemVault, double weightLimit)
    {
        double bestValue = 0;
        BackPackItem? bestItem = null;

        foreach (var item in theItemVault.Items)
        {
            if (item.Weight <= weightLimit)
            {
                double candidateValue = ActualItemValue(item);

                if (candidateValue > bestValue)
                {
                    bestValue = candidateValue;
                    bestItem = item;
                }

            }

        }

        return (bestItem != null) ? bestItem.Description : string.Empty;
    }

    protected abstract double ActualItemValue(BackPackItem item);
 
}
