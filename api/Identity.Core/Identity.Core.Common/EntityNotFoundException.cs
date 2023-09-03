using System.Reflection;

namespace Identity.Core.Common
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(MemberInfo entityType) 
            : base($"Entity {entityType.Name} not found") {}
        
        public EntityNotFoundException(MemberInfo entityType, Guid entityId) 
            : base($"Entity {entityType.Name} with Id {entityId} not found") {}
    }
}