// i need to add a way to save the AccountNumber and PIN to a CSV file
// i need to add a way to check the CSV file for the AccountNumber and PIN

using System;
using System.IO;
using System.Linq;

namespace CurrencyCalculator
{
    class SaveToCSV
    {
        TypeOut t = new TypeOut();
        public void SaveToCsv(string Name, int AN, int PIN)
        {
            //check file exists
            if (!File.Exists("user-data.csv"))
            {
                //if not create it
                File.Create("user-data.csv");
            }
            //check if AN already exists
            string[] lines = File.ReadAllLines("user-data.csv");
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields[1] == AN.ToString())
                {
                    t.TypeLine("Account Number already exists.");
                    t.TypeLine("Please try again.");
                    return;
                }
            }
            //create a string to write to the file
            string csv = $"{Name},{AN},{PIN}, 0"; 
            
            //write to the file
            File.AppendAllText("user-data.csv", csv);
        }
        //class to return name from csv from AN
        public string CustomerName(int AN)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[1] == AN.ToString())
                {
                    // If a match is found, return the second field (column)
                    return fields[0];
                }
            }

            // If no match is found, return an empty string
            return "";
        }
        
        public bool CheckAccountNumber(int AN)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[1] == AN.ToString())
                {
                    return true;
                }
            }

            // If no match is found, return false
            return false;
        }
        // generate a class to return the account number from the csv file
        public int GetAN(int AN)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[1] == AN.ToString())
                {
                    // If a match is found, try to parse the second field (column) as an int
                    // and return the value
                    if (int.TryParse(fields[1], out int result))
                    {
                        return result;
                    }
                    else
                    {
                        // If the value cannot be parsed as an int, return 0
                        return 0;
                    }
                }
            }

            // If no match is found, return 0
            return 0;
        }
        public bool CheckPIN(int AN, int PIN)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[1] == AN.ToString())
                {
                    if (fields[2] == PIN.ToString())
                    {
                        return true;
                    }
                }
            }

            // If no match is found, return false
            return false;
        }
        //Find and amend the balance of a user using AN as input to verify user
        public void UpdateBalance(int AN, float balance)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[1] == AN.ToString())
                {
                    string CN = fields[0];
                    int PIN = Convert.ToInt32(fields[2]);

                    // If a match is found, try to parse the second field (column) as a float
                    // and return the value
                    if (float.TryParse(fields[1], out float result))
                    {
                        result = balance;
                        //create a string to write to the file
                        string csvBal = $"{CN},{AN},{PIN},{result}";
                        //clear Specific line from csv file
                        File.WriteAllLines("user-data.csv", File.ReadAllLines("user-data.csv").Where(l => l != line).ToArray());
                        //use the result variable to update the csv file in a specific position in the array
                        File.AppendAllText("user-data.csv", csvBal);
                        
                    }
                    else
                    {
                        // If the value cannot be parsed as a float, return 0
                        return;
                    }
                }
            }
        }
        //class to return balance of a user using AN as input to verify user
        public float GetBalance(int AN)
        {
            // Read the CSV file
            string[] lines = File.ReadAllLines("user-data.csv");

            // Loop through the lines and split each line into an array of strings (fields)
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                // Check if the first field (column) matches the input string
                if (fields[1] == AN.ToString())
                {
                    // If a match is found, try to parse the second field (column) as a float
                    // and return the value
                    if (float.TryParse(fields[3], out float result))
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
    }

}

