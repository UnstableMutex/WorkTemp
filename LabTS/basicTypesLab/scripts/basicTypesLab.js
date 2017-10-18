"use strict";
var color = "green";
var squareSizeNum = 100;
var squareSize = squareSizeNum + "px";
var button = document.createElement('button');
var div = document.createElement('div');
div.style.width = squareSize;
div.style.height = squareSize;
button.textContent = "Change Color";
var colorChange = function (elem, color) {
    elem.style.backgroundColor = color;
    return true;
};
button.onclick = function (event) {
    colorChange(div, color);
};
document.body.appendChild(button);
document.body.appendChild(div);
