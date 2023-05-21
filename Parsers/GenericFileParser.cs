using Domain.Common;
using Microsoft.Extensions.Logging;

namespace Domain.Parsers
{
	internal sealed class GenericFileParser<T> where T:class, new()
	{

		private readonly ILogger _logger;
		private readonly FileConfiguration _configuration;
		private readonly Dictionary<string, string> _logicalColumnsDefinitions;

		public GenericFileParser(FileConfiguration config, ILogger logger)
		{
			_configuration = config;
			_logger = logger;
			_logicalColumnsDefinitions = new Dictionary<string, string>();
		}

		public GenericFileParser(FileConfiguration config, ILogger logger, Dictionary<string, string> logicalColumnsDefinitions) 
		{
			_configuration = config;
			_logger = logger;
			_logicalColumnsDefinitions = logicalColumnsDefinitions;
		}

		public IEnumerable<T> Parse(string filePath) 
		{ 
			using var sr = new StreamReader(filePath, _configuration.Encoding);
			return ParseFile(sr);

		}

		private IEnumerable<T> ParseFile(StreamReader sr)
		{
			Dictionary<string, int> columnOrder = new Dictionary<string, int>();
			var loadedItems = new List<T>();
			var lineCounter = 0;
			var parseHeader = true;

			string? currentLine;

			while ((currentLine = sr.ReadLine()) != null) 
			{
				var row = currentLine.Split(_configuration.SplitChar);

				if (parseHeader) 
				{
					columnOrder = ParseHeader(row);
					parseHeader= false;
					continue;
				}

				lineCounter++;

				var parsedItem = ParseItem(row, columnOrder);

				loadedItems.Add(parsedItem);

			}

			return loadedItems;
		}

		private T ParseItem(string[] row, Dictionary<string, int> columnOrder)
		{
			T parsedItem = this.GetNewObject();
			
			foreach(var column in columnOrder.Select(s => s.Key)) 
			{ 
			
				var prop = parsedItem.GetType().GetProperties().FirstOrDefault(p => p.Name.ToUpperInvariant() == column);
			
				if (prop != null)
				{

					var columnParser = GetColumnParser(column, prop.PropertyType);

					if (columnParser != null)  prop.SetValue(parsedItem, columnParser.GetValue(row, columnOrder));
				}

			}

			return parsedItem;
		}

		private ColumnParserMapping GetColumnParser(string columnName, Type propertyType)
		{

			if (propertyType == typeof(bool))
			{
				if (_logicalColumnsDefinitions.Keys.Contains(columnName))
					return new ColumnParserMapping(columnName, new BoolColumnParser(_logicalColumnsDefinitions.GetValueOrDefault(columnName)));
				else
					return new ColumnParserMapping(columnName, new BoolColumnParser(_configuration.DefaultBooleanString));
			}
			if (propertyType == typeof(int))
				return new ColumnParserMapping(columnName, new IntColumnParser());
			if (propertyType == typeof(decimal))
				return new ColumnParserMapping(columnName, new DecimalColumnParser());
			if (propertyType == typeof(double))
				return new ColumnParserMapping(columnName, new DoubleColumnParser());
			if (propertyType == typeof(DateTime))
				return new ColumnParserMapping(columnName, new DateTimeColumnParser(_configuration.DefaultDateTimeFormat));
			if (propertyType == typeof(string))
				return new ColumnParserMapping(columnName, new StringColumnParser());
			if (propertyType == typeof(char))
				return new ColumnParserMapping(columnName, new CharColumnParser());

			return null;
		}

		private Dictionary<string, int> ParseHeader(string[] row)
		{
			var header = new Dictionary<string, int>();
			var columnSequence = 0;
			foreach (var item in row) 
			{
				header.Add(item.Trim().ToUpperInvariant(), columnSequence);
				columnSequence++;
			}
			return header;
		}

		internal T GetNewObject()
		{
			return new T();
		}
	}


}
