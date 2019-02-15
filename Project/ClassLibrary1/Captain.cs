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
            
        }

        public void CaptainCards()
        {
            
            for (int i = 0; i < 10; i++)
            {
                deck.DrawPile.Enqueue(
                    new Card(
                        "default", 
                        new BasicRepairs
                        {
                            name = "do nothing",
                            description = "do nothing at all...",
                            
                        }
                    )
                );
            }
           
        }

    }
}
