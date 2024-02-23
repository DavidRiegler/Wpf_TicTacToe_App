using System.Windows;
using System.Windows.Controls.Primitives;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private bool isPlayerX = true;
        private ToggleButton[,] btn;

        public MainWindow()
        {
            InitializeComponent();
            btn = new ToggleButton[3, 3] {
                { btn00, btn01, btn02 },
                { btn10, btn11, btn12 },
                { btn20, btn21, btn22 }
            };
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            if (button != null && button.IsChecked == true)
            {
                button.Content = isPlayerX ? "X" : "O";
                button.IsEnabled = false;
                isPlayerX = !isPlayerX;
                CheckForWinner();
            }
        }

        private void CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsSameSymbol(btn[i, 0], btn[i, 1], btn[i, 2]))
                {
                    DeclareWinner(btn[i, 0]);
                    return;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (IsSameSymbol(btn[0, i], btn[1, i], btn[2, i]))
                {
                    DeclareWinner(btn[0, i]);
                    return;
                }
            }

            if (IsSameSymbol(btn[0, 0], btn[1, 1], btn[2, 2]) ||
                IsSameSymbol(btn[0, 2], btn[1, 1], btn[2, 0]))
            {
                DeclareWinner(btn[1, 1]);
                return;
            }

            bool draw = true;
            foreach (ToggleButton button in btn)
            {
                if (button.IsChecked == false)
                {
                    draw = false;
                    break;
                }
            }
            if (draw)
            {
                MessageBox.Show("It's a draw!");
                ResetBoard();
            }
        }

        private bool IsSameSymbol(ToggleButton btn1, ToggleButton btn2, ToggleButton btn3)
        {
            if (btn1.IsChecked == true && btn2.IsChecked == true && btn3.IsChecked == true)
            {
                string symbol1 = btn1.Content.ToString();
                string symbol2 = btn2.Content.ToString();
                string symbol3 = btn3.Content.ToString();

                return symbol1 == symbol2 && symbol2 == symbol3;
            }

            return false;
        }


        private void DeclareWinner(ToggleButton winnerButton)
        {
            string winner = winnerButton.Content.ToString();
            MessageBox.Show($"Player {winner} wins!");
            ResetBoard();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            isPlayerX = true;
            foreach (ToggleButton button in btn)
            {
                button.IsChecked = false;
                button.IsEnabled = true;
                button.Content = null;
            }
        }

        private void ResetBoard()
        {
            isPlayerX = true;
            foreach (ToggleButton button in btn)
            {
                button.IsChecked = false;
                button.IsEnabled = true;
                button.Content = null;
            }
        }

    }
}
