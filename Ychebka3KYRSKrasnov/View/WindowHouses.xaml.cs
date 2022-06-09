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
using Ychebka3KYRSKrasnov.db;

namespace Ychebka3KYRSKrasnov
{
    /// <summary>
    /// Логика взаимодействия для WindowHouses.xaml
    /// </summary>
    public partial class WindowHouses : Window
    {
        public WindowHouses()
        {
            InitializeComponent();
            if (MainWindow.authUser.ID_Role == 2)
            {
                Btn_Add_Home.Visibility = Visibility.Collapsed;
            }
            List<Home> homes = MainWindow.house.Home.ToList();
            //List<Home> homesForFirstLstView = new List<Home>();
            //List<Home> homesForSecondLstView = new List<Home>();
            //int count = (homes.Count) / 2;
            //for (int i = 0; i < count; i++)
            //{
            //    homesForFirstLstView.Add(homes[i]);
            //}
            //for (int i = count; i < homes.Count; i++)
            //{
            //    homesForSecondLstView.Add(homes[i]);
            //}

            HousesLstView1.ItemsSource = homes;
            //HousesLstView2.ItemsSource = homesForSecondLstView;
        }

        private void Btn_Add_Home_Click(object sender, RoutedEventArgs e)
        {
            AddHomeWindow addHomeWindow = new AddHomeWindow();
            addHomeWindow.Show();
        }

        //private void Image_1Home_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    ThirdBlock thirdBlock = new ThirdBlock(MainWindow.house.Home.Where(x=>x.ID_Home == 1).FirstOrDefault());
        //    thirdBlock.Show();
        //}

        //private void Image_2Home_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    ThirdBlock thirdBlock = new ThirdBlock(MainWindow.house.Home.Where(x => x.ID_Home == 8).FirstOrDefault());
        //    thirdBlock.Show();
        //}

        //private void Image_3Home_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    ThirdBlock thirdBlock = new ThirdBlock(MainWindow.house.Home.Where(x => x.ID_Home == 10).FirstOrDefault());
        //    thirdBlock.Show();
        //}

        private void HousesLstView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var home = (Home)((sender as ListView).SelectedItem);       
            ThirdBlock thirdBlock = new ThirdBlock(home);
            thirdBlock.Show();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}