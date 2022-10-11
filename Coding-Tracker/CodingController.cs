
internal class CodingController
{
    private readonly Database Database = new();

    internal void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("\nWhat would you like to do:");
        Console.WriteLine("\nType 0 To Close Application");
        Console.WriteLine("Type 1 To View All Records");
        Console.WriteLine("Type 2 To Insert Record");
        Console.WriteLine("Type 3 To Delete Record");
        Console.WriteLine("Type 4 To Update Record");
    }

    internal void Navigate(int Number)
    {
        switch (Number)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.Clear();
                break;
            default:
                Console.WriteLine("Wrong Input!");
                break;
        }
    }
}

