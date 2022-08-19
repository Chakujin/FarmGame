[System.Serializable]
//SCRIPT TO STACK ITEMS
public class InventoryItem
{
    public ItemData data;
    public int stackSize;

    public InventoryItem( ItemData itemData)
    {
        data = itemData;
        AddStack();
    }

    public void AddStack()
    {
        stackSize++;
    }

    public void RemoveStack()
    {
        stackSize--;
    }
}
