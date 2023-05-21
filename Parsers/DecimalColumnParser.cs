using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class DecimalColumnParser:ColumnValueParser<decimal>
	{
		private readonly NumberFormatInfo _numberFormatInfo;

		public DecimalColumnParser()
		{
			_numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
		}

		public override decimal GetValue(string rawValue)
		{
			return string.IsNullOrEmpty(rawValue) ? default : decimal.Parse(rawValue.Trim(), _numberFormatInfo);
		}
	}
}
