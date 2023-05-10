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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Controls;

namespace IcarusV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //6.2	Create a global List<T> of type Drone called “FinishedList”. 
        List<Drone> FinishedList = new List<Drone>();

        //6.3	Create a global Queue<T> of type Drone called “RegularService”.
        Queue<Drone> RegularService = new Queue<Drone>();

        //6.4	Create a global Queue<T> of type Drone called “ExpressService”.
        Queue<Drone> ExpressService = new Queue<Drone>();

      

        //6.5	Create a button method called “AddNewItem” that will add a new service item to a Queue<> based on the priority. Use TextBoxes for the Client Name, Drone Model, Service Problem and Service Cost. Use a numeric up/down control for the Service Tag. The new service item will be added to the appropriate Queue based on the Priority radio button.
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
            // cam use switch case
            Drone drone = new Drone();
            drone.setClientName(nameTextBox.Text);
            drone.setDroneModel(modelTextBox.Text);
            drone.setSvProblem(problemTextBox.Text);
            switch (GetServicePriority())
            {
                case 1: 
                    drone.setSvCost(Double.Parse(costTextBox.Text)); 
                    break;
                
                case 2:
                    int cost = 0;
                    
                        cost = 1.15m * cost;
                        drone.setSvCost(costTextBox.Text);
                 
                    
                    break;

                default:
                    statusBarText.Text = "Error: no service is selected";
                    return;
            }


            drone.setSvCost(costTextBox.Text);
            GetServicePriority();
        }

        private int GetServicePriority()
        {
            if (regularRB.IsChecked == true)
            {
                return 1;
            }
            else if (expressRB.IsChecked == true)
            {
                return 2;
            }
            else
            {
                statusBarText.Text = "Error";
                return 0;
            }


        }

        private void expressFinishedButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void regularFinishedButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //6.10	Create a custom keypress method to ensure the Service Cost textbox can only accept a double value with one decimal point.
        //must use regex and ehandle for it
    }
}
