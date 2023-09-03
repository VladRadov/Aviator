using System.Text;

public static class StringHandler
{
    private static StringBuilder _builder = new StringBuilder();

    public static string RemoveChars(string inputLine, params char[] removedChars)
    {
        _builder.Clear();
        _builder.Append(inputLine);
        foreach (var oneChar in removedChars)
            _builder.Replace(oneChar, ' ');

        return _builder.Replace("  ", " ").ToString();
    }
}
