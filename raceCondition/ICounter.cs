namespace raceCondition
{
    public interface ICounter
    {
        int Counter { get; }

        void AddMany(int howmany);
        void SubtractMany(int howmany);
    }
}