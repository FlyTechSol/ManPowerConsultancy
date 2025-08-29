namespace MC.Domain.Entity.Enum.Common
{
    [Flags]
    public enum DocumentPurpose
    {
        None = 0,
        Identity = 1,
        Address = 2,
        Age = 4,
        Qualification = 8
    }
}
