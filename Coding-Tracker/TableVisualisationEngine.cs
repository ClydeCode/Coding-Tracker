using ConsoleTableExt;

internal class TableVisualisationEngine
{
    private readonly List<List<object>> TableData = new();

    internal void Print()
    {
        ConsoleTableBuilder
            .From(TableData)
            .WithTitle("Coding Tracker", ConsoleColor.Blue, ConsoleColor.Black)
            .WithColumn("ID", "Start Session", "End Session", "Duration")
            .ExportAndWriteLine();
    }

    internal void Insert(List<CodingTrackerModel> list)
    {
        foreach (CodingTrackerModel model in list)
        {
            TableData.Add(
                new List<object>
                {
                    model.Id,
                    model.StartTime,
                    model.EndTime,
                    model.Duration
                }
                );
        }
    }
}
