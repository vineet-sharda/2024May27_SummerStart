using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerStart
{
    public class CapChooser : ICapChooser
    {
        private Random random = new Random();

        public int Turns { get; set; }
        public ICollection<Cap> Caps { get; set; } = new List<Cap>();

        public ICollection<Cap> MakeChoices()
        {
            var ChosenCaps = new List<Cap>();
            for (int i = 0; i < Turns; i++)
            {
                ChosenCaps.Add(GetNextCap());
            }
            return ChosenCaps;
        }

        private Cap GetNextCap()
        {
            var rand = random.Next(0, Caps.Count);
            var selectedCap = Caps.Single(c => c.ID == rand);
            if (selectedCap.IsChosen) return GetNextCap();

            selectedCap.IsChosen = true;
            return selectedCap;
        }
    }

}
