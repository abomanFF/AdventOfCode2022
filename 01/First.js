Math.max(
  ...document
    .getElementsByTagName("pre")[0]
    .textContent.split("\n\n")
    .map((arr) =>
      arr.split("\n").reduce((a, b) => (b ? a + parseInt(b) : a), 0)
    )
);
