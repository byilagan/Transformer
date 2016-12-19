///Bailey Ilagan
///October 27, 2016 
///viralTransformer.cs
///The purpose of this class is to extend the transformer class. Implements a
///different transform method to help the user guess

/// Assumptions: 
///  - Whether the class returns a product or a product modulo depends on 
///    the operation bool; alternates after every guess 
///  - The number used for modulo is the sum of hiddenNum and the passed in
///    number

using System;

namespace p3
{
    class viralTransformer: transformer
    {
        //constructor
        public viralTransformer(int val): base(val){}

        /// Processes the users guess 
        /// 
        /// if operation is true -> returns product of val and hiddenNum
        /// if operation is false -> product modulus the sum of val 
        ///                          and hiddenNum 
        /// 
        /// Preconditions: 
        ///  - Object needs to be active 
        ///  - Accepted number can't be negative 
        /// Postconditions: 
        ///  - If val doesn't match hiddenNum, either the product of 
        ///    hiddenNum and val or that product modulus the sum of 
        ///    val and hiddenNum will be returned
        /// Invariants: 
        ///  - A number will always be returned 
        public override int processGuess(int val)
        {
            update(val); 

            if (val != hiddenNum)
            {
                if (operation)
                {
                    operation = false;
                    return hiddenNum * val;
                }
                else
                {
                    operation = true;
                    return (hiddenNum * val) % (hiddenNum + val);
                }
            }
            else
            {
                return -1; 
            }
        }
    }
}
