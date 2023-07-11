using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
	internal static class EnumDescriptionException
	{
		public static string GetEnumDescription<T>(this T enumValue) where T : struct 
		{
			Type tp= enumValue.GetType();
			if (tp.IsEnum) {
				var memberInfo = tp.GetMember(enumValue.ToString());
				if (memberInfo != null && memberInfo.Length > 0) 
				{
					var memberAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),false);
					if (memberAttributes != null && memberAttributes.Length > 0)
					{
						return ((DescriptionAttribute) memberAttributes[0]).Description;
					}
				}
			}
			throw new ArgumentException("enumValue must be of Enum type");
		}
	}
}
