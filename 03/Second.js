const abc = Array.from(Array(26)).reduce((a, b, i) => {
  a[String.fromCharCode(i + 65)] = i + 1;
  return a;
}, {});

document
  .getElementsByTagName("pre")[0]
  .textContent.split("\n")
  .filter((l) => l)
  .reduce((a, b, i) => {
    const arr = a[Math.floor(i / 3)] ?? [];
    arr.push(b);
    a[Math.floor(i / 3)] = arr;
    return a;
  }, [])
  .map(
    (a) => a[0].split("").filter((l) => a[1].includes(l) && a[2].includes(l))[0]
  )
  .map((l) =>
    l === l.toUpperCase() ? abc[l.toUpperCase()] + 26 : abc[l.toUpperCase()]
  )
  .reduce((a, b) => a + b, 0);
