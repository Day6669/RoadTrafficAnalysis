namespace AC_Assignment1
{
    internal class Program
    {
        static List<int>? sorted;
        static void print(List<int> array)
        {
            string output = "";
            foreach (int item in array)
            {
                output += $"{item}, ";
            }
            Console.WriteLine(output);
        }
        // Searches for all occurrences of a given key in a given sorted list.
        private static List<int> BinarySearch(int key, List<int> array)
        {
        // Initialize an empty list to store the indexes where the key was found.
            List<int> Indexes = new List<int>();
            int steps = 0;
        // Initialize two pointers to the start and end of the list.
            int min = 0;
            int max = array.Count - 1;
        // Loop until the pointers cross each other.
            while (min <= max)
            {
                int mid = (min + max) / 2;
                steps++;
        // If the key is found at the middle index, add it to the indexes list,
        // and search for other occurrences of the key to the left and right of the middle index.
                if (key == array[mid])
                {
                    Indexes.Add(mid);
                    for (int j = mid - 1; j >= min; j--)
                    {
                        steps++;
                        if (key == array[j])
                        {
                            Indexes.Add(j);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = mid + 1; i <= max; i++)
                    {
                        steps++;
                        if (key == array[i])
                        {
                            Indexes.Add(i);
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"operations = {steps}");
                    return Indexes;

                }
        // If the key is smaller than the middle element, search in the left half of the list.
                else if (key < array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            List<int> closest = Sorting.NearestNeighbors(key, array.ToArray());
            Console.WriteLine($"operations = {steps}");
            return closest;
        }

        private static List<int> LinearSearch(int key,List<int> array)
        {
            List<int> Indexes = new List<int>();
            int steps = 0;
            for (int i = 0; i < array.Count; i++)
            {
                steps++;
                if (array[i] == key)
                    Indexes.Add (i);
            }
        // If no indexes were found (i.e. the "Indexes" list is empty), it prints an error message to the console.
            if (Indexes.Count == 0)
            {
                List<int> closest = Sorting.NearestNeighbors(key, array.ToArray());
                Console.WriteLine($"operations = {steps}");
                return closest;
            }
            // Returns the list of all indexes where the key is found in the array, or an empty list if no indexes were found.
            Console.WriteLine($"operations = {steps}");
            return Indexes;
        }
        // This method displays a numbered list of options to the user and prompts for input.
        static int GetMenuInput(List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {options[i]}");
            }
            int menuIndex = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    menuIndex = userInput;
                    break;
                }
        // The input is validated to ensure it is a number. If not, an error message is displayed and the user is prompted again.
                else
                {
                    Console.WriteLine("Please enter a number!");
                }
            }

            return menuIndex;
        }
        static void Main(string[] args)
        {
            Roads roads = new Roads();
            Roads.readfiles();
            Console.WriteLine("Pick a road:");
            Road[] allroads = Roads.getallroads();
            int counter = 1;
            foreach (Road road in allroads)
            {
                Console.WriteLine($"{counter}) {road.roadname}");
                counter++;
            }
        // Get user's choice of road.
            string? userinput = Console.ReadLine();
            if (userinput is not null)
            {
                int roadindex = int.Parse(userinput) - 1;
        // Get the selected road.
                Road currentroad = allroads[roadindex];
                currentroad.ShowEvery(10);
        // Create a list of sorting algorithms.
                List<string> Sortlist = new List<string>()
          {
              "BubbleSort","SelectionSort","PancakeSort","QuickSort"
          };
                int sorttype = GetMenuInput(Sortlist);
                Console.WriteLine("Do you want to sort backwards? Y/N");
                string? choices = Console.ReadLine();
                if (choices is not null)
                {
                    bool reverse = choices == "Y" ? true : false;
        // Apply the chosen sorting algorithm to the road data.
                    switch (sorttype)
                    {
                        case 1:
                            if (reverse)
                            {
                                sorted = Sorting.BubbleSortback(currentroad.roaddata);
                                break;
                            }
                                sorted = Sorting.BubbleSort(currentroad.roaddata);
                                 break;
                        case 2:
                            if (reverse)
                            {
                                sorted = Sorting.SelectionSortback(currentroad.roaddata);
                                break;
                            }
                            sorted = Sorting.SelectionSort(currentroad.roaddata);
                            break;
                        case 3:
                            if (reverse)
                            {
                                sorted = Sorting.pancakeSortback(currentroad.roaddata.ToArray()).ToList();
                                break;
                            }
                                sorted = Sorting.pancakeSort(currentroad.roaddata.ToArray()).ToList();
                                break;
                        case 4:
                            int[] array = currentroad.roaddata.ToArray();
                            if (reverse)
                            {
                            Sorting.QuickSort(ref array,0,array.Length-1,reverse);
                                sorted = array.ToList();
                                Console.WriteLine($"operations = {Sorting.quicksortsteps}");
                                break;
                            }
                            Sorting.QuickSort(ref array, 0, array.Length-1);
                                sorted = array.ToList();
                            Console.WriteLine($"operations = {Sorting.quicksortsteps}");
                            break;
                    }
                    foreach (int n in sorted)
                        Console.WriteLine(n);
                    Console.WriteLine("displayeveryfifty");
                    currentroad.ShowEvery(10, sorted);
                }
        // Prompt the user to select a search algorithm.
                List<string> Searchlist = new List<string>()
          {
              "LinearSearch","BinarySearch"
          };
                int searchtype = GetMenuInput(Searchlist);
        // Get the key to search for from the user input
                Console.WriteLine("What are you searching for?");
                int key = int.Parse(Console.ReadLine());
                switch (searchtype)
                {
                 case 1:
        // Perform linear search and print the resulting indexes.
                        List<int> Indexes = LinearSearch(key, sorted);
                        print(Indexes);
                    break;
                 case 2:
                        List<int> indx = BinarySearch(key, sorted);
                        print(indx);
                        break;
                }
            }
        }
    }
}
