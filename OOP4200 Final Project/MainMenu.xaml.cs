#region USINGS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
#endregion

namespace OOP4200_Final_Project
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {


        public MainMenu()
        {
            InitializeComponent();
            Control main = new Main();
            this.MainMenuView.Children.Add(main);
           
        }
        public void OpenMenu()
        {
            MainMenuView.Children.Clear();
            Control main = new Main();
            this.MainMenuView.Children.Add(main);
        }
        public void OpenSetUp()
        {
            MainMenuView.Children.Clear();
            Control set = new SetUpGame();
            this.MainMenuView.Children.Add(set);
        }
        public void OpenStats()
        {
            MainMenuView.Children.Clear();
            Control set = new SetUpGame();
            this.MainMenuView.Children.Add(set);
        }

    }
}
