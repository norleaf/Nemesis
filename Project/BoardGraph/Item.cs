using System.Collections.Generic;

namespace BoardGraph
{
    public class Item
    {
        public bool singleUse =false;
        public string name;
        public ItemType type;
        public CraftComponent craftComponent;
        public List<Option> options;

        public Item(string name, params Option[] optionParams)
        {
            this.name = name;
            options = new List<Option>();
            options.AddRange(optionParams);
        }
    }

    public class Weapon : Item
    {
        public int ammo;

        public Weapon(string name, params Option[] optionParams) : base(name, optionParams)
        {
        }
    }

    public enum CraftComponent
    {
        chemical,
        tool,
        cloth,
        electrical
    }

    public enum ItemType
    {
        crafted,
        military,
        technical,
        medical,
        weapon
    }
}