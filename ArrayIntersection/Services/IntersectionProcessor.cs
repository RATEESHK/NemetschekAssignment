using ArrayIntersection.IntersectionOperations.Interfaces;
using ArrayIntersection.Services.Interfaces;

namespace ArrayIntersection.Services
{
    public class IntersectionProcessor : IIntersectionService
    {
        private readonly IIntersectionFinder _intersectionFinder;

        public IntersectionProcessor(IIntersectionFinder intersectionFinder) => _intersectionFinder = intersectionFinder ?? throw new ArgumentNullException(nameof(intersectionFinder), "IntersectionFinder cannot be null.");

        public void Execute(int[] array1, int[] array2)
        {
            try
            {
                int[] result = _intersectionFinder.FindIntersection(array1, array2);
                Console.WriteLine("Intersection: " + string.Join(", ", result));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}