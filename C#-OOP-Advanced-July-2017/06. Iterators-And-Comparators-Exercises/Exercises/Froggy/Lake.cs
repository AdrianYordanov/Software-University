using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private readonly IList<int> stones;

    public Lake(IEnumerable<int> stones)
    {
        this.stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (var i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }

        for (var i = this.stones.Count - 1; i > 0; i--)
        {
            if (i % 2 == 0)
            {
                continue;
            }

            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}