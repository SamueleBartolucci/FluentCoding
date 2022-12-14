using FluentAssertions;
using FluentCoding;

using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class Do_T_Action_Tests
    {

        [Test]
        public void Do_Action_Object()
        {
            var preDo = Test.T;
            var postDo = preDo.Do(_ => _.DescType = Test.Done);
            postDo.DescType.Should().Be(Test.Done);
            preDo.Should().BeSameAs(postDo);
        }

        [Test]
        public void Do_Action_Null()
        {
            TypeT preDo = null;
            var postDo = preDo.Do((_) => _.DescType = Test.Done);
            postDo.Should().Be(null);
        }

        [Test]
        public void Do_Action_StringEmpty()
        {
            string preDo = string.Empty;
            var postDo = preDo.Do((_) => _ = Test.Done);
            postDo.Should().Be(string.Empty);

        }
        [Test]
        public void Do_Action_String()
        {
            string preDo = "notDone";
            var postDo = preDo.Do((_) => _ = Test.Done);
            postDo.Should().Be(Test.Done);
        }
    }
}