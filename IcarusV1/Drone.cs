using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcarusV1
{
    //6.1	Create a separate class file to hold the data items of the Drone.Use separate getter and setter methods, ensure the attributes are private and the accessor methods are public. Add a display method that returns a string for Client Name and Service Cost.Add suitable code to the Client Name and Service Problem accessor methods so the data is formatted as Title case or Sentence case. Save the class as “Drone.cs”.
    class Drone : IComparable<Drone>
    {

        // Apply backing field and prevent System.StackOverflowException 
        private string _clientName;
        private string _droneModel;
        private double _svCost;
        private string _svProblem;
        private int _svTag;


        public string clientName
        {
            get { return _clientName; }
            set { _clientName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        }
        public string droneModel {
            get { return _droneModel; }
            set { _droneModel = value; }
        }

        public double svCost
        {
            get { return _svCost; }
            set { _svCost = (value < 0) ? 0 : Math.Round(value, 2); }
        }

        public string svProblem {
            get { return _svProblem; }
            set { _svProblem = value; }
        }
        public int svTag {
            get { return _svTag; }
            set { _svTag = value; }
        }

        public Drone() { }

        public Drone(string newName, string newModel, double newCost, string newProblem, int newTag)
        {
            clientName = newName;
            droneModel = newModel;
            svCost = newCost;
            svProblem = newModel;
            svTag = newTag;

        }

        public int CompareTo(Drone other)
        {
            return clientName.CompareTo(other.clientName);
        }
    }
}
