using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class Do_Func_Tests
    {
        private TypeT CopyFrom(TypeT original)
        {
            var result = Test.T;
            result.DescType = "copy";
            return result;
        }

        private TypeT Update(TypeT original, string newDescPart)
        {
            original.DescType += newDescPart;
            return original;
        }


        [Test]
        public void Do_Func_Null()
        {
            TypeT preDo = null;
            var postDo = preDo.Do(_ => Update(_, "."));
            postDo.Should().BeNull();
        }

        [Test]
        public void Do_Func_UpdateObject()
        {
            TypeT newData = null;
            TypeT preDo = Test.T;
            var postDo = preDo.Do(_ => newData = CopyFrom(_));
            postDo.Should().BeSameAs(preDo);
            preDo.Should().BeEquivalentTo(Test.T);
            newData.Should().NotBeNull();
            newData.DescType.Should().Be("copy");
        }


        [Test]
        public void Do_Func_UpdateSubject()
        {
            TypeT preDo = Test.T;
            var postDo = preDo.Do(_ => Update(_, "."));
            postDo.Should().BeSameAs(preDo);
            postDo.DescType.Should().Be(Test.T.DescType + ".");
            preDo.DescType.Should().Be(Test.T.DescType + ".");
        }

        [Test]
        public void Do_Funcs_UpdateObject_UpdateSubject()
        {
            TypeT newData = null;
            TypeT preDo = Test.T;
            var postDo = preDo.Do(_ => newData = CopyFrom(_),
                                  _ => Update(_, "."));
            postDo.Should().BeSameAs(preDo);
            preDo.DescType.Should().Be(Test.T.DescType + ".");
            newData.Should().NotBeNull();
            newData.DescType.Should().Be("copy");
        }



    }
}