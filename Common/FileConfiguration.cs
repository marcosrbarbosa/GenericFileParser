using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
	internal sealed class FileConfiguration
	{
		public const int WIN_1252_CP = 1252;

		public char SplitChar = ';';
		public Encoding Encoding { get; set; } = Encoding.GetEncoding("ISO-8859-1");

	}
}
