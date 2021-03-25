namespace Assets.Scripts.Interfaces
{
    public interface ITileResolver<T> where T : class, ITile
    {
        void ApplyBehaviour(T tile);
        int CalculatePoints(T tile);
    }
}
