public record FacialFeatures(string EyeColor, decimal PhiltrumWidth)
{
    bool IEquatable<FacialFeatures>.Equals(FacialFeatures? other) => EyeColor == other?.EyeColor && PhiltrumWidth == other?.PhiltrumWidth;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public record Identity(string Email, FacialFeatures FacialFeatures)
{
    bool IEquatable<Identity>.Equals(Identity? other) => Email == other?.Email && ((IEquatable<FacialFeatures>)FacialFeatures).Equals(other?.FacialFeatures);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly Identity admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private readonly HashSet<Identity> registeredIdentities = [];

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => ((IEquatable<FacialFeatures>)faceA).Equals(faceB);

    public bool IsAdmin(Identity identity) => ((IEquatable<Identity>)admin).Equals(identity);

    public bool Register(Identity identity) => registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) => registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
