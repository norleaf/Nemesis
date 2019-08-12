using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public abstract class NemesisEventCard : EventCard
    { 
        public int moveDirection;
        public ResourceManager resourceManager;

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

    public class DamagingFire : NemesisEventCard
    {
        public DamagingFire() : base(1,"Damaging Fire","...", Type.adult.ToString())
        {
        }

        public override void ResolveEvent(Board board)
        {
            base.ResolveEvent(board);
            board.listener.Notify(name, description);
            //todo: resolve damaging fire
        }
    }

    public class NestProtection : NemesisEventCard
    {
        public NestProtection() : base(2, "Nest Protection", resourceManager.GetString(""), Type.creeper.ToString())
        { }
    }

    //public class TestCards
    //{
    //    List<Card> cards;

    //    public TestCards()
    //    {
    //        cards = new List<Card>();

    //    }
    //}
}
