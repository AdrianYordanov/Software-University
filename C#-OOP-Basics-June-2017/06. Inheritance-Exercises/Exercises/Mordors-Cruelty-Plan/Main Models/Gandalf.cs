using System.Collections.Generic;
using System.Linq;

class Gandalf
{
    private List<Food> foods;
    private Mood mood;

    public Gandalf()
    {
        this.foods = new List<Food>();
        this.ChangeMood();
    }

    private int PointsOfHappines
    {
        get
        {
            return this.foods.Sum(food => food.PointsOfHappines);
        }
    }

    public void TakeFood(string food)
    {
        this.foods.Add(FoodFactory.GetFood(food));
        this.ChangeMood();
    }

    private void ChangeMood()
    {
        this.mood = MoodFactory.GetMood(this.PointsOfHappines);
    }

    public override string ToString()
    {
        return $"{this.PointsOfHappines}\n{this.mood.HappinesDescription}";
    }
}