using ArrayIntersection.IntersectionOperations;
using ArrayIntersection.IntersectionOperations.Interfaces;
using ArrayIntersection.Services;
using ArrayIntersection.Services.Interfaces;

//int[] array1 = { 4, 9, 5, 1, 2, 9, 5 };
//int[] array2 = { 9, 4, 9, 8, 4, 2 };
int[] array1 = { };
int[] array2 = { };
IIntersectionFinder finder = new IntersectionFinder();
IIntersectionService processor = new IntersectionProcessor(finder);

try
{
    processor.Execute(array1, array2);
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Handled exceptions: {ex.Message}");
}