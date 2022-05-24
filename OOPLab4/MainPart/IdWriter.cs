using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainPart
{
    internal class IdWriter: IIdWriter
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public void Write()
            => MessageBox.Show($"{Id}");
    }
}
