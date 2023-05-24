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
       
        public string clientName
        {
            get { return clientName; }
            set { clientName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        }
        public string droneModel {
            get { return droneModel; }
            set { droneModel = value; }
        }

        public double svCost
        {
            get { return svCost; }
            set { svCost = (value < 0) ? 0 : value; }
        }

        public string svProblem {
            get { return svProblem; }
            set { svProblem = value; }
        }
        public int svTag {
            get { return svTag; }
            set { svTag = value; }
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

        //public void setClientName(string newName)
        //{
        //    this.clientName = newName;
        //}

        //public string getClientName()
        //{
        //    return this.clientName;
        //}

        //public void setDroneModel(string newDroneModel)
        //{
        //    this.droneModel = newDroneModel;
        //}

        //public string getDroneModel()
        //{
        //    return this.droneModel;
        //}

        //public void setSvProblem(string svProblem)
        //{
        //    this.svProblem = svProblem;
        //}

        //public string getSvProblem()
        //{
        //    return this.svProblem;
        //}

        //public void setSvCost(double svCost)
        //{
        //    if (svCost < 0)
        //        svCost = 0;
        //    else
        //        this.svCost = svCost;
        //}

        //public double getSvCost()
        //{
            
        //    return this.svCost;
        //}

        //public void setSvTag(int svTag)
        //{
        //    this.svTag = svTag;
        //}

        //public int getSvTag()
        //{
        //    return svTag;
        //}

        public int CompareTo(Drone other)
        {
            return clientName.CompareTo(other.clientName);
        }
    }
}
