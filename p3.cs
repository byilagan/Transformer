///Bailey Ilagan
///October 27, 2016
///p3.cs
///The purpose of this class is to test all the functionality of the 
///transformer class heirarchy. 

using System;
using static System.Console;

namespace p3
{
    class p3
    {
        const int NUM_TRANS = 2; //# of transformer objects in array 
        const int NUM_ACCEL = 2; //# of accelerateTransformer objects in array 
        const int NUM_VIRAL = 2; //# of viralTransformer objects in array 
        const int ARRAY_SIZE = NUM_TRANS + NUM_ACCEL + NUM_VIRAL; 
        const int RAND_LIMIT = 20; //max of random number 
        const int NUM_TESTS = 5; //number of tests ran on each object 
        static Random random = new Random(); 

        /// Returns a random number based on the RAND_LIMIT
        /// Preconditions: (RAND)LIMIT is positive 
        /// Postconditions: returns random number greater than or equal to 0
        ///                 and less than RAND_LIMIT
        /// Invariants: None
        static int randomNum(){return random.Next(RAND_LIMIT);}
             
        /// Prints the stats for a given transformer array 
        /// Precondtions: transformer array must not be empty and size must be
        ///               the size of the array 
        /// Postconditions: Stats will be printed for all objects in the array 
        /// Invariants: None
        static void printStats(transformer[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                WriteLine("---------");
                WriteLine("Object " + (i + 1));
                WriteLine("---------");
                WriteLine("# of guesses: " + array[i].getNumGuesses());
                WriteLine("# of high guesses: " + array[i].getHighGuesses());
                WriteLine("# of low guesses: " + array[i].getLowGuesses());
                WriteLine("Average guess: " + array[i].getAvgGuess());
            }
        }

        /// Runs a test on a given transformer array 
        /// Preconditions: transformer array must not be empty and size must be
        ///                the size of the array 
        /// Postconditions: Test will run on given array 
        /// Invariants: None 
        static void runTests(transformer[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                WriteLine("---------");
                WriteLine("Object " + (i + 1));
                WriteLine("---------");

                int count = 0; //used for while loop 
                //runs until correct or out of tests
                while (count < NUM_TESTS && array[i].isActive())
                {
                    int input = randomNum();
                    int returnVal = 0;

                    WriteLine("Enter guess: " + input);
                    returnVal = array[i].processGuess(input);

                    if (returnVal == -1)
                    {
                        WriteLine("Congrats! You have guessed correctly!");
                    }
                    else
                    {
                        WriteLine("Incorrect...Object has returned " + returnVal);
                        count++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //array of all objects in hierarchy
            transformer[] Trans_Array = new transformer[NUM_TRANS + NUM_ACCEL +
                NUM_VIRAL]; 

            //array of accelerateTransformer objects 
            transformer[] Accel_Array = new transformer[NUM_TRANS];

            //array of viralTransformer objects
            transformer[] Viral_Array = new transformer[NUM_ACCEL];

            int index = 0; 

            //fills Trans_Array 
            for (int i = 0; i < NUM_TRANS; i++)
            {
                Trans_Array[index] = new transformer(randomNum());
                index++; 
            }
            for (int i = 0; i < NUM_TRANS; i++)
            {
                Trans_Array[index] = new accelerateTransformer(randomNum());
                index++;
            }
            for (int i = 0; i < NUM_TRANS; i++)
            {
                Trans_Array[index] = new viralTransformer(randomNum());
                index++;
            }

            //fills Accel_Array
            for (int i = 0; i < NUM_ACCEL; i++)
            {
                Accel_Array[i] = new accelerateTransformer(randomNum());
            }

            //fills Viral_Array 
            for (int i = 0; i < NUM_VIRAL; i++)
            {
                Viral_Array[i] = new viralTransformer(randomNum());
            }

            WriteLine("\n");
            WriteLine("Welcome to the Transformer Class Hierarchy Test");
            WriteLine("-----------------------------------------------");
            WriteLine("\n");

            WriteLine("The purpose of this program is test all the functionality");
            WriteLine("that the transformer class hierarchy has to offer.");
            WriteLine("\n");

            WriteLine("Press enter to begin test...");
            ReadKey();

            Clear();

            WriteLine("transformer Array Test");
            WriteLine("----------------------");

            runTests(Trans_Array, ARRAY_SIZE);

            WriteLine("\n");
            WriteLine("transformer Array Stats");
            WriteLine("-----------------------");

            printStats(Trans_Array, ARRAY_SIZE);

            WriteLine("\n");
            WriteLine("accelerateTransformer Array Test");
            WriteLine("--------------------------------");

            runTests(Accel_Array, NUM_ACCEL);

            WriteLine("\n");
            WriteLine("accelerateTransformer Array Stats");
            WriteLine("---------------------------------");

            printStats(Accel_Array, NUM_ACCEL);

            WriteLine("\n"); 
            WriteLine("viralTransformer Array Test");
            WriteLine("---------------------------");

            runTests(Viral_Array, NUM_VIRAL); 

            WriteLine("\n");
            WriteLine("viralTransformer Array Stats");
            WriteLine("----------------------------");

            printStats(Viral_Array, NUM_VIRAL);

            WriteLine("\n");
            WriteLine("Press enter to exit program...");
            ReadKey();
        }
    }
}
