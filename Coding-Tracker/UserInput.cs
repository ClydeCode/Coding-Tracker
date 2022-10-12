
internal class UserInput
{
    Validation Validation = new();
    internal DateTime GetDate()
    {
        Console.WriteLine("Type Date <YYYY-MM-DD>:");

        string? Date = Console.ReadLine();

        while (!Validation.CheckDate(Date))
        {
            Console.WriteLine("Wrong Date Format!");
            Date = Console.ReadLine();
        }

        return DateTime.Parse(Date);
    }

    internal int GetInt()
    {
        Console.WriteLine("Type Number:");

        string? Number = Console.ReadLine();

        while (!Validation.CheckInt(Number))
        {
            Console.WriteLine("Wrong Number Format!");
            Number = Console.ReadLine();
        }

        return int.Parse(Number);
    }
}
