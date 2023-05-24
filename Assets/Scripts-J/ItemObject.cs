public enum ItemType
{
    Weapon,
    Armor
}

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Icon { get; set; }
    public ItemType Type { get; set; }

    // Attributes specific to weapon
    public int Damage { get; set; }

    // Attributes specific to armor
    public int Defense { get; set; }

    // Constructor to set the item type and initialize attributes
    public Item(ItemType type)
    {
        Type = type;

        // Initialize attributes based on the item type
        if (type == ItemType.Weapon)
        {
            Damage = 0;
        }
        else if (type == ItemType.Armor)
        {
            Defense = 0;
        }
    }
}
