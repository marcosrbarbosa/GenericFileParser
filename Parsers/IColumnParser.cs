namespace Domain.Parsers
{
	internal interface IColumnParser
	{
		public object GetValue(string rawValue);
	}
}