using Detached.Annotations;
using Detached.Mappers.TypePairs;
using Detached.Mappers.TypePairs.Builder;
using Detached.Mappers.Types;
using Detached.Mappers.Types.Class;
using Detached.Mappers.Types.Class.Builder;
using System.ComponentModel.DataAnnotations.Schema;



namespace Detached.Mappers.Annotations
{
    public class BusinessKeyAnnotationHandler : AnnotationHandler<BusinessKeyAttribute>
    {
        public override void Apply(BusinessKeyAttribute annotation, MapperOptions mapperOptions, ClassType typeOptions, ClassTypeMember memberOptions)
        {
            memberOptions.BusinessKey(true);
        }
    }
}

namespace Detached.Mappers
{
    public static class BusinessKeyAnnotationHandlerExtensions
    {
        public const string KEY = "DETACHED_BUSINESS_KEY";


        public static bool IsBusinessKey(this ITypeMember member)
        {
            return member.Annotations.ContainsKey(KEY);
        }

        public static void BusinessKey(this ITypeMember member, bool value = true)
        {
            if (value)
                member.Annotations[KEY] = true;
            else
                member.Annotations.Remove(KEY);
        }
        public static ClassTypeMemberBuilder<TType, TMember> BusinessKey<TType, TMember>(this ClassTypeMemberBuilder<TType, TMember> member, bool value = true)
        {
            member.MemberOptions.BusinessKey(value);
            return member;
        }

        public static bool IsBusinessKey(this TypePairMember member)
        {
            return member.Annotations.ContainsKey(KEY);
        }

        public static void BusinessKey(this TypePairMember member, bool value = true)
        {
            if (value)
                member.Annotations[KEY] = true;
            else
                member.Annotations.Remove(KEY);
        }

        public static TypePairMemberBuilder<TType, TMember> BusinessKey<TType, TMember>(this TypePairMemberBuilder<TType, TMember> member, bool value = true)
        {
            member.TypePairMember.Exclude();
            return member;
        }
    }
}
