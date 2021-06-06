using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows;
using System.Xml.Serialization;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ComboBox1.Items.Add(Serialize.Binary);
            //ComboBox1.Items.Add(Serialize.XML);
            //ComboBox1.SelectedItem = ComboBox1.Items[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateRooms window = new CreateRooms();
            window.ShowDialog();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if(List1.SelectedItem != null)
            {
                List1.Items.Remove(List1.SelectedItem);
                List1.Items.Refresh();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateUnit window2 = new CreateUnit();
            window2.ShowDialog();
        }

        private void Selection_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            List2.Items.Clear();
            if (List1.SelectedItem != null)
            {
                foreach (var hairstyle in ((AnimalRooms)List1.SelectedItem).AccUnits)
                {
                    List2.Items.Add(hairstyle);
                }
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            if (List2.SelectedItem != null)
            {
                CreateUnit window = new CreateUnit();
                AccountingUnit unit = (AccountingUnit)List2.SelectedItem;
                
                window.AnimalName.Text = unit.Animal.AnimalName;
                window.Country.Text = unit.Animal.Country;
                window.Name.Text = unit.Animal.Name;
                window.BirthDay.Text = unit.Animal.BirthDay.ToString();
                window.RecieveDate.Text = unit.RecieveDate.ToString();
                window.Price.Text = unit.Price.ToString();
                window.Editing = true;
                window.ShowDialog();
                window.Editing = false;
            }
        }

        private void Button_Edit2(object sender, RoutedEventArgs e)
        {
            if (List1.SelectedItem != null)
            {
                CreateRooms window = new CreateRooms();
                AnimalRooms rooms = (AnimalRooms)List1.SelectedItem;
                
                window.Combo.SelectedItem = rooms.RoomType.room; 
                window.SizeText.Text = rooms.Size.ToString();
                window.PriceText.Text = rooms.ClearPrice.ToString();
                window.Editing = true;
                window.ShowDialog();
                window.Editing = false;
            }
        }
  
        private String FileName = Directory.GetCurrentDirectory() + "\\xmlfile.xml";
       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            List<AnimalRooms> AnimalRooms = new List<AnimalRooms>();
            foreach (var animalRooms in List1.Items)
            {
                AnimalRooms.Add((AnimalRooms)animalRooms);
            }
           

            FileStream fileStreamXml = new FileStream(FileName, FileMode.Create);
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<AnimalRooms>), new Type[] { typeof(Animal), typeof(RoomType), typeof(AccountingUnit) });
            try
            {
                xmlFormatter.Serialize(fileStreamXml, AnimalRooms);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize file...");
                throw;
            }
            finally
            {
                fileStreamXml.Close();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List1.Items.Clear();
            List2.Items.Clear();
            if (!(File.Exists(FileName)))
            {
                File.Create(FileName);
            }
            FileStream fileStream = new FileStream(FileName, FileMode.Open);
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<AnimalRooms>), new Type[] { typeof(Animal), typeof(RoomType), typeof(AccountingUnit) });
            List<AnimalRooms> AnimalRooms = new List<AnimalRooms>();
            try
            {
                AnimalRooms = xmlFormatter.Deserialize(fileStream) as List<AnimalRooms>;
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to open serializable file... ");
                throw;
            }
            finally
            {
                fileStream.Close();
            }
            foreach (var animalrooms in AnimalRooms)
            {
                List1.Items.Add(animalrooms);
            }
        }
    }
}
