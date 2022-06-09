using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ychebka3KYRSKrasnov.db;

namespace Ychebka3KYRSKrasnov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Auth auth = new Auth();
        public static DataBaseHomeEntities house = new DataBaseHomeEntities();
        public static Auth authUser;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_OTZIV_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxTBEmail.Text) || string.IsNullOrEmpty(TxTBName.Text) || string.IsNullOrEmpty(TxTBPhone.Text) || string.IsNullOrEmpty(txtboxotziv.Text) || string.IsNullOrEmpty(TxTBsybject.Text))
            {
                MessageBox.Show("Пожалуйста введите символы во все поля!");
            }
            else
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Credentials = new NetworkCredential("Sasha-kr90@bk.ru", "Tge2MzEYdDfZ8CPmRQ3B");
                    smtpClient.Host = ("smtp.mail.ru");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("Sasha-kr90@bk.ru");
                    mailMessage.To.Add(new MailAddress(TxTBEmail.Text));
                    mailMessage.Subject = "Тема сообщения: " + TxTBsybject.Text;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = "Имя: " + TxTBName.Text + "<br>" + "Телефон: " + TxTBPhone.Text + "<br>" + "Почта:" + TxTBEmail.Text + "<br>" + "Текст сообщения: " + txtboxotziv.Text;
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        private void LB_Registration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            qwer.ScrollToVerticalOffset(1340);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        //private void LB_InformationCompany_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    qwer.ScrollToVerticalOffset(2000);
        //}

        private void LB_InformationCompany_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            qwer.ScrollToVerticalOffset(440);
        }

        private void LB_BuyHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new WindowHouses().Show(); 
            this.Close(); 
        }
    }
}