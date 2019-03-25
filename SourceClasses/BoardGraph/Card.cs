using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Card
    {
        public string name;
        public bool contamination = false;
        public List<Option> options;

        public Card(string name, params Option[] optionsParams)
        {
            options = new List<Option>();
            options.AddRange(optionsParams);
        }
    }
    
    public class Contamination : Card
    {
        public bool infected;

        public Contamination(string name, bool infected, params Option[] optionsParams) : base(name, optionsParams)
        {
            contamination = true;
            this.infected = infected;
        }
    }
}
