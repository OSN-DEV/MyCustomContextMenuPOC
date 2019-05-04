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

namespace MyCustomContextmenuPoc {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        private CustomContextMenu _contextMenu = new CustomContextMenu();
        public MainWindow() {
            InitializeComponent();

            var itemAdd = new CustomContextMenu.Item();
            itemAdd.Id = 1;
            itemAdd.Text = "Add";
            itemAdd.Click += this.Add_Click;
            this._contextMenu.AddItem(itemAdd);

            var itemEdit = new CustomContextMenu.Item();
            itemEdit.Id = 2;
            itemEdit.Text = "Edit";
            itemEdit.Click += this.Edit_Click;
            this._contextMenu.AddItem(itemEdit);

            this._contextMenu.AddSeparator();


            var itemDelete = new CustomContextMenu.Item();
            itemDelete.Id = 3;
            itemDelete.Text = "Delete";
            itemDelete.Click += this.Delete_Click;
            itemDelete.ForeGround = "#FF0000";
            itemDelete.MouseOverColor = "#FF9999";
            itemDelete.PressedColor = "#FF0000";
            this._contextMenu.AddItem(itemDelete);
        }


        private bool _enabled = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            _contextMenu.Close();
        }
        private void ListBox_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            _enabled = !_enabled;
            _contextMenu.SetEnabled(3, _enabled);
            _contextMenu.ShowMenu(this, e);
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Add Click");
        }
        private void Edit_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Edit Click");
        }
        private void Delete_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Delete Click");
        }
    }
}
