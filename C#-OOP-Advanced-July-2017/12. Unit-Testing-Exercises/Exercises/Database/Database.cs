namespace Database
{
    using System;

    public class Database
    {
        private const int MaxArrayLength = 16;
        private int?[] array;
        private int currentIndex;

        public Database(params int[] numbers)
        {
            if (numbers.Length != MaxArrayLength)
            {
                throw new InvalidOperationException("There are not exactly sixteen numbers.");
            }

            this.array = new int?[MaxArrayLength];
            for (var i = 0; i < numbers.Length; i++)
            {
                this.array[i] = numbers[i];
            }

            this.currentIndex = MaxArrayLength - 1;
        }

        public void Add(int number)
        {
            if ((this.currentIndex + 1) >= MaxArrayLength)
            {
                throw new InvalidOperationException("You can't add number, there are already sixteen numbers.");
            }

            this.array[++this.currentIndex] = number;
        }

        public void Remove()
        {
            if (this.currentIndex < 0)
            {
                throw new InvalidOperationException("You can't remove number, there aren't any numbers.");
            }

            this.array[this.currentIndex--] = null;
        }

        public int[] Fetch()
        {
            var result = new int[this.currentIndex + 1];
            for (var i = 0; i <= this.currentIndex; i++)
            {
                result[i] = (int) this.array[i];
            }

            return result;
        }
    }
}