
internal class UserInput
{
    Validation Validation = new();
    internal DateTime GetDate()
    {
        Console.WriteLine("Type Date <YYYY-MM-DD>:");

        string? Date = Console.ReadLine();

        while (!Validation.CheckDate(Date))
        {
            Console.WriteLine("Wrong Date format!");
            Date = Console.ReadLine();
        }

        return DateTime.Parse(Date);
    }
}
