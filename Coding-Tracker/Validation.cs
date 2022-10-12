
internal class Validation
{
    internal bool CheckDate(string? Date)
    {
        return (DateTime.TryParse(Date, out _));
    }

    internal bool CheckInt(string? Number)
    {
        return (int.TryParse(Number, out _));
    }
}
