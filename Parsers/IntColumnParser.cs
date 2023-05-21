using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class IntColumnParser: ColumnValueParser<int>
	{
		public override int GetValue(string rawValue)
		{
			return string.IsNullOrEmpty(rawValue) ? default : int.Parse(rawValue, System.Globalization.NumberStyles.AllowDecimalPoint);
		}
	}
}
