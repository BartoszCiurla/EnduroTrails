namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface IDistanceLocationsAnalizer
    {
        double GetDistanceInKm(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo);
    }
}
