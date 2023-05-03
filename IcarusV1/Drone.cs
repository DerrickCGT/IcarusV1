using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcarusV1
{
    //6.1	Create a separate class file to hold the data items of the Drone.Use separate getter and setter methods, ensure the attributes are private and the accessor methods are public. Add a display method that returns a string for Client Name and Service Cost.Add suitable code to the Client Name and Service Problem accessor methods so the data is formatted as Title case or Sentence case. Save the class as “Drone.cs”.
    class Drone : IComparable<Drone>
    {
        private string clientName;
        private string droneModel;
        private string svProblem;
        private double svCost;
        private int svTag;

        public Drone() { }

        public Drone(string clientName, string droneModel, string svProblem, double svCost, int svTag)
        {
            setClientName(clientName);
            setDroneModel(droneModel);
            setSvCost(svCost);
            setSvTag(svTag);
            setSvProblem(svProblem);
        }

        public void setClientName(string newName)
        {
            this.clientName = newName;
        }

        public string getClientName()
        {
            return this.clientName;
        }

        public void setDroneModel(string newDroneModel)
        {
            this.droneModel = newDroneModel;
        }

        public string getDroneModel()
        {
            return this.droneModel;
        }

        public void setSvProblem(string svProblem)
        {
            this.svProblem = svProblem;
        }

        public string getSvProblem()
        {
            return this.svProblem;
        }

        public void setSvCost(double svCost)
        { 
            this.svCost = (double)Math.Round(svCost,2);
        }

        public double getSvCost()
        {
            return this.svCost;
        }

        public void setSvTag(int svTag)
        {
            this.svTag = svTag;
        }

        public int getSvTag()
        {
            return svTag;
        }

        public int CompareTo(Drone other)
        {
            return clientName.CompareTo(other.clientName);
        }
    }
}
