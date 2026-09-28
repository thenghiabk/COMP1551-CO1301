namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* TASK 1 */

            // Create an empty array with 10 elements
            int[] randomNumbers = new int[10];

            // Create an instance of the Random class
            Random rand = new Random();

            // SOLUTION 1: Manually add random number into array
            // Generate a random integer between 1 and 100 (101 is excluded)
            // then insert it into the array
            //randomNumbers[0] = rand.Next(1, 101);
            //randomNumbers[1] = rand.Next(1, 101);
            //randomNumbers[2] = rand.Next(1, 101);
            //randomNumbers[3] = rand.Next(1, 101);
            //randomNumbers[4] = rand.Next(1, 101);
            //randomNumbers[5] = rand.Next(1, 101);
            //randomNumbers[6] = rand.Next(1, 101);
            //randomNumbers[7] = rand.Next(1, 101);
            //randomNumbers[8] = rand.Next(1, 101);
            //randomNumbers[9] = rand.Next(1, 101);

            // SOLUTION 2: Add random numbers using a for loop
            for (int i = 0; i < randomNumbers.Length; i++)
            {   
                // Generate a random integer between 1 and 100 (101 is excluded)
                // then insert it into the array
                randomNumbers[i] = rand.Next(1, 101);
            }

            // Display the array on the screen
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                Console.WriteLine(randomNumbers[i]);
            }

            // Find maximum number in the array
            int maxValue = randomNumbers[0];

            for (int i = 1; i < randomNumbers.Length; i++)
            {
                if (randomNumbers[i] > maxValue)
                {
                    maxValue = randomNumbers[i];
                }
            }

            Console.WriteLine($"Maximum value is: {maxValue}");

            // TODO: Extract finding max value code to a method
        }
    }
}
