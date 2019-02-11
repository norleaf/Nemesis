﻿using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class Captain
    {


        public Queue<Card> CaptainCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int i = 0; i < 10; i++)
            {
                cards.Enqueue(
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
            return cards;
        }

    }
}
