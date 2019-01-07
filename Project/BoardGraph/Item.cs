using System;
using System.Collections.Generic;

namespace BoardGraph
{
    public class Item
    {
        public bool singleUse =false;
        public string name;
        public bool combatOnly = false;
        public bool nonCombat=false;
        public bool heavy=false;
        public CraftComponent craftComponent;
        public List<Option> options;

        public Item(string name, params Option[] optionParams)
        {
            this.name = name;
            options = new List<Option>();
            options.AddRange(optionParams);
        }
    }

    public class SingleUse : Item
    {
        public SingleUse(string name, params Option[] optionParams) : base(name, optionParams)
        {
            singleUse = true;
        }
    }

    public class CombatItem : Item
    {
        public CombatItem(string name, params Option[] optionParams) : base(name, optionParams)
        {
            combatOnly = true;
        }
    }

    public class Weapon : CombatItem
    {
        public int ammo;
        public int maxAmmo;

        public Weapon(string name,int maxAmmo) : base(name, null)
        {
            this.maxAmmo = maxAmmo;
            this.ammo = maxAmmo;
            this.heavy =true;
        }

        public virtual void Shoot(Option option)
        {
            if(ammo > 0)
            {
                ammo--;
                Enemy enemy = (Enemy)option.target;
                int difficulty = enemy.size;
                int roll = option.board.random.Next(6) + 1;
                int damage = roll == 6 ? 2 : roll >= difficulty ? 1 : 0;
                Damage(option, damage);
            }
        }

        public virtual void Damage(Option option, int damage)
        {
            option.target.lightWounds += damage;
            var card = option.board.attackCards.DrawCard();
        }
    }



    public enum CraftComponent
    {
        chemical,
        tool,
        cloth,
        electrical
    }

    
}