using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisClasses
{
    public static class Items
    {
        public static List<Item> craftedItems = new List<Item>();
        List<Item> militaryItems = new List<Item>();
        List<Item> medicalItems = new List<Item>();
        List<Item> techItems = new List<Item>();

        public static List<Item> GetCrafted()
        {
            

            return craftedItems;
        }

        private static createCrafted(string name, string description, bool singleUse, params Option[] options)
        {
            craftedItems.Add(new Item {
                name = name,
                singleUse = singleUse,
                type = ItemType.crafted,
                
            });
        }
    }
}
