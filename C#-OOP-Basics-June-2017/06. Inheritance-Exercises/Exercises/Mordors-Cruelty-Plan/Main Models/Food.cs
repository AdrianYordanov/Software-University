abstract class Food
{
    private int pointsOfHappines;

    public Food(int pointsOfHappines)
    {
        this.PointsOfHappines = pointsOfHappines;
    }

    public int PointsOfHappines
    {
        get
        {
            return this.pointsOfHappines;
        }
        private set
        {
            this.pointsOfHappines = value;
        }
    }
}