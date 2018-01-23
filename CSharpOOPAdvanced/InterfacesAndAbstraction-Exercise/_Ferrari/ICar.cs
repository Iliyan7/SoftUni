namespace _Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string DriverName { get; }

        string UseBreaks();
        string PushTheGas();
    }
}