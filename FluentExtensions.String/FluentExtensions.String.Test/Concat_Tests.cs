using FluentAssertions;
using FluentCoding;
using FluentCoding.String;

namespace FluentExtensions.String.Test
{
    public class Concat_Tests
    {
        [TestCase("INPUT", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("INPUT", "LEFTVALUE", "")]
        [TestCase("INPUT", "", "RIGHTVALUE")]
        [TestCase("INPUT", "", "")]
        [TestCase("INPUT", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("INPUT", "LEFTVALUE", " ")]
        [TestCase("INPUT", " ", "RIGHTVALUE")]
        [TestCase("INPUT", " ", " ")]
        [TestCase("INPUT", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("INPUT", "LEFTVALUE", null)]
        [TestCase("INPUT", null, "RIGHTVALUE")]
        [TestCase("INPUT", null, null)]

        [TestCase("", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "LEFTVALUE", "")]
        [TestCase("", "", "RIGHTVALUE")]
        [TestCase("", "", "")]
        [TestCase("", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "LEFTVALUE", " ")]
        [TestCase("", " ", "RIGHTVALUE")]
        [TestCase("", " ", " ")]
        [TestCase("", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "LEFTVALUE", null)]
        [TestCase("", null, "RIGHTVALUE")]
        [TestCase("", null, null)]

        [TestCase(" ", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(" ", "LEFTVALUE", "")]
        [TestCase(" ", "", "RIGHTVALUE")]
        [TestCase(" ", "", "")]
        [TestCase(" ", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(" ", "LEFTVALUE", " ")]
        [TestCase(" ", " ", "RIGHTVALUE")]
        [TestCase(" ", " ", " ")]
        [TestCase(" ", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(" ", "LEFTVALUE", null)]
        [TestCase(" ", null, "RIGHTVALUE")]
        [TestCase(" ", null, null)]

        [TestCase(null, "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(null, "LEFTVALUE", "")]
        [TestCase(null, "", "RIGHTVALUE")]
        [TestCase(null, "", "")]
        [TestCase(null, "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(null, "LEFTVALUE", " ")]
        [TestCase(null, " ", "RIGHTVALUE")]
        [TestCase(null, " ", " ")]
        [TestCase(null, "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(null, "LEFTVALUE", null)]
        [TestCase(null, null, "RIGHTVALUE")]
        [TestCase(null, null, null)]
        public void ConcatWhenWithValue_Trim_Tests(string input, string leftValue, string rightValue)
        {            
            var result = input.ConcatWhenWithValue(leftValue, rightValue);
            if (input.IsNullOrDefault())
                result.Should().BeNullOrWhiteSpace(); 
            else
                result.Should().Be(leftValue.Or("") + input+ rightValue.Or(""));
        }


        [TestCase("INPUT", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("INPUT", "LEFTVALUE", "")]
        [TestCase("INPUT", "", "RIGHTVALUE")]
        [TestCase("INPUT", "", "")]
        [TestCase("INPUT", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("INPUT", "LEFTVALUE", " ")]
        [TestCase("INPUT", " ", "RIGHTVALUE")]
        [TestCase("INPUT", " ", " ")]
        [TestCase("INPUT", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("INPUT", "LEFTVALUE", null)]
        [TestCase("INPUT", null, "RIGHTVALUE")]
        [TestCase("INPUT", null, null)]

        [TestCase("", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "LEFTVALUE", "")]
        [TestCase("", "", "RIGHTVALUE")]
        [TestCase("", "", "")]
        [TestCase("", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "LEFTVALUE", " ")]
        [TestCase("", " ", "RIGHTVALUE")]
        [TestCase("", " ", " ")]
        [TestCase("", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "LEFTVALUE", null)]
        [TestCase("", null, "RIGHTVALUE")]
        [TestCase("", null, null)]

        [TestCase(" ", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(" ", "LEFTVALUE", "")]
        [TestCase(" ", "", "RIGHTVALUE")]
        [TestCase(" ", "", "")]
        [TestCase(" ", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(" ", "LEFTVALUE", " ")]
        [TestCase(" ", " ", "RIGHTVALUE")]
        [TestCase(" ", " ", " ")]
        [TestCase(" ", "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(" ", "LEFTVALUE", null)]
        [TestCase(" ", null, "RIGHTVALUE")]
        [TestCase(" ", null, null)]

        [TestCase(null, "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(null, "LEFTVALUE", "")]
        [TestCase(null, "", "RIGHTVALUE")]
        [TestCase(null, "", "")]
        [TestCase(null, "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(null, "LEFTVALUE", " ")]
        [TestCase(null, " ", "RIGHTVALUE")]
        [TestCase(null, " ", " ")]
        [TestCase(null, "LEFTVALUE", "RIGHTVALUE")]
        [TestCase(null, "LEFTVALUE", null)]
        [TestCase(null, null, "RIGHTVALUE")]
        [TestCase(null, null, null)]
        public void ConcatWhenWithValue_NoTrim_Tests(string input, string leftValue, string rightValue)
        {            
            var result = input.ConcatWhenWithValue(leftValue, rightValue, false);
            if (input.IsNullOrDefault())
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue+ input + rightValue);
        }

        [TestCase("RIGHTVALUE", "LEFTVALUE")]
        [TestCase("", "LEFTVALUE")]
        [TestCase(" ", "LEFTVALUE")]
        [TestCase(null, "LEFTVALUE")]
        public void AppendRightToWhenWithValue(string rightValue, string leftValue)
        {
            var result = rightValue.ConcatRightToWhenWithValue(leftValue);
            if (rightValue.IsNullOrDefault())
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue + rightValue);
        }

        [TestCase("LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "RIGHTVALUE")]
        [TestCase(" ", "RIGHTVALUE")]
        [TestCase(null, "RIGHTVALUE")]
        public void AppendLeftToWhenWithValue(string leftValue, string rightValue)
        {
            var result = leftValue.ConcatLeftToWhenWithValue(rightValue);
            if (leftValue.IsNullOrDefault())
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue + rightValue);
        }


        [TestCase("RIGHTVALUE", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        [TestCase("", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        [TestCase(" ", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        [TestCase(null, "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        public void AppendRightToAll_NoSeparator(string rightValue, string values)
        {
            var testList = values.Split(";");
            var result = rightValue.ConcatRightToAll(testList);

            if (rightValue.IsNullOrDefault())
                result.Should().AllSatisfy(_ => _.IsNullOrDefault());
            else
            {
                result.Should().AllSatisfy(_ =>
                {
                    _.Should().EndWith(rightValue);
                    _.Should().StartWith("APPENDVALUE");
                });
            }
        }

        [TestCase("RIGHTVALUE", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4", "_")]
        [TestCase("", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4", "_")]
        [TestCase(" ", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4", "_")]
        [TestCase(null, "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4", "_")]
        public void AppendRightToAll_WithSeparator(string rightValue, string values, string separator)
        {
            var testList = values.Split(";");
            var result = rightValue.ConcatRightToAll(testList, separator);
            if (rightValue.IsNullOrDefault())
                result.Should().AllSatisfy(_ => _.IsNullOrDefault());
            else
            {
                result.Should().AllSatisfy(_ =>
                {
                    _.Should().EndWith($"{separator}{rightValue}");
                    _.Should().StartWith("APPENDVALUE");
                });
            }
        }


        [TestCase("LEFTVALUE", "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE")]
        [TestCase("", "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE")]
        [TestCase(" ", "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE")]
        [TestCase(null, "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE")]
        public void AppendLeftToAll_NoSeparator(string leftValue, string values)
        {
            var testList = values.Split(";");
            var result = leftValue.ConcatLeftToAll(testList);

            if (leftValue.IsNullOrDefault())
                result.Should().AllSatisfy(_ => _.IsNullOrDefault());
            else
            {
                result.Should().AllSatisfy(_ =>
                {
                    _.Should().StartWith(leftValue);
                    _.Should().EndWith("APPENDVALUE");
                });
            }
        }

        [TestCase("LEFTVALUE", "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE", "_")]
        [TestCase("", "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE", "_")]
        [TestCase(" ", "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE", "_")]
        [TestCase(null, "1APPENDVALUE;2APPENDVALUE;3APPENDVALUE;4APPENDVALUE", "_")]
        public void AppendLeftToAll_WithSeparator(string leftValue, string values, string separator)
        {
            var testList = values.Split(";");
            var result = leftValue.ConcatLeftToAll(testList, separator);
            if (leftValue.IsNullOrDefault())
                result.Should().AllSatisfy(_ => _.IsNullOrDefault());
            else
            {
                result.Should().AllSatisfy(_ =>
                {
                    _.Should().StartWith($"{leftValue}{separator}");
                    _.Should().EndWith("APPENDVALUE");
                });
            }
        }
    }
}
