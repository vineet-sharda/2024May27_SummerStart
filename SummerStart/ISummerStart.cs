namespace SummerStart
{
    public interface ISummerStart
    {
        ICollection<ICollection<Cap>> ChosenCapsCollection { get; }
        int Iterations { get; set; }
        int TotalCaps { get; set; }
        int Turns { get; set; }
        int WinnerEvery { get; set; }
        Dictionary<int, int> WinnerCounts { get; }

        void Start();
    }
}