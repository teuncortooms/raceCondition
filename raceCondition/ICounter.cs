namespace raceCondition
{
    public interface ICounter
    {
        int Counter { get; set; }

        void AddOneSlow();
        void AddOneFast();
    }
}