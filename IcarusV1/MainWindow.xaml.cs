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
            if (string.IsNullOrWhiteSpace(nameTextBox.Text)) {
                MessageBox.Show("Please fill in the name and cost field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(costTextBox.Text))
            {
                costTextBox.Text = "0";
            }

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
                    statusBarText.Text = "Regular Service Drone Added";
                    statusBarText.Foreground = Brushes.Green;
                    break;

                case 2:
                    // 6.6	Before a new service item is added to the Express Queue the service cost must be increased by 15%.
                    drone.svCost = 1.15 * Double.Parse(costTextBox.Text);
                    ExpressService.Enqueue(drone);
                    tcSample.SelectedIndex = 1;
                    statusBarText.Text = "Express Service Drone Added";
                    statusBarText.Foreground = Brushes.Green;
                    break;

                default:
                    statusBarText.Text = "Error: no service is selected";
                    statusBarText.Foreground = Brushes.Red;
                    MessageBox.Show("Service type is not selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            IncrementTagValue();
            DisplayRegularLVI();
            DisplayExpresLVI();
            ClearDisplay();
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


        // 6.8	Create a custom method that will display all the elements in the RegularService queue. The display must use a List View and with appropriate column headers.
        private void DisplayRegularLVI()
        {

            //List<Drone> regularCollection = new List<Drone>();

            //foreach (var drone in RegularService)
            //{
            //    regularCollection.Add(drone);
            //}
            //regularLVI.ItemsSource = regularCollection;

            regularLVI.ItemsSource = RegularService.ToList();
        }

        // 6.9	Create a custom method that will display all the elements in the ExpressService queue. The display must use a List View and with appropriate column headers
        private void DisplayExpresLVI()
        {
            //List<Drone> expressCollection = new List<Drone>();

            //foreach (var drone in ExpressService)
            //{
            //    expressCollection.Add(drone);
            //}
            //expressLVI.ItemsSource = expressCollection;

            expressLVI.ItemsSource = ExpressService.ToList();
        }

        // Display and Update Finished Service ListBox
        private void DisplayFinishedListBox()
        {
            //List<string> finishedCollection = new List<string>();

            //foreach (var drone in FinishedList)
            //{
            //    string droneText = $"Tag: {drone.svTag}| {drone.clientName} ({drone.droneModel}): {drone.svProblem} (Cost: ${drone.svCost.ToString()})";
            //    finishedCollection.Add(droneText);
            //}
            //finishListBox.ItemsSource = finishedCollection;

            finishListBox.ItemsSource = FinishedList.Select(drone =>
                $"Tag: {drone.svTag}| {drone.clientName} ({drone.droneModel}): {drone.svProblem} (Cost: ${drone.svCost.ToString()})"
            ).ToList();
        }

        //6.10	Create a custom keypress method to ensure the Service Cost textbox can only accept a double value with one decimal point.
        private void costTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex decimalRegex = new Regex(@"^^[0-9]*\.?[0-9]{0,2}?$");
            e.Handled = !decimalRegex.IsMatch(((TextBox)sender).Text + e.Text);
        }

        // 6.11	Create a custom method to increment the service tag control, this method must be called inside the “AddNewItem” method before the new service item is added to a queue.
        private void IncrementTagValue()
        {
            tagUpDown.Value += 10;
        }

        //6.12	Create a mouse click method for the regular service ListView that will display the Client Name and Service Problem in the related textboxes.
        private void regularLVI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayTextBox(regularLVI);
        }

        //6.13	Create a mouse click method for the express service ListView that will display the Client Name and Service Problem in the related textboxes.
        private void expressLVI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayTextBox(expressLVI);
        }

        // Common method to display and focus textbox when listview item selected
        private void displayTextBox(ListView lvi)
        {
            ClearDisplay();
            if (lvi.SelectedItem != null)
            {
                var selectedDataItem = (Drone)lvi.SelectedItem;
                nameTextBox.Text = selectedDataItem.clientName;
                problemTextBox.Text = selectedDataItem.svProblem;
            }

        }

        //6.14	Create a button click method that will remove a service item from the regular ListView and dequeue the regular service Queue<T> data structure. The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items.
        private void regularFinishedButton_Click(object sender, RoutedEventArgs e)
        {
            removeDrone(RegularService, "Regular");
        }


        //6.15	Create a button click method that will remove a service item from the express ListView and dequeue the express service Queue<T> data structure. The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items.
        private void expressFinishedButton_Click(object sender, RoutedEventArgs e)
        {
            removeDrone(ExpressService, "Express");
        }

        // Common method to remove drone from either regular or express service and transfer to finished list
        private void removeDrone(Queue<Drone> serviceList, string serviceType)
        {
            if (serviceList.Count > 0)
            {
                Drone removedDrone = serviceList.Dequeue();
                FinishedList.Add(removedDrone);
                DisplayFinishedListBox();

                if (serviceType == "Regular")
                    DisplayRegularLVI();
                else if (serviceType == "Express")
                    DisplayExpresLVI();
                
                statusBarText.Text = $"{serviceType} Service Drone Service Completed and transfer to Finished List";
                statusBarText.Foreground = Brushes.Green;
            }
            else
            {
                MessageBox.Show($"No item left in {serviceType} Service.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                statusBarText.Text = "Error!";
                statusBarText.Foreground = Brushes.Green;
            }
        }


        // 6.16	Create a double mouse click method that will delete a service item from the finished listbox and remove the same item from the List<T>.
        private void finishListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (finishListBox.SelectedItem != null)
            {
                int selectedIndex = finishListBox.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < finishListBox.Items.Count)
                {
                    FinishedList.RemoveAt(selectedIndex);
                    DisplayFinishedListBox();
                    statusBarText.Text = "Finished Drone Deleted";
                    statusBarText.Foreground = Brushes.Green;
                }
            }
        }

        // 6.17	Create a custom method that will clear all the textboxes after each service item has been added.
        private void ClearDisplay()
        {
            nameTextBox.Clear();
            problemTextBox.Clear();
            costTextBox.Clear();
            modelTextBox.Clear();
            regularRB.IsChecked = false;
            expressRB.IsChecked = false;
        }
    }
}
