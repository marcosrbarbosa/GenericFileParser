using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parsers
{
	internal sealed class DateTimeColumnParser: ColumnValueParser<DateTime?>
	{
		private readonly string[] _dateFormat;

		public DateTimeColumnParser(string dateFormat)
		{
			_dateFormat = new string[1] { dateFormat };
		}

		public DateTimeColumnParser(params string[] dateFormats)
		{
			_dateFormat = new string[dateFormats.Length];
			_dateFormat = dateFormats;
		}

		public override DateTime? GetValue(string rawValue)
		{
			if (_dateFormat == null || _dateFormat.Length== 0 || string.IsNullOrEmpty(rawValue)) 
				return default;

			foreach(var dateFormat in _dateFormat) 
			{
				DateTime output;

				if (DateTime.TryParseExact(rawValue.TrimEnd(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out output))
				{
					return output;
				}

			}
			throw new FormatException($"DateTimeColumnParser Exception occurred with {rawValue} using {AggregatedFormats()}");
		}

		private string AggregatedFormats()
		{
			return string.Join(",", _dateFormat);
		}


	}
}
