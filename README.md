# Branch and Bound Assignment

- Their are three branches for this assignment. You can see these branches in the `Program.cs` file specifically on these three lines. (117, 122, 127).

  1. Add the new car to the *front* of the train.
  2. Add the new car to the *back* of the train.
  3. Do not add the new car at all.

- The bound I found was if best value is greater than the current number of cars in the train + the remaining cars to add then we will always choose the current best value so there is no point in continuing.
You can see this between lines (109 - 112).

- Add my tree as an image at the root of the project named `branchbound-diagram.png`

- You can see my answers to the given inputs in my `BranchBoundTests.cs` file. Also here are the results:

| Output | Input |
| ------ | ----- |
| 7 | 10 11 5 13 15 7 1 18 12 16 17|
| 12 | 25 31 19 17 4 10 37 42 35 15 43 45 30 39 9 21 33 25 3 47 41 50 18 11 26 28 |
| 10 | 10 5 6 4 7 3 8 2 9 1 10 |
|14 | 50 5 24 84 58 21 57 98 51 6 16 75 95 11 23 92 85 29 56 45 55 73 20 4 34 76 96 63 30 93 2 19 39 14 71 80 40 69 54 62 42 1 10 35 8 22 70 67 15 27 38 |
