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
        public Hibernatorium() : base(11, 40, 22, "Cockpit", "Here you can check the plottet course or enter a new destination coordinate.", isDiscovered: true)
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

    public class LayOut
    {
        public List<BasicRoom> BasicRooms { get; set; }
        public List<AdditionalRoom> AdditionalRooms { get; set; }

        public LayOut()
        {
            BasicRooms = new List<BasicRoom>();
            AdditionalRooms = new List<AdditionalRoom>();

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
