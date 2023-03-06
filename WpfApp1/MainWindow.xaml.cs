using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Machine machine;

        public MainWindow()
        {
            InitializeComponent();
            machine = new Machine(); 
        }

        private void ButtonWrzuc_Click(object sender, RoutedEventArgs e)
        {
            string tekst = TextBoxValue.Text;
            if (!string.IsNullOrWhiteSpace(tekst))
            {
                machine.Add(tekst); 
                LabelInfo.Content = $"Wrzucono kupon: {tekst}. Aktualna zawartość maszyny: {machine}";
            }
            else
            {
                LabelInfo.Content = "Nie podano tekstu do wrzucenia.";
            }
        }

        private void ButtonWyjmij_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Any())
            {
                string wylosowany = machine.Draw(); 
                LabelInfo.Content = $"Wylosowano kupon: {wylosowany}. Aktualna zawartość maszyny: {machine}";
            }
            else
            {
                LabelInfo.Content = "Brak napisów w maszynie.";
            }
        }
    }

    public class Machine
    {
        private List<string> kupony = new List<string>(); 

        public void Add(string kupon)
        {
            kupony.Add(kupon); 
        }

        public string Draw()
        {
            int index = new Random().Next(kupony.Count);
            string kupon = kupony[index]; 
            kupony.RemoveAt(index);
            return kupon;
        }

        public bool Any()
        {
            return kupony.Any();
        }

        public override string ToString()
        {
            return string.Join(", ", kupony); 
        }
    }
}