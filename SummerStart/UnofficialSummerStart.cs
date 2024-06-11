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
        private Dictionary<int, int> winnerCounts = new Dictionary<int, int>();

        public ICollection<ICollection<Cap>> ChosenCapsCollection { get; private set; } = new List<ICollection<Cap>>();
        public int Turns
        {
            get { return turns; }
            set
            {
                turns = value;
                for (int i = 0; i <= turns; i++)
                {
                    winnerCounts.Add(i, 0);
                }
            }
        }
        public int Iterations { get; set; }
        public int TotalCaps { get; set; }
        public int WinnerEvery { get; set; }
        public Dictionary<int, int> WinnerCounts
        {
            get
            {
                for (int i = 0; i < winnerCounts.Count; i++)
                {
                    winnerCounts[i] = 0;
                }
                foreach (var capCollection in ChosenCapsCollection)
                {
                    winnerCounts[capCollection.Count(c => c.IsWinner)]++;
                }
                return winnerCounts;
            }
        }

        public void Start()
        {
            ICapChooser capChooser = new CapChooser() { Turns = Turns };
            for (int i = 0; i < Iterations; i++)
            {
                capChooser.Caps = new CapsCreator().Create(TotalCaps, WinnerEvery);
                ChosenCapsCollection.Add(capChooser.MakeChoices());
            }
        }

    }

}
