using BoardGraph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dump = RoomActions.GetAllRoomActions().Where(r=>r.Method.Name=="Armory");
           // TestBoard.ConnectRooms();
            // var test = new PlayerTest();
            //test.TestTwo();


            //Console.WriteLine("done");
            Console.Read();
        }

        
    }

    

    public static class Extensions
    {
        public static void Log<T>(this T output)
        {
            string json = JsonConvert.SerializeObject(output, Formatting.Indented);
            Debug.WriteLine(json);
        }
    }
}
