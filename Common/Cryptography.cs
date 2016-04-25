using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
	public static class Cryptography
	{
		public static string Hash(string text, string salt)
		{
			var saltBytes = Encoding.UTF8.GetBytes(salt + "--" + text);
			var hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(saltBytes);

			return Convert.ToBase64String(hashBytes);
		}
	}
}
