using FluentAssertions;
using FluentExtensions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;
using UsefulExtensionsTest.TestTypes;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class TryTests
    {

        [Test]
        public void Try_Ok()
        {
            var tryResult = Test.T.Try
                (
                    (_) => Test.TRight,
                    (e) => Test.EException
                 );
            tryResult.Result.Should().BeEquivalentTo(Test.TRight);
            tryResult.Error.Should().BeNull();
        }


        [Test]
        public void Try_Error()
        {
            var tryResult = Test.T.Try
                (
                    (_) => Test.GetDefault<TypeT>().DescType,
                    (e) => Test.EException
                 );
            tryResult.Result.Should().BeNull();
            tryResult.Error.Should().BeEquivalentTo(Test.EException);
        }


        [Test]
        public void WhenTryOk_OK()
        {
            var outcome = Test.TryTKE_OK.WhenTryOk(_ => Test.TDone);

            outcome.Result.Should().BeEquivalentTo(Test.TDone);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void WhenTryOk_Exception()
        {
            var outcome = Test.TryTKE_Exception.WhenTryOk(_ => Test.TDone);

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.EException);
        }



        [Test]
        public void WhenTryException_OK()
        {
            var outcome = Test.TryTKE_OK.WhenTryException((s, e) => (s, null as TypeK, Test.EException));

            outcome.Result.Should().BeEquivalentTo(Test.T);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void WhenTryException_Exception()
        {
            var outcome = Test.TryTKE_Exception.WhenTryException(_ => Test.EException);

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.EException);
        }


        [Test]
        public void When_Cascade_OK()
        {
            var outcome = Test.TryTKE_OK
                .WhenTryOk(_ => Test.TDone)
                .WhenTryException(_ => Test.EException);

            outcome.Result.Should().BeEquivalentTo(Test.TDone);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void When_Cascade_Exception()
        {
            var outcome = Test.TryTKE_Exception
                .WhenTryOk(_ => Test.TDone)
                .WhenTryException(_ => Test.EException);

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.EException);
        }

        [Test]
        public void ContinueTryWith_OK()
        {
            var outcome = Test.TryTKE_OK
                .ContinueTryWith
                (
                    _ => Test.T,
                    _ => Test.EException
                );

            outcome.Result.Should().BeEquivalentTo(Test.T);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void ContinueTryWith_Exception()
        {
            var outcome = Test.TryTKE_Exception
                .ContinueTryWith
                (
                    _ => Test.T,
                    _ => Test.EException
                );

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.EException);
        }





        [Test]
        public void TryMap_Ok()
        {
            var tryResult = Test.T.TryMap
                (
                    (_) => Test.KRight,
                    (e) => Test.EException
                 );
            tryResult.Result.Should().BeEquivalentTo(Test.KRight);
            tryResult.Error.Should().BeNull();
        }


        [Test]
        public void TryMap_Error()
        {
            var tryResult = Test.T.TryMap
                (
                    (_) => Test.GetDefault<TypeK>().K,
                    (e) => Test.EException
                 );
            tryResult.Result.Should().BeNull();
            tryResult.Error.Should().BeEquivalentTo(Test.EException);
        }


        [Test]
        public void WhenTryOkMap_OK()
        {
            var outcome = Test.TryTKE_OK.WhenTryOkMap(_ => Test.KDone);

            outcome.Result.Should().BeEquivalentTo(Test.KDone);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void WhenTryOkMap_Exception()
        {
            var outcome = Test.TryTKE_Exception.WhenTryOkMap(_ => Test.KDone);

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.EException);
        }



        [Test]
        public void WhenTryExceptionMap_OK()
        {
            var outcome = Test.TryTKE_OK.WhenTryExceptionMap(_ => Test.XException);

            outcome.Result.Should().BeEquivalentTo(Test.T);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void WhenTryExceptionMap_Exception()
        {
            var outcome = Test.TryTKE_Exception.WhenTryExceptionMap(_ => Test.XException);

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.XException);
        }


        [Test]
        public void WhenMap_Cascade_OK()
        {
            var outcome = Test.TryTKE_OK
                .WhenTryOkMap(_ => Test.KDone)
                .WhenTryExceptionMap(_ => Test.XException);

            outcome.Result.Should().BeEquivalentTo(Test.KDone);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void WhenMap_Cascade_Exception()
        {
            var outcome = Test.TryTKE_Exception
                .WhenTryOkMap(_ => Test.KDone)
                .WhenTryExceptionMap(_ => Test.XException);

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.XException);
        }

        [Test]
        public void ContinueTryWitMaph_OK()
        {
            var outcome = Test.TryTKE_OK
                .ContinueTryWithMap
                (
                    _ => Test.K,
                    _ => Test.XException
                );

            outcome.Result.Should().BeEquivalentTo(Test.K);
            outcome.Error.Should().BeNull();
        }

        [Test]
        public void ContinueTryWithMap_Exception()
        {
            var outcome = Test.TryTKE_Exception
                .ContinueTryWithMap
                (
                    _ => Test.K,
                    _ => Test.XException
                );

            outcome.Result.Should().BeNull();
            outcome.Error.Should().BeEquivalentTo(Test.XException);
        }
    }
}
