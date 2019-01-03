namespace Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Iterator
    {
        private readonly IList<string> collection;
        private int currentIndex;

        public Iterator(string[] input)
        {
            this.currentIndex = 0;
            this.collection = new List<string>(this.ClearInputArray(input));
        }

        public bool HasNext
        {
            get => this.currentIndex < (this.collection.Count - 1);
        }

        private bool IsEmptyCollection
        {
            get => this.collection.Count <= 0;
        }

        public bool Move()
        {
            if (!this.HasNext)
            {
                return false;
            }

            this.currentIndex++;
            return true;
        }

        public string Print()
        {
            if (this.IsEmptyCollection)
            {
                throw new InvalidOperationException("The collection is empty.");
            }

            return this.collection.ElementAt(this.currentIndex);
        }

        private IList<string> ClearInputArray(string[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            if (input.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input));
            }

            return input.Skip(1).ToList();
        }
    }
}