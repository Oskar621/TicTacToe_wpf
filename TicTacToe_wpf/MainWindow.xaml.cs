using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

namespace TicTacToe_wpf
{
    public partial class MainWindow : Window
    {
        private bool turn = true;
        private int turn_count = 0;
        public MainWindow()
        {
            InitializeComponent();
        
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Content = "X";
            else
                b.Content="O";

            turn = !turn;
            b.IsEnabled = false;
            turn_count++;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool winner = false;

            //poziomo

            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                winner = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                winner = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                winner = true;

            //pionowo

            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                winner = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                winner = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                winner = true;

            //po skosie

            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                winner = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!A3.IsEnabled))
                winner = true;

            if (winner)
            {
                //wylaczenie buttonow
                DisableButtons();

                // kto wygral
                string who_win = "";
                if (!turn)
                    who_win = "X";
                else
                    who_win = "O";

                MessageBox.Show(who_win + " Wygrywa!");
            }
            else if (turn_count == 9)
                    MessageBox.Show("Remis!");

        }

        private void DisableButtons()
        {
            try
            {
                foreach (var control in Grid.Children)
                {
                    Button b = (Button)control;
                    b.IsEnabled = false;
                }
            }
            catch { }
        }
    }
}
