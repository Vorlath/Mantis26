using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svelto.ECS;

namespace Mantis26.Sokoban.Components
{
    public struct EntityType : IEntityComponent
    {
        private static int _nextId;
        private static Dictionary<int, string> _names = [];

        private readonly int _id;

        public string Name => _names[_id];

        public EntityType(string name)
        {
            _id = _nextId++;
            _names.Add(_id, name);
        }

        public override bool Equals(object? obj)
        {
            return obj is EntityType type &&
                   _id == type._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
        public static bool operator ==(EntityType left, EntityType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityType left, EntityType right)
        {
            return !(left == right);
        }

        public readonly bool Is<TDescriptor>()
        {
            return this == EntityType<TDescriptor>.Instance;
        }
    }

    public class EntityType<TDescriptor>
    {
        public static readonly EntityType Instance = new EntityType(typeof(TDescriptor).Name);
    }
}
