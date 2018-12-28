using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class RoomActions
    {
        public static void Shower(PlayerCharacter player, Target target, Room room, Room destination)
        {
            
        }
        public static void Armory(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void CommsRoom(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void EmergencyRoom(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void EvacuationA(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void EvacuationB(PlayerCharacter player, Target target, Room room, Room destination)
        {
        }
        public static void FireControl(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Generator(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Laboratory(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void TakeEgg(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Storage(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Surgery(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void AirlockControl(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Cabins(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Canteen(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void CommandCenter(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void EngineControl(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void HatchControl(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void MonitoringRoom(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Slime(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        
        public static void Engine1(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Engine2(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Engine3(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }
        public static void Hibernate(PlayerCharacter player, Target target, Room room, Room destination)
        {

        }

        public static List<Action<PlayerCharacter, Target, Room, Room>> GetAllRoomActions()
        {
            var list = new List<Action<PlayerCharacter, Target, Room, Room>>();
            list.Add(Armory);                          
            list.Add(CommsRoom);                       
            list.Add(EmergencyRoom);
            list.Add(EvacuationA);                     
            list.Add(EvacuationB);                     
            list.Add(FireControl);                     
            list.Add(Generator);                       
            list.Add(Laboratory);                      
            list.Add(TakeEgg);                         
            list.Add(Storage);                         
            list.Add(Surgery);                         
            list.Add(AirlockControl);
            list.Add(Cabins);                          
            list.Add(Canteen);                            
            list.Add(CommandCenter);
            list.Add(EngineControl);
            list.Add(HatchControl);
            list.Add(MonitoringRoom);
            list.Add(Slime);
            list.Add(Shower);
            list.Add(Engine1);
            list.Add(Engine2);
            list.Add(Engine3);
            list.Add(Hibernate);
            return list;
        }
    }
}
