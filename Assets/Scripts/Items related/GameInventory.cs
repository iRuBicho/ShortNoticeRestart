using System.Collections.Generic;

public static class GameInventory
{
    private static Dictionary<string, int> inventory = new Dictionary<string, int>();

    public static void AddItem(string itemName, int amount = 1)
    {
        if (inventory.ContainsKey(itemName))
            inventory[itemName] += amount;
        else
            inventory[itemName] = amount;
    }

    public static Dictionary<string, int> GetInventory()
    {
        return inventory;
    }

    public static int GetCount(string itemName)
    {
        return inventory.TryGetValue(itemName, out int value) ? value : 0;
    }
}
