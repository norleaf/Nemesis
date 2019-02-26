using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public class Cockpit : Room
    {
        public Cockpit() : base(1, 2, 22, "Cockpit", "Here you can check the plottet course or enter a new destination coordinate.", isDiscovered: true)
        {
            options.Add(new ViewCoordinates(this), new CheckCoordinates(this));
        }
    }

    public class Hibernatorium : Room
    {
        public Hibernatorium() : base(11, 40, 22, "Hibernatorium", "When the preparation for the hyperdrive jump enters its final stage you must enter into cryosleep.", isDiscovered: true)
        {
            options.Add(new EnterHibernation(this));
        }
    }

    public class EngineRoom : Room
    {
        public bool EngineOperational { get; set; }
        public EngineRoom(int id, int x, int y, string name, string description = "") : base(id, x, y, name, description, isDiscovered: true)
        {
            options.Add(new RepairEngine(this));
        }
    }

    public class EngineThree : EngineRoom
    {
        public EngineThree() : base(19, 71, 7, "Engine Three", "description")
        {
        }
    }

    public class EngineTwo : EngineRoom
    {
        public EngineTwo() : base(20, 71, 25, "Engine Two", "description")
        {
        }
    }

    public class EngineOne : EngineRoom
    {
        public EngineOne() : base(21, 71, 37, "Engine One", "description")
        {

        }
    }

    public class TechnicalCorridors : Room
    {
        public TechnicalCorridors() : base(999, 5, 5, "Technical Corridors", "description", isDiscovered: true)
        {

        }
    }

    public class EscapePod : Room
    {
        public string section;
        public bool locked;
        public PlayerCharacter[] playerCharacters;
        public EscapePod(string name, string section) : base(0, 0, 0, name, isDiscovered: true)
        {
            this.section = section;
            locked = true;
            playerCharacters = new PlayerCharacter[2];
            options.Add(new Launch(this));
        }

        private class Launch : RoomOption
        {
            public Launch(Room room) : base(room)
            {
            }

            public override void Perform()
            {
                //todo: remove escape pod room and players from gameboard.
                throw new NotImplementedException();
            }
        }
    }

    public class BasicRoom : Room
    {
        public BasicRoom(int id = 0, int x = 0, int y = 0) : base(id, x, y, "basic room")
        {
        }
    }

    public class AdditionalRoom : Room
    {
        public AdditionalRoom(int id = 0, int x = 0, int y = 0) : base(id, x, y, "additional room")
        {
        }
    }



    public class AirlockControl : AdditionalRoom
    {
        public AirlockControl() : base()
        {
            options.Add(new OpenAirlock(this));
        }

        private class OpenAirlock : RoomOption
        {
            public OpenAirlock(Room room) : base(room, requiresTargetRoom: true)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Cabins : AdditionalRoom
    {
        public Cabins() : base()
        {
            options.Add(new CatchBreath(this));
        }

        private class CatchBreath : RoomOption
        {
            public CatchBreath(Room room) : base(room)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }
    public class Canteen : AdditionalRoom
    {
        public Canteen() : base()
        {
            options.Add(new Snack(this));
        }

        private class Snack : RoomOption
        {
            public Snack(Room room) : base(room)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class CommandCenter : AdditionalRoom
    {
        public CommandCenter() : base()
        {
            options.Add(new OpenCloseDoors(this));
        }

        private class OpenCloseDoors : RoomOption
        {
            public OpenCloseDoors(Room room) : base(room, requiresTargetRoom: true)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class EngineControl : AdditionalRoom
    {
        public EngineControl() : base()
        {
            options.Add(new EnginesStatus(this));
        }

        private class EnginesStatus : RoomOption
        {
            public EnginesStatus(Room room) : base(room)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class HatchControl : AdditionalRoom
    {
        public HatchControl() : base()
        {
            options.Add(new OpenCloseEscapePod(this));
        }

        private class OpenCloseEscapePod : RoomOption
        {
            public OpenCloseEscapePod(Room room) : base(room, requiresTargetRoom: true)
            {
            }

            public override void PickTargetRoom(Room target)
            {
                if (target is EscapePod)
                {
                    targetRoom = target;
                }
            }

            public override void Perform()
            {
                EscapePod escapePod = (EscapePod)targetRoom;
                escapePod.locked = !escapePod.locked;
            }
        }
    }

    public class MonitoringRoom : AdditionalRoom
    {
        public MonitoringRoom() : base()
        {
            options.Add(new CheckRoom(this));
        }

        private class CheckRoom : RoomOption
        {
            public CheckRoom(Room room) : base(room, requiresTargetRoom: true)
            {
            }

            public override void PickTargetRoom(Room target)
            {
                if (!target.isDiscovered) targetRoom = target;
            }

            public override void Perform()
            {
                if (!targetRoom.isDiscovered)
                    targetRoom.RevealTemporarily();
            }
        }
    }

    public class SlimedCoveredRoom : AdditionalRoom
    {
        public SlimedCoveredRoom() : base()
        {

        }
    }

    public class ShowerRoom : AdditionalRoom
    {
        public ShowerRoom() : base()
        {
            options.Add(new Shower(this));
        }
    }

    public class Armory : BasicRoom
    {
        public Armory() : base()
        {
            description = "Recharge your energy weapons.";
            options.Add(new Recharge(this));
        }
    }

    public class CommsRoom : BasicRoom
    {
        public CommsRoom() : base()
        {
            description = "Send a signal back to Earth.";
            options.Add(new Signal(this));
        }
    }

    public class EmergencyRoom : BasicRoom
    {
        public EmergencyRoom() : base()
        {
            description = "Treat your wounds.";
            options.Add(new Treat(this));
        }
    }

    public class EvacuationSection : BasicRoom
    {
        EscapePod[] escapePods;
        public EvacuationSection() : base()
        {
            escapePods = new EscapePod[2];
            description = "Enter into an escape pod.";
            options.Add(new Escape(this));
        }

        public class Escape : RoomOption
        {
            private EvacuationSection evacSec;
            public Escape(EvacuationSection room) : base(room)
            {
                this.evacSec = room;
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }

        public class EscapePod
        {
        }
    }

    public class FireControlSystem : BasicRoom
    {
        public FireControlSystem() : base()
        {
            description = "Initiate fire control procedure.";
            options.Add(new FightFire(this));
        }

        public class FightFire : RoomOption
        {
            public FightFire(Room room) : base(room, requiresTargetRoom: true)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }
    public class Generator : BasicRoom
    {
        int turnsToSelfDestruct = 6;
        bool isSelfDestructing = false;
        public Generator() : base()
        {
            description = "Start/Stop self-destruct sequence.";
            options.Add(new SelfDestruct(this));
        }

        public class SelfDestruct : RoomOption
        {
            Generator generator;
            public SelfDestruct(Generator room) : base(room)
            {
                this.generator = room;
            }

            public override void Perform()
            {
                generator.isSelfDestructing = !generator.isSelfDestructing;
                generator.turnsToSelfDestruct = 6;
                throw new Exception("Ship self destructed!");
            }
        }
    }

    public class Laboratory : BasicRoom
    {
        public Laboratory() : base()
        {
            description = "Analyse item.";
            options.Add(new Analyse(this));
        }

        public class Analyse : RoomOption
        {
            public Analyse(Room room) : base(room)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Layout : ILayout
    {
        public List<Room> FixedRooms { get; set; }
        public List<Room> BasicRooms { get; set; }
        public List<Room> AdditionalRooms { get; set; }
        public List<Corridor> Corridors { get; set; }

        public Layout()
        {
            FixedRooms = new List<Room>();
            BasicRooms = new List<Room>();
            AdditionalRooms = new List<Room>();
            Corridors = new List<Corridor>();

            FixedRooms.Add
            (
                new Cockpit(),
                new Hibernatorium(),
                new EngineOne(),
                new EngineTwo(),
                new EngineThree(),
                new TechnicalCorridors()
            );

            BasicRooms.Add
            (
                new Room(2, 16, 9, "basic"),
                new Room(3, 13, 25, "basic"),
                new Room(4, 16, 38, "basic"),
                new Room(5, 30, 4, "basic"),
                new Room(9, 30, 45, "basic"),
                new Room(10, 43, 6, "basic"),
                new Room(12, 44, 36, "basic"),
                new Room(13, 57, 7, "basic"),
                new Room(16, 57, 37, "basic"),
                new Room(17, 63, 16, "basic"),
                new Room(18, 63, 28, "basic")
            );

            AdditionalRooms.Add
            (
                new Room(6, 31, 12, "additional"),
                new Room(7, 26, 25, "additional"),
                new Room(8, 31, 34, "additional"),
                new Room(14, 51, 17, "additional"),
                new Room(15, 51, 29, "additional")
            );

            ConnectRooms();
        }

        public void ConnectRooms()
        {
            var union = FixedRooms.Union(BasicRooms).Union(AdditionalRooms).ToDictionary(r => r.id, r => r);
            Corridors.Add(1, 2, union);
            Corridors.Add((1), (3), union);
            Corridors.Add((1), (4), union);
            Corridors.Add((2), (6), union);
            Corridors.Add((2), (999), union, 2, true);
            Corridors.Add((3), (7), union, 2);
            Corridors.Add((4), (8), union);
            Corridors.Add((4), (999), union, 2, true);
            Corridors.Add((5), (999), union, 2, true);
            Corridors.Add((5), (6), union);
            Corridors.Add((5), (10), union, 2);
            Corridors.Add((6), (7), union);
            Corridors.Add((6), (11), union);
            Corridors.Add((7), (8), union);
            Corridors.Add((8), (9), union);
            Corridors.Add((8), (11), union);
            Corridors.Add((9), (12), union, 2);
            Corridors.Add((9), (999), union, 1, true);
            Corridors.Add((10), (13), union, 2);
            Corridors.Add((11), (14), union);
            Corridors.Add((11), (15), union);
            Corridors.Add((12), (16), union, 2);
            ;
            Corridors.Add((13), (14), union);
            Corridors.Add((13), (19), union);
            ;
            Corridors.Add((14), (17), union);
            Corridors.Add((14), (999), union, 1, true);
            Corridors.Add((15), (18), union);
            Corridors.Add((15), (16), union);
            Corridors.Add((15), (999), union, 1, true);
            ;
            ;
            Corridors.Add((16), (21), union);
            Corridors.Add((17), (19), union);
            Corridors.Add((17), (20), union, 2);
            Corridors.Add((18), (20), union, 2);
            Corridors.Add((18), (21), union);
            ;
            Corridors.Add((19), (999), union, 2, true);
            Corridors.Add((21), (999), union, 2, true);

        }
    }

    public static class Exts
    {
        public static void Add(this List<Corridor> Corridors, int a, int b, Dictionary<int, Room> rooms, int width = 1, bool technical = false)
        {
            Corridors.Add(new Corridor(rooms[a], rooms[b], width, technical));
        }
    }

}
