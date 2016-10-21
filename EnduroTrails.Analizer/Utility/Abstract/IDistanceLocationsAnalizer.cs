namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface IDistanceLocationsAnalizer
    {
        double GetDistanceInMiles(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo);
    }
}
