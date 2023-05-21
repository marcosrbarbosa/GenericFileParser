namespace Domain.Parsers
{
	internal abstract class ColumnValueParser<T> : IColumnParser
	{

		public abstract T GetValue(string rawValue);
		object IColumnParser.GetValue(string rawValue)
		{
			return GetValue(rawValue);
		}
	}
}