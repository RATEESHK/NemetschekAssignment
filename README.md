# NemetschekAssignment

# Array Intersection Finder

This project provides an efficient solution to find the intersection of two unsorted arrays of integers using C#. It is structured to follow SOLID principles and utilizes design patterns for maintainability and scalability.

## Overview

The main objective is to output an array containing the intersection of two input arrays. The solution implements an interface-based design that allows for easy extension and modification.

### Design Principles

1. **Single Responsibility Principle**: Each class and interface has a single responsibility, promoting better organization and maintenance.
2. **Open/Closed Principle**: New intersection strategies can be added without modifying existing code.
3. **Interface Segregation Principle**: Interfaces are specific and focused, making it easier to implement different strategies.

### Components

- **IIntersectionFinder**: An interface defining the contract for finding intersections.
- **IntersectionFinder**: A concrete implementation of `IIntersectionFinder` that uses a `HashSet` for efficient lookups.
- **IIntersectionService**: An interface defining the contract for executing intersection operations.
- **IntersectionProcessor**: A service class that executes the intersection logic and handles exceptions gracefully.

### Algorithm

1. Check for null arrays and throw an exception if found.
2. If either array is empty, return an empty array.
3. Use a `HashSet` to store elements from the first array.
4. Iterate through the second array and check for intersections, adding them to the result list while ensuring uniqueness by removing elements from the set.

### Time Complexity

- The time complexity is **O(n)**, where *n* is the size of the larger array. This accounts for the time taken to populate the `HashSet` and to iterate through the second array for lookups.

### Space Complexity

- The space complexity is **O(n)** in the worst case, as we may store all elements of the larger array in the `HashSet`.

### Usage

1. Compile the project.
2. Run the `Main` method to see the intersection of the example arrays.

### Example

```csharp
int[] array1 = { 4, 9, 5, 1, 2, 9, 5 };
int[] array2 = { 9, 4, 9, 8, 4, 2 };
