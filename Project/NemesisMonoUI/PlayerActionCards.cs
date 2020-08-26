using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;
using NemesisLibrary;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisMonoUI
{
    public class PlayerActionCards : ViewBase, Listener
    {
        private Board board;
        private Dictionary<string,ActionCardView> actionCards;
        private List<ActionCardView> playerHand;
        public PlayerActionCards(GraphicsDevice graphicsDevice, Board board) : base(graphicsDevice)
        {
            this.board = board;
            board.activePlayer.listeners.Add(this);
            actionCards = CreateCards(graphicsDevice);
            UpdateHand();

            //Init(graphicsDevice);
        }

        public Dictionary<string,ActionCardView> CreateCards(GraphicsDevice graphicsDevice)
        {
            var dic = new Dictionary<string, ActionCardView>();
            AddCard<BasicRepairsCard>(dic,0, 0, 240, graphicsDevice);
            AddCard<SearchCard1>(dic,0, 240, 240, graphicsDevice);
            AddCard<SearchCard2>(dic,0, 240, 240, graphicsDevice);
            AddCard<InterruptionCard>(dic,240, 0, 240, graphicsDevice);
            AddCard<MotivationCard>(dic,240, 0, 0, graphicsDevice);
            AddCard<RestCard>(dic,100, 0, 100, graphicsDevice);
            AddCard<DemolitionCard>(dic,100, 0, 240, graphicsDevice);
            AddCard<ReloadCard>(dic,0, 240, 0, graphicsDevice);
            AddCard<OrderCard>(dic,150, 150, 150, graphicsDevice);
            AddCard<SuppressiveFireCard>(dic,240, 160, 80, graphicsDevice);
           // dic.Add(typeof(SearchCard1).Name, new ActionCardView(new SearchCard1(), new Color(0, 240, 240), graphicsDevice));
           // dic.Add(typeof(SearchCard2).Name, new ActionCardView(new SearchCard2(), new Color(0, 220, 240), graphicsDevice));
           // dic.Add(typeof(InterruptionCard).Name, new ActionCardView(new InterruptionCard(), new Color(100, 100, 0), graphicsDevice));
            return dic;
        }

        public void AddCard<T>(Dictionary<string, ActionCardView> dic, int red, int green, int blue, GraphicsDevice graphicsDevice) where T : Card
        {
            Card card = (T)Activator.CreateInstance(typeof(T));
            dic.Add(card.GetType().Name, new ActionCardView(card, new Color(red, green, blue), graphicsDevice));
        }

        public void UpdateHand()
        {
            playerHand = board.activePlayer.deck.HandCards
                .Select(card => actionCards[card.GetType().Name]).ToList();
            for (int i = 0; i < playerHand.Count; i++)
            {
                var box = playerHand[i].box;
                box.offset = new Vector3(i * 60, 0, 0);
                box.vertexBuffer.SetData(box.VerticeArray);
            }
        }


        public override void Draw(GraphicsDevice graphicsDevice)
        {
            playerHand.Draw(graphicsDevice);
        }

        public void Notify(params object[] messages)
        {
            throw new NotImplementedException();
        }

        public void NotifyMove(Room room)
        {
            UpdateHand();
        }
    }

    public class ActionCardView : ViewBase
    {

        public Box box;
        public Card card;

        public ActionCardView(Card card, Color color, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.card = card;
            box = new Box(0, 0, 50, 50, color, graphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            box.Draw(graphicsDevice);
        }

         
    }
}
