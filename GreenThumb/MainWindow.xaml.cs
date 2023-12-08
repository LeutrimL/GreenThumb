using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel;
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
        
        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new PlantsDbContext();
            _dbContext.Database.Migrate();
            LoadPlant();

        }


        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            var addPlantWindow = new AddPlantWindow();
            addPlantWindow.ShowDialog();

            LoadPlant();
            
        }

       

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Lw1.ItemsSource).Refresh();
        }

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlant = Lw1.SelectedItem as Plant;
            if (selectedPlant !=null)
            {
               

                _dbContext.Plants.Remove(selectedPlant);
                _dbContext.SaveChanges();

                LoadPlant();
            }
        }

        private void Dtbtn_Click(object sender, RoutedEventArgs e)
        {
            
            var selectedPlant = Lw1.SelectedItem as Plant;
            

            if (selectedPlant !=null)
            {
                var plantDetailsWindow = new PlantDetailsWindow(selectedPlant);
                plantDetailsWindow.ShowDialog();
            }
        }

        private bool PlantFilter(object item)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                return true;

            var plant = item as Plant;
            return plant != null && plant.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase);
        }



        private void LoadPlant()
        {
            //För att visa namnet på växterna i Listview!! 
            var plants = _dbContext.Plants.Select(p => new ViewModel { Id = p.Plantid, PlantName = p.Name}).ToList();
            Lw1.ItemsSource = plants;

            CollectionViewSource.GetDefaultView(Lw1.ItemsSource).Filter = PlantFilter;


        }
    }


    
}

