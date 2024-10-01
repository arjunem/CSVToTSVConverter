
namespace CSVToTSVConverter
{
    public class Program
    {
        static void Main(string[] args)
        {

            string inputFilePath = "";
            string outputFilePath = "";
            char direction = 'x';
            int noOfLines = -1;

            if (args.Any())
            {
                inputFilePath = args[0];
                outputFilePath = args[1];

                try
                {
                    // Since direction and nooflines are optional arguments, if it is not provided, we will just go forward with all records
                    if (args.Count() > 2)
                        char.TryParse(args[2], out direction);
                    if (args.Count() > 3)
                        int.TryParse(args[3], out noOfLines);

                    Converter.ConvertToTSVFile(inputFilePath, outputFilePath, direction, noOfLines);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Conversion failed : " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No Arguments available");
            }
        }
    }
}


