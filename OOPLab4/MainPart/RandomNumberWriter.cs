using System;
using System.Windows;

namespace MainPart
{
    public class RandomNumberWriter : IRandomNumberWriter
    {
        public int Number { get; set; }

        public void Write()
        {
            Random rnd = new Random();
            Number = rnd.Next();
            MessageBox.Show(Number.ToString());
        }
    }
}
