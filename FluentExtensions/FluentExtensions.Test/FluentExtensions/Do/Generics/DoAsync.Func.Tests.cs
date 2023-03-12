using FluentAssertions;

using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Do.Generics
{
    [ExcludeFromCodeCoverage]
    public class DoAsync_Func_Tests
    {
        private TType CopyFrom(TType original)
        {
            var result = Test.NewT;
            result.TDesc = "copy";
            return result;
        }

        private TType Update(TType original, string newDescPart)
        {
            original.TDesc += newDescPart;
            return original;
        }


        [Test]
        public void DoAsync_Func_Null()
        {
            TType preDo = null;
            var postDo = preDo.ToTask().DoAsync(_ => Update(_, ".")).Result;
            postDo.Should().BeNull();
        }

        [Test]
        public void DoAsync_Func_UpdateObject()
        {
            TType newData = null;
            TType preDo = Test.NewT;
            var postDo = preDo.ToTask().DoAsync(_ => newData = CopyFrom(_)).Result;
            postDo.Should().BeSameAs(preDo);
            preDo.Should().BeEquivalentTo(Test.NewT);
            newData.Should().NotBeNull();
            newData.TDesc.Should().Be("copy");
        }


        [Test]
        public void DoAsync_Func_UpdateSubject()
        {
            TType preDo = Test.NewT;
            var postDo = preDo.ToTask().DoAsync(_ => Update(_, ".")).Result;
            postDo.Should().BeSameAs(preDo);
            postDo.TDesc.Should().Be(Test.NewT.TDesc + ".");
            preDo.TDesc.Should().Be(Test.NewT.TDesc + ".");
        }

        [Test]
        public void DoAsync_Funcs_UpdateObject_UpdateSubject()
        {
            TType newData = null;
            TType preDo = Test.NewT;
            var postDo = preDo.ToTask().DoAsync(_ => newData = CopyFrom(_),
                                                _ => Update(_, "."))
                                       .Result;
            postDo.Should().BeSameAs(preDo);
            preDo.TDesc.Should().Be(Test.NewT.TDesc + ".");
            newData.Should().NotBeNull();
            newData.TDesc.Should().Be("copy");
        }



    }
}