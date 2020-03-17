window.__require = function e(t, r, i) {
function n(c, s) {
if (!r[c]) {
if (!t[c]) {
var u = c.split("/");
u = u[u.length - 1];
if (!t[u]) {
var a = "function" == typeof __require && __require;
if (!s && a) return a(u, !0);
if (o) return o(u, !0);
throw new Error("Cannot find module '" + c + "'");
}
c = u;
}
var f = r[c] = {
exports: {}
};
t[c][0].call(f.exports, function(e) {
return n(t[c][1][e] || e);
}, f, f.exports, e, t, r, i);
}
return r[c].exports;
}
for (var o = "function" == typeof __require && __require, c = 0; c < i.length; c++) n(i[c]);
return n;
}({
"test-first": [ function(e, t, r) {
"use strict";
cc._RF.push(t, "912795WyhhNJ7ssdtf4at3V", "test-first");
cc.Class({
extends: cc.Component,
properties: {
tips: e("LabelLocalized")
},
start: function() {
this.tips.textKey = "cases/subpackage1.loaded";
},
goLoadSubpackage: function() {
cc.director.loadScene("Subpackages");
}
});
cc._RF.pop();
}, {
LabelLocalized: void 0
} ]
}, {}, [ "test-first" ]);