using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DI_Library;

namespace MainPart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            CollectionOfServices services = new CollectionOfServices();
            services.AddSingelton<IRandomNumberWriter, RandomNumberWriter>();
            DIContainer container = services.GetContainer();

            CollectionOfServices services2 = new CollectionOfServices();
            services2.AddTransient<IRandomNumberWriter, RandomNumberWriter>();
            DIContainer container2 = services2.GetContainer();

            var a = container.GetService<IRandomNumberWriter>();
            var b = container.GetService<IRandomNumberWriter>();

            a.Write();
            b.Write();

            var c = container2.GetService<IRandomNumberWriter>();
            var d = container2.GetService<IRandomNumberWriter>();

            c.Write();
            d.Write();
        }
    }
}
