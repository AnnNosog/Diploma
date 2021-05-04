namespace Diploma.Strategy
{
    public interface IWorkerQuery
    {
        string LoadQuery { get; }
        int RileID { get; }
        string GetQuatityQuery(int quantity);
        string GetTextWindow();
    }
}
