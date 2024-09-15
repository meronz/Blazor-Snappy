
export function getElementPosition(elementId) {
  const element = document.getElementById(elementId);
  if (!element) return `0|0|0|0`;
  return `${element.offsetLeft}|${element.offsetTop}|${element.offsetWidth}|${element.offsetHeight}`;
}