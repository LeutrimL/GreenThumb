using GreenThumb.Models;
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

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {

        private PlantsDbContext _dbContext;
        public AddPlantWindow()
        {
            InitializeComponent();
            _dbContext = new PlantsDbContext();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string plantName = txtPlantName.Text;
            string plantAdvice = txtPlantAdvice.Text;

            if (string.IsNullOrEmpty(plantName) || string.IsNullOrEmpty(plantAdvice))
            {
                MessageBox.Show("You need to fill in everything before Saving");
                return;
            }

            var newPlant = new Plant { Name = plantName };
            _dbContext.Plants.Add(newPlant);
            _dbContext.SaveChanges();

            Close();
        }
    }
}
