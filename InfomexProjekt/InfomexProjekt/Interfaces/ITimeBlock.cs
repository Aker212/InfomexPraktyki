namespace InfomexProjekt.Interfaces
{
    public interface ITimeBlock
    {
        DateTime[] SearchForBroadbandTimeBlocks(DateTime startDate, DateTime endDate, int numberOfBlocks);
    }
}
