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
    public class NemesisEventCard : EventCard
    {
        public int moveDirection;
        public ResourceManager resourceManager;
        public Action<Board> EventEffect;



        public NemesisEventCard(int moveDirection, string name, string description, Action<Board> eventEffect, params Type[] types) : base(name, description, types.TypeToString())
        {
            this.EventEffect = eventEffect;
            this.moveDirection = moveDirection;

        }

        public override void ResolveEvent(Board board)
        {
            EventEffect(board);
            board.eventCards.Discard(this);
        }

        public override void MoveEnemies(Board board)
        {

            //todo: Implement movement of aliens
        }


    }

    public static class EventDeck
    {
       

        public static Queue<EventCard> GenerateCards()
        {
            Queue<EventCard> cards = new Queue<EventCard>();



            cards.Enqueue(new NemesisEventCard(1, "Coolant Leak", "Coolant leak description coming soon", EventEffectActions.coolleak, new Type[] { Type.adult, Type.breeder, Type.queen }));

            return cards;
        }
    }

    public static class EventEffectActions
    {
        public static Action<Board> coolleak = (b) => { };
    }
}
