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
    /// Interaction logic for CreateRooms.xaml
    /// </summary>
    public partial class CreateRooms : Window
    {
        public CreateRooms()
        {
            InitializeComponent();
            Combo.Items.Add(RoomType.Room.Aquarium);
            Combo.Items.Add(RoomType.Room.Aviary);
            Combo.Items.Add(RoomType.Room.Cage);
            Combo.Items.Add(RoomType.Room.Terrarium);
        }
        public bool Editing = false;
        ListBox listbox1 = (ListBox)Application.Current.Windows[0].FindName("List1");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Editing)
                {
                    if (listbox1.SelectedItem != null)
                    {
                        AnimalRooms AnimalRooms = listbox1.SelectedItem as AnimalRooms;
                        AnimalRooms.RoomType.room = (RoomType.Room)Combo.SelectedItem;

                        AnimalRooms.Size = Convert.ToInt32(SizeText.Text);
                        AnimalRooms.ClearPrice = Convert.ToInt32(PriceText.Text);
                        listbox1.Items[listbox1.SelectedIndex] = AnimalRooms;
                        listbox1.Items.Refresh();
                        this.Close();
                    }
                }

                else
                {

                    RoomType RoomType = new RoomType((RoomType.Room)Combo.SelectedItem);
                    int Number = 0;
                    if (listbox1.Items.Count > 0)
                    {
                        Number = ((AnimalRooms)listbox1.Items[listbox1.Items.Count - 1]).Number + 1;
                    }
                    int Size = Convert.ToInt32(SizeText.Text);
                    int ServicePrice = Convert.ToInt32(PriceText.Text);

                    AnimalRooms AnimalRooms = new AnimalRooms(RoomType, Number, Size, ServicePrice);
                    listbox1.Items.Add(AnimalRooms);
                    listbox1.Items.Refresh();

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
