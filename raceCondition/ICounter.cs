namespace raceCondition
{
    public interface ICounter
    {
        int Counter { get; }

        void AddOneSlow();
        void AddOneFast();
    }
}