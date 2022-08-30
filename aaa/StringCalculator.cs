using System;
using System.Text;

namespace aaa
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers?.Trim()))
                return 0;
            string[] a = GetNumbers(numbers);
            int wynik = 0;
            StringBuilder ujemne = new StringBuilder();
            foreach (var aa in a)
            {
                int.TryParse(aa, out int result);
                if (result > 1000)
                    continue;
                if (result < 0)
                    ujemne.Append(aa + " ");
                wynik += result;
            }
            if(ujemne.Length > 0)
                throw new ArgumentException("negatives not allowed: " + ujemne);
            return wynik;
        }

        private static string[] GetNumbers(string numbers)
        {
            char znak = ',';
            string dalimiter;
            if (numbers.StartsWith("//["))
            {
                dalimiter = numbers.Substring(numbers.IndexOf("//[") + 3, numbers.IndexOf("]") - (numbers.IndexOf("//[") + 3));
                return numbers.Substring(numbers.IndexOf("]") + 1).Split(new[] { dalimiter, "\n" }, StringSplitOptions.None);
            }
            else
            {
                
                if (numbers.StartsWith("//"))
                {
                    znak = numbers[2];
                    return numbers.Substring(3).Split(new[] { znak, '\n' });
                }
            }
            return numbers.Split(new[] { znak, '\n' });
        }

    }
}
