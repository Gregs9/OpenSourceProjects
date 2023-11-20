"use strict";

const path = window.location.pathname;
let page = path.split("/").pop();
page = page.split(".");
page = page[0];

const home = document.getElementById("home");
const promoties = document.getElementById("promoties");
const overons = document.getElementById("overons");

switch (page) {
    case "home":
        geefMakeup(home);
        break;
    case "promoties":
        geefMakeup(promoties);
        break;
    case "overons":
        geefMakeup(overons);
        break;
    default:
        geefMakeup(home);
        break;
}

/*COLOR PALLETTE : #5f1707 #faf0ca*/

function geefMakeup(element) {
    element.style.color = "#5f1707";
    element.style.background = "#faf0ca";
}