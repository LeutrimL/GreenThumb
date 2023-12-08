using GreenThumb.Models;
using System.Windows;

namespace GreenThumb
{

   
    public partial class PlantDetailsWindow : Window
    {

        
        public PlantDetailsWindow(Plant selectedPlant)
        {
            InitializeComponent();

            txtplantdts.Text = selectedPlant.Name;

            

            

        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();

            Close();
        }
    }
}
