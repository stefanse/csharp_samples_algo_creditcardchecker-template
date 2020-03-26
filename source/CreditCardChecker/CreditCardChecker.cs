using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
       
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        ///


        public static bool IsCreditCardValid(string creditCardNumber)
        {
            int oddSum = 0;
            int evenSum =0 ;


            for (int i = 0; i < creditCardNumber.Length -2; i++)
            {
                if (i % 2 == 0)
                {
                   evenSum +=  ConvertToInt(creditCardNumber[i]) * 2;
                   
                }

                else 
                {
                    oddSum += ConvertToInt(creditCardNumber[i]);
                }
            }

            if (CalculateCheckDigit(oddSum, evenSum) == creditCardNumber.Length-2)
            {
                return true;
            }
            else
            {
                return false;
            }
            


        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        ///
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            int number;
            int checksum = 0 ;

            number = CalculateDigitSum(oddSum) + evenSum;
            
            while (number % 10 != 0)
            {
                number++;
                checksum++;

            }

            return checksum;
            
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int sum = 0;
            int digit = 0;
            while (number > 0)
            {

                digit = number % 10;
                number = number / 10;
                sum = sum + digit;
                
            }
            return sum;
        }

        private static int ConvertToInt(char ch)
        {
            int number;
            number = ch - '0';
            return number;
        }
    }
}
