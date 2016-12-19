///Bailey Ilagan
///October 27, 2016
///transformer.cs 
///The purpose of this class is to implement a transformer object which holds 
///encapsulates an integer that can be guessed. Transforms guesses to help 
///user guess 

///Assumptions: 
/// - Whether the class returns a sum or a difference depends on the operation 
///   bool; alternates after each guess

///States: 
/// - When active, the objects encapsulated number (hiddenNum) has not been 
///   guessed correctly yet 
/// - When not active, the objects encapsulated number (hiddenNum) has already 
///   been guess correctly 

using System;

namespace p3
{
    class transformer
    {
        protected int hiddenNum; //number that needs to guessed 
        protected bool active; //indicates whether object is active or not 
        protected bool operation; //chooses an operation (if there is a choice)
        protected int num_lowGuesses; //number of low guesses
        protected int num_highGuesses; //number of high guesses
        protected int num_Guesses; //number of guesses 
        protected int total_Guess; //total sum of all the guesses 

        //constructor
        public transformer(int val) 
        {
            hiddenNum = val; 
            active = true;
            operation = true; 
            num_lowGuesses = 0; 
            num_highGuesses = 0; 
            num_Guesses = 0;
            total_Guess = 0; 
        }

        //active = hasn't  been guessed yet 
        //not active = guessed correctly 
        
        //getter for active 
        public bool isActive(){return active;}

        //getter for num_Guesses 
        public int getNumGuesses(){return num_Guesses;}

        //getter for num_lowGuesses
        public int getLowGuesses(){return num_lowGuesses;}

        //getter for num_highGuesses
        public int getHighGuesses(){return num_highGuesses;}

        /// returns the average guess by dividing total_Guess by num_Guesses
        /// 
        /// Preconditions: 
        ///  - numGuesses can't be 0 
        ///  - total_Guess can't be 0
        /// Postconditions:
        ///  - Average of all guesses will be returned 
        public int getAvgGuess(){return total_Guess / num_Guesses;}

        /// Processes the users guess 
        /// 
        /// if operation is true -> sum of val and hiddenNum 
        /// if operation is false -> difference of hiddenNum and val
        /// 
        /// Preconditions:
        ///  - Object needs to be active
        ///  - Accepted number is not negative
        /// Postconditions:
        ///  - The sum or difference of hiddenNum and val will be 
        ///    returned if guess is wrong
        ///  - -1 will be returned if guess is right
        /// Invariants: 
        ///  - A number will always be returned 
        public virtual int processGuess(int val)
        {
            update(val);

            if (val != hiddenNum)
            {
                if (operation)
                {
                    operation = false;
                    return hiddenNum + val;
                }
                else
                {
                    operation = true;
                    if ((hiddenNum - val) < 0)
                        return hiddenNum + val;
                    else
                        return hiddenNum - val; 
                }
            }
            else
            {
                return -1; 
            }
        }

        /// Takes in the number and updates all the stats data members 
        /// and checks if the passed in number matches the hiddenNum. 
        /// 
        /// Preconditions: 
        ///  - Accepted number is not a negative
        /// Postconditions: 
        ///  - all data members will be updated 
        ///  - Object becomes not active if accepted number equals 
        ///    hiddenNum
        /// Invariants: None
        protected void update (int val)
        {
            if (val > hiddenNum) 
                num_highGuesses++;
            else if (val < hiddenNum) 
                num_lowGuesses++;
            else if (val == hiddenNum) 
                active = false; 

            num_Guesses++;
            total_Guess = total_Guess + val; 
        }
    }
}
