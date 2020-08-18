using System;

namespace Meziantou.GitLab
{
    public struct OrderBy : IEquatable<OrderBy>
    {
        public string Name { get; set; }
        public OrderByDirection Direction { get; set; }

        public override bool Equals(object? obj) => obj is OrderBy by && Equals(by);
        public bool Equals(OrderBy other) => Name == other.Name && Direction == other.Direction;
        public override int GetHashCode() => HashCode.Combine(Name, Direction);
        public static bool operator ==(OrderBy left, OrderBy right) => left.Equals(right);
        public static bool operator !=(OrderBy left, OrderBy right) => !(left == right);
    }
}
