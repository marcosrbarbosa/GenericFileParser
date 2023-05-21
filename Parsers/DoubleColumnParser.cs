using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class DoubleColumnParser: ColumnValueParser<double>
	{
		private readonly NumberFormatInfo _numberFormatInfo;

		public DoubleColumnParser()
		{
			_numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "," };
		}

		public DoubleColumnParser(NumberFormatInfo numberFormatInfo) {
			_numberFormatInfo = numberFormatInfo;
		}

		public override double GetValue(string rawValue)
		{

			double output;

			if (double.TryParse(rawValue.Trim(), NumberStyles.AllowDecimalPoint, _numberFormatInfo, out output)) 
				return output;

			if (double.TryParse(rawValue.Trim(), out output)) 
				return output;

			return default(double);

		}

	}
}
