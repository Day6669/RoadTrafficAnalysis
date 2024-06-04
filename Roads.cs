using System.Runtime.InteropServices;
namespace AC_Assignment1
{
    internal class Roads
    {
        private static Road[] roadarray = new Road[6];
        public static void readfiles()
        {
            try
            {
                string currentpath;
                List<string> formatPath;
                string folderPath = "";
                if (RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
                {

                    // mac file paths have backward slashes hence checking OS (I use Mac)
                    currentpath = Directory.GetCurrentDirectory();
                    formatPath = currentpath.Split('/').ToList<String>();
                    formatPath.RemoveAt(formatPath.Count - 1);
                    formatPath.RemoveAt(formatPath.Count - 1);
                    formatPath.RemoveAt(formatPath.Count - 1);
                    // add \Roads folder and join it together
                    folderPath = string.Join('/', formatPath) + "/Roads/";
                }
                else
                {
                    currentpath = Directory.GetCurrentDirectory();
                    formatPath = currentpath.Split('\\').ToList<String>();
                    formatPath.RemoveAt(formatPath.Count - 1);
                    // add \Roads folder and join it together
                    folderPath = string.Join('\\', formatPath) + "\\Roads\\";
                }
                int counter = 0;
                foreach (string file in Directory.EnumerateFiles(folderPath, "*.txt"))
                {
                    // Extracting the name from the file path.
                    string name = file.Split('/')[6].Split(".")[0];
                    List<string> dataPoints = File.ReadLines(file).ToList();
                    List<int> data = dataPoints.Select(x => Convert.ToInt32(x)).ToList();
                    roadarray[counter] = new Road(data, name);
                    counter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static Road[] getallroads()
        {
            return roadarray;
        }
    }
 }

