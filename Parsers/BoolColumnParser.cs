using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class BoolColumnParser: ColumnValueParser<bool>
	{

		private readonly string _value;
		public BoolColumnParser(string trueValue) 
		{
			_value = trueValue;
		}

		public override bool GetValue(string rawValue)
		{
			return _value == rawValue.Trim();
		}

	}
}
