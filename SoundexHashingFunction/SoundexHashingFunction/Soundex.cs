using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundexHashingFunction
{
    public static class Soundex
    {

        public static Dictionary<string, char[]> ReplacementText = new Dictionary<string, char[]>();

        static Soundex()
        {
            ReplacementText.Add("1", new char[] { 'b', 'f', 'p', 'v' });
            ReplacementText.Add("2", new char[] { 'c', 'g', 'j', 'k', 'q', 's', 'x', 'z' });
            ReplacementText.Add("3", new char[] { 'd', 't' });
            ReplacementText.Add("4", new char[] { 'l' });
            ReplacementText.Add("5", new char[] { 'm', 'n' });
            ReplacementText.Add("6", new char[] { 'r' });

            //Note: since key cant be empty char we keep it 'e'/'E' to represent  empty string
            ReplacementText.Add("e", new char[] { 'h', 'w' });
            ReplacementText.Add("E", new char[] { 'a', 'e', 'i', 'o', 'u', 'y' });
        }

        public static string EncodeToSoundex(string text)
        {
            try
            {
                //Keep first letter as uppercase and Convert the rest of the letters to lowercase 
                text = text[0].ToString().ToUpper() +  text.Substring(1, text.Length - 1).ToLower(); 

                #region Step1 Deal with consonants

                foreach (var item in ReplacementText)
                {
                    int result = 0;
                    if (int.TryParse(item.Key, out result) && result != 0)
                    {
                        text = text[0] + text.Substring(1, text.Length - 1).Replace(item.Value, item.Key);
                        //Console.WriteLine(text + "-" + item.Key);
                    }
                }

                #endregion

                #region Step2 Deal with h,w collpase identical adjacent numbers

                KeyValuePair<string, char[]> kvp = ReplacementText.Where(k => k.Key == "e").FirstOrDefault();
                text = text[0] + text.Substring(1, text.Length - 1).Replace(kvp.Value, string.Empty);
                //Console.WriteLine(text + "-" + kvp.Key);

                //collpase identical adjacent numbers
                int index = 0;
                while (index < text.Length - 1)
                {
                    //|| ReplacementText.Where(k=>k.Key == text[index + 1].ToString()).FirstOrDefault().Value.Contains(text[index]) 
                    if (text[index].ToString().ToLower() == text[index + 1].ToString().ToLower())
                    {
                        text = text.Remove(index + 1, 1);
                    }
                    else index++;
                }

                //Case when first letter and second letter match for example Bb23=>B123 - it should become B23
                if(text.Length>=2 && Char.IsNumber(text[1]))
                {
                    var secondCharKey =  text[1].ToString();
                    var keyvaluepair = ReplacementText.Where(k=>k.Key == secondCharKey.ToString()).FirstOrDefault();
                    var firstCharKey=  text[0].ToString().ToLower().Replace(keyvaluepair.Value,keyvaluepair.Key);
                    if(firstCharKey == secondCharKey)
                    {
                        text = text[0]+ text.Substring(2,text.Length-2);
                    }
                }
             
                //Console.WriteLine(text);
                #endregion

                #region Step3 remove all instances of the vowels and y

                kvp = ReplacementText.Where(k => k.Key == "E").FirstOrDefault();
                text = text[0] + text.Substring(1, text.Length - 1).Replace(kvp.Value, string.Empty);
                //Console.WriteLine(text + "-" + kvp.Key);

                #endregion

                #region Step4 return the soundex

                if (text.Length == 4)
                    return text;
                else if (text.Length > 4)
                    return text.Substring(0, 4);
                else
                {
                    if (text.Length == 1)
                        return text + "000";
                    else if (text.Length == 2)
                        return text + "00";
                    else if (text.Length == 3)
                        return text + "0";
                }

               //The code would not come here likely but still i'll set a empty string return if code reaches here
                return string.Empty;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
