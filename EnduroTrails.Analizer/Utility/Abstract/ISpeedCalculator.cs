namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface ISpeedCalculator
    {
        double CalculateInKilometerPerHour(double distanceInMiles, double timeInSeconds);
    }
}
