//The main class that implements a mechanism for sorting an array of integers from a file,
//taking into account the limitation of the length of the array that can be placed in RAM

//The algorithm works with an arbitrary ratio between the size of the input array and the size of the allowed length in memory
namespace exercise_2
{
    internal static class SortController
    {
        //Specify the length of the array that can be stored in RAM
        private static readonly int _size = 50;
        private static int[] _income_part = new int[_size];


        //First, the length of the array in the file is evaluated.
        //Then the loading of the array is organized in parts, the length of which is no more than specified in the restrictions.
        //Parts of the array are passed to the merge sort algorithm.
        //After sorting, the array is written to a separate temporary file
        public static void SortParts()
        {
            int length = DB.GetCount(DB.PathData._init_path);
            int step = (int)Math.Ceiling(length / (decimal)_size);
            string[] pathTemp = new string[step];

            for (int i = 0; i < step; i++)
            {
                _income_part = DB.GetRangeLine(DB.PathData._init_path, i * _size + 1,  _size* (1 + i));

                MergeSort.SortArray(_income_part, 0, _income_part.Length - 1);

                DB.InitTempPath(step);
                pathTemp[i] = Path.Combine(DB.PathData._temp_path, $"temp{i}.txt");
                DB.WriteAllLine(_income_part, pathTemp[i]);
            }


            //A method call that merges all temporary files into the input file.
            //As a result, we get the input array in a sorted form
            MergeFiles(pathTemp, DB.PathData._init_path);


            //Delete all temporary files
            DeleteTempFile(pathTemp);
        }


        //
        private static void MergeFiles(string[] inputFilePaths, string outputFilePath)
        {
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                int[] currentValues = new int[inputFilePaths.Length];

                // Open the input files
                StreamReader[] inputFiles = new StreamReader[inputFilePaths.Length];
                for (int i = 0; i < inputFilePaths.Length; i++)
                {
                    inputFiles[i] = new StreamReader(inputFilePaths[i]);
                    ReadNextValue(i, inputFiles[i], currentValues);
                }

                // Merge the arrays
                bool isFinished = false;
                while (!isFinished)
                {
                    int minValue = int.MaxValue;
                    int minIndex = -1;

                    // Find the minimum value among the current values from each file
                    for (int i = 0; i < currentValues.Length; i++)
                    {
                        if (currentValues[i] != -1 && currentValues[i] < minValue)
                        {
                            minValue = currentValues[i];
                            minIndex = i;
                        }
                    }

                    if (minIndex != -1)
                    {
                        // Write the minimum value to the output file
                        outputFile.WriteLine(minValue);

                        // Read the next value from the file that contained the minimum value
                        ReadNextValue(minIndex, inputFiles[minIndex], currentValues);
                    }
                    else
                    {
                        // All files have been processed
                        isFinished = true;
                    }
                }

                // Close the input files
                for (int i = 0; i < inputFiles.Length; i++)
                {
                    inputFiles[i].Close();
                }
            }
        }

        private static void ReadNextValue(int fileIndex, StreamReader file, int[] currentValues)
        {
            string line = file.ReadLine();
            if (line != null)
            {
                currentValues[fileIndex] = int.Parse(line);
            }
            else
            {
                currentValues[fileIndex] = -1; // Indicates end of file
            }
        }

        private static void DeleteTempFile(string[] pathTemp)
        {
            foreach (string file in pathTemp)
            {
                DB.DeleteFile(file);
            }
        }
    }
}
