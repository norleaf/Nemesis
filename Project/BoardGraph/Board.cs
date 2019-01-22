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
        public Queue<RoomEvent> roomEvents;
        public List<Target> targets;
        public Bag<Enemy> enemies;
        public Deck<AttackCard> attackCards;
        public int turn;
        public List<string> log;

        public Board()
        {
            log = new List<string>();
            turn = 0;
            random = new Random();
            rooms = new Dictionary<int, Room>();
            corridors = new List<Corridor>();
            roomEvents = new Queue<RoomEvent>();
            targets = new List<Target>();
            enemies = new Bag<Enemy>();
            attackCards = new Deck<AttackCard>();
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
            EvolveTokenBag();
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
            foreach (var target in targets.Where(t=>t is Enemy) )
            {
                Enemy enemy = (Enemy)target;
                if (enemy.isInCombat(this))
                    enemy.Attack(this);
                else enemy.Move(this);
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

        public PlayerCharacter NextPlayer(PlayerCharacter player)
        {
            var allPlayers = targets
                .Where(t => t is PlayerCharacter)
                .Select(t => (PlayerCharacter)t);

            var activePlayers = allPlayers
                .Where(p=>p.HasUsableHandCards() && !p.passed);

            var numbers = activePlayers
                    .Select(r => r.number)
                    .OrderBy(r => r)
                    .ToList();
            int index;

            if (!activePlayers.Any())
            {

                foreach (var p in allPlayers)
                {
                    p.passed = false;
                    p.actionsTakenInTurn = 0;
                }
                EventPhase();
                index = numbers.IndexOf(allPlayers.Single(c => c.firstPlayer).number);
            }
            else
            {
                index = numbers.IndexOf(player.number);
            }
                

                

                //Todo: index +1 is it within bounds of array otherwise to 0. give turn to next player.
                if(index +1 < numbers.Count)
                {

                }
        }
    }

    public class BoardSetup
    {
        public List<Room> fixedRooms;
        public List<Room> basicRooms;
        public List<Room> additionalRooms;
        public List<Room> boardLayout;
        public List<Corridor> corridors;

        public BoardSetup()
        {
            corridors = new List<Corridor>();
            fixedRooms = new List<Room>();
            basicRooms = new List<Room>();
            additionalRooms = new List<Room>();
            boardLayout = new List<Room>();
        }

        public Room GetLayout(int id)
        {
            return boardLayout.Single(r => r.id == id);
        }
     }

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

        
    }
}
