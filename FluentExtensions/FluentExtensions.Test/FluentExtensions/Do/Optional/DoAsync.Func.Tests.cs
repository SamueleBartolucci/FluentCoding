using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Do.Optional
{
    [ExcludeFromCodeCoverage]
    public class DoAsync_Optional_Func_Tests
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
            var postDo = preDo.ToOptional().ToTask().DoOptnAsync(_ => Update(_, ".")).Result;
            postDo.IsNone().Should().BeTrue();
            postDo.Subject.Should().BeNull();
        }

        [Test]
        public void DoAsync_Func_UpdateObject()
        {
            TType newData = null;
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.ToTask().DoOptnAsync(_ => newData = CopyFrom(_)).Result;
            postDo.Should().BeSameAs(preDo);
            preDo.Subject.Should().BeEquivalentTo(Test.NewT);
            newData.Should().NotBeNull();
            newData.TDesc.Should().Be("copy");
        }


        [Test]
        public void DoAsync_Func_UpdateSubject()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.ToTask().DoOptnAsync(_ => Update(_, ".")).Result;
            postDo.Should().BeSameAs(preDo);
            postDo.Subject.TDesc.Should().Be(Test.NewT.TDesc + ".");
            preDo.Subject.TDesc.Should().Be(Test.NewT.TDesc + ".");
        }

        [Test]
        public void DoAsync_Funcs_UpdateObject_UpdateSubject()
        {
            TType newData = null;
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.ToTask().DoOptnAsync(_ => newData = CopyFrom(_),
                                                _ => Update(_, "."))
                                       .Result;
            postDo.Should().BeSameAs(preDo);
            preDo.Subject.TDesc.Should().Be(Test.NewT.TDesc + ".");
            newData.Should().NotBeNull();
            newData.TDesc.Should().Be("copy");
        }



    }
}