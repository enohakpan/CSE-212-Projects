public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new array of doubles with size equal to 'length'
        // Step 2: Loop through each index from 0 to length - 1
        // Step 3: At each index i, the multiple is number * (i + 1)
        //         e.g. i=0 -> number*1, i=1 -> number*2, ...
        // Step 4: Store each calculated multiple into the array
        // Step 5: Return the filled array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
            result[i] = number * (i + 1);
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Find the split point: index = data.Count - amount
        //         This is where the "tail" that moves to the front begins.
        //         e.g. {1,2,3,4,5,6,7,8,9}, amount=3 -> splitIndex=6
        // Step 2: Slice the tail: GetRange(splitIndex, amount) -> {7,8,9}
        // Step 3: Slice the head: GetRange(0, splitIndex)      -> {1,2,3,4,5,6}
        // Step 4: Clear the original list
        // Step 5: Add the tail first, then the head back into data
        //         Result: {7,8,9,1,2,3,4,5,6}

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        List<int> head = data.GetRange(0, splitIndex);
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
