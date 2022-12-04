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
    if (
      (pair[0].start > pair[1].start && pair[0].end < pair[1].end) ||
      (pair[1].start > pair[0].start && pair[1].end < pair[0].end)
    )
      a++;
    return a;
  }, 0);
