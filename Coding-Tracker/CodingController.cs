
internal class CodingController
{
    private readonly Database Database = new();
    private readonly TableVisualisationEngine VisualisationEngine = new();
    private readonly UserInput UserInput = new();

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
        Console.Clear();

        switch (Number)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                View();
                break;
            case 2:
                Insert();
                break;
            case 3:
                Delete();
                break;
            default:
                Console.WriteLine("Wrong Input!");
                break;
        }
    }

    internal void View()
    {
        VisualisationEngine.Clear();

        VisualisationEngine.Add(Database.Read());

        VisualisationEngine.Print();
    }

    internal void Insert()
    {
        Console.WriteLine("[StartTime]");
        DateTime StartTime = UserInput.GetDate();

        Console.WriteLine("\n[EndTime]");
        DateTime EndTime = UserInput.GetDate();

        Database.Insert(
            StartTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            EndTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            CalculateDuration(StartTime, EndTime)
        );
    }

    internal void Delete()
    {
        int Id = UserInput.GetInt();

        if (Database.ReadById(Id).Id != null) Database.Delete(Id);
    }

    internal int CalculateDuration(DateTime DT1, DateTime DT2)
    {
        return Convert.ToInt32((DT2 - DT1).TotalDays);
    }
}

