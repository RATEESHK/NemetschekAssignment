using ArrayIntersection.IntersectionOperations;
using ArrayIntersection.IntersectionOperations.Interfaces;
using FluentAssertions;

namespace ArrayIntersection.Tests.IntersectionOperations
{
    [TestFixture]
    public class IntersectionFinderTests
    {
        private IIntersectionFinder _intersectionFinder;

        [SetUp]
        public void Setup()
        {
            _intersectionFinder = new IntersectionFinder();
        }

        [Test]
        public void FindIntersection_WithCommonElements_ReturnsIntersection()
        {
            // Arrange
            int[] array1 = { 4, 9, 5, 1, 2, 9, 5 };
            int[] array2 = { 9, 4, 9, 8, 4, 2 };
            int[] expectedResult = { 9, 4, 2 };

            // Act
            int[] result = _intersectionFinder.FindIntersection(array1, array2);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void FindIntersection_WithNoCommonElements_ReturnsEmptyArray()
        {
            // Arrange
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };

            // Act
            int[] result = _intersectionFinder.FindIntersection(array1, array2);

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void FindIntersection_WithEmptyArrays_ReturnsEmptyArray()
        {
            // Arrange
            int[] array1 = { };
            int[] array2 = { };

            // Act
            int[] result = _intersectionFinder.FindIntersection(array1, array2);

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void FindIntersection_WithNullFirstArray_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array1 = null;
            int[] array2 = { 1, 2, 3 };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _intersectionFinder.FindIntersection(array1, array2));
        }

        [Test]
        public void FindIntersection_WithNullSecondArray_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array1 = { 1, 2, 3 };
            int[] array2 = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _intersectionFinder.FindIntersection(array1, array2));
        }
    }
}
