
internal class Validation
{
    internal bool CheckDate(string? date)
    {
        return (DateTime.TryParse(date, out _));
    }

    internal bool CheckInt(string? number)
    {
        return (int.TryParse(number, out _));
    }
}
