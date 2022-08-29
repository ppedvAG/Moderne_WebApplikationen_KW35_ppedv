namespace _003_LP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }


    #region Bad-Code
    public class BadErdbeere
    {
        public string Colour()
        {
            return "Rot";
        }
    }

    public class BadKirsche : BadErdbeere
    {
        public string Colour()
        {
            return base.Colour();
        }
    }
    #endregion

    #region Besser
    public abstract class Fruits
    {
        public abstract string Colour();
    }

    public class Kirsche : Fruits
    {
        public override string Colour()
        {
            return "Rot";
        }
    }

    #endregion


}