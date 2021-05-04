namespace Diploma.Strategy
{
    public interface IWorkerQuery
    {
        string LoadQuery { get; }
        string GetQuatityQuery(int quantity);
        string GetTextWindow();
    }
}
