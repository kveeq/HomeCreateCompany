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

namespace Ychebka3KYRSKrasnov
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //Auth auth = new Auth();
        //public static Auth authUser;
        public LoginWindow()
        {
            InitializeComponent();
            //Auth auth = new Auth();
        }

        

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
        }

        private void btnVXOD_Click(object sender, RoutedEventArgs e)
        {
            if (txtblogin.Text == "" || Passbox.Password == "")
            {
                MessageBox.Show("Введите свои данные");
            }
            else foreach (var user in MainWindow.house.Auth)
                {
                    if (user.Login == txtblogin.Text.Trim())
                    {
                        if (user.Password == Passbox.Password.Trim() && user.ID_Role == 2)
                        {
                            MessageBox.Show($"Привет Пользователь {user.Login}");
                            MainWindow.authUser = user;
                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Close();
                        }
                        if (user.Password == Passbox.Password.Trim() && user.ID_Role == 1)
                        {
                            MessageBox.Show($"Привет админ {user.Login}");
                            MainWindow.authUser = user;
                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Close();

                        }
                    }
                }
            if(MainWindow.authUser == null)
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
            
        }

        //public void ProverkaProbel()
        //{
        //    if(txtblogin.Text == "" || Passbox.Text == "")
        //    {
        //        MessageBox.Show("Заполните все поля!");
        //    }
        //}
    }
}
