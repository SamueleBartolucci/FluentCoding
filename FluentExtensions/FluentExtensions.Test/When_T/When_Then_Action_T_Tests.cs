using FluentAssertions;
using FluentCoding;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class When_Then_Action_T_Tests
    {
        private TypeT UpdateT(TypeT t, string newDesc)
        {
            t.DescType = newDesc;
            return t;
        }

        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);
        [TestCase(true)]
        [TestCase(false)]
        public void Then_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.T, trueCondition)
                .Then(_ => UpdateT(_, Test.Done))
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.T);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void ThenAnd_TrueAndFalse_Func_T_T(bool trueCondition)
        {
            0.IsNullOrEquivalent();
            var output = new List<TypeT>();

            WhenContext(Test.T, trueCondition)
                .ThenAnd(_ => UpdateT(_, Test.Done))
                .ThenAnd(_ => output.Add(_))
                .Then(_ => output.Add(_))
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.T);

            output.Count.Should().Be(0.Or(2, trueCondition));

            if(trueCondition) 
                output.Should().AllSatisfy(x => x.Should().BeEquivalentTo(Test.TDone));            
        }


        [TestCase(true)]
        [TestCase(false)]
        public void Then_TrueAndFalse_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.T, trueCondition)
                .Then(_ => _.DescType = Test.Done, _ => _.DescType = Test.NotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.TNotDone);
        }


    }
}
