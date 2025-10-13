public class SpaceAge
{
    private int seconds;
    private double oneYearInSeconds = 31557600;
    public SpaceAge(int seconds) => this.seconds = seconds;

    public double OnMercury() => seconds / (oneYearInSeconds * 0.2408467);

    public double OnVenus() => seconds / (oneYearInSeconds * 0.61519726);
    public double OnEarth() => seconds / oneYearInSeconds;

    public double OnMars() => seconds / (oneYearInSeconds * 1.8808158);

    public double OnJupiter() => seconds / (oneYearInSeconds * 11.862615);

    public double OnSaturn() => seconds / (oneYearInSeconds * 29.447498);

    public double OnUranus() => seconds / (oneYearInSeconds * 84.016846);

    public double OnNeptune() => seconds / (oneYearInSeconds * 164.79132);
}