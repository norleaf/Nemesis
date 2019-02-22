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

    public class BasicRoom : Room
    {
        public BasicRoom(int id = 0, int x = 0, int y = 0) : base(id, x, y, "basic room")
        {
        }
    }

    public class AdditionalRoom : Room
    {
        public AdditionalRoom(int id =0, int x=0, int y=0) : base(id, x, y, "additional room")
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

    public class Sho : AdditionalRoom
    {
          public Sho() : base()
          {
              options.Add(new (this));
          }
    }

    public class Sho : AdditionalRoom
    {
        public Sho() : base()
        {
            options.Add(new (this));
        }
    }
    public class Sho : AdditionalRoom
    {
        public Sho() : base()
        {
            options.Add(new (this));
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

    public class EvacuationSection: BasicRoom
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

    public class FireControlSystem: BasicRoom
    {
        public FireControlSystem() : base()
        {
            description = "Initiate fire control procedure.";
            options.Add(new FightFire(this));
        }

        public class FightFire : RoomOption
        {
            public FightFire(Room room) : base(room, requiresTargetRoom:true)
            {
            }

            public override void Perform()
            {
                throw new NotImplementedException();
            }
        }
    }
    public class Generator: BasicRoom
    {
        int turnsToSelfDestruct = 6;
        bool isSelfDestructing = false;
        public Generator() : base()
        {
            description = "Start/Stop self-destruct sequence.";
            options.Add(new SelfDestruct(this));
        }

        public class SelfDestruct: RoomOption
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

    public class Laboratory: BasicRoom
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

    public class LayOut
    {
        public List<Room> FixedRooms { get; set; }
        public List<BasicRoom> BasicRooms { get; set; }
        public List<AdditionalRoom> AdditionalRooms { get; set; }

        public LayOut()
        {
            FixedRooms = new List<Room>();
            BasicRooms = new List<BasicRoom>();
            AdditionalRooms = new List<AdditionalRoom>();

            FixedRooms.Add
            (
                new Cockpit(),
                new Hibernatorium(),
                new EngineOne(),
                new EngineTwo(),
                new EngineThree()
            );

            BasicRooms.Add
            (
                new BasicRoom(2, 16, 9),
                new BasicRoom(3, 13, 25),
                new BasicRoom(4, 16, 38),
                new BasicRoom(5, 30, 4),
                new BasicRoom(9, 30, 45),
                new BasicRoom(10, 43,6 ),
                new BasicRoom(12, 44,36 ),
                new BasicRoom(13, 57,7 ),
                new BasicRoom(16, 57, 37),
                new BasicRoom(17, 63, 16),
                new BasicRoom(18, 63, 28)
            );

            AdditionalRooms.Add
            (
                new AdditionalRoom(6, 31, 12),
                new AdditionalRoom(7, 26, 25),
                new AdditionalRoom(8, 31, 34),
                new AdditionalRoom(14, 51, 17),
                new AdditionalRoom(15, 51, 29)
            );
        }
    }

}
