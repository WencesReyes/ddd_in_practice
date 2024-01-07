namespace Core.Entities
{
    public class Entity<TId>
    {
        public TId Id { get; private set; }

        //public override bool Equals(object? obj)
        //{
        //    var other = obj as Entity<TId>;

        //    if (ReferenceEquals(other, null))
        //        return false;

        //    if (ReferenceEquals(other, this)) 
        //        return true;

        //    if (GetType() != other.GetType())
        //        return false;

        //    if (Id == 0 || other.Id == 0)
        //        return false;

        //    return Id == other.Id;
        //}

        //public static bool operator ==(Entity left, Entity right)
        //{
        //    if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
        //        return true;

        //    if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
        //        return false;

        //    return left.Equals(right);
        //}

        //public static bool operator !=(Entity left, Entity right) => !(left == right);

        //public override int GetHashCode()
        //{
        //    return (GetType().ToString() + Id).GetHashCode();
        //}
    }
}
