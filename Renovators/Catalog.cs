using System.Collections.Generic;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
		private string name;
		private int neededRenovators;
		private string project;
		private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
			this.Name = name;
			this.NeededRenovators = neededRenovators;
			this.Project = project;
			this.renovators = new List<Renovator>();
        }


		public int Count => renovators.Count;

		public IReadOnlyList<Renovator> Renovators => renovators;

        public string Project
		{
			get { return project; }
			private set { project = value; }
		}

		public int NeededRenovators
        {
			get { return neededRenovators; }
			private set { neededRenovators = value;}
        }

		public string Name
		{
			get { return name; }
			private set { name = value; }
		}

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.renovators[i].Name == name)
                {
                    this.renovators.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (renovators[i].Type == type)
                {
                    renovators.RemoveAt(i);
                    count++;
                }
            }

            return count;
        }

        public Renovator HireRenovator(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (renovators[i].Name == name)
                {
                    renovators[i].Hire();
                    return this.renovators[i];
                }
            }

            return default;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> resultList = new List<Renovator>();

            foreach (var renovator in this.renovators)
            {
                if (renovator.Days >= days)
                {
                    resultList.Add(renovator);
                }
            }

            return resultList;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in this.renovators)
            {
                if (renovator.Hired == false)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
