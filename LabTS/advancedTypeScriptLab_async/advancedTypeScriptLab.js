"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class genericClass {
    setVal(val) {
        this.val = val;
    }
    getVal() {
        return this.val;
    }
}
class Rotater {
    rotate(elem) {
        elem.style.transform = "rotate(-315deg)";
    }
    rotateBack(elem) {
        elem.style.transform = "";
    }
}
class Mover {
    move(elem) {
        elem.style.transform = "translateX(50px)";
    }
    moveBack(elem) {
        elem.style.transform = "";
    }
}
function animated(target) {
    class Animatable extends target {
        static rawr() {
            console.log(`RAWR`);
        }
    }
    return Animatable;
}
let movingElement = class movingElement {
    constructor(elem) {
        elem.onmousedown = () => {
            this.move(elem);
        };
        elem.onmouseup = () => {
            this.moveBack(elem);
        };
        elem.onmouseover = () => {
            this.rotate(elem);
        };
        elem.onmouseout = () => {
            this.rotateBack(elem);
        };
        if (this.animated) {
            elem.style.transition = "transform 3s ease";
        }
        this.element = elem;
    }
};
movingElement = __decorate([
    animated
], movingElement);
let element1 = new genericClass();
let element2 = new genericClass();
let element3 = new genericClass();
element1.setVal(document.createElement('div'));
element2.setVal(document.createElement('div'));
element3.setVal(document.createElement('div'));
let elementArray = [
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
    for (let elem of elemArray) {
        convertElement(elem);
    }
    return elemArray;
}
let standardElements = standardizeElements(elementArray);
function applyMixins(derivedClass, baseClasses) {
    baseClasses.forEach(baseClass => {
        Object.getOwnPropertyNames(baseClass.prototype).forEach(name => {
            derivedClass.prototype[name] = baseClass.prototype[name];
        });
    });
}
applyMixins(movingElement, [Mover, Rotater]);
for (let elem of standardElements) {
    elem.style.width = "60px";
    elem.style.height = "60px";
    elem.style.margin = "5px";
    let elemClass = new movingElement(elem);
    getAvatar_Async(elemClass.element);
}
function getAvatar_Async(elem) {
    return __awaiter(this, void 0, void 0, function* () {
        let uiName = yield fetch('https://uinames.com/api/');
        let avatarName = yield uiName.json();
        alert('Hi! My name is ' + avatarName.name);
        let avatar = 'https://robohash.org/set_set3/' + avatarName.name + '?size=60x60';
        elem.style.backgroundImage = 'url("' + avatar + '")';
        document.body.appendChild(elem);
    });
}
//# sourceMappingURL=advancedTypeScriptLab.js.map