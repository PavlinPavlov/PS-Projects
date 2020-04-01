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
using System.Windows.Shapes;

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window
    {
        public DateTime LastChecked { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
        }

        public void OpenReport(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport(peopleListBox.SelectedItem);
            expenseReport.Width = this.Width;
            expenseReport.Height = this.Height;
            expenseReport.Show();
        }
    }
    
}
