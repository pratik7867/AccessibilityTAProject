using System;
using System.Text;

namespace AccessibilityTAProject.Utilities.DataUtilities
{
    public class DataGenerator
    {
        public static string GenerateUniqueGmailAddress(string emailAddress)
        {
            Random randomNumber = new Random();

            return emailAddress.Insert(emailAddress.IndexOf("@"), "+" + randomNumber.Next(10000, 999999).ToString());
        }

        public static string GenerateRandomString(string prefix = "")
        {
            Random randomNumber = new Random();

            return (prefix == "") ? "Auto" + randomNumber.Next(999999).ToString() : prefix + randomNumber.Next(999999).ToString();
        }

        public static string GenerateRandomString(int Length)
        {
            char letter;
            StringBuilder GenerateString = new StringBuilder();
            Random randomText = new Random();

            for (int i = 0; i < Length; i++)
            {
                double flt = randomText.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                GenerateString.Append(letter);
            }

            return GenerateString.ToString();
        }

        public static string GenerateUniqueRandomString(int Length)
        {
            char letter;
            StringBuilder GenerateString = new StringBuilder();
            Random randomText = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < Length; i++)
            {
                double flt = randomText.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                GenerateString.Append(letter);
            }

            return GenerateString.ToString();
        }

        public static int GenerateRandomInt()
        {
            Random randomNumber = new Random();

            return randomNumber.Next(999999);
        }

        public static double GenerateRandomDouble(int min, int max)
        {
            Random randomNumber = new Random();

            return Math.Round(randomNumber.NextDouble() * (max - min) + min, 2);
        }

        public static string GetSpecificDateTime(int months = 0, int years = 0, int days = 0, string format = "")
        {
            DateTime date = DateTime.Today.AddYears(years).AddMonths(months).AddDays(days);

            return format.Equals("") ? date.ToString("MM/dd/yyyy H:mm tt") : date.ToString(format);
        }
    }
}
