using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class Do_Optional_Action_Tests
    {
        [Test]
        public void DoWrap_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue.ToOptional().DoWrap(_ => _.Subject++);
            postDo.Subject.Should().Be(2);
        }

        [Test]
        public void Do_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue.ToOptional().DoOptn(_ => _++);
            postDo.Subject.Should().Be(1);
        }

        [Test]
        public void Do_Action_Null()
        {
            var preDo = ((TType)null).ToOptional();
            var postDo = preDo.DoOptn(_ => _.TDesc = Test.DONE);
            postDo.Subject.Should().Be(null);
        }

        [Test]
        public void Do_Action_SubjectField()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.DoOptn(_ => _.TDesc = Test.DONE);
            postDo.Subject.TDesc.Should().Be(Test.DONE);
            postDo.Subject.Should().BeEquivalentTo(Test.NewTDone);            
            preDo.Should().BeSameAs(postDo);
        }

        [Test]
        public void Do_Actions_SubjectField()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.DoOptn(_ => _.TDesc = ".",
                                  _ => _.TDesc += ".",
                                  _ => _.TDesc += ".",
                                  _ => _.TDesc += ".");
            postDo.Subject.TDesc.Should().Be("....");            
            preDo.Should().BeSameAs(postDo);
        }

        private Optional<string> Testino(Optional<string> t) => t;

        [Test]
        public void Do_Actions_NewObject()
        {
            Optional<string> preDo = Optional<string>.Some("notDone");
            List<string> output = new List<string>();
            
            var postDo = preDo.DoOptn(_ => output.Add(_ +"1"),
                                  _ => output.Add(_ + "2"),
                                  _ => output.Add(_ + "3"));

            postDo.Subject.Should().Be(preDo.Subject);
            output.Should().HaveCount(3);
            output[0].Should().Be(preDo.Subject + "1");
            output[1].Should().Be(preDo.Subject + "2");
            output[2].Should().Be(preDo.Subject + "3");
        }
    }
}