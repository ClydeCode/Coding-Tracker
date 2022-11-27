
internal class UserInput
{
    Validation Validation = new();
    internal DateTime GetDate(DateTime dtSecond = new())
    {
        string? date;

        while (true)
        {
            Console.WriteLine("Type Date <yyyy-MM-dd HH:mm:ss>:");
            date = Console.ReadLine();

            if (!Validation.CheckDate(date))
            {
                Console.WriteLine("Wrong Date Format!");
                continue;
            }

            if (!(DateTime.Parse(date).CompareTo(dtSecond) > 0)) Console.WriteLine("EndTime can't be earlier than StartTime!");

            else break;

        }

        return DateTime.Parse(date);
    }

    internal int GetInt()
    {
        Console.WriteLine("\nType Number:");

        string? number = Console.ReadLine();

        while (!Validation.CheckInt(number))
        {
            Console.WriteLine("Wrong Number Format!");
            number = Console.ReadLine();
        }

        return int.Parse(number);
    }
}
