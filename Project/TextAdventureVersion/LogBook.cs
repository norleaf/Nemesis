using BoardGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule;

namespace TextAdventureVersion
{
    class LogBook
    {
        private Board board;
        private List<String> Log { get; set; }

        public LogBook()
        {
            var test = new PlayerTest();
            board = test.TestTwo();
            Console.WriteLine("game started");
        }
    }
}
