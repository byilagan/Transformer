///Bailey Ilagan
///October 27, 2016 
///accelerateTransformer.cs
///The purpose of this class is to extend the transformer class. Implements a
///different transform method to help the user guess

///Assumption: 
/// - The "internal pattern" is accelerateFactor incremented by 1 each time 
///   the user tries to guess 
/// - accelerateFactor is added to product to "accelerate" 

using System;

namespace p3
{
    class accelerateTransformer: transformer
    {
        private int accelerateFactor; //number added to sum to "accelerate"

        //constructor
        public accelerateTransformer(int val): base(val){accelerateFactor = 0;}

        /// Processes the users guess 
        /// 
        /// Precondition: 
        ///  - Object needs to be active
        /// Postcondition: 
        ///  - If accepted value does not match hiddenNum then the 
        ///    sum of the product of hiddenNum and val and the 
        ///    accelerateFactor will be returned 
        /// Inveriants: 
        ///  - A number will always be returned
        public override int processGuess(int val)
        {
            update(val);

            if (val != hiddenNum)
            { 
                accelerateFactor++; 
                return (hiddenNum * val) + accelerateFactor; 
            } 
            else
            { 
                return -1;
            } 
        }
    }
}
