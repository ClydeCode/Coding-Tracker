
internal class Validation
{
    internal bool CheckDate(string? Date)
    {
        return (DateTime.TryParse(Date, out _));
    }
}
