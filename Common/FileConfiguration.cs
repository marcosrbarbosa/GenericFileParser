using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
	internal sealed class FileConfiguration
	{
		public const int WIN_1252_CP = 1252;

		public char SplitChar = ';';
		public Encoding Encoding { get; set; } = Encoding.GetEncoding("ISO-8859-1");

		public string DefaultDateFormat { get; } = "yyyy-MM-dd";

		public string DefaultTimeFormat { get; } = "hh:mm:ss";

		public string DefaultDateTimeFormat { get; } = "yyyy-MM-dd hh:mm:ss";

		public string DefaultBooleanString {get;} = "1";

	}
}
