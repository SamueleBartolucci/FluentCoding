namespace FluentCoding
{
    public class SubjectContextReadonly<T> : SubjectContext<T>
    {
        internal SubjectContextReadonly(T subject) : base(subject) { }

        /// <summary>
        /// Subject from which the fluent operation started
        /// </summary>
        public new T Subject => base.Subject;
    }
}
