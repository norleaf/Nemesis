using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public abstract class NemesisEventCard : EventCard
    { 
        public int moveDirection;

        protected NemesisEventCard(int moveDirection, string name, string description, params string[] types) : base(name,description,types)
        {
            this.moveDirection = moveDirection;
        }

        public override void ResolveEvent(Board board)
        {
            board.eventCards.Discard(this);
        }

        public override void MoveEnemies(Board board)
        {
            //todo: Implement movement of aliens
        }

       
    }

    public class DamagingFireEvent : NemesisEventCard
    {
        public DamagingFireEvent() : base(1,"Damaging Fire","...", Type.adult.ToString())
        {
        }

        public override void ResolveEvent(Board board)
        {
            base.ResolveEvent(board);
            board.listener.Notify(name, description);
            //todo: resolve damaging fire
        }
    }

    public class TestCards
    {
        List<Card> cards;

        public TestCards()
        {
            cards = new List<Card>();
            
        }
    }
}
