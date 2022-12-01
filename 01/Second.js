/*
    Browser console solution, go to https://adventofcode.com/2022/day/1/input.
    Paste this in the console and you will get the answer for part 2 of day 1.
*/
let dreamteamWeight = 0;
let elfs = input
  .getElementsByTagName("pre")[0]
  .textContent.split("\n\n")
  .map((arr) => arr.split("\n").reduce((a, b) => (b ? a + parseInt(b) : a), 0));

for (let i = 0; i < 3; i++) {
  dreamteamWeight =
    dreamteamWeight + parseInt(elfs.splice(elfs.indexOf(Math.max(...elfs)), 1));
}

console.log(dreamteamWeight);
