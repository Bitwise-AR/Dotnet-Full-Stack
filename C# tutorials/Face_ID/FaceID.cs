namespace Security.Authentication
{
    class FacialFeatures
    {
        public string EyeColor { get; }
        public decimal PhiltrumWidth { get; }

        public FacialFeatures(string eyeColor, decimal philtrumWidth)
        {
            EyeColor = eyeColor;
            PhiltrumWidth = philtrumWidth;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return obj is FacialFeatures other && Equals(other);
        }

        public bool Equals(FacialFeatures other)
        {
            if (other == null) return false;
            return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EyeColor, PhiltrumWidth);
        }
    }

    class Identity
    {
        public string Email { get; }
        public FacialFeatures FacialFeatures { get; }

        public Identity(string email, FacialFeatures facialFeatures)
        {
            Email = email;
            FacialFeatures = facialFeatures;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return obj is Identity other && Equals(other);
        }

        public bool Equals(Identity other)
        {
            if (other == null) return false;
            return Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, FacialFeatures);
        }
    }

    class Authenticator
    {
        private HashSet<Identity> _registeredIdentities = new HashSet<Identity>();
        private static readonly Identity _admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

        public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
        {
            return faceA.Equals(faceB);
        }

        public bool IsAdmin(Identity identity)
        {
            return identity.Equals(_admin);
        }

        public bool Register(Identity identity)
        {
            return _registeredIdentities.Add(identity);
        }

        public bool IsRegistered(Identity identity)
        {
            return _registeredIdentities.Contains(identity);
        }

        public static bool AreSameObject(Identity identityA, Identity identityB)
        {
            return ReferenceEquals(identityA, identityB);
        }
    }
}