using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SummerStart
{
    public class UnofficialSummerStart : ISummerStart
    {
        private int turns;

        public bool KeepChosenCaps { get; set; }
        public ICollection<ICollection<Cap>> ChosenCapsCollection { get; private set; } = new List<ICollection<Cap>>();
        public int Turns { get; set; }
        public int Iterations { get; set; }
        public int TotalCaps { get; set; }
        public int WinnerEvery { get; set; }
        public Dictionary<int, int> WinnerCounts { get; private set; }

        public void Start()
        {
            ResetWinnerCounts();

            ICapChooser capChooser = new CapChooser() { Turns = Turns };
            for (int i = 0; i < Iterations; i++)
            {
                capChooser.Caps = new CapsCreator().Create(TotalCaps, WinnerEvery);
                var chosenCaps = capChooser.MakeChoices();
                if (KeepChosenCaps)
                {
                    ChosenCapsCollection.Add(capChooser.MakeChoices());
                }
                WinnerCounts[chosenCaps.Count(c => c.IsWinner)]++;
            }
        }

        private void ResetWinnerCounts()
        {
            WinnerCounts = new Dictionary<int, int>();
            for (int i = 0; i <= Turns; i++)
            {
                WinnerCounts.Add(i, 0);
            }
        }

    }

}
