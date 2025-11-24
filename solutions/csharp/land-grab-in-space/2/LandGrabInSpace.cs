public struct Coord(ushort x, ushort y) : IEquatable<Coord>
{
    public ushort X { get; } = x;
    public ushort Y { get; } = y;

    public bool Equals(Coord other) => X == other.X && Y == other.Y;
}

public struct Plot(Coord a, Coord b, Coord c, Coord d) : IEquatable<Plot>
{
    public Coord A { get; } = a;
    public Coord B { get; } = b;
    public Coord C { get; } = c;
    public Coord D { get; } = d;

    public bool Equals(Plot other) => A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D);

    public ushort GetLongestSideLength() => new[]
      {
            Distance(A, B),
            Distance(B, C),
            Distance(C, D),
            Distance(D, A)
        }.Max();

    private ushort Distance(Coord a, Coord b) => (ushort)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
}


public class ClaimsHandler
{
    HashSet<Plot> plots = [];

    public void StakeClaim(Plot plot) => plots.Add(plot);

    public bool IsClaimStaked(Plot plot) => plots.Contains(plot);

    public bool IsLastClaim(Plot plot) => plot.Equals(plots.LastOrDefault());

    public Plot GetClaimWithLongestSide() => plots.OrderByDescending(p => p.GetLongestSideLength()).First();
}
