using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class Items
    {
        public static List<Item> craftedItems = new List<Item>();
        public static List<Item> militaryItems = new List<Item>();
        public static List<Item> medicalItems = new List<Item>();
        public static List<Item> techItems = new List<Item>();

        public static List<Item> GetCrafted()
        {
            CreateCrafted("Antidote","",true,)

            return craftedItems;
        }

        private static void CreateMilitary(string name, string description, bool singleUse, params Action[] actions)
        {
            militaryItems.Add(CreateItem(name, description, singleUse, ItemType.military, actions));
        }

        private static void CreateMedical(string name, string description, bool singleUse, params Action[] actions)
        {
            medicalItems.Add(CreateItem(name, description, singleUse, ItemType.medical, actions));
        }

        private static void CreateTechnical(string name, string description, bool singleUse, params Action[] actions)
        {
            techItems.Add(CreateItem(name, description, singleUse, ItemType.technical, actions));
        }

        private static void CreateCrafted(string name, string description, bool singleUse, params Action[] actions)
        {
            craftedItems.Add(CreateItem(name,description,singleUse,ItemType.crafted,actions));
        }

        private static Item CreateItem(string name, string description, bool singleUse, ItemType type, params Action[] actions)
        {
            return new Item
            {
                name = name,
                singleUse = singleUse,
                type = type,
                options = actions.Select(a=>new )
            };
        }
    }
}
