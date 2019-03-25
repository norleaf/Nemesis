using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class NamedState<T>
    {
        public T State { get; set; }
        public string Name { get; private set; }

        public NamedState(T type, string name)
        {
            State = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name + State;
        }
    }
}
