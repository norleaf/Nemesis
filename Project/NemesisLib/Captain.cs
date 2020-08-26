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
                new SearchCard1(),
                new SearchCard2(),
                new SuppressiveFireCard(),
                new OrderCard(),
                new ReloadCard(),
                new DemolitionCard(),
                new RestCard(),
                new MotivationCard(),
                new InterruptionCard()
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
