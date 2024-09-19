
namespace CSVToTSVConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "";
            string outputFilePath = "";
            char direction = 'x';
            int noOfLines = 0;
            try
            {
                if (args.Any())
                {
                    inputFilePath = args[0];
                    outputFilePath = args[1];
                    string headerRecord;
                    Console.WriteLine("Loading csv file " + inputFilePath);

                    if (File.Exists(inputFilePath))
                    {
                        // Reads all the lines of the file and converts to string collection
                        IEnumerable<string>? listOfRecords = File.ReadAllLines(inputFilePath)?.ToList();

                        if (listOfRecords?.Any() ?? false)
                        {
                            // Taking into consideration that we have header in the file, we don't want that row to be considered for selection
                            // Removing Header Row and adding it to headerRow
                            headerRecord = listOfRecords.First();
                            IEnumerable<string> listOfRecordsToConvert = listOfRecords.Skip(1);

                            // Since direction is optional argument, if it is not provided, we will just go forward with all records
                            if (char.TryParse(args[2], out direction))
                            {
                                var directionText = (direction == 'x') ? "First" : "Last";
                                if (int.TryParse(args[3], out noOfLines))
                                {
                                    if (noOfLines <= listOfRecordsToConvert.Count())
                                    {
                                        Console.WriteLine($"Fetching {directionText} {noOfLines} records in the file!!");
                                        listOfRecordsToConvert = directionText == "First"
                                                                                        ? listOfRecordsToConvert.Take(noOfLines)
                                                                                        : listOfRecordsToConvert.TakeLast(noOfLines);
                                    }
                                    else
                                    {
                                        throw new Exception($"There are only {listOfRecordsToConvert.Count()} records in the file and you are looking for {noOfLines} records!!");
                                    }

                                }
                            }

                            // The converted header row is added back to the convertedRecords list
                            var convertedRecords = new List<string>() { ReturnTabbedRecord(headerRecord) };
                            convertedRecords.AddRange(ConvertToTSV(listOfRecordsToConvert));

                            Console.WriteLine("Writing tsv file to " + outputFilePath);
                            File.WriteAllLines(outputFilePath, convertedRecords);

                            Console.WriteLine("Successfully Converted!");
                        }
                        else
                        {
                            Console.WriteLine("File is either empty or not valid");
                        }
                    }
                    else
                    {
                        Console.WriteLine("File doesnot exists!!");
                    }
                }
                else
                {
                    Console.WriteLine("No Arguments available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Conversion failed : " + ex.Message);
            }
        }

        /// <summary>
        /// Conversion to the TSV
        /// </summary>
        /// <param name="listOfRecordsToConvert"></param>
        /// <returns></returns>
        private static IEnumerable<string> ConvertToTSV(IEnumerable<string> listOfRecordsToConvert)
        {
            var listOfRecords = new List<string>();

            foreach (string record in listOfRecordsToConvert)
            {
                listOfRecords.Add((string)ReturnTabbedRecord(record));
            }
            return listOfRecords;
        }

        /// <summary>
        /// Returns a tabbed record string
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static string ReturnTabbedRecord(string record)
        {
            return record.Replace(',', '\t');
        }

    }

}


