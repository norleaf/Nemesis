using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Board
    {
        public Random random;
        public Dictionary<int,Room> rooms;
        public List<Corridor> corridors;
        public Bag<RoomEvent> roomEvents;
        public Targets targets;
        public Bag<Enemy> enemies;
        public Deck<AttackCard> attackCards;
        public Deck<EventCard> eventCards;
        public int turn;
        public List<string> log;
        public PlayerCharacter activePlayer;

        public Board()
        {
            log = new List<string>();
            turn = 0;
            random = new Random();
            rooms = new Dictionary<int, Room>();
            corridors = new List<Corridor>();
            roomEvents = new Bag<RoomEvent>();
            targets = new Targets();
            enemies = new Bag<Enemy>();
            attackCards = new Deck<AttackCard>();
            eventCards = new Deck<EventCard>();
        }

        public List<Room> Rooms()
        {
            return rooms.Values.ToList();
        }

        public void EventPhase()
        {
            AdvanceTurn();
            EnemyAttacks();
            FireDamage();
            ResolveEventCard();
            EvolveTokenBag();
            PassFirstPlayerToken();
            PlayerPhase();
        }

        private void ResolveEventCard()
        {
            var card = eventCards.DrawCard();
            card.MoveEnemies(this);
            card.ResolveEvent(this);
        }

        private void PlayerPhase()
        {
            var players = targets.Players;
            foreach (var player in players)
            {
                player.FillHand();
            }
            activePlayer.CalculateOptions(this);
        }

        private void PassFirstPlayerToken()
        {
            var players =targets.Players
                .OrderBy(c => c.number)
                .ToList();

            var oldFirstplayer = players.Single(r => r.firstPlayer);

            foreach (var p in players)
            {
                p.passed = false;
                p.actionsTakenInTurn = 0;
            }
                        
            var index = players.IndexOf(oldFirstplayer);
            oldFirstplayer.firstPlayer = false;

            int nextIndex = (index + 1) < players.Count ? index++ : 0;
            var newFirstplayer = players[nextIndex];
            newFirstplayer.firstPlayer = true;
            activePlayer = newFirstplayer;
            
        }

        private void FireDamage()
        {
           // throw new NotImplementedException();
        }

        private void EvolveTokenBag()
        {
           // throw new NotImplementedException();
        }

        private void EnemyAttacks()
        {
            foreach (var target in targets.Enemies )
            {
                Enemy enemy = (Enemy)target;
                enemy.Attack(this);
            }
        }

        public Room GetRoom(int id)
        {
            return rooms[id];
        }
    

        public virtual void AdvanceTurn()
        {
            turn++;
            Log("Turn {0} starting...", turn);
        }

        public void Log(string message, params object[] parameters)
        {
            log.Add(string.Format(message, parameters) );
        }

       

        public void NextPlayer(PlayerCharacter player)
        {
            var activePlayers = targets.Players
                .Where(p=>p.HasUsableHandCards() && !p.passed)
                .OrderBy(r => r.number)
                .ToList();

            if (activePlayers.Any())
            {
                int index = activePlayers.IndexOf(player);
                int nextIndex = (index + 1) >= activePlayers.Count ? index++ : 0;
                var nextplayer = activePlayers[nextIndex];
                activePlayer = nextplayer;
                activePlayer.CalculateOptions(this);
            }
            else
            {
                //The player phase is over.
                //Todo: notify ui listeners. 
                //Todo: implement observer listener.
                EventPhase();
            }
        }

        
    }

    public interface ILayout
    {
        List<Room> AdditionalRooms { get; set; }
        List<Room> BasicRooms { get; set; }
        List<Room> FixedRooms { get; set; }
        Dictionary<int,Room> AllRooms { get; }
        List<Corridor> Corridors { get; set; }
    }

    //public class BoardSetup
    //{
    //    public List<Room> fixedRooms;
    //    public List<Room> basicRooms;
    //    public List<Room> additionalRooms;
    //    public List<Room> boardLayout;
    //    public List<Corridor> corridors;
        

     //   public BoardSetup(ILayout layout)
     //   {
     //       corridors = new List<Corridor>(layout.Corridors);
     //       fixedRooms = new List<Room>(layout.FixedRooms);
     //       basicRooms = new List<Room>();
     //       additionalRooms = new List<Room>();
     //       boardLayout = new List<Room>(layout.BasicRooms.Union(layout.AdditionalRooms).Union(layout.FixedRooms));
     //   }

     //   public Room GetLayout(int id)
     //   {
     //       return boardLayout.Single(r => r.id == id);
     //   }
     //}

    public static class Extensions
    {
        

        public static List<T> Shuffle<T>(this List<T> list )
        {
            var random = new Random();
            var tempList = new List<T>();
            while (list.Any())
            {
                T element = list[random.Next(list.Count())];
                tempList.Add(element);
                list.Remove(element);
            }
            list.AddRange(tempList);
            return list;
        }

        public static void Add<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }

        public static List<T> New<T>(this List<T> list)
        {
            return new List<T>();
           
        }

    }
}
