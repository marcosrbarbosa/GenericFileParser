using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class StringColumnParser: ColumnValueParser<string>
	{
		public override string GetValue(string rawValue)
		{
			return rawValue.Trim();
		}
	}
}
