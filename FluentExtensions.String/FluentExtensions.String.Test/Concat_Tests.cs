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
        public void ConcatWhenWithValue_SubjectIsStringWithValue(string input, string leftValue, string rightValue)
        {
            var expectedResult = leftValue + input + rightValue;

            var result = input.ConcatWhenWithValue(leftValue, rightValue);
            result.Should().Be(expectedResult);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.Null);
            result.Should().Be(expectedResult);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmpty);
            result.Should().Be(expectedResult);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces);
            result.Should().Be(expectedResult);
        }

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
        public void ConcatWhenWithValue_SubjectIsEmptyStrings(string input, string leftValue, string rightValue)
        {
            var expectedResult = leftValue + input + rightValue;

            var result = input.ConcatWhenWithValue(leftValue, rightValue);
            result.Should().Be(input);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.Null);
            result.Should().Be(expectedResult);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmpty);
            result.Should().Be(input);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces);
            result.Should().Be(input);
        }

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
        public void ConcatWhenWithValue_SubjectIsWhiteSpaceStrings(string input, string leftValue, string rightValue)
        {
            var expectedResult = leftValue + input + rightValue;

            var result = input.ConcatWhenWithValue(leftValue, rightValue);
            result.Should().Be(expectedResult);


            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.Null);
            result.Should().Be(expectedResult);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmpty);
            result.Should().Be(expectedResult);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces);
            result.Should().Be(input);
        }

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
            result.Should().Be(input);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.Null);
            result.Should().Be(input);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmpty);
            result.Should().Be(input);

            result = input.ConcatWhenWithValue(leftValue, rightValue, StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces);
            result.Should().Be(input);
        }


        [TestCase("RIGHTVALUE", "LEFTVALUE")]
        [TestCase("", "LEFTVALUE")]
        [TestCase(" ", "LEFTVALUE")]
        [TestCase(null, "LEFTVALUE")]
        [TestCase("RIGHTVALUE", " ")]
        public void ConcatRightTo(string rightValue, string leftValue)
        {
            var result = rightValue.ConcatRightTo(leftValue);
            if (string.IsNullOrEmpty(rightValue))
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue + rightValue);
        }

        [TestCase("RIGHTVALUE", "LEFTVALUE")]
        [TestCase("", "LEFTVALUE")]
        [TestCase(" ", "LEFTVALUE")]
        [TestCase(null, "LEFTVALUE")]
        [TestCase("RIGHTVALUE", " ")]
        public void ConcatRightTo_WhiteSpacesAsEmpty(string rightValue, string leftValue)
        {
            var result = rightValue.ConcatRightTo(leftValue, StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces);
            if (string.IsNullOrWhiteSpace(rightValue))
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue + rightValue);
        }

        [TestCase("LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "RIGHTVALUE")]
        [TestCase(" ", "RIGHTVALUE")]
        [TestCase(null, "RIGHTVALUE")]
        [TestCase("LEFTVALUE", " ")]
        public void ConcatLeftTo(string leftValue, string rightValue)
        {
            var result = leftValue.ConcatLeftTo(rightValue);
            if (string.IsNullOrEmpty(leftValue))
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue + rightValue);
        }

        [TestCase("LEFTVALUE", "RIGHTVALUE")]
        [TestCase("", "RIGHTVALUE")]
        [TestCase(" ", "RIGHTVALUE")]
        [TestCase(null, "RIGHTVALUE")]
        [TestCase("LEFTVALUE", " ")]
        public void ConcatLeftTo_WhiteSpacesAsEmpty(string leftValue, string rightValue)
        {
            var result = leftValue.ConcatLeftTo(rightValue, StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces);
            if (string.IsNullOrWhiteSpace(leftValue))
                result.Should().BeNullOrWhiteSpace();
            else
                result.Should().Be(leftValue + rightValue);
        }

        [TestCase("RIGHTVALUE", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        [TestCase("", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        [TestCase(" ", "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        [TestCase(null, "APPENDVALUE1;APPENDVALUE2;APPENDVALUE3;APPENDVALUE4")]
        public void ConcatRightToAll_NoSeparator(string rightValue, string values)
        {
            var testList = values.Split(";");
            var result = rightValue.ConcatRightToAll(testList);

            if (rightValue.IsNullOrEquivalent())
                result.Should().AllSatisfy(_ => _.IsNullOrEquivalent());
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
        public void ConcatRightToAll_WithSeparator(string rightValue, string values, string separator)
        {
            var testList = values.Split(";");
            var result = rightValue.ConcatRightToAll(testList, separator);
            if (rightValue.IsNullOrEquivalent())
                result.Should().AllSatisfy(_ => _.IsNullOrEquivalent());
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
        public void ConcatLeftToAll_NoSeparator(string leftValue, string values)
        {
            var testList = values.Split(";");
            var result = leftValue.ConcatLeftToAll(testList);

            if (leftValue.IsNullOrEquivalent())
                result.Should().AllSatisfy(_ => _.IsNullOrEquivalent());
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
        public void ConcatLeftToAll_WithSeparator(string leftValue, string values, string separator)
        {
            var testList = values.Split(";");
            var result = leftValue.ConcatLeftToAll(testList, separator);
            if (leftValue.IsNullOrEquivalent())
                result.Should().AllSatisfy(_ => _.IsNullOrEquivalent());
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
