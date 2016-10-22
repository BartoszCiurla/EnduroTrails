namespace EnduroTrails.Analizer.Utility.Abstract
{
    public interface ISpeedCalculator
    {
        double CalculateInKilometerPerHour(double distanceInKm, double timeInSeconds);
    }
}
