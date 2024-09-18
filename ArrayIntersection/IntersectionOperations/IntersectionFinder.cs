using ArrayIntersection.IntersectionOperations.Interfaces;

namespace ArrayIntersection.IntersectionOperations
{
    public class IntersectionFinder : IIntersectionFinder
    {
        public int[] FindIntersection(int[] array1, int[] array2)
        {
            if (array1 == null || array2 == null)
            {
                throw new ArgumentNullException(array1 == null ? nameof(array1) : nameof(array2), "Input arrays cannot be null.");
            }

            if (array1.Length == 0 || array2.Length == 0)
            {
                return Array.Empty<int>();
            }

            HashSet<int> set = new HashSet<int>(array1);
            List<int> intersection = new List<int>();

            foreach (int num in array2)
            {
                if (set.Contains(num))
                {
                    intersection.Add(num);
                    set.Remove(num); // Optional: To avoid duplicates in result
                }
            }

            return intersection.ToArray();
        }
    }
}