
using System;

namespace FluentCoding
{
    /// <summary>
    /// When->Then class. Run the 'Then' logic only if the 'When' is true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class When<T> : FluentContext<T>
    {
        internal When(T subject) : base(subject) { }

        /// <summary>
        /// If condition is true apply whenTrue(subject) and return the result 
        /// Otherwise return the subject
        /// </summary>
        /// <param name="whenTrue"></param>
        /// <returns></returns>
        public T Then(Func<T, T> whenTrue)

            /* Unmerged change from project 'FluentCoding (netstandard2.1)'
            Before:
                        => IsSuccessful ? whenTrue(Subject) : Subject;

                    /// <summary>
            After:
                        => IsSuccessful ? whenTrue(Subject) : Subject;

                    /// <summary>
            */

            /* Unmerged change from project 'FluentCoding (net48)'
            Before:
                        => IsSuccessful ? whenTrue(Subject) : Subject;

                    /// <summary>
            After:
                        => IsSuccessful ? whenTrue(Subject) : Subject;

                    /// <summary>
            */

            /* Unmerged change from project 'FluentCoding (netstandard2.0)'
            Before:
                        => IsSuccessful ? whenTrue(Subject) : Subject;

                    /// <summary>
            After:
                        => IsSuccessful ? whenTrue(Subject) : Subject;

                    /// <summary>
            */
            => IsSuccessful ? whenTrue(Subject) : Subject;

        /// <summary>
        /// If condition is true apply whenTrue() and return the result 
        /// Otherwise return the subject
        /// </summary>
        /// <param name="whenTrue"></param>
        /// <returns></returns>
        public T Then(Func<T> whenTrue)
            => IsSuccessful ? whenTrue() : Subject;


        /// <summary>
        /// Based on the boolean condition value, apply mapWhenTrue(subject) or mapWhenFalse(subject) and return the result
        /// </summary>
        /// <param name="mapWhenTrue"></param>
        /// <param name="mapWhenFalse"></param>
        /// <returns></returns>
        public K Then<K>(Func<T, K> mapWhenTrue, Func<T, K> mapWhenFalse)
            => IsSuccessful ? mapWhenTrue(Subject) : mapWhenFalse(Subject);

        /// <summary>
        /// Based on the boolean condition value, apply mapWhenTrue() or mapWhenFalse() and return the result
        /// </summary>
        /// <param name="mapWhenTrue"></param>
        /// <param name="mapWhenFalse"></param>
        /// <returns></returns>
        public K Then<K>(Func<K> mapWhenTrue, Func<K> mapWhenFalse)
            => IsSuccessful ? mapWhenTrue() : mapWhenFalse();



        /// <summary>
        /// Based on the boolean condition value, run whenTrue(subject) or whenFalse(subject) 
        /// Then return the Subject
        /// </summary>
        /// <param name="whenTrue"></param>
        /// <param name="whenFalse"></param>
        /// <returns></returns>
        public T Then(Action<T> whenTrue, Action<T> whenFalse)
        {
            if (IsSuccessful)
                whenTrue(Subject);
            else
                whenFalse(Subject);

            return Subject;
        }

        /// <summary>
        /// If condition is true, run whenTrue(subject)
        /// Then return the Subject
        /// </summary>
        /// <param name="whenTrue"></param>
        /// <returns></returns>
        public T Then(Action<T> whenTrue)
        {
            if (IsSuccessful)
                whenTrue(Subject);

            return Subject;
        }



        /// <summary>
        /// If condition is true, run whenTrue(subject)
        /// Then return the When Context to chains more ThenAnd or close with Then
        /// </summary>
        /// <param name="whenTrue"></param>
        /// <returns></returns>
        public When<T> ThenAnd(Action<T> whenTrue)
        {
            if (IsSuccessful)
                whenTrue(Subject);

            return this;
        }

        /// <summary>
        /// If condition is true, apply whenTrue(subject)
        /// Then return the When Context to chains more ThenAnd or close with Then
        /// </summary>
        /// <param name="whenTrue"></param>
        /// <returns></returns>
        public When<T> ThenAnd(Func<T, T> whenTrue)
        {
            if (IsSuccessful)
                whenTrue(Subject);

            return this;
        }

        /// <summary>
        /// If condition is true, run mapWhenTrue(subject) 
        /// Then return:
        ///  - the mapWhenTrue result (or default K if false)
        ///  - the subject of When context
        /// </summary>
        /// <param name="mapWhenTrue"></param>
        /// <returns></returns>
        public (K OnTrue, T Subject) ThenMap<K>(Func<T, K> mapWhenTrue)
            => (IsSuccessful ? mapWhenTrue(Subject) : default, Subject);

    }
}
