document
  .getElementsByTagName("pre")[0]
  .textContent.split("\n")
  .filter((l) => l)
  .map((p) => p.split(","))
  .map((a) =>
    a.map((b) => ({
      start: parseInt(b.split("-")[0]),
      end: parseInt(b.split("-")[1]),
    }))
  )
  .reduce((a, pair) => {
    const first = pair[0],
      second = pair[1];
    if (
      (first.start >= second.start && first.start <= second.end) ||
      (first.end >= second.start && first.end <= second.end) ||
      (second.start >= first.start && second.start <= first.end) ||
      (second.end >= first.start && second.end <= first.end)
    )
      a++;
    return a;
  }, 0);
