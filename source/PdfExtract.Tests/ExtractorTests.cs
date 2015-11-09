using System.Diagnostics;
using NUnit.Framework;

namespace PdfExtract.Tests
{
    [TestFixture]
    public class ExtractorTests
    {
        [Test]
        public void Can_extract_text()
        {
            ////Arrange
            var pdfStream = GetType().Assembly.GetManifestResourceStream(typeof (ExtractorTests), "sample.pdf");
            string result;

            ////Act
            using (var extractor = new Extractor())
                result = extractor.ExtractToString(pdfStream);

            ////Assert
            Assert.That(result.Trim(), Is.EqualTo("hello world"));
        }

        [Test]
        public void Can_extract_text_with_cli()
        {
            ////Arrange
            var pdfStream = GetType().Assembly.GetManifestResourceStream(typeof(ExtractorTests), "table-example.pdf");
            string result;

            ////Act
            using (var extractor = new Extractor("-table"))
                result = extractor.ExtractToString(pdfStream);

            ////Assert
            Assert.That(result.Trim(), Is.EqualTo("Pdf with table\r\n\r\n00              01  02\r\n\r\n10              11  12"));
        }
    }
}