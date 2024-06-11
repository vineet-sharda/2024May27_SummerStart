
namespace SummerStart
{
    public interface ICapsCreator
    {
        ICollection<Cap> Caps { get; set; }

        ICollection<Cap> Create(int capacity, int chance);
    }
}