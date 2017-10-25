"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var genericClass = /** @class */ (function () {
    function genericClass() {
    }
    genericClass.prototype.setVal = function (val) {
        this.val = val;
    };
    genericClass.prototype.getVal = function () {
        return this.val;
    };
    return genericClass;
}());
var Rotater = /** @class */ (function () {
    function Rotater() {
    }
    Rotater.prototype.rotate = function (elem) {
        elem.style.transform = "rotate(-315deg)";
    };
    Rotater.prototype.rotateBack = function (elem) {
        elem.style.transform = "";
    };
    return Rotater;
}());
var Mover = /** @class */ (function () {
    function Mover() {
    }
    Mover.prototype.move = function (elem) {
        elem.style.transform = "translateX(50px)";
    };
    Mover.prototype.moveBack = function (elem) {
        elem.style.transform = "";
    };
    return Mover;
}());
function animated(target) {
    var Animatable = /** @class */ (function (_super) {
        __extends(Animatable, _super);
        function Animatable() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Animatable.rawr = function () {
            console.log("RAWR");
        };
        return Animatable;
    }(target));
    return Animatable;
}
var movingElement = /** @class */ (function () {
    function movingElement(elem) {
        var _this = this;
        elem.onmousedown = function () {
            _this.move(elem);
        };
        elem.onmouseup = function () {
            _this.moveBack(elem);
        };
        elem.onmouseover = function () {
            _this.rotate(elem);
        };
        elem.onmouseout = function () {
            _this.rotateBack(elem);
        };
        if (this.animated) {
            elem.style.transition = "transform 3s ease";
        }
        this.element = elem;
    }
    movingElement = __decorate([
        animated
    ], movingElement);
    return movingElement;
}());
var element1 = new genericClass();
var element2 = new genericClass();
var element3 = new genericClass();
element1.setVal(document.createElement('div'));
element2.setVal(document.createElement('div'));
element3.setVal(document.createElement('div'));
var elementArray = [
    element1.getVal(),
    element2.getVal(),
    element3.getVal(),
];
function isHTMLElement(x) {
    return x.style !== undefined;
}
function convertElement(elem) {
    if (!isHTMLElement(elem)) {
        return elem;
    }
    else {
        return elem;
    }
}
function standardizeElements(elemArray) {
    for (var _i = 0, elemArray_1 = elemArray; _i < elemArray_1.length; _i++) {
        var elem = elemArray_1[_i];
        convertElement(elem);
    }
    return elemArray;
}
var standardElements = standardizeElements(elementArray);
function applyMixins(derivedClass, baseClasses) {
    baseClasses.forEach(function (baseClass) {
        Object.getOwnPropertyNames(baseClass.prototype).forEach(function (name) {
            derivedClass.prototype[name] = baseClass.prototype[name];
        });
    });
}
applyMixins(movingElement, [Mover, Rotater]);
for (var _i = 0, standardElements_1 = standardElements; _i < standardElements_1.length; _i++) {
    var elem = standardElements_1[_i];
    elem.style.width = "60px";
    elem.style.height = "60px";
    elem.style.backgroundColor = "green";
    elem.style.margin = "5px";
    var elemClass = new movingElement(elem);
    document.body.appendChild(elemClass.element);
}
//# sourceMappingURL=advancedTypeScriptLab.js.map