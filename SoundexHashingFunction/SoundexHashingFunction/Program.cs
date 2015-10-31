using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundexHashingFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sample test cases
           
            Console.WriteLine("Sample Test Cases Begin");

            string[] sampleTexts = new string[] {"Ramakrishna", "Dell","DELL", "VentureSity","Sajad","Salad","Bangalore","Mangalore","Microsoft" };
            foreach (var sampleText in sampleTexts)
            {
                Console.WriteLine("The encoded text for {0} is {1}",sampleText, Soundex.EncodeToSoundex(sampleText));
            }
            Console.WriteLine("Sample Test Cases End \n");

            #endregion

            #region user input
            Console.WriteLine("Press N to exit anytime");
            bool stopUserInput = false;
            while (!stopUserInput)
            {

                Console.WriteLine("Please enter a text to encode");
                var text = Console.ReadLine();
                if (text.ToLower() == "n")
                    stopUserInput = true;
                else 
                {
                    if (Validate(text))
                    {
                        Console.WriteLine("The encoded text for {0} is {1}", text, Soundex.EncodeToSoundex(text));
                    }
                    else
                        Console.WriteLine("Invalid Inpput Text");
                }

            }

            #endregion
        }

        public static bool Validate(string text)
        {
            bool isValidText = true;
            if (string.IsNullOrEmpty(text))
                isValidText = false;
            //other validations: should we validate if string contains numbers!
            //spaces in the string?
            //Alphanumeric Chars/Punctuation marks?
            return isValidText;
        }
    }
}
