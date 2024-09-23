using System.Reflection;

namespace CSVToTSVConverter.Test
{
    public class ConverterTest
    {
        /// <summary>
        /// Checks whether the first 2 lines are matching in X direction
        /// </summary>
        [Fact]
        public void ConvertToTSVFile_ShouldMatchFirstTwoLinesInXDirection()
        {
            // Arrange
            string inputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Input\\currency.csv";
            string outputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Output\\currency.tsv";

            // Act
            Converter.ConvertToTSVFile(inputFilePath, outputFilePath, 'x', 2);

            // Assert
            var tsvOutput = File.ReadAllLines(outputFilePath);
            // Since we have header too we have 3 rows
            Assert.Equal(3, tsvOutput.Length);
            Assert.Equal("AED\tد.إ\tUnited Arab Emirates d", tsvOutput[1]);
            Assert.Equal("AFN\t؋\tAfghan afghani", tsvOutput[2]);
        }

        /// <summary>
        /// Checks whether the first 2 lines are matching in Y direction
        /// </summary>
        [Fact]
        public void ConvertToTSVFile_ShouldMatchFirstTwoLinesInYDirection()
        {
            // Arrange
            string inputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Input\\currency.csv";
            string outputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Output\\currency.tsv";

            // Act
            Converter.ConvertToTSVFile(inputFilePath, outputFilePath, 'y', 2);

            // Assert
            var tsvOutput = File.ReadAllLines(outputFilePath);
            // Since we have header too we have 3 rows
            Assert.Equal(3, tsvOutput.Length);
            Assert.Equal("ZAR\tR\tSouth African rand", tsvOutput[1]);
            Assert.Equal("ZMW\tZK\tZambian kwacha", tsvOutput[2]);
        }

        /// <summary>
        /// Convert all rows if no line number provided
        /// </summary>
        [Fact]
        public void ConvertToTSVFile_ShouldConvertAllRowsForNoLineNumber()
        {
            // Arrange
            string inputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Input\\currency.csv";
            string outputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Output\\currency.tsv";

            // Act
            Converter.ConvertToTSVFile(inputFilePath, outputFilePath, 'x');

            // Assert
            var tsvOutput = File.ReadAllLines(outputFilePath);
            // Since we have test file has 164 rows
            Assert.Equal(164, tsvOutput.Length);
        }

        /// <summary>
        /// Convert all rows if no line number and direction is  provided 
        /// </summary>
        [Fact]
        public void ConvertToTSVFile_ShouldConvertAllRowsForNoDirectionAndLineNumber()
        {
            // Arrange
            string inputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Input\\currency.csv";
            string outputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Output\\currency.tsv";

            // Act
            Converter.ConvertToTSVFile(inputFilePath, outputFilePath);

            // Assert
            var tsvOutput = File.ReadAllLines(outputFilePath);
            // Since we have test file has 164 rows
            Assert.Equal(164, tsvOutput.Length);
        }

        /// <summary>
        /// Throw file not found if file not found in location
        /// </summary>
        [Fact]
        public void ConvertToTSVFile_ShouldThrowFileNotFoundException()
        {
            // Arrange
            string inputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Input\\currency_error.csv";
            string outputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Output\\currency.tsv";

            // Act + Assert
            var exception = Assert.Throws<FileNotFoundException> (() => Converter.ConvertToTSVFile(inputFilePath, outputFilePath));

            //Compare
            Assert.Equal("File doesnot exists!!", exception.Message);
        }
    }
}