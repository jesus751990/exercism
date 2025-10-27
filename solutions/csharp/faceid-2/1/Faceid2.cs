public class FacialFeatures : IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures? other) => EyeColor == other?.EyeColor && PhiltrumWidth == other?.PhiltrumWidth;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity : IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity? other) => Email == other?.Email && FacialFeatures.Equals(other?.FacialFeatures);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private Identity admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private HashSet<Identity> registeredIdentities = [];

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => admin.Equals(identity);

    public bool Register(Identity identity) => registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) => registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA.GetHashCode() == identityB.GetHashCode();
}
