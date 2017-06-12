namespace Calculator
{
    internal class Operation
    {
        public string Op { get; set; }
        public double DigSource { get; set; }
        public double DigResult { get; set; }
        public string AsString => Op != "√" ? $"{DigResult}{Op}{DigSource}" : $"{Op}{DigSource}";
    }
}