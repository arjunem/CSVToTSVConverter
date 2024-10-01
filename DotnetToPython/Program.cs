using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Path to the Python interpreter (use "python3" for Linux/macOS or "python" for Windows)
        string pythonExe = "python3.12";  // On Windows, use "python" instead

        // Path to your Python script
        string scriptPath = "/home/amukundan/Documents/CSVToTSVConverter/pythontodotnet.py"; // Replace with actual path to your Python script

        Console.WriteLine(args.ToList());

        var inputPath = args[1];
        var outputPath = args[2];
        var direction = args[3];
        var noOfLines = args[4];

        // Arguments to pass to the Python script (e.g., a name in this case)
        string pythonArgs = $"\"{scriptPath}\" \"{inputPath}\" \"{outputPath}\" \"{direction}\" \"{noOfLines}\"";

        // Set up the process start information
        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = pythonExe,
            Arguments = $"{scriptPath} {pythonArgs}",
            UseShellExecute = false,        // Required for capturing output
            RedirectStandardOutput = true,  // Capture output
            RedirectStandardError = true    // Capture errors
        };

        try
        {
            // Start the process
            using (Process process = Process.Start(start))
            {
                // Read the standard output and error
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Display the output
                Console.WriteLine("Output from Python script:");
                Console.WriteLine(output);

                // If there is any error, print it
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error from Python script:");
                    Console.WriteLine(error);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
