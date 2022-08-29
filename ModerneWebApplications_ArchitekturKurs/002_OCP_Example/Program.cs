namespace _002_OCP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Schlimmer Source Code

    public class BadReportGenerator
    {
        public string ReportType { get; set; }

        public BadReportGenerator()
        {
        }

        public void GenerateReport()
        {
            if (ReportType == "PDF")
            {
                //PDF wird ausgegeben
                //PDF kann CompessRate, Watermark... alles PDF spezifische
            }
            else if (ReportType == "CR")
            {
                //CR wird ausgegeben
                //Standardtext - Vorlagen 
            }
            else if (ReportType == "List10")
            {
                //List10 wird ausgegeben
            }
            else
            {

            }
        }
    }
    #endregion

    #region Besser Variante
    public abstract class ReportGeneratorBase
    {
        public abstract void GenerateReport();
    }

    public class PDFGenerator : ReportGeneratorBase
    {
        public override void GenerateReport()
        {
            //Erstelle ein PDF
        }
    }

    public class CRGenerator : ReportGeneratorBase
    {
        public override void GenerateReport()
        {
            //Erstelle ein CR
        }
    }
    #endregion
}