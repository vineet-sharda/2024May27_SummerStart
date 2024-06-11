
namespace SummerStart
{
    public interface ICapChooser
    {
        ICollection<Cap> Caps { get; set; }
        //ICollection<Cap> ChosenCaps { get; set; }
        int Turns { get; set; }
        //int WinnerCount { get; }

        ICollection<Cap> MakeChoices();
    }
}