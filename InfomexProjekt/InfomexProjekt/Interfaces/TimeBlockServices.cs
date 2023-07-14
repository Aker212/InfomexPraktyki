namespace InfomexProjekt.Interfaces
{
    public class TimeBlockService : ITimeBlock
    {
        public DateTime[] SearchForBroadbandTimeBlocks(DateTime startDate, DateTime endDate, int numberOfBlocks)
        {
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan blockDuration = TimeSpan.FromTicks(timeSpan.Ticks / (numberOfBlocks - 1));

            DateTime[] timeBlocks = new DateTime[numberOfBlocks];

            for (int i = 0; i < numberOfBlocks - 1; i++)
            {
                timeBlocks[i] = startDate + (blockDuration * i);
            }

            timeBlocks[numberOfBlocks - 1] = endDate;

            return timeBlocks;
        }
    }
}
