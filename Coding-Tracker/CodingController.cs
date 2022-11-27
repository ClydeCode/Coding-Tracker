
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

    internal void Navigate(int number)
    {
        Console.Clear();

        switch (number)
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
            case 4:
                Update();
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
        DateTime startTime = UserInput.GetDate();

        Console.WriteLine("\n[EndTime]");
        DateTime endTime = UserInput.GetDate(startTime);

        Database.Insert(
            startTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            endTime.ToString("yyyy-MM-dd HH:mm:ss"), 
            CalculateDuration(startTime, endTime)
        );
    }

    internal void Delete()
    {
        int id = UserInput.GetInt();

        if (Database.ReadById(id).Id != null) Database.Delete(id);
    }

    internal void Update()
    {
        int id = UserInput.GetInt();

        if (Database.ReadById(id).Id != null)
        {
            Console.WriteLine("[StartTime]");
            DateTime startTime = UserInput.GetDate();

            Console.WriteLine("\n[EndTime]");
            DateTime endTime = UserInput.GetDate();

            Database.Update(
                id, 
                startTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                endTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                CalculateDuration(startTime, endTime)
            );
        }
    }

    internal int CalculateDuration(DateTime DT1, DateTime DT2)
    {
        return Convert.ToInt32((DT2 - DT1).TotalDays);
    }
}

