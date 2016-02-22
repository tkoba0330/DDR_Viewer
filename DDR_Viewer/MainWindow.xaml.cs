using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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
using System.Xml;
using System.Xml.Linq;

namespace DDR_Viewer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<models.table> Tables;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var elFMPReport = XElement.Load(@"DDR\MPRO_M01_fmp12.xml").Elements();
            var BaseTableCatalog = elFMPReport.Elements("BaseTableCatalog");

            Tables = new List<models.table>();
            foreach (var table in BaseTableCatalog.Elements("BaseTable"))
            {
                var new_table = new models.table();
                Tables.Add(new_table);
                new_table.Name = table.Attribute("name").Value;

                foreach (var field in table.Element("FieldCatalog").Elements("Field"))
                {
                    var new_firld = new models.field();
                    new_table.Fields.Add(new_firld);

                    new_firld.Name = field.Attribute("name").Value;
                    new_firld.DataType = field.Attribute("dataType").Value;
                    new_firld.FieldType = field.Attribute("fieldType").Value;
                }
            }


            gridTables.ItemsSource = Tables;
        }

        private void gridTables_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            var table = e.NewItem as models.table;
            gridFields.ItemsSource = table.Fields;
        }
    }
}
