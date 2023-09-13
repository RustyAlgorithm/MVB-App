using System;
using System.IO;
using System.Linq;

namespace CurrencyCalculator
{
    class SaveToCSV
    {
        TypeOut t = new TypeOut();

        public void SaveToCsv(string name, float value)
        {
            // Check if the file exists
            if (File.Exists("user-data.csv"))
            {
                // Read the contents of the file into a string array
                string[] lines = File.ReadAllLines("user-data.csv");

                // Check if the user's name exists in the file
                if (lines.Any(line => line.StartsWith(name)))
                {
                    // If the user's name exists, update the value associated with the name
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith(name))
                        {
                            // Split the line into name and value
                            string[] parts = lines[i].Split(",");

                            // Update the value
                            lines[i] = parts[0] + "," + value;
                            break;
                        }
                    }

                    // Write the updated lines back to the file
                    File.WriteAllLines("user-data.csv", lines);
                }
                else
                {
                    // If the user's name does not exist, append the name and value to the file
                    using (StreamWriter file = File.AppendText("user-data.csv"))
                    {
                        file.WriteLine(name + "," + value);
                    }
                }
            }
            else
            {
                // If the file does not exist, create a new file and write the name and value to it
                using (StreamWriter file = new StreamWriter("user-data.csv"))
                {
                    file.WriteLine(name + "," + value);
                }
            }
        }

        public float GetBalance(string input)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[0] == input)
                {
                    // If a match is found, try to parse the second field (column) as a float
                    // and return the value
                    if (float.TryParse(fields[1], out float result))
                    {
                        return result;
                    }
                    else
                    {
                        // If the value cannot be parsed as a float, return 0
                        return 0;
                    }
                }
            }

            // If no match is found, return 0
            return 0;
        }

        public void ClearCSV(string filepath)
        {
            File.WriteAllText(filepath, String.Empty);
        }



    }

}

