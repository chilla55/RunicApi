
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace RunicApi.datamanger
{
    public class File
        {
            private const string FilePath = "data.json";
            public static void SaveData(Data data)
            {
                try
                {
                    string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                    System.IO.File.WriteAllText(FilePath, jsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving data: {ex.Message}");
                }
            }
            public static Data LoadData()
            {
                try
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                    Console.WriteLine("Data file not found, returning a new instance.");
                        return new Data();
                    }

                    string jsonData = System.IO.File.ReadAllText(FilePath);
                    return JsonConvert.DeserializeObject<Data>(jsonData) ?? new Data();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading data: {ex.Message}");
                    return new Data();
                }
            }
        }
}
