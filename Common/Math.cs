using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
	public static class Math
	{
		public static List<int> Range(int end)
		{
			return Range(1, end);
		}
		public static List<int> Range(int start, int end, int increase = 1)
		{
			var result = new List<int>();
			for (var i = start; i <= end; i += increase)
			{
				result.Add(i);
			}

			return result;
		}
	}
}
