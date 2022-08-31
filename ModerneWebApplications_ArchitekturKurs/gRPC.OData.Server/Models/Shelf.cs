namespace Bookstores //selbes Namesspace wie -> obj\Debug\net6.0\Protos\Bookstore.cs
{
    //'partial class' ist nötig um eine 1:N Relation abzubilden
    public sealed partial class Shelf
    {
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}