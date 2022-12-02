document
  .getElementsByTagName("pre")[0]
  .textContent.split("\n\n")
  .map((arr) => arr.split("\n").reduce((a, b) => (b ? a + parseInt(b) : a), 0))
  .sort((a, b) => b - a)
  .splice(0, 3)
  .reduce((a, b) => a + b, 0);
