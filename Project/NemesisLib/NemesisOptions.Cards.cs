using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class ContaminationCard : Card
    {
        public bool infected;

        public ContaminationCard(string name, bool infected, params Option[] optionsParams) : base(name, optionsParams)
        {
            contamination = true;
            this.infected = infected;
        }

        public static void GenerateBag(Bag<Card> contaminations)
        {
            for(int i = 0; i < 20; i++)
            {
                contaminations.Put(new ContaminationCard("contamination", false, new Option[0]));
            }
            for (int i = 0; i < 7; i++)
            {
                contaminations.Put(new ContaminationCard("contamination", true, new Option[0]));
            }
        }
    }

    public class BasicRepairsCard : Card
    {
        public BasicRepairsCard() : base("Basic Repairs", new BasicRepairs())
        {
        }

        public class BasicRepairs : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class InterruptionCard : Card
    {
        public InterruptionCard() : base("Interruption", new Interruption())
        {
        }

        public class Interruption : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class MotivationCard : Card
    {
        public MotivationCard() : base("Motivation", new Motivation())
        {
        }

        public class Motivation : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class RestCard : Card
    {
        public RestCard() : base("Rest", new Rest())
        {
        }

        public class Rest : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class DemolitionCard : Card
    {
        public DemolitionCard() : base("Demolition", new Demolition())
        {
        }

        public class Demolition : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class ReloadCard : Card
    {
        public ReloadCard() : base("Reload", new Reload())
        {
        }

        public class Reload : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class OrderCard : Card
    {
        public OrderCard() : base("Order", new Order())
        {
        }

        public class Order : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class SuppressiveFireCard : Card
    {
        public SuppressiveFireCard() : base("Suppressive Fire", new SuppressiveFire())
        {
        }

        public class SuppressiveFire : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }


    public class SearchCard1 : Card
    {
        public SearchCard1() : base("Search", new Search())
        {
        }
    }

    public class Search : Option
    {
        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }

    public class SearchCard2 : Card
    {
        public SearchCard2() : base("Search", new Search())
        {
        }
    }
}
