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

namespace WpfApp10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string groupNumber = TextBoxGroup.Text;
            if (groupNumber.Length == 0)
            {
                MessageBox.Show("Необходимо ввести номер группы");
                return;
            }
            //sozdat podklyuchenie k BD
            db.base10Entities connection = new db.base10Entities();
           db.Группа isExists = connection.Группа.Where(g => g.НомерГруппы == groupNumber).FirstOrDefault();
            if(isExists !=null)
            {
                MessageBox.Show("Группа с таким номером уже существует");
                return;
            }
            db.Группа group = new db.Группа();
            group.НомерГруппы = groupNumber;
            connection.Группа.Add(group);

            connection.SaveChanges();
            int result = connection.SaveChanges();
            if (result == 1)
            {
                TextBoxGroup.Text = "";
                MessageBox.Show("Группа успешно создана");
            }
        }

        

    }
}
