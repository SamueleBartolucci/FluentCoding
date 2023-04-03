namespace FluentCoding
{
    public class ResultContext
    {
        internal ResultContext(bool resultState) { IsSuccessful = resultState; }

        /// <summary>
        /// Truthy/Falsy operator
        /// </summary>
        /// <param name="context"></param>
        public static implicit operator bool(ResultContext context) => context.IsSuccessful;

        /// <summary>
        /// Truthy operator
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool operator true(ResultContext context) => context.IsSuccessful;

        /// <summary>
        /// Falsy operator 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool operator false(ResultContext context) => !context.IsSuccessful;

        /// <summary>
        /// Negation operator 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool operator !(ResultContext context) => !context.IsSuccessful;

        /// <summary>
        /// Status of the current fluent operation
        /// </summary>
        public bool IsSuccessful { get; set; }

    }
}
