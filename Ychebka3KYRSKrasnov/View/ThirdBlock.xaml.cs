using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Ychebka3KYRSKrasnov.db;

namespace Ychebka3KYRSKrasnov
{
    /// <summary>
    /// Логика взаимодействия для ThirdBlock.xaml
    /// </summary>
    public partial class ThirdBlock : Window, IDisposable
    {
        Home Home { get; set; }
        public ThirdBlock(Home home)
        {
            InitializeComponent();
            Home = home;
            DataContext = null;
            DataContext = Home;
            VivodIZBd();
        }

        private void Normilize()
        {
            cmb1.Visibility = cmb1.HasItems ? Visibility.Visible : Visibility.Collapsed;
            cmb2.Visibility = cmb2.HasItems ? Visibility.Visible : Visibility.Collapsed;
            cmb3.Visibility = cmb3.HasItems ? Visibility.Visible : Visibility.Collapsed;
            cmb4.Visibility = cmb4.HasItems ? Visibility.Visible : Visibility.Collapsed;
            cmb5.Visibility = cmb5.HasItems ? Visibility.Visible : Visibility.Collapsed;
            cmb6.Visibility = cmb6.HasItems ? Visibility.Visible : Visibility.Collapsed;
        }

        public void VivodIZBd()
        {
            cmb1.ItemsSource = MainWindow.house.Home_Roof.Where(x => x.ID_Home == Home.ID_Home).ToList();
            cmb2.ItemsSource = MainWindow.house.Home_Cokol.Where(g => g.ID_Home == Home.ID_Home).ToList();
            cmb3.ItemsSource = MainWindow.house.Home_Fasad.Where(c => c.ID_Home == Home.ID_Home).ToList();
            cmb4.ItemsSource = MainWindow.house.Home_Pavers.Where(j => j.ID_Home == Home.ID_Home).ToList();
            cmb5.ItemsSource = MainWindow.house.Home_Window.Where(k => k.ID_Home == Home.ID_Home).ToList();
            cmb6.ItemsSource = MainWindow.house.Home_Drain.Where(l => l.ID_Home == Home.ID_Home).ToList();
            //Normilize();
        }

        Home_Roof tt1 = new Home_Roof() { Home = new Home(), Roof_of_the_house = new Roof_of_the_house() { Price_Roof = 0} };
        Home_Fasad tt2 = new Home_Fasad() { Home = new Home(), House_Facade = new House_Facade() { Price_Facade = 0 } };
        Home_Cokol tt3 = new Home_Cokol() { Home = new Home(), House_Basement_Cokol_ = new House_Basement_Cokol_() { Price_Basement = 0 } };
        Home_Pavers tt4 = new Home_Pavers() { Home = new Home(), Pavers_House = new Pavers_House() { Price_Pavers = 0 } };
        Home_Window tt5 = new Home_Window() { Home = new Home(), House_Windows = new House_Windows() { Price_Roof = 0 } };
        Home_Drain tt6 = new Home_Drain() { Home = new Home(), Drain_For_Home = new Drain_For_Home() { Price_Drain = 0 } };
        private void cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tt1 = cmb1.SelectedItem as Home_Roof;
            img1.Source = new Bitmap(new MemoryStream(tt1.Roof_of_the_house.Image_Roof)).BitmapToImageSource();
        }

        private void cmb3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tt2 = cmb3.SelectedItem as Home_Fasad;
            img3.Source = new Bitmap(new MemoryStream(tt2.House_Facade.Image_Facade)).BitmapToImageSource();
        }

        private void cmb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tt3 = cmb2.SelectedItem as Home_Cokol;
            img2.Source = new Bitmap(new MemoryStream(tt3.House_Basement_Cokol_.Image_Basement)).BitmapToImageSource();
        }

        private void cmb4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tt4 = cmb4.SelectedItem as Home_Pavers;
            img4.Source = new Bitmap(new MemoryStream(tt4.Pavers_House.Image_Pavers)).BitmapToImageSource();
        }

        private void cmb5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tt5 = cmb5.SelectedItem as Home_Window;
            img5.Source = new Bitmap(new MemoryStream(tt5.House_Windows.Image_Window)).BitmapToImageSource();
        }

        private void cmb6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tt6 = cmb6.SelectedItem as Home_Drain;
            img6.Source = new Bitmap(new MemoryStream(tt6.Drain_For_Home.Image_Drain)).BitmapToImageSource();
        }

        private void btnOfotmitHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Итоговая цена вашего дома {Home.Price + (Convert.ToDecimal(tt1.Roof_of_the_house.Price_Roof)) +  (Convert.ToDecimal(tt2.House_Facade.Price_Facade)) + (Convert.ToDecimal(tt3.House_Basement_Cokol_.Price_Basement)) + (Convert.ToDecimal(tt4.Pavers_House.Price_Pavers)) + (Convert.ToDecimal(tt5.House_Windows.Price_Roof)) + (Convert.ToDecimal(tt6.Drain_For_Home.Price_Drain))}") ;
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}