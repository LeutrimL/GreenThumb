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
        private Repository _repository;
        private List<string> _advices = new List<string>();
        private List<ViewModel> _addedPlants;

        public AddPlantWindow(Repository repository)
        {
            InitializeComponent();
            _dbContext = new PlantsDbContext();
            _repository = repository;

            _addedPlants = new List<ViewModel>();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

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
                _repository.AddPlant(newPlant);

                if (!string.IsNullOrEmpty(plantAdvice))
                {
                    var newAdvice = new Advice { Description = plantAdvice, PlantId = newPlant.Plantid };
                    _repository.AddAdvice(newAdvice);
                }

           

                var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mainWindow != null)
                {
                    mainWindow.LoadPlant();
                }

            Close();
        }

        private void btnAddAdvice_Click(object sender, RoutedEventArgs e)
        {

            string plantName = txtPlantName.Text;
            string plantAdvice = txtPlantAdvice.Text;

            if (string.IsNullOrEmpty(plantName) || string.IsNullOrEmpty(plantAdvice))
            {
                MessageBox.Show("You need to fill in both Plant Name and Advice before adding.");
                return;
            }


            _addedPlants.Add(new ViewModel { PlantName = plantName, Advice = plantAdvice });

            lvAddedPlants.ItemsSource = null; 
            lvAddedPlants.ItemsSource = _addedPlants;

        }
    }
}
