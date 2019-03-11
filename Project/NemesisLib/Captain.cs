using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class Captain : PlayerCharacter
    {
        public Captain() : base()
        {
            name = "Captain Brenegan";
            deck = new Deck<Card>(
                new BasicRepairsCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard(),
                new SearchCard()
            );
            roomId = 11;
        }

        public void CaptainCards()
        {
            
            for (int i = 0; i < 10; i++)
            {
                deck.DrawPile.Enqueue(
                    new BasicRepairsCard()
                );
            }
           
        }

    }
}
