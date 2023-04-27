namespace Roulette.Aids
{
    public class JsonRequestWrapper
    {
        public string? Qualifier { get; set; }
        public DataClass? Data { get; set; }
        public class DataClass
        {
            public int WinningNumber { get; set; }
        }
    }
}
