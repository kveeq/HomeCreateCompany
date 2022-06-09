using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Ychebka3KYRSKrasnov.db;

namespace Ychebka3KYRSKrasnov
{
    /// <summary>
    /// Логика взаимодействия для AddHomeWindow.xaml
    /// </summary>
    public partial class AddHomeWindow : Window
    {
        string SELECTiTEM = "";
        List<Home> homes = null;
        public AddHomeWindow()
        {
            InitializeComponent();
            homes = MainWindow.house.Home.ToList();
            CmbVibor.ItemsSource = homes.Select(x => x.Name).Distinct();
            LstViewChastiDoma.ItemsSource = new List<string>() 
            {
                "Фасад дома",
                "Брусчатка дома",
                "Крыша дома",
                "Двери дома",
                "Балки дома",
                "Водостоки дома",
                "Цоколь дома",
                "Ступени дома",
                "Окна дома",
                "Терраса дома",
                "Готовые решения",
                "Перила дома",
                "Штукатурка дома"
            };
        }

        private void LstViewChastiDoma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SELECTiTEM = ((sender as ListView).SelectedItem).ToString();
            if(SELECTiTEM == "Готовые решения" ||  SELECTiTEM == "Терраса дома")
                TxtBMaterial.Visibility = Visibility.Visible;
            else 
                TxtBMaterial.Visibility = Visibility.Collapsed;
        }

        private void BtnAddToDB_Click(object sender, RoutedEventArgs e)
        {
            //proverkacifri();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Image_Vibor.Source = new Bitmap(openFileDialog.FileName).BitmapToImageSource();
            }
            else 
            {
                MessageBox.Show("Выберите фото");
                return;
            }
            var home = homes.Find(x => x.Name == CmbVibor.SelectedItem.ToString());
            
            switch(SELECTiTEM)
            {
                case "Фасад дома":
                    House_Facade house_Facade = new House_Facade()
                    {
                        Image_Facade = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Facade = decimal.Parse(TxtBpice.Text),
                        Facade_Color =  TxtbCoolorobject.Text
                    };
                    MainWindow.house.House_Facade.Add(house_Facade);
                    Home_Fasad home_Fasad = new Home_Fasad() { Home = home, House_Facade = house_Facade };
                    MainWindow.house.Home_Fasad.Add(home_Fasad);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Брусчатка дома":
                    Pavers_House pavers_House = new Pavers_House()
                    {
                        Image_Pavers = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Pavers = Convert.ToDecimal(TxtBpice.Text),
                        Pavers_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Pavers_House.Add(pavers_House);
                    Home_Pavers pavers = new Home_Pavers() { Home = home, Pavers_House = pavers_House };
                    MainWindow.house.Home_Pavers.Add(pavers);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Крыша дома":
                    Roof_of_the_house roof_Of_The_House = new Roof_of_the_house()
                    {
                        Image_Roof = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Roof = Convert.ToDecimal(TxtBpice.Text),
                        Roof_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Roof_of_the_house.Add(roof_Of_The_House);
                    Home_Roof roofs = new Home_Roof() { Home = home, Roof_of_the_house = roof_Of_The_House };
                    MainWindow.house.Home_Roof.Add(roofs);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Двери дома":
                    Door_For_House door = new Door_For_House()
                    {
                        Image_Dooor = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Door = Convert.ToInt32(TxtBpice.Text),
                        Door_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Door_For_House.Add(door);
                    Home_Door dors = new Home_Door() { Home = home, Door_For_House = door };
                    MainWindow.house.Home_Door.Add(dors);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Балки дома":
                    Balki_House balki = new Balki_House()
                    {
                        Image_Balka = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Balka = Convert.ToDecimal(TxtBpice.Text),
                        Color_Balka = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Balki_House.Add(balki);
                    Home_Balki balki1 = new Home_Balki() { Home = home, Balki_House = balki };
                    MainWindow.house.Home_Balki.Add(balki1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Водостоки дома":
                    Drain_For_Home drain = new Drain_For_Home()
                    {
                        Image_Drain = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Drain = Convert.ToDecimal(TxtBpice.Text),
                        Drain_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Drain_For_Home.Add(drain);
                    Home_Drain drain1 = new Home_Drain() { Home = home, Drain_For_Home = drain };
                    MainWindow.house.Home_Drain.Add(drain1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Цоколь дома":
                    House_Basement_Cokol_ cokol = new House_Basement_Cokol_()
                    {
                        Image_Basement = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Basement = Convert.ToDecimal(TxtBpice.Text),
                        Basement_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.House_Basement_Cokol_.Add(cokol);
                    Home_Cokol cokol1 = new Home_Cokol() { Home = home, House_Basement_Cokol_ = cokol };
                    MainWindow.house.Home_Cokol.Add(cokol1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Ступени дома":
                    House_Steps steps = new House_Steps()
                    {
                        Image_Steps = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Steps = Convert.ToDecimal(TxtBpice.Text),
                        Steps_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.House_Steps.Add(steps);
                    Home_Steps steps1 = new Home_Steps() { Home = home, House_Steps = steps };
                    MainWindow.house.Home_Steps.Add(steps1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Окна дома":
                    House_Windows windows = new House_Windows()
                    {
                        Image_Window = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Roof = Convert.ToDecimal(TxtBpice.Text),
                        Window_Color = TxtbCoolorobject.Text
                    };
                    MainWindow.house.House_Windows.Add(windows);
                    Home_Window window1 = new Home_Window() { Home = home, House_Windows = windows };
                    MainWindow.house.Home_Window.Add(window1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Терраса дома":
                    Terrace_Home terrace = new Terrace_Home()
                    {
                        Image_Terrace = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Terrace = Convert.ToDecimal(TxtBpice.Text),
                        Material_Terrace = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Terrace_Home.Add(terrace);
                    Home_Terrace Terrace1 = new Home_Terrace() { Home = home, Terrace_Home = terrace };
                    MainWindow.house.Home_Terrace.Add(Terrace1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Готовые решения":
                    Turnkey_solution_for_home _Solution_For_Home = new Turnkey_solution_for_home()
                    {
                        Image = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Solution = Convert.ToDecimal(TxtBpice.Text),
                    };
                    MainWindow.house.Turnkey_solution_for_home.Add(_Solution_For_Home);
                    Home_Solution solution1 = new Home_Solution() { Home = home, Turnkey_solution_for_home = _Solution_For_Home };
                    MainWindow.house.Home_Solution.Add(solution1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Перила дома":
                    Railing_For_Home railing_ = new Railing_For_Home()
                    {
                        Image_Railing = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Railing = Convert.ToDecimal(TxtBpice.Text),
                        Color_Railing = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Railing_For_Home.Add(railing_);
                    Home_Railing railing = new Home_Railing() { Home = home, Railing_For_Home = railing_ };
                    MainWindow.house.Home_Railing.Add(railing);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;
                case "Штукатурка дома":
                    Plaster_for_the_house plaster = new Plaster_for_the_house()
                    {
                        Image_Plaster = getJPGFromImageControl(Image_Vibor.Source as BitmapImage),
                        Price_Plaster = Convert.ToDecimal(TxtBpice.Text),
                        Color_Plaster = TxtbCoolorobject.Text
                    };
                    MainWindow.house.Plaster_for_the_house.Add(plaster);
                    Home_Plaster plaster1 = new Home_Plaster() { Home = home, Plaster_for_the_house = plaster };
                    MainWindow.house.Home_Plaster.Add(plaster1);
                    MainWindow.house.SaveChanges();
                    MessageBox.Show("Успешно!");
                    break;

            }
        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void TxtbCoolorobject_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Str = TxtbCoolorobject.Text.Trim();
            int Num;
            bool isNum = int.TryParse(Str, out Num);
            if (isNum)
            {
                MessageBox.Show("Только символы,но не цифры!");
                TxtbCoolorobject.Clear();
            }
            else
            {
                MessageBox.Show("Пиши!");
            }
        }
    }

    static class Extensions
    {
        public static BitmapImage BitmapToImageSource(this Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
    }
}