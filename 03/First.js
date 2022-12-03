const abc = Array.from(Array(26)).reduce((a, b, i) => {
  a[String.fromCharCode(i + 65)] = i + 1;
  return a;
}, {});

document
  .getElementsByTagName("pre")[0]
  .textContent.split("\n")
  .filter((l) => l)
  .map(
    (s) =>
      s
        .slice(0, s.length / 2)
        .split("")
        .filter((l) => s.slice(s.length / 2).includes(l))[0]
  )
  .map((l) =>
    l === l.toUpperCase() ? abc[l.toUpperCase()] + 26 : abc[l.toUpperCase()]
  )
  .reduce((a, b) => a + b, 0);
