# Brent's Algorithm Library

A pure C# library. No external dependencies except for Microsoft's unit testing. No binaries. Unit tested.

This code is free to use under the MIT license.

## Brent's Algorithm

Brent's Algorithm is an efficient method for cycle detection in iterated function sequences. It improves upon Floyd’s cycle detection algorithm by reducing the number of function calls while maintaining the same O(λ) space complexity. The algorithm is particularly useful in scenarios where a function is repeatedly applied, and the sequence eventually enters a cycle.

### How It Works

1. Initialize two pointers:
   - `tortoise` (slow pointer) starts at `x0`.
   - `hare` (fast pointer) moves twice as fast.
2. Use an exponential search approach:
   - `hare` moves `power` steps ahead, doubling `power` each iteration.
   - If `hare` and `tortoise` meet, a cycle is detected.
3. Determine cycle start (`mu`):
   - Reset `tortoise` to the beginning and advance `hare` by `lambda` steps.
   - Move both one step at a time until they meet again.
4. The distance from the start to the meeting point is `mu`, and the cycle length is `lambda`.

### Code Implementation

The `BrentCycleDetection` class in this library provides a static method `FindCycle<T>` that detects cycles in a function's output sequence.

```csharp
public static CycleDetectionResult FindCycle<T>(T x0, Func<T, T> f)
```
- **Parameters:**
  - `x0`: Initial value.
  - `f`: A function mapping an element to its next state.
- **Returns:**
  - `CycleDetectionResult`, containing:
    - `Mu`: The start index of the cycle.
    - `Lambda`: The cycle length.

### Usage Example

#### Detecting a Simple Cycle in Integer Sequence

```csharp
int x0 = 1;
Func<int, int> f = x => (x * 2) % 5; // Cycle: 2 → 4 → 3 → 1 → 2
CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, f);
Console.WriteLine($"Cycle starts at {result.Mu} and has length {result.Lambda}");
```

#### Detecting a Cycle in a String Sequence

```csharp
string x0 = "A";
Func<string, string> f = s => s == "A" ? "B" : s == "B" ? "C" : "A";
CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, f);
Console.WriteLine($"Cycle starts at {result.Mu} and has length {result.Lambda}");
```

### Unit Tests

The library includes a suite of MSTest unit tests to verify correctness under various conditions:
- Handling null functions.
- Detecting self-loops.
- Detecting cycles with pre-cycles.
- Testing different data types (integers, strings).

To run tests, use:
```sh
dotnet test BrentsAlgorithmTest
```

![AI Image](aiimage.jpg)
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.</br>
Authored by Warren Harding. AI assisted.</br>

