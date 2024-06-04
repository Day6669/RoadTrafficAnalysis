using System;
namespace AC_Assignment1
{
	public class Road
	{
		public List<int> roaddata;
		public string roadname;
		// Road Constructor.
		public Road(List <int> data, string name) 
		{
			roaddata = data;
			roadname = name;
		}
		// Print data in intervals.
		public void ShowEvery(int n)
		{
			for (int i = 0; i < roaddata.Count; i++)
			{
				if ((i + 1) % n == 0)
				{
					Console.WriteLine($"{roaddata[i]}");
				}
			}
		}
		public void ShowEvery(int n, List<int> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if ((i + 1) % n == 0)
                {
                    Console.WriteLine($"{array[i]}");
                }
            }
        }
    }
}

