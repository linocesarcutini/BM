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

        private void DgParafusos_previewKeyDown(object sender, KeyEventArgs e) {
            DataGrid grid = (DataGrid)sender;

            if (e.Key == Key.Enter || e.Key == Key.Return) {
                // get the selected row
                DataGridRow selectedRow = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;

                int columnIndex = grid.SelectedCells[0].Column.DisplayIndex;
                int rowIndex = grid.Items.IndexOf(grid.SelectedCells[0].Item) - 1;

                // selectedRow can be null due to virtualization
                if (selectedRow != null) {

                    // there should always be a selected cell
                    if (grid.SelectedCells.Count != 0) {
                        // get the cell info
                        DataGridCellInfo currentCell = grid.SelectedCells[0];

                        // get the display index of the cell's column + 1 (for next column)
                        int columnDisplayIndex = currentCell.Column.DisplayIndex++;

                        // if display index is valid
                        if (columnDisplayIndex < grid.Columns.Count) {
                            // get the DataGridColumn instance from the display index
                            DataGridColumn nextColumn = grid.ColumnFromDisplayIndex(columnDisplayIndex);

                            // now telling the grid, that we handled the key down event
                            e.Handled = true;

                            // setting the current cell (selected, focused)
                            grid.CurrentCell = new DataGridCellInfo(grid.SelectedItem, nextColumn);

                            // tell the grid to initialize edit mode for the current cell
                            grid.BeginEdit();
                        }
                    }
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
}
