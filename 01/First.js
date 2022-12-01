/*
    Browser console solution, go to https://adventofcode.com/2022/day/1/input.
    Paste this in the console and you will get the answer for part 1 of day 1.
*/
console.log(
  Math.max(
    ...document
      .getElementsByTagName("pre")[0]
      .textContent.split("\n\n")
      .map((arr) =>
        arr.split("\n").reduce((a, b) => (b ? a + parseInt(b) : a), 0)
      )
  )
);
