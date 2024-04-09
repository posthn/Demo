namespace Demo.Core.Domain.Models;

public class Pager
{
    public int Number { get; }

    public short Size { get; }

    public Pager(int number, short size)
    {
        if (number < 1 || size < 1)
            throw new ArgumentOutOfRangeException(nameof(Pager));

        Number = number;
        Size = size;
    }
}