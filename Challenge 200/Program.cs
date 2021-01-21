using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_200
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHALLENGE 201");
            Console.WriteLine(Maskify("4556364607935616"));
            Console.WriteLine(Maskify("64607935616"));
            Console.WriteLine(Maskify("1"));
            Console.WriteLine(Maskify(""));
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 202");
            Console.WriteLine(ExpressFactors(2));
            Console.WriteLine(ExpressFactors(4));
            Console.WriteLine(ExpressFactors(10));
            Console.WriteLine(ExpressFactors(60));
            Console.WriteLine();

            
            Console.WriteLine("CHALLENGE 203");
            var primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            Console.WriteLine(IsPrime(primes, 3));
            Console.WriteLine(IsPrime(primes, 4));
            Console.WriteLine(IsPrime(primes, 67));
            Console.WriteLine(IsPrime(primes, 36));
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 204");
            Console.WriteLine(Potatoes("potato"));
            Console.WriteLine(Potatoes("potatopotato"));
            Console.WriteLine(Potatoes("potatoapple"));          
            Console.WriteLine();


            Console.WriteLine("CHALLENGE 205");
            var encryptedArray = Encrypt("Hello");
            Console.WriteLine("[{0}]", string.Join(", ", encryptedArray));
            Console.WriteLine(Decrypt(new int[] { 72, 33, -73, 84, -12, -3, 13, -13, -68 }));
            encryptedArray = Encrypt("Sunshine");
            Console.WriteLine("[{0}]", string.Join(", ", encryptedArray));
            Console.WriteLine();

        }

        static string Maskify(string input)
        {
            if (input.Length > 4)
            {
                return String.Concat(new String('#', input.Length - 4), input.Substring(input.Length - 4, 4));
            }
            else
            {
                return input;
            }
        }


      
        static string ExpressFactors(int number)
        {
            string output = "";
            int smallestDivisor = 2;

            // Jeg har valgt et while loop frem for et for loop, fordi at 'number' potentielt gøres mindre undervejs = fære itereringer.
            // Fremtidige forbedringer: tjek løbende om 'number' er et primtal så loopet potentielt kan breakes noget før. Eller i stedet for at incremente 'smallestDivisor' med 1, find det næste primtal i rækken

            while (smallestDivisor <= number)
            {
                int exponent = 0;

                while (number % smallestDivisor == 0)
                {
                    number = number / smallestDivisor;
                    exponent++;
                }


                if (exponent == 1)
                {
                    output += String.Format("{0} X ", smallestDivisor);

                } else if (exponent > 1)
                {
                    output += String.Format("{0} ^ {1} X ", smallestDivisor, exponent);

                }

                smallestDivisor++;
            
            }
                // Fjerner det sidste " X "
                return output.Substring(0, output.Length - 3);
        }

        static string IsPrime(int[] primes, int target)
        {

            int result = BinarySearch(primes, 0, primes.Length - 1, target);

            return result == -1 ? "no" : "yes";

        }

        static int BinarySearch(int[] array, int lowerBound, int upperBound, int target)
        {
            if (upperBound >= lowerBound)
            {
                int mid = lowerBound + (upperBound - lowerBound) / 2;

                if (array[mid] == target)
                    return mid;

                if (array[mid] > target)
                    return BinarySearch(array, lowerBound, mid - 1, target);

                return BinarySearch(array, mid + 1, upperBound, target);
            }

            return -1;
        }

        static int Potatoes(string input)
        {
            string word = "potato";
            int index = 0;
            int count = 0;

            // 
            while((index = input.IndexOf(word, index)) != -1)
            {
                count++;
                index += word.Length;
            }


            return count;


        }

        static int[] Encrypt(string input)
        {
           
            var asciiByteArray = Encoding.ASCII.GetBytes(input);
            var encryptedArray = new int[input.Length];
            encryptedArray[0] = asciiByteArray[0];

            for (int i = 1; i < input.Length; i++)
            {
                encryptedArray[i] = asciiByteArray[i] - asciiByteArray[i - 1];
            }

            return encryptedArray;
        }

        static string Decrypt(int[] inputArray)
        {
          
            var asciiByteArray= new byte[inputArray.Length];
            asciiByteArray[0] = (byte)inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                asciiByteArray[i] = (byte)(inputArray[i] + asciiByteArray[i - 1]);
            }

            return Encoding.ASCII.GetString(asciiByteArray);

        }

    }
}
