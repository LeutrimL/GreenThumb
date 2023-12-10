using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenThumb
{
 
    public partial class MainWindow : Window
    {

        private PlantsDbContext _dbContext;
        private List<Plant> _allPlants;
        private List<Plant> _filteredPlants;
        private readonly Repository _repository;

        public MainWindow()
        {
            
            InitializeComponent();
            //_repository = repository;
            _dbContext = new PlantsDbContext();
            _dbContext.Database.Migrate();
            LoadPlant();

        }


        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {

            //Öppna AddPlantWindow!!
            //var addPlantWindow = new AddPlantWindow(_repository);
            //addPlantWindow.ShowDialog();

            //LoadPlant();

            var repository = new Repository(new PlantsDbContext());
            var addPlantWindow = new AddPlantWindow(repository);
            addPlantWindow.ShowDialog();

            LoadPlant();

        }

       

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _filteredPlants = _allPlants.Where(p => p.Name.Contains(txtSearch.Text)).ToList();

            Lw1.Items.Clear();

            foreach(var plant in _filteredPlants)
            {
                ListViewItem item = new()
                {
                    Content = plant.Name,
                    Tag = plant
                };

                Lw1.Items.Add(item);
            }
        }

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
 

            ListViewItem selectedItem = (ListViewItem)Lw1.SelectedItem;
            if (selectedItem !=null)
            {
                Lw1.Items.Remove(selectedItem);

                using (PlantsDbContext context = new())
                {

                }
            }
            else
            {
                MessageBox.Show("You need to choose atleast one plant");
            }

        }

        private void Dtbtn_Click(object sender, RoutedEventArgs e)
        {

            var item = Lw1.SelectedItem as ListViewItem;
            var selectedPlant = (Plant)item.Tag;

            //var selectedPlant = Lw1.SelectedItem as Plant;
            if (selectedPlant != null)
            {
                var plantDetailsWindow = new PlantDetailsWindow(selectedPlant);
                plantDetailsWindow.ShowDialog();
            }

            if (selectedPlant != null)
            {
                var plantDetailsWindow = new PlantDetailsWindow(selectedPlant);
                plantDetailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("You need to choose atleast one plant");
            }


            //var item = Lw1.SelectedItem as ListViewItem;
            //var selectedPlant = (Plant)item.Tag;

            //if (selectedPlant != null)
            //{
            //    var plantDetailsWindow = new PlantDetailsWindow(selectedPlant);
            //    plantDetailsWindow.UpdatePlantList(); // Uppdatera råd i PlantDetailsWindow
            //    plantDetailsWindow.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You need to choose at least one plant");
            //}


        }

        private bool PlantFilter(object item)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                return true; 

            var plant = item as Plant;
            return plant != null && plant.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase);
        }



        public void LoadPlant()
        {
            var plants = _dbContext.Plants.ToList();
            _allPlants = plants;
            _filteredPlants = plants;
            _allPlants = _dbContext.Plants.Include(p => p.Advices).ToList();

            


            foreach (var plant in plants)
            {
                ListViewItem item = new()
                {
                    Content = plant.Name,
                    Tag = plant
                };

                Lw1.Items.Add(item);
            }
           

            CollectionViewSource.GetDefaultView(Lw1.Items).Filter = PlantFilter;

            
        }

        public void UpdatePlantList()
        {
            Lw1.Items.Clear();
            LoadPlant();
        }






    }


    
}

