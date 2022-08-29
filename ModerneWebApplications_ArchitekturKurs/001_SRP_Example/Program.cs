namespace _001_SRP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Schlechter SourceCode
    //Mit der Zeit wird diese Klasse sehr groß
    //Muss unterschiedliche Aufgaben bewältigen und wird mit der Zeit unübsichtlich 
    //Klasse wird mit der Zeit immer teurer. 

    public class AllInOneEmployeeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }    


        public void SaveEmployeeToDb(AllInOneEmployeeClass multipleEmployeeClass)
        {
            //Speicher Datensatz zu DB
        }

        public void GenerateReport()
        {
            //Erstelle ein Report 
        }
    }
    #endregion

    #region Besserer Code

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //DataAccess Layer (DAL) -> wird verwendet um Objekte in/aus einer DB zu speichern oder zu lesen 
    public class EmployeeRepository //Mehr Infos (siehe Repository-Design Pattern) 
    {
        public void Save(Employee em)
            => Console.WriteLine("Wird in DB gespeichert");
    }

    public class EmployeeReport //Ausgabe eines Reports -> (Entweder UI (als Export-Format) ODER Service-Layer als JSON) 
    {
        //Intern werden Anbieter wir CrystalReports oder List10 verwendet oder PDF
        public void GenerateReport()
            => Console.WriteLine("Report wird erstellt");
    }
    #endregion
}