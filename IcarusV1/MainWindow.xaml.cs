using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            Drone drone = new Drone();
            drone.clientName = nameTextBox.Text;
            drone.droneModel = modelTextBox.Text;
            drone.svProblem = problemTextBox.Text;
            drone.svTag = int.Parse(tagUpDown.Text);

            switch (GetServicePriority())
            {
                case 1:
                    drone.svCost = Double.Parse(costTextBox.Text);
                    RegularService.Enqueue(drone);
                    break;

                case 2:
                    // 6.6	Before a new service item is added to the Express Queue the service cost must be increased by 15%.
                    drone.svCost = 1.15 * Double.Parse(costTextBox.Text);
                    ExpressService.Enqueue(drone);
                    break;

                default:
                    statusBarText.Text = "Error: no service is selected";
                    return;
            }

            IncrementTagValue();
            DisplayRegularLVI();
        }

        //6.7   Create a custom method called “GetServicePriority” which returns the value of the priority radio group.
        //This method must be called inside the “AddNewItem” method before the new service item is added to a queue.
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

        private void IncrementTagValue()
        {
            tagUpDown.Value += 10;
        }

        private void DisplayRegularLVI()
        {

            List<Drone> collection = new List<Drone>();

            foreach (var drone in RegularService)
            {
                 collection.Add(drone);
            }
            regularLVI.ItemsSource = collection;
            
        }
 
        //6.10	Create a custom keypress method to ensure the Service Cost textbox can only accept a double value with one decimal point.
        
        private void costTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex decimalRegex = new Regex(@"^^[0-9]*\.?[0-9]{0,2}?$");
            e.Handled = !decimalRegex.IsMatch(((TextBox)sender).Text + e.Text);
        }


        private void expressFinishedButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void regularFinishedButton_Click(object sender, RoutedEventArgs e)
        {

        }




        //        //6.12

        //        if{TextBox.text = reguarservice.elementAT(indx).getclientname()
        //    }
        //        else {listviereuglarservicequeue.unselectall()
        //}





    }
}
