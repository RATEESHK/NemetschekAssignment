using ArrayIntersection.IntersectionOperations.Interfaces;
using ArrayIntersection.Services;
using ArrayIntersection.Services.Interfaces;
using FluentAssertions;
using Moq;

namespace ArrayIntersection.Tests.Services
{
    [TestFixture]
    public class IntersectionProcessorTests
    {
        private Mock<IIntersectionFinder> _mockFinder;
        private IIntersectionService _intersectionProcessor;

        [SetUp]
        public void Setup()
        {
            _mockFinder = new Mock<IIntersectionFinder>();
            _intersectionProcessor = new IntersectionProcessor(_mockFinder.Object);
        }

        [Test]
        public void Execute_WithCommonElements_PrintsIntersection()
        {
            // Arrange
            int[] array1 = { 4, 9, 5, 1, 2, 9, 5 };
            int[] array2 = { 9, 4, 9, 8, 4, 2 };
            int[] expectedResult = { 9, 4 };

            _mockFinder.Setup(f => f.FindIntersection(array1, array2)).Returns(expectedResult);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                _intersectionProcessor.Execute(array1, array2);

                // Assert
                sw.ToString().Trim().Should().Be("Intersection: 9, 4");
            }
        }

        [Test]
        public void Execute_WithNoCommonElements_PrintsEmptyIntersection()
        {
            // Arrange
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };
            int[] expectedResult = { };

            _mockFinder.Setup(f => f.FindIntersection(array1, array2)).Returns(expectedResult);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                _intersectionProcessor.Execute(array1, array2);

                // Assert
                sw.ToString().Should().Be("Intersection: \r\n");
            }
        }

        [Test]
        public void Execute_WithEmptyArrays_PrintsEmptyIntersection()
        {
            // Arrange
            int[] array1 = { };
            int[] array2 = { };

            _mockFinder.Setup(f => f.FindIntersection(array1, array2)).Returns(new int[0]);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                _intersectionProcessor.Execute(array1, array2);

                // Assert
                sw.ToString().Should().Be("Intersection: \r\n");
            }
        }

        [Test]
        public void Execute_WithNullFirstArray_PrintsErrorMessage()
        {
            // Arrange
            int[] array1 = null;
            int[] array2 = { 1, 2, 3 };

            _mockFinder.Setup(f => f.FindIntersection(array1, array2)).Throws(new ArgumentNullException("array1", "Input arrays cannot be null."));

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _intersectionProcessor.Execute(array1, array2);

                // Assert
                sw.ToString().Trim().Should().Contain("Error: Input arrays cannot be null.");
            }
        }

        [Test]
        public void Execute_WithNullSecondArray_PrintsErrorMessage()
        {
            // Arrange
            int[] array1 = { 1, 2, 3 };
            int[] array2 = null;

            _mockFinder.Setup(f => f.FindIntersection(array1, array2)).Throws(new ArgumentNullException("array2", "Input arrays cannot be null."));

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _intersectionProcessor.Execute(array1, array2);

                // Assert
                sw.ToString().Trim().Should().Contain("Error: Input arrays cannot be null.");
            }
        }

        [Test]
        public void Execute_WithValidInput_ShouldHandleUnexpectedExceptions()
        {
            // Arrange
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };

            // Setup to throw an unexpected exception
            _mockFinder.Setup(f => f.FindIntersection(array1, array2)).Throws(new Exception("Unexpected error"));

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                _intersectionProcessor.Execute(array1, array2);

                // Assert
                sw.ToString().Trim().Should().Contain("An unexpected error occurred: Unexpected error");
            }
        }
    }
}
