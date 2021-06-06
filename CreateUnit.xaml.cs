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

namespace Zoo
{
    /// <summary>
    /// Interaction logic for CreateUnit.xaml
    /// </summary>
    public partial class CreateUnit : Window
    {
        public CreateUnit()
        {
            InitializeComponent();
        }
        public bool Editing = false;
        ListBox listbox1 = (ListBox)Application.Current.Windows[0].FindName("List1");
        ListBox listbox2 = (ListBox)Application.Current.Windows[0].FindName("List2");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Editing)
                {
                    if (listbox1.SelectedItem != null&& listbox2.SelectedItem != null)
                    {
                        Animal Animal = new Animal(AnimalName.Text, Country.Text, Name.Text, Convert.ToDateTime(BirthDay.Text));
                        AccountingUnit accountingUnit = new AccountingUnit(Animal, Convert.ToDateTime(RecieveDate.Text), Convert.ToDecimal(Price.Text));
                        listbox2.Items[listbox2.SelectedIndex] = accountingUnit;
                        ((AnimalRooms)listbox1.SelectedItem).EditAccountingUnit(listbox2.SelectedIndex, accountingUnit);
                        listbox1.Items.Refresh();
                        listbox2.Items.Refresh();
                        this.Close();
                    }
                }
                else
                {
                    if (listbox1.SelectedItem != null)
                    {
                        Animal Animal = new Animal(AnimalName.Text, Country.Text, Name.Text, Convert.ToDateTime(BirthDay.Text));
                        AccountingUnit accountingUnit = new AccountingUnit(Animal, Convert.ToDateTime(RecieveDate.Text), Convert.ToDecimal(Price.Text));
                        listbox2.Items.Add(accountingUnit);
                        ((AnimalRooms)listbox1.SelectedItem).AddAccountingUnit(accountingUnit);
                        listbox1.Items.Refresh();
                        listbox2.Items.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
