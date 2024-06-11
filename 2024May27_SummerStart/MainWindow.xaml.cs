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
                Iterations = GetInt(txtIterations)
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
                lstBoxWinnerCount.Items.Add($"{winnerCounts[i]:n0}");
                total += winnerCounts[i];
            }

            lstBoxChoices.Items.Add("-- -- --");
            lstBoxWinnerCount.Items.Add("-- -- --");
            lstBoxChoices.Items.Add("Total");
            lstBoxWinnerCount.Items.Add($"{total:n0}");
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

        private int GetInt(TextBox txtBox)
        {
            decimal parsedNumber = 0;
            //decimal.TryParse(txtBox.Text,
            //    NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,
            //    CultureInfo.InvariantCulture,
            //    out parsedNumber);
            decimal.TryParse(txtBox.Text,
                NumberStyles.Number,
                CultureInfo.InvariantCulture.NumberFormat,
                out parsedNumber);
            if (parsedNumber < 0) parsedNumber = 0;
            int parsedInt = (int)Math.Floor(parsedNumber);

            txtBox.Text = $"{parsedInt:n0}";
            return parsedInt;
        }
    }
}