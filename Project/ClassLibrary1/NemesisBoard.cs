using BoardGraph;
using System;

namespace NemesisLibrary
{
    public class NemesisBoard : BoardSetup
    {
        public NemesisBoard() : base()
        {
            AddFixedRooms();
            AddBasicRooms();
            AddAdditionalRooms();
            AddCorridors();
        }
 
        private void AddFixedRooms()
        {
            fixedRooms.Add
            (
                new Cockpit()
            );
        }

        private void AddBasicRooms()
        {
            throw new NotImplementedException();
        }

        private void AddAdditionalRooms()
        {
            throw new NotImplementedException();
        }

        private void AddCorridors()
        {
            throw new NotImplementedException();
        }
    }

    
}
