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

namespace BM {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            List<Bolt> bolts = new List<Bolt>();
            //bolts.Add(new Bolt() { Diametro = "12.7", Qualidade = "T0L", QTPorca = 1, QualPorca = "GRAL",
            //EspArruela = "3", QTArruela = "1", QualArruela = "ARPS", Palnut = "PNT" });

            dgParafusos.ItemsSource = bolts;
        }

        private void Abrir_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Aqui abre uma estrutura");
        }

        private void NovaEstrutura_Click(object sender, RoutedEventArgs e) {
            Grid_NewEstructure.Visibility = Visibility.Hidden;
        }

        private void Varias_Checked(object sender, RoutedEventArgs e) {
            if ((bool)cbVariasSiglas.IsChecked) {
                tbUnicaSigla.IsEnabled = false;
            } else {
                tbUnicaSigla.IsEnabled = true;
            }
        }
    }

    public class Bolt {
        public string Diametro { get; set; }
        public string Qualidade { get; set; }
        public int QTPorca { get; set; }
        public string QualPorca { get; set; }
        public string EspArruela { get; set; }
        public string QTArruela { get; set; }
        public string QualArruela { get; set; }
        public string EspArruelaP { get; set; }
        public string QTArruelaP { get; set; }
        public string QualArruelaP { get; set; }
        public string Palnut { get; set; }
    }
}
