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

    internal void Add(List<CodingTrackerModel> List)
    {
        foreach (CodingTrackerModel Model in List)
        {
            TableData.Add(
                new List<object>
                {
                    Model.Id,
                    Model.StartTime,
                    Model.EndTime,
                    Model.Duration
                }
                );
        }
    }

    internal void Clear()
    {
        TableData.Clear();
    }
}
