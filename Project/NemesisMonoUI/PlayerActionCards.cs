using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;
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
        private List<ActionCard> actionCards;
        public PlayerActionCards(GraphicsDevice graphicsDevice, Board board) : base(graphicsDevice)
        {
            this.board = board;
            actionCards = new List<ActionCard>();
            for(var i = 0; i < board.activePlayer.deck.HandCards.Count; i++)
            {
                actionCards.Add(new ActionCard(i, graphicsDevice));
            }
            //Init(graphicsDevice);
        }


        public override void Draw(GraphicsDevice graphicsDevice)
        {
            actionCards.Draw(graphicsDevice);
        }

            public void Notify(params object[] messages)
        {
            throw new NotImplementedException();
        }

        public void NotifyMove(Room room)
        {
            throw new NotImplementedException();
        }
    }

    public class ActionCard : ViewBase
    {

        public Box box;

        public ActionCard(int cardNumber, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            box = new Box(cardNumber * 60, 0, 50, 50, new Color(0, 0, 240), graphicsDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            box.Draw(graphicsDevice);
        }
    }
}
