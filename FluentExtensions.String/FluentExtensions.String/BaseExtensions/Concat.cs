namespace FluentCoding.String
{

    public static class Concat
    {
        public static string ConcatWhenWithValue(this string _, string appendLeft, string appendRight)
         => _.When(!_.IsNullOrDefault()).Then(sbj => string.Concat(appendLeft.Or(""), sbj, appendRight.Or("")));
    }
}