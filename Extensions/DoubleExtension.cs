using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
	internal static class DoubleExtension
	{
		public static double ToExcelRoundedDouble(this double value) 
		{
			return Math.Round(value, 2, MidpointRounding.AwayFromZero);
		}
	}
}
