using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundexHashingFunction
{
      public static class ExtensionMethods
        {
          /// <summary>
          /// This would replace the given chars with the number in the string
          /// </summary>
          /// <param name="s"></param>
          /// <param name="separators"></param>
          /// <param name="newVal"></param>
          /// <returns></returns>
            public static string Replace(this string s, char[] separators, string newVal)
            {
               separators.ToList().ForEach(c => { s = s.Replace(c.ToString(), newVal); });
               return s;
            }
        }
}
