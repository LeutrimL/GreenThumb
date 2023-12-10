﻿using GreenThumb.Models;
using System.Windows;

namespace GreenThumb
{

   
    public partial class PlantDetailsWindow : Window
    {
        private readonly Plant _selectedPlant;
        private readonly List<Advice> _advicesForPlant;


        public PlantDetailsWindow(Plant selectedPlant)
        {
            InitializeComponent();
            DataContext = selectedPlant;

            _selectedPlant = selectedPlant;

            var plantDetails = new List<Plant> { selectedPlant };

            var detailsViewModels = _selectedPlant.Advices.Select(advice => new PlantDetailsViewModel
            {
                PlantName = _selectedPlant.Name,
                Advice = advice.Description
            });

            listViewDetails.ItemsSource = plantDetails;

        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();

            Close();
        }
    }
}
