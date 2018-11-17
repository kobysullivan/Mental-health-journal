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

namespace MentalHealthTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String[] months = new String[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public MainWindow()
        {
            InitializeComponent();
            InitializeColors();
        }

        private void AddNewEntry_Click(object sender, RoutedEventArgs e)
        {
            var newEntryWindow = new NewEntryWindow();
            newEntryWindow.ShowDialog();
            Entry newEntry = Entries.entries[Entries.entries.Count() - 1];
            String name = months[newEntry.GetMonth()-1] + newEntry.GetDay();
            //System.Windows.MessageBox.Show(name);
            Label date = FindLabel(name);
            Emotion emotion = newEntry.GetEmotion();
            if (emotion == Emotion.happy)
            {
                date.Background = new SolidColorBrush(Colors.Yellow);
            }
            else if (emotion == Emotion.angry)
            {
                date.Background = new SolidColorBrush(Colors.Red);
            }
            else if (emotion == Emotion.normal)
            {
                date.Background = new SolidColorBrush(Colors.Beige);
            }
            else if (emotion == Emotion.despair)
            {
                date.Background = new SolidColorBrush(Colors.Blue);
            }
            else if (emotion == Emotion.anxious)
            {
                date.Background = new SolidColorBrush(Colors.Orange);
            }
            else if (emotion == Emotion.excited)
            {
                date.Background = new SolidColorBrush(Colors.Pink);
            }
        }

        public Label FindLabel(String name)
        {

            foreach (Label lbl in Dates.Children)
            {
                if (lbl.Name == name)
                {
                    return lbl;
                }
            }
            return null;
        }

        private void InitializeColors()
        {
            for (int i=1; i<13; i++)
            {
                for (int j=1; j<32; j++)
                {
                    Label date = new Label();
                    date.Background = new SolidColorBrush(Colors.Gray);
                    String month = months[i - 1];
                    date.Name = month + j.ToString();
                    //System.Windows.MessageBox.Show(date.Name);
                    date.BorderBrush = new SolidColorBrush(Colors.Black);
                    Grid.SetColumn(date, i);
                    Grid.SetRow(date, j);
                    Dates.Children.Add(date);
                }
            }
        }
    }

    public enum Emotion { happy, despair, anxious, normal, excited, angry};

    static partial class Entries
    {
        public static List<Entry> entries = new List<Entry>();

    }

    public class Entry
    {
        String note;
        Emotion emotion;
        DateTime date;

        public Entry()
        {
            note = "";
            emotion = Emotion.normal;
            //DateTime.Now.ToString("M/d/yyyy");
            date = DateTime.Now;
        }

        public Entry(String notes, Emotion emo, DateTime newDate)
        {
            note = notes;
            emotion = emo;
            date = newDate;
        }

        public int GetDay()
        {
            return date.Day;
        }
        public int GetMonth()
        {
            return date.Month;
        }
        public Emotion GetEmotion()
        {
            return emotion;
        }
    }
}
