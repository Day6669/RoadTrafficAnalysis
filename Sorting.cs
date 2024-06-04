using System;
using System.Xml.Linq;

namespace AC_Assignment1
{
	public class Sorting
	{
        public static int quicksortsteps;
        public static int FindNearest(int firstValueIdx, int secondValueIdx, int target, int[] array)
        {
            // Calculate the difference between the target and the two values.
            int diffFirst = target - array[firstValueIdx];
            int diffSecond = array[secondValueIdx] - target;
            // Compare the differences and return the index of the nearest value.
            if (diffFirst >= diffSecond)
                return secondValueIdx;
            else
                return firstValueIdx;
        }
        // A method to find the nearest neighbors to a given key in a sorted array.
        public  static List<int> NearestNeighbors(int key, int[] array)
        {
            List<int> nearest = new List<int>();
            // Check if the key is less than or equal to the first value in the array.
            if (key <= array[0])
            {
                // Iterate over the array and find all the values that are equal to the first value.
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[0] == array[i])
                    {
                        nearest.Add(i);
                    }
                    else
                    {
                        break;
                    }
                }
                // Return the list of nearest neighbor indexes.
                return nearest;
            }
            // Check if the key is greater than or equal to the last element in the array.
            if (key >= array[array.Length - 1])
            {
                // Iterate backwards over the array to find the nearest neighbors to the key.
                for (int i = array.Length - 1; i > 0; i--)
                {
                 // If an element is equal to the last element in the array, add it to the list of nearest neighbors.
                    if (array[array.Length - 1] == array[i])
                    {
                        nearest.Add(i);
                    }
                    // If the element is not equal to the last element, break the loop since we have found all the nearest neighbors.
                    else
                    {
                        break;
                    }
                }
                return nearest;
            }
            // If the key is not greater than or equal to the last element in the array, find the nearest neighbors using binary search.
            int min = 0;
            int max = array.Length;
            int mid = 0;

            // If broken change to <.
            while (min <= max)
            {
                mid = (min + max) / 2;

                if (key < array[mid])
                {
                    if (mid > 0 && key > array[mid - 1])
                    {
                        // Find the nearest index to the key and add it to the result list.
                        int nearestIndex = FindNearest(mid - 1, mid, key, array);
                        nearest.Add(nearestIndex);
                        // Check for any other matching values to the left and add their indices.
                        for (int i = nearestIndex + 1; i < max; i++)
                        {
                            if (array[i] == array[nearestIndex])
                            {
                                nearest.Add(i);
                            }
                            else
                                break;
                        }
                        // Check for any other matching values to the right and add their indices.
                        for (int j = nearestIndex - 1; j > min; j--)
                        {
                            if (array[j] == array[nearestIndex])
                            {
                                nearest.Add(j);
                            }
                            else
                                break;
                        }
                        return nearest;
                    }
                    max = mid;
                }
                else
                {
                    // If key is greater than the middle element, search the right half.
                    if (mid < array.Length - 1 && key < array[mid + 1])
                    {
                        // Find the nearest index to the key and add it to the result list.
                        int nearestIndex = FindNearest(mid, mid + 1, key, array);
                        nearest.Add(nearestIndex);
                        // Check for any other matching values to the right and add their indices.
                        for (int i = nearestIndex + 1; i < max; i++)
                        {
                            if (array[i] == array[nearestIndex])
                            {
                                nearest.Add(i);
                            }
                        }
                        // Check for any other matching values to the left and add their indices.
                        for (int j = nearestIndex - 1; j > min; j--)
                        {
                            if (array[j] == array[nearestIndex])
                            {
                                nearest.Add(j);
                            }
                        }
                        return nearest;
                    }
                    min = mid + 1;
                }
            }
            nearest.Add(mid);
            return nearest;
        }

            public static int partition(int low, int high, ref int[] arr)
        {
            // Select the pivot element.
            int pivot = arr[high];
            // Initialize the index of smaller element.
            int i = low - 1;
            // Traverse the array from left to right.
            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than the pivot.
                if (arr[j] < pivot)
                {
                    quicksortsteps++;
                    i++; int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            // Swap the pivot element with the element at the (i + 1)th position.
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;
            // Return the index of the pivot element.
            quicksortsteps++;
            return i + 1;

        }
        public static int partitionback(int low, int high, ref int[] arr)
        {
            int pivot = arr[high];
            int i = low - 1;
            // Traverse the array from left to right.
            for (int j = low; j <= high - 1; j++)
            {
                // If current element is greater than the pivot.
                if (arr[j] > pivot)
                {
                    quicksortsteps++;
                    i++; int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            // Swap the pivot element with the element at the (i + 1)th position.
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;
            // Return the index of the pivot element.
            quicksortsteps++;
            return i + 1;

        }
        // Recursive QuickSort calls.
        public static void QuickSort(ref int[] arr, int low, int high,bool reverse = false)
        {
            quicksortsteps++;
            if (low < high)
            {
                int pivot;
                if (reverse == true)
                {
                    pivot = partitionback(low, high, ref arr);
                }
                else
                {
                    pivot = partition(low, high, ref arr);
                }
                QuickSort(ref arr, low, pivot - 1);
                QuickSort(ref arr, pivot + 1, high);
            }
        }
        // Flips the array.
        public static void flip(int[] arr, int i)
        {
            int temp, start = 0;
            while (start < i)
            {
                temp = arr[start];
                arr[start] = arr[i];
                arr[i] = temp;
                start++;
                i--;
            }
        }

        // Gets largest index.
        public static int GetLargestIndex(int[] arr, int n, ref int steps)
        {
            int largest = 0;

            for (int i = 0; i < n; ++i)
            {
                steps++;
                if (arr[i] > arr[largest])
                    largest = i;
            }

            return largest;
        }
        // Gets smallest index.
        public static int GetSmallestIndex(int[] arr, int n, ref int steps)
        {
            int smallest = 0;

            for (int i = 0; i < n; ++i)
            {
                steps++;
                if (arr[i] < arr[smallest])
                    smallest = i;
            }

            return smallest;
        }

        public static int[] pancakeSort(int[] arr)
        {
            int n = arr.Length;
            int steps = 0;
            // Go from the end to start.
            for (int curr_size = n; curr_size > 1; --curr_size)
            {
                int max = GetLargestIndex(arr, curr_size, ref steps);

                // If the current element isn't the largest flip it to the end.
                steps++;
                if (max != curr_size - 1)
                {
                    flip(arr, max);
                    steps++;
                    // Flip the array so that the largest ends up at the end.
                    flip(arr, curr_size - 1);
                }
            }
            Console.WriteLine($"operations = {steps}");
            return arr;
        }
        public static int[] pancakeSortback(int[] arr)
        {
            int n = arr.Length;
            int steps = 0;
            // Go from the end to start.
            for (int curr_size = n; curr_size > 1; --curr_size)
            {
                int min = GetSmallestIndex(arr, curr_size, ref steps);

                // If the current element isn't the largest flip it to the end.
                steps++;
                if (min != curr_size - 1)
                {
                    flip(arr, min);
                    steps++;
                    // Flip the array so that the largest ends up at the end.
                    flip(arr, curr_size - 1);
                }
            }
            Console.WriteLine($"operations = {steps}");
            return arr;
        }
        // Swap element until the largest one is bubbled to top.
        public static List<int> BubbleSort(List<int> array)
        {
            int steps = 0;
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    steps++;
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"operations = {steps}");
            return array;
        }
        // The same as bubble but backwards.
        public static List<int> BubbleSortback(List<int> array)
        {
            int steps = 0;
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    steps++;
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"operations = {steps}");
            return array;
        }
        // Looping and getting the smallest each time.
        public static List<int> SelectionSort(List<int> array)
        {
            int size = array.Count;
            int steps = 0;
            for (int i = 0; i < size - 1; i++)
            {
                int smallestindex = i;

                for (int j = i + 1; j < array.Count; j++)
                {
                    steps++;
                    if (array[j] < array[smallestindex])
                    {
                        smallestindex = j;
                    }
                }
                // Swapping the smallest with the current.
                steps++;
                int temp = array[smallestindex];
                array[smallestindex] = array[i];
                array[i] = temp;
            }
            Console.WriteLine($"operations = {steps}");
            return array;
        }
        // The same as selection but backwards.
        public static List<int> SelectionSortback(List<int> array)
        {
            int size = array.Count;
            int steps = 0;
            for (int i = 0; i < size - 1; i++)
            {
                int largestindex = i;

                for (int j = i + 1; j < array.Count; j++)
                {
                    steps++;
                    if (array[j] > array[largestindex])
                    {
                        largestindex = j;
                    }
                }
                steps++;
                int temp = array[largestindex];
                array[largestindex] = array[i];
                array[i] = temp;
            }
            Console.WriteLine($"operations = {steps}");
            return array;
        }
        public Sorting()
        {
            quicksortsteps = 0;
        }
	}

}
