﻿namespace Black_Wars_The_Command_Strike_Back.Data
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class UnitRepository : IRepository
    {
        private IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                var statBuilder = new StringBuilder();
                foreach (var entry in this.amountOfUnits)
                {
                    var formatedEntry = string.Format("{0} -> {1}", entry.Key, entry.Value);
                    statBuilder.AppendLine(formatedEntry);
                }

                return statBuilder.ToString()
                   .Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            var unitType = unit.GetType()
               .Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            this.amountOfUnits[unitType]--;
        }
    }
}