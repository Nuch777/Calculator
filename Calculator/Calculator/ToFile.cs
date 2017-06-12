using System.IO;

namespace Calculator
{
    internal static class ToFile
    {
        public static void Save(this Operation op)
        {
            using (var wr = File.AppendText("Results.txt"))
            {
                wr.WriteLine(op.AsString);
            }
        }
    }
}