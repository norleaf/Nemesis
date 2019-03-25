using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Deck<T>
    {
        public Queue<T> DrawPile { get; set; }
        public List<T> Discards { get; set; }
        public List<T> HandCards { get; set; }

        public Deck()
        {
            DrawPile = new Queue<T>();
            Discards = new List<T>();
            HandCards = new List<T>();
        }

        public Deck(params T[] cards)
        {
            DrawPile = new Queue<T>();
            Discards = new List<T>();
            HandCards = new List<T>();

            cards.ToList().ForEach(r => DrawPile.Enqueue(r));
        }



        public T DrawCard()
        {
            if (!DrawPile.Any())
            {
                DrawPile = new Queue<T>(Discards.Shuffle().ToArray());
                Discards.Clear();
            }
            var card = DrawPile.Dequeue();
            HandCards.Add(card);
            return card;
        }

        public void Discard(T card)
        {
            HandCards.Remove(card);
            Discards.Add(card);
        }

        public void DiscardHand()
        {
            Discards.AddRange(HandCards.ToArray());
            HandCards.Clear();
        }

        public void DiscardMultible(params T[] cards)
        {
            
            HandCards.RemoveAll(c=> cards.Contains(c));
            Discards.AddRange(cards);
        }
    }
}
