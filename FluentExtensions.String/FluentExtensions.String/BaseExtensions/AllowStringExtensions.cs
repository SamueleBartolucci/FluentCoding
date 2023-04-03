namespace FluentCoding.String
{
    //    internal static class AllowStringExtensions
    //    {

    //        internal static IsNullOptions ToNullOptions(this StringIsNullWhenEnum? allow)
    //            => allow.When(allow.HasValue).ThenMap(_ => _.Value.ToNullOptions(), _ => new IsNullOptions());

    //        internal static IsNullOptions ToNullOptions(this StringIsNullWhenEnum allow)
    //            => new IsNullOptions() { EmptyStringIsNull = false }
    //                .When(allow.EqualsToAny(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, StringIsNullWhenEnum.NullOrEmpty))
    //                .Then(_ => _.EmptyStringIsNull = true)
    //                .When(allow.EqualsToAny(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces))
    //                .Then(_ => _.EmptyOrWhiteSpacesIsNull = true);
    //    }
}
