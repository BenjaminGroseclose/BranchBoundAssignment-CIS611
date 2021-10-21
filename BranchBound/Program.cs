using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BranchBound
{
    /*
    Problem Statement: In this problem, originally written by Ondřej Lhoták, Erin is an engineer. She drives 
    trains. She also arranges the cars within each train. She prefers to put the cars in decreasing order 
    of weight, with the heaviest car at the front of the train.

    Unfortunately, sorting train cars is not easy. One cannot simply pick up a car and place it somewhere else. 
    It is impractical to insert a car within an existing train. A car may only be added to the beginning and 
    end of the train.

    Cars arrive at the train station in a predetermined order. When each car arrives, Erin can add it to the 
    beginning or end of her train, or refuse to add it at all. The resulting train should be as long as 
    possible, but the cars within it must be ordered by weight.

    Given the weights of the cars in the order in which they arrive, what is the longest train 
    that Erin can make?

    Inputs: The first integer (n) specifies the number of cars. The remaining n positive integers 
    each contain the weight of a car in the order they arrive.

    Output: Output a single integer giving the number of cars in the longest train that can be made 
    with the given restrictions.

    Example: The following is a simple example:

    Input: 4 5 4 3 1
    Output: 4

    Input: 5, 2, 4, 3
    Output: 3
    */
    public class Program
    {
        public static int BestValue = 0;
        static void Main(string[] args)
        {
            //int[] numbers = new int[] { 4, 5, 4, 3, 1 };
            int[] numbers = new int[] { 4, 5, 2, 4, 3 };
            //int[] numbers = new int[] { 50, 5, 24, 84, 58, 21, 57, 98, 51, 6, 16, 75, 95, 11, 23, 92, 85, 29, 56, 45, 55, 73, 20, 4, 34, 76, 96, 63, 30, 93, 2, 19, 39, 14, 71, 80, 40, 69, 54, 62, 42, 1, 10, 35, 8, 22, 70, 67, 15, 27, 38 };

            if (3 == Process(numbers))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Wrong");
            }
        }

        public static int Process(int[] numbers, int depth = 1, List<int> train = null)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int finalValue = 0;
            // If there is no train, add the first car
            if (train == null)
            {
                train = new List<int>()
                {
                    numbers.ElementAt(depth)
                };

                finalValue = Process(numbers, depth + 1, train);

                stopwatch.Stop();
                Console.WriteLine($"Total time in milliseconds: {stopwatch.ElapsedMilliseconds}");
                return BestValue;
            }
            else if (depth == numbers[0] + 1)
            {
                Console.Write($"Current Train:");
                train.ForEach(x =>
                {
                    Console.Write($" {x}");
                });
                Console.WriteLine();
                int retval = train.Count;

                if (retval > BestValue)
                {
                    BestValue = retval;
                    Console.WriteLine($"Updating return value to be: {BestValue}");
                }

                return BestValue;
            }
            else
            {
                // Getting max weight
                int upperBound = train.ElementAt(0);

                // Getting min weight of the train
                int lowerBound = train.ElementAt(train.Count - 1);

                // Current train car to add
                int currentTrainWeight = numbers[depth];

                // START BOUND
                // If best value is greater than the current number of cars in the 
                // train + the remaining cars to add then we will always choose the 
                // current best value so there is no point in continuing
                if (BestValue > (train.Count + numbers[0] - depth))
                {
                    return BestValue;
                }
                // END BOUND

                // START BRANCHING
                // Do not add
                finalValue = Process(numbers, depth + 1, train);
                
                if (currentTrainWeight >= upperBound)
                {
                    // Add to front
                    finalValue = Process(numbers, depth + 1, AddToFront(train, numbers[depth]));
                }
                else if (currentTrainWeight <= lowerBound)
                {
                    // Add to Back
                    finalValue = Process(numbers, depth + 1, AddToBack(train, numbers[depth]));
                }
                // END BRANCHING

                return finalValue;
            }
        }

        private static List<int> AddToFront(List<int> train, int car)
        {
            List<int> tempTrain = new List<int>();

            tempTrain.Add(car);

            train.ForEach(x => 
            {
                tempTrain.Add(x);
            });

            return tempTrain;
        }

        private static List<int> AddToBack(List<int> train, int car)
        {
            List<int> tempTrain = new List<int>();

            train.ForEach(x => 
            {
                tempTrain.Add(x);
            });

            tempTrain.Add(car);

            return tempTrain;
        }
    }
}
