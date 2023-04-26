using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcarusV1
{
    class Drone : IComparable<Drone>
    {
        private string clientName;
        private string droneModel;
        private string svProblem;
        private double svCost;
        private int svTag;

        public Drone() { }

        public void setClientName(string clientName)
        {
            this.clientName = clientName;
        }

        public string getClientName()
        {
            return this.clientName;
        }

        public void setDroneModel(string droneModel)
        {
            this.droneModel = droneModel;
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
