using System.Globalization;
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
                WinnerEvery = GetInt(txtWinnerEvery),
                Turns = GetInt(txtTurns),

                TotalCaps = GetInt(txtUniverse),
                Iterations = GetInt(txtIterations),

                KeepChosenCaps = false // be mindful of memory used, if making this true
            };

            ss.Start();
            Reset();
            ShowResult(ss.WinnerCounts);

            /// make KeepChosenCaps true above, if you want to see the chosen caps
            /// but be mindful of memory used
            //ShowResultDetail(ss.ChosenCapsCollection);
        }

        private void ShowResult(Dictionary<int, int> winnerCounts)
        {
            int total = 0;
            foreach (var winnerCount in winnerCounts)
            {
                lstBoxChoices.Items.Add(winnerCount.Key);
                lstBoxWinnerCount.Items.Add($"{winnerCount.Value:n0}");
                total += winnerCount.Value;
            }

            lstBoxChoices.Items.Add("-- -- --");
            lstBoxWinnerCount.Items.Add("-- -- --");
            lstBoxChoices.Items.Add("Total");
            lstBoxWinnerCount.Items.Add($"{total:n0}");
        }

        private void ShowResultDetail(ICollection<ICollection<Cap>> collectionOfChosenCollections)
        {
            foreach (var capCollection in collectionOfChosenCollections)
            {
                string capIDs = "";
                foreach (var cap in capCollection)
                {
                    capIDs = $"{capIDs},{cap.ID}";
                }
                lstBoxWinnerCount.Items.Add(capIDs.Substring(1));
                lstBoxChoices.Items.Add(capCollection.Count(c => c.IsWinner));
            }
        }

        private int GetInt(TextBox txtBox)
        {
            decimal parsedNumber = 0;
            decimal.TryParse(txtBox.Text,
                NumberStyles.Number,
                CultureInfo.InvariantCulture.NumberFormat,
                out parsedNumber);
            if (parsedNumber < 0) parsedNumber = 0;
            int parsedInt = (int)Math.Floor(parsedNumber);

            txtBox.Text = $"{parsedInt:n0}";
            return parsedInt;
        }

        private void Reset()
        {
            lstBoxChoices.Items.Clear();
            lstBoxWinnerCount.Items.Clear();
        }
    }
}