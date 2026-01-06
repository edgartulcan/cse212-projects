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

        // PLAN for MultiplesOf(number, length)
        // 1) Create a new array of doubles with exactly 'length' elements.
        // 2) For i from 0 up to length - 1:
        //    - The i-th element should be the (i + 1)-th multiple of 'number'.
        //    - That is: result[i] = number * (i + 1).
        // 3) After the loop, return the filled array.
        //
        // Notes / Edge cases:
        // - If number == 0, every element will be 0 (correct).
        // - If number is negative, multiples remain negative in the same pattern.
        // - We assume 'length' > 0 


        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

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
        // PLAN for RotateListRight(data, amount)
        // 1) Determine how many elements will move from the end of the list to the front.
        //    - This is equal to 'amount'.
        // 2) Get the last 'amount' elements from the list using GetRange.
        // 3) Get the remaining elements from the beginning of the list.
        // 4) Clear the original list.
        // 5) Add the last elements first, then add the remaining elements.

        int count = data.Count;

        List<int> endPart = data.GetRange(count - amount, amount);
        List<int> startPart = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(endPart);
        data.AddRange(startPart);
    }
}
