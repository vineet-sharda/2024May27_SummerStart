using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerStart
{
    public class CapsCreator : ICapsCreator
    {
        public ICollection<Cap> Caps { get; set; }

        public ICollection<Cap> Create(int capacity, int chance)
        {
            var caps = new List<Cap>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                caps.Add(new Cap() { ID = i, IsWinner = i % chance == 0 });
            }
            return caps;
        }
    }

}
