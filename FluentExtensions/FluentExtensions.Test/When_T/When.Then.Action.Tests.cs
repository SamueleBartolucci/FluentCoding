using FluentAssertions;
using FluentCoding;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class When_Then_Action_T_Tests
    {
        private TType UpdateT(TType t, string newDesc)
        {
            t.TDesc = newDesc;
            return t;
        }

        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);
        [TestCase(true)]
        [TestCase(false)]
        public void Then_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.NewT, trueCondition)
                .Then(_ => UpdateT(_, Test.DONE))
                .Should().BeEquivalentTo(trueCondition ? Test.NewTDone : Test.NewT);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void ThenAnd_TrueAndFalse_Func_T_T(bool trueCondition)
        {
            0.IsNullOrEquivalent();
            var output = new List<TType>();

            WhenContext(Test.NewT, trueCondition)
                .ThenAnd(_ => UpdateT(_, Test.DONE))
                .ThenAnd(_ => output.Add(_))
                .Then(_ => output.Add(_))
                .Should().BeEquivalentTo(trueCondition ? Test.NewTDone : Test.NewT);

            output.Count.Should().Be(0.Or(2, trueCondition));

            if(trueCondition) 
                output.Should().AllSatisfy(x => x.Should().BeEquivalentTo(Test.NewTDone));            
        }


        [TestCase(true)]
        [TestCase(false)]
        public void Then_TrueAndFalse_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.NewT, trueCondition)
                .Then(_ => _.TDesc = Test.DONE, (System.Action<TType>)(_ => _.TDesc = Test.NOT_DONE))
                .Should().BeEquivalentTo(trueCondition ? Test.NewTDone : Test.NewTNotDone);
        }


    }
}
