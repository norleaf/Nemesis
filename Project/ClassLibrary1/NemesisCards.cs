using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class NemesisCards
    {

        
    }

    public class TestCards
    {
        List<Card> cards;

        public TestCards()
        {
            cards = new List<Card>();
            var card = new Card
            (
                "Basic Repairs",
                new BasicRepairs
                {

                }

            );
        }
    }
}
