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

namespace Date_Picker_and_DateTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ageToDrive = 16;
        const int ageToVote = 18;
        const int ageToDrink = 21;
        public MainWindow()
        {
            InitializeComponent();
            DateTime date = new DateTime();
            RunDisplay.Text = date.ToString();
            DateTime now = DateTime.Now;
            string shorttime = now.ToShortTimeString();
            string longtime = now.ToLongTimeString();

            string formatString = $"" +
                $"Short Time: {shorttime}\n" +
                $"Long Time: {longtime}\n" +
                $"Short Day: {now.ToShortDateString}\n" +
                $"Long Date: {now.ToShortDateString} \n" +
                $"Year {now.Year}\n" + 
                $"Date Of the Week: {now.DayOfWeek} \n";
           DateTime nowPlus7Months = now.AddMonths(7);
            TimeSpan differenceInDays = nowPlus7Months - now;


            RunDisplay.Text = (differenceInDays / 365.25).ToString();

        }

        private void btDisplayTime_Click(object sender, RoutedEventArgs e)
        {
            DateTime bday = BirthdayObject();           
            
            RunDisplay.Text = $"Your Birthday is {bday}";
        }

        public DateTime BirthdayObject()
        {
            int day = int.Parse(txtDay.Text);
            int month = int.Parse(txtMonth.Text);
            int year = int.Parse(txtYear.Text);
            return new DateTime(year, month, day);
        }

        private void btDriverLicense_Click(object sender, RoutedEventArgs e)
        {
            DateTime bday = BirthdayObject();
            DateTime now = DateTime.Now;
            TimeSpan ageInDays = now - bday;
            int age = (int)(ageInDays.Days / 365.25);
            RunDisplay.Text  = $"Your age is {age.ToString ()} old\n";
            if (age >= ageToDrive)
            {
                RunDisplay.Text += $"You are old enough to drive.\n";
            }
            if (age >= ageToVote)
            {
                RunDisplay.Text += $"You are old enough to vote.\n";

            }
            if (age >= ageToDrink)
            {
                RunDisplay.Text += $"You are old enough to drink.\n";
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            DateTime selecteddate = dpDate.SelectedDate.Value;
            RunDisplay.Text = selecteddate.ToString();
        }
    }
}
