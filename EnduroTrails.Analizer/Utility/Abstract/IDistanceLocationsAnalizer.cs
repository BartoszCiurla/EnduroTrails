namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface IDistanceLocationsAnalizer
    {
        double DistanceTo(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo);
    }
}
