
using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    public List<string> name;
    public List<int> amount;

    public InventoryData(List<string> name, List<int> amount)
    {
        this.name = name;
        this.amount = amount;
    }
}
