namespace FluentCoding
{
    /// <summary>
    /// Defube the 'Nothing' value to be use instead of Null
    /// </summary>
    public struct Nothing
    {
        /// <summary>
        /// Return the dafult Nothing 'Value'
        /// </summary>
        public static readonly Nothing NothingOf = new Nothing { };
    }
}
