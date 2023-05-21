using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class CharColumnParser: ColumnValueParser<char>
	{
		public override char GetValue(string rawValue)
		{
			if (rawValue.Length == 0) return new char();
			return rawValue.TrimStart()[0];
		}

	}
}
