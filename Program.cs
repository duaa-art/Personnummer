using System;

namespace PersonnummerKontroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ange ett svenskt personnummer (YYYYMMDD-XXXX):");
            string input = Console.ReadLine();

            if (ValidatePersonnummer(input))
            {
                Console.WriteLine("Personnumret är korrekt.");
            }
            else
            {
                Console.WriteLine("Personnumret är felaktigt.");
            }
        }

        public static bool ValidatePersonnummer(string personnummer)
        {
            if (string.IsNullOrWhiteSpace(personnummer) || personnummer.Length != 13 || personnummer[8] != '-')
                return false;

            string numbers = personnummer.Replace("-", "");
            if (!long.TryParse(numbers, out _))
                return false;

            int[] weights = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int checksum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                int product = (numbers[i] - '0') * weights[i];
                checksum += product / 10 + product % 10;
            }

            int controlDigit = (10 - (checksum % 10)) % 10;
            return controlDigit == (numbers[10] - '0');
        }
    }
}
