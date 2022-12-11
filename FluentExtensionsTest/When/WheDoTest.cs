using FluentAssertions;
using FluentExtensions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When
{
    [ExcludeFromCodeCoverage]
    public class WheDoTest
    {
        static WhenDo<T> WhenTest<T>(T obj, bool isTrue) => obj.When<T>(isTrue);
        
        
        [TestCase(true)]
        [TestCase(false)]
        public void ThenDo_Func_T_T(bool trueCondition)
        {
            WhenTest(Test.T, trueCondition)
                .ThenDo((_) => Test.TDone)                
                .Should().Be(trueCondition ? Test.TDone : Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ThenDo_TrueAndFalse_Func_T_T(bool trueCondition)
        {
            WhenTest(Test.T, trueCondition)
                .ThenDo((_) => Test.TDone, (_) => Test.TNotDone)
                .Should().Be(trueCondition ? Test.TDone : Test.TNotDone);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ThenDo_Action_T(bool trueCondition)
        {
            WhenTest(Test.T, trueCondition)
                .ThenDo(_ => _.DescType = Test.Done)                
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.T);


        }

        [TestCase(true)]
        [TestCase(false)]
        public void ThenDo_TrueAndFalse_Action_T_T(bool trueCondition)
        {
            WhenTest(Test.T, trueCondition)
                .ThenDo(_ => _.DescType = Test.Done, _ => _.DescType = Test.NotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.TNotDone);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ThenMap_T_K(bool trueCondition) => 
            WhenTest(Test.T, trueCondition)
                .ThenMap((_) => Test.KDone, (_) => Test.KNotDone)            
                .Should().BeEquivalentTo(trueCondition ? Test.KDone : Test.KNotDone);

        [TestCase(true)]
        [TestCase(false)]
        public void ThenWhenTrue(bool trueCondition)
        {
            WhenTest(Test.T, trueCondition)
                .ThenMap((_) => Test.KDone, (_) => Test.KNotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.KDone : Test.KNotDone);
        }
        /*
        public (K OnTrue, T OnFalse) ThenWhenTrue<K>(Func<T, K> whenTrue) => ((IsSuccesful ? this.Subject.Map(whenTrue) : default(K)), this.Subject);
        public (K OnTrue, T OnFalse) ThenWhenFalse<K>(Func<T, K> whenFalse) => ((!IsSuccesful ? this.Subject.Map(whenFalse) : default(K)), this.Subject
        */


    }
}
