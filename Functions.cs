﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using static System.Security.Cryptography.RandomNumberGenerator;
using System.Globalization;

namespace RSA
{
    static class Functions
    {
        internal static BigInteger GCD(BigInteger x, BigInteger y)
        {
            while (y != 0)
            {
                BigInteger temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }
        
        internal static bool IsPrime(BigInteger number)
        {
            BigInteger limit = Sqrt(number);
            for (BigInteger i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        internal static BigInteger Sqrt(BigInteger n)
        {
            BigInteger x = n;
            BigInteger y = (x + 1) / 2;
            while (y < x)
            {
                x = y;
                y = (x + n / x) / 2;
            }
            return x;
        }
        
        internal static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, temp, q;
            BigInteger x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                q = a / m;

                temp = m;
                
                m = a % m;
                a = temp;

                temp = x0;
                
                x0 = x1 - q * x0;
                x1 = temp;
            }
            
            if (x1 < 0)
                x1 += m0;

            return x1;
        }
        
        internal static BigInteger GenerateRandomBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            Random random = new Random();

            BigInteger range = maxValue - minValue + 1;
            BigInteger randomNumber = (BigInteger)(random.NextDouble() * (double)range) + minValue;
            return randomNumber;
        }

        internal static string TextToBinary(string text)
        {
            char[] textArray = text.ToCharArray();
            string textBinary = "";

            foreach (char c in textArray)
            {
                int cInt = (int)c;
                string cBinary = Convert.ToString(cInt, 2);
                cBinary = cBinary.PadLeft(8, '0');
                textBinary += cBinary;
            }
            
            return textBinary;
        }
        
        internal static string TextToASCII(string text)
        {
            string[] textArray = new string[text.Length/8];
            for(int i = 0; i < textArray.Length; i++) { textArray[i] = ""; }
            int counter = 0;
            for (int i = 0; i < textArray.Length; i++)
            {
                while (textArray[i].Length < 8)
                {
                    textArray[i] += text[counter];
                    counter++;
                }
            }

            string textASCII = "";
            for (int i = 0; i < textArray.Length; i++)
            {
                int number = Convert.ToInt32(textArray[i], 2);
                textASCII += (char)number;
            }
            
            return textASCII;
        }
        
        internal static string ConvertToBinary(BigInteger bigInt)
        {
            if (bigInt == 0) return "0";

            StringBuilder sb = new StringBuilder();
            while (bigInt > 0)
            {
                sb.Insert(0, (bigInt % 2).ToString());
                bigInt /= 2;
            }

            return sb.ToString();
        }

        internal static string TextToSuperNumber(string text)
        {
            string textNumber = TextToBinary(text);
            int textNumberLength = textNumber.Length;
            string textNumberBlock = "";
            string textNumberDecade = "";

            for (int i = 0; i < textNumberLength; i++)
            {
                textNumberBlock += textNumber[i];

                if (textNumberBlock.Length == 40 || i == textNumberLength-1)
                {
                    BigInteger superNumberDecade = Convert.ToInt64(textNumberBlock, 2);
                    textNumberDecade += superNumberDecade.ToString();
                    textNumberBlock = "";
                }
            }
            
            return textNumberDecade;
        }

        internal static string SuperNumberToText(string superNumber)
        {
            string textInput = superNumber;
            string[] textBlocks = new string[(int)Math.Ceiling((double)textInput.Length / 14)];
            int counter = 0;
            for (int i = 0; i < Math.Ceiling((double)textInput.Length/14); i++)
            {
                string block = "";
                if (counter % 14 == 0 && counter != textInput.Length - 1)
                {
                    block += textInput[counter];
                    counter++;
                }
                while (counter % 14 != 0 || counter == 0)
                {
                    if (counter == textInput.Length) { break; }
                    block += textInput[counter];
                    counter++;
                }
                textBlocks[i] = block;
                if (counter == textInput.Length) { break; }
            }
            
            string[] textBlocksBinary = new string[textBlocks.Length];
            for (int i = 0; i < textBlocksBinary.Length; i++)
            {
                BigInteger number = BigInteger.Parse(textBlocks[i]);
                string binary = ConvertToBinary(number);
                while (binary.Length % 8 != 0) { binary = '0' + binary; }
                textBlocksBinary[i] = binary;
            }
            
            string textResult = "";
            foreach (string s in textBlocksBinary)
            {
                textResult += TextToASCII(s);
            }
            
            return textResult;
        }

        internal static string TextEncrypt(BigInteger c, BigInteger N, BigInteger E)
        {
            return BigInteger.ModPow(c, E, N).ToString();
        }
        
        internal static string TextDecrypt(BigInteger c, BigInteger N, BigInteger D)
        {
            return BigInteger.ModPow(c, D, N).ToString();
        }
        
        internal static string ConvertToAscii(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            
            string formD = text.Normalize(NormalizationForm.FormD);
            
            StringBuilder result = new StringBuilder();
        
            foreach (char c in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    if (c <= 127)
                    {
                        result.Append(c);
                    }
                    else
                    {
                        result.Append(ReplaceWithAscii(c));
                    }
                }
            }

            return result.ToString();
        }
        
        internal static char ReplaceWithAscii(char c)
        {
            switch (c)
            {
                case 'á': return 'a';
                case 'č': return 'c';
                case 'ď': return 'd';
                case 'é': return 'e';
                case 'ě': return 'e';
                case 'í': return 'i';
                case 'ň': return 'n';
                case 'ó': return 'o';
                case 'ř': return 'r';
                case 'š': return 's';
                case 'ť': return 't';
                case 'ú': return 'u';
                case 'ů': return 'u';
                case 'ý': return 'y';
                case 'ž': return 'z';
                case 'Á': return 'A';
                case 'Č': return 'C';
                case 'Ď': return 'D';
                case 'É': return 'E';
                case 'Ě': return 'E';
                case 'Í': return 'I';
                case 'Ň': return 'N';
                case 'Ó': return 'O';
                case 'Ř': return 'R';
                case 'Š': return 'S';
                case 'Ť': return 'T';
                case 'Ú': return 'U';
                case 'Ů': return 'U';
                case 'Ý': return 'Y';
                case 'Ž': return 'Z';
                default: return '?';
            }
        }
    }
}