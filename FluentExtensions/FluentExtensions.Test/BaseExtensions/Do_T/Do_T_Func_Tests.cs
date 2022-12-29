using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class Do_T_Func_Tests
    {
        [Test]
        public void Do_Func_Object()
        {
            TypeT preDo = Test.T;
            var postDo = preDo.Do((_) => new TypeT() { DescType = Test.Done });
            postDo.DescType.Should().Be(Test.Done);
            preDo.Should().NotBeSameAs(postDo);
        }


        [Test]
        public void Do_Func_StringEmpty()
        {            
            string preDo = string.Empty;
            var postDo = preDo.Do((_) => Test.Done);
            postDo.Should().Be(string.Empty);
            preDo.Should().Be(string.Empty);

        }

        [Test]
        public void Do_Func_String()
        {
            string preDo = Test.NotDone;
            var postDo = preDo.Do((_) => Test.Done);
            postDo.Should().Be(Test.Done);
            preDo.Should().NotBeSameAs(postDo);
        }

        
        [Test]
        public void Do_Func_Enum()
        {
            var preDo = TestEnum.Enum1;
            var postDo = preDo.Do((_) => TestEnum.Enum2);
            postDo.Should().Be(TestEnum.Enum2);
            preDo.Should().NotBe(postDo);
        }

        [Test]
        public void Do_Func_Null()
        {
            TypeT preDo = null;
            var postDo = preDo.Do((_) => new TypeT() { DescType = Test.Done });
            postDo.Should().BeNull();
        }

    }
}