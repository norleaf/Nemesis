using BoardGraph;
using System;

namespace NemesisLibrary
{
    public class ViewCoordinates : RoomOption
    {
        public ViewCoordinates(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }

    public class CheckCoordinates : RoomOption
    {
        public CheckCoordinates(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }

    public class RepairEngine : RoomOption
    {
        public RepairEngine(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            var engine = (EngineRoom)room;
            engine.EngineOperational = true;
        }
    }

    public class SabotageEngine : RoomOption
    {
        public SabotageEngine(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            var engine = (EngineRoom)room;
            engine.EngineOperational = false;
        }
    }

    public class EnterHibernation : RoomOption
    {
        public EnterHibernation(Room room) : base(room)
        {
        }

        public override bool CanTakeAction(Board board, PlayerCharacter player)
        {
            return base.CanTakeAction(board, player) && board.turn >= 8;
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }

    public class Shower : RoomOption
    {
        public Shower(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }

    public class Recharge : RoomOption
    {
        public Recharge(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }

    public class Signal: RoomOption
    {
        public Signal(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }
    public class Treat: RoomOption
    {
        public Treat(Room room) : base(room)
        {
        }

        public override void Perform()
        {
            throw new NotImplementedException();
        }
    }
}
