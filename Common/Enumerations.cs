using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
	internal class Enumerations
	{
		public enum FilterOptions
		{
			Blank = 0,
			Contains = 1,
			NotContains = 2,
			StarsWith = 3,
			NotStartsWith = 4,
			EndsWith = 5,
			NotEndsWith = 6,
			Equals = 7,
			NotEquals = 8,
			GreaterThan	= 9,
			GreaterThanOrEqual = 10,
			LessThan = 11,
			LessThanOrEqual = 12,
			In = 13,
			Between = 14,
			Is = 15,
			IsNot = 16,
			Before = 17,
			After = 18,
			DateIs = 19,
			DateIsNot = 20,
			DateBefore = 21,
			DateAfter = 22,
			OrderByAsc = 23,
			OrderByDesc = 24,
			OffSet = 25,
			FetchNext = 26
		}
	}
}
