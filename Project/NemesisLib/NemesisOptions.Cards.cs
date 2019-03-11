using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{


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

    public class SearchCard : Card
    {
        public SearchCard() : base("Search", new Search())
        {
        }

        public class Search : Option
        {
            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }
}
