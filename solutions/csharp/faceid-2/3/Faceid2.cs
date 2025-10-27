public record FacialFeatures(string EyeColor, decimal PhiltrumWidth);

public record Identity(string Email, FacialFeatures FacialFeatures);

public class Authenticator
{
    private readonly Identity admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private readonly HashSet<Identity> identities = [];

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => admin.Equals(identity);

    public bool Register(Identity identity) => identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
