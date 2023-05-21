using Domain.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
	internal class ColumnParserMapping
	{
		public ColumnParserMapping(string name, IColumnParser columnParser) 
		{
			Name = name;
			ColumnParser = columnParser; 
		}

		public string Name { get; private set; }
		public IColumnParser ColumnParser { get;private set; }

		public object GetValue(string[] row, Dictionary<string, int> columnOrder)
		{
			return ColumnParser.GetValue(row[columnOrder[Name]]);
		}

		public object GetValue(Dictionary<string, object> rows)
		{
			return rows[Name] == null ? default : ColumnParser.GetValue(rows[Name].ToString());
		}

	}
}
