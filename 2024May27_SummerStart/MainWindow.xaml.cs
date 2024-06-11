using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SummerStart;

namespace _2024May27_SummerStart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ISummerStart ss = new UnofficialSummerStart()
            {
                WinnerEvery = int.Parse(txtWinnerEvery.Text),
                Turns = int.Parse(txtTurns.Text),

                TotalCaps = int.Parse(txtUniverse.Text),
                Iterations = int.Parse(txtIterations.Text)
            };
            ss.Start();

            lstBoxChoices.Items.Clear();
            lstBoxWinnerCount.Items.Clear();

            //ShowResultDetail(ss.ChosenCapsCollection);
            ShowResult(ss.WinnerCounts);
        }

        public void ShowResult(Dictionary<int, int> winnerCounts)
        {
            int total = 0;
            for (int i = 0; i < winnerCounts.Count; i++)
            {
                lstBoxChoices.Items.Add(i);
                lstBoxWinnerCount.Items.Add(winnerCounts[i]);
                total += winnerCounts[i];
            }

            lstBoxChoices.Items.Add("-- -- --");
            lstBoxWinnerCount.Items.Add("-- -- --");
            lstBoxChoices.Items.Add("Total");
            lstBoxWinnerCount.Items.Add(total);
        }

        public void ShowResultDetail(ICollection<ICollection<Cap>> collectionOfChosenCollections)
        {
            foreach (var capCollection in collectionOfChosenCollections)
            {
                string capIDs = "";
                foreach (var cap in capCollection)
                {
                    capIDs = $"{capIDs},{cap.ID}";
                }
                lstBoxChoices.Items.Add(capIDs.Substring(1));
                lstBoxWinnerCount.Items.Add(capCollection.Count(c => c.IsWinner));
            }
        }

        private void txtWinnerEvery_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}