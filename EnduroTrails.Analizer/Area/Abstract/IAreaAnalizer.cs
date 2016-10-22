namespace EnduroTrails.Analizer.Area.Abstract
{
    public interface IAreaAnalizer
    {
        bool IsArea(double elevationFrom, double elevationTo);
        double GetTotalElevation(double elevation);
    }
}
