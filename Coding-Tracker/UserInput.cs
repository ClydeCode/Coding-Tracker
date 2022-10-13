
internal class UserInput
{
    Validation Validation = new();
    internal DateTime GetDate(DateTime DTSecond = new())
    {
        string? Date;

        while (true)
        {
            Console.WriteLine("Type Date <yyyy-MM-dd HH:mm:ss>:");
            Date = Console.ReadLine();

            if (!Validation.CheckDate(Date))
            {
                Console.WriteLine("Wrong Date Format!");
                continue;
            }

            if (!(DateTime.Parse(Date).CompareTo(DTSecond) > 0)) Console.WriteLine("EndTime can't be earlier than StartTime!");

            else break;

        }

        return DateTime.Parse(Date);
    }

    internal int GetInt()
    {
        Console.WriteLine("\nType Number:");

        string? Number = Console.ReadLine();

        while (!Validation.CheckInt(Number))
        {
            Console.WriteLine("Wrong Number Format!");
            Number = Console.ReadLine();
        }

        return int.Parse(Number);
    }
}
