public class SpaceAge
{
    private int seconds;
    private double oneYearInEarth = 31557600;
    public SpaceAge(int seconds) => this.seconds = seconds;

    public double OnMercury() => seconds / (oneYearInEarth * 0.2408467);

    public double OnVenus() => seconds / (oneYearInEarth * 0.61519726);

    public double OnEarth() => seconds / oneYearInEarth;

    public double OnMars() => seconds / (oneYearInEarth * 1.8808158);

    public double OnJupiter() => seconds / (oneYearInEarth * 11.862615);

    public double OnSaturn() => seconds / (oneYearInEarth * 29.447498);

    public double OnUranus() => seconds / (oneYearInEarth * 84.016846);

    public double OnNeptune() => seconds / (oneYearInEarth * 164.79132);
}