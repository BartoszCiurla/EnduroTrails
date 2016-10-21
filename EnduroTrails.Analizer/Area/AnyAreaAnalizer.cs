using EnduroTrails.Analizer.Area.Abstract;

namespace EnduroTrails.Analizer.Area
{
    public class AnyAreaAnalizer:IAreaAnalizer
    {
        public bool IsArea(double elevationFrom, double elevationTo) => AcceptAnyArea();
        private bool AcceptAnyArea() => true;
    }
}
