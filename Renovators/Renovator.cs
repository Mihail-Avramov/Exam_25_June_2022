using System.Text;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        

        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
        }

        public string Name
        {
            get { return this.name;}
            private set { this.name = value; }
        }

        public string Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public double Rate
        {
            get { return this.rate; }
            private set { this.rate = value; }
        }

        public int Days
        {
            get { return this.days; }
            private set { this.days = value; }
        }
        public bool Hired { get; private set; } = false;

        public void Hire()
        {
            this.Hired = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-Renovator: {this.Name}");
            sb.AppendLine($"--Specialty: {this.Type}");
            sb.AppendLine($"--Rate per day: {this.Rate} BGN");

            return sb.ToString().TrimEnd();
        }
    }
}
