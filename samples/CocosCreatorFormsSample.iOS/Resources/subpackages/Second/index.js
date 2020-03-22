window.__require = function e(t, r, o) {
function n(i, s) {
if (!r[i]) {
if (!t[i]) {
var u = i.split("/");
u = u[u.length - 1];
if (!t[u]) {
var a = "function" == typeof __require && __require;
if (!s && a) return a(u, !0);
if (c) return c(u, !0);
throw new Error("Cannot find module '" + i + "'");
}
i = u;
}
var p = r[i] = {
exports: {}
};
t[i][0].call(p.exports, function(e) {
return n(t[i][1][e] || e);
}, p, p.exports, e, t, r, o);
}
return r[i].exports;
}
for (var c = "function" == typeof __require && __require, i = 0; i < o.length; i++) n(o[i]);
return n;
}({
"test-second": [ function(e, t, r) {
"use strict";
cc._RF.push(t, "f43242HNENDFpDggQECDo13", "test-second");
cc.Class({
extends: cc.Component,
properties: {
tips: e("LabelLocalized")
},
start: function() {
this.tips.textKey = "cases/subpackage2.loaded";
},
goLoadSubpackage: function() {
cc.director.loadScene("Subpackages");
}
});
cc._RF.pop();
}, {
LabelLocalized: void 0
} ]
}, {}, [ "test-second" ]);