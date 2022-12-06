function parseString(str) {
  let keyIndex = 0;
  for (let i = 0; i < input.length - 4; i += 1) {
    let seg = input.substring(i, i + 4);
    let isKey = !/(.).*\1/.test(seg);
    if (isKey) {
      keyIndex = i + 4;
      break;
    }
  }
  return keyIndex;
}
parseString(document.getElementsByTagName("pre")[0].textContent.trim());
