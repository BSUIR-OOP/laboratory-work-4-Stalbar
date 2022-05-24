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
            try
            {
                InitializeComponent();

                var container2 = new DependencyContainer();
                var error2 = new CycleError();
                string err = error2.CheckForCycles(typeof(IdWriter));
                if (err != null)
                {
                    throw new CycleException(err);
                }
                container2.AddSingleton<IdWriter, IIdWriter>();

                var resolver2 = new DependencyResolver(container2);

                var service3 = resolver2.GetService<IIdWriter>();
                service3.Write();
                var service4 = resolver2.GetService<IIdWriter>();
                service4.Write();

                var container1 = new DependencyContainer();
                var error = new CycleError();
                err = error.CheckForCycles(typeof(IdWriter));
                if (err != null)
                {
                    throw new CycleException(err);
                }
                container1.AddTransient<IdWriter, IIdWriter>();

                var resolver1 = new DependencyResolver(container1);

                var service1 = resolver1.GetService<IIdWriter>();
                service1.Write();
                var service2 = resolver1.GetService<IIdWriter>();
                service2.Write();
            }
            catch (CycleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
