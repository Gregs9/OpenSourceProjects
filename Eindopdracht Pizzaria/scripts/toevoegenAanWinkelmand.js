"use strict";

let arr_winkelmand = [];

//load local storage if it is set
loadOrderCookie();
toonCaddy();
hideCaddyIfEmpty();

console.table(arr_winkelmand);

const all_pizzas = document.getElementsByClassName('pizza-info');
for (const pizza of all_pizzas) {
    pizza.onclick = function () {
        voegToeAanCaddy(pizza.dataset.id, pizza.dataset.naam, pizza.dataset.prijs);
        saveCaddyAsCookie();
        hideCaddyIfEmpty();
    }
}

function hideCaddyIfEmpty() {
    if (document.getElementById("selectie").rows.length <= 2) {
        document.getElementById("caddy").style.display = 'none';
    } else {
        document.getElementById("caddy").style.display = 'block';
    }

    /*Get amount of pizzas in arr_winkelmand*/
    let aantalPizzas = 0;
    for (const pizza of arr_winkelmand) {
        aantalPizzas += pizza.aantal;
    }


    document.getElementById('aantal').innerText = aantalPizzas + ' items';
}

function voegToeAanCaddy(pizzaId, pizzaNaam, pizzaPrijs) {
    //controleer als het winkelmandje de pizza al bevat
    let gevonden_index = -1;
    for (let i = 0; i < arr_winkelmand.length; i++) {
        if (arr_winkelmand[i].id === pizzaId) {
            gevonden_index = i;
        }
    }
    //Als het winkelmandje de pizza al bevat, tel het aantal op
    if (gevonden_index !== -1) {
        arr_winkelmand[gevonden_index].aantal++;
    } else {
        //Als het winkelmandje de pizza nog niet bevat, voeg het toe met het aantal 1
        arr_winkelmand.push({ id: pizzaId, naam: pizzaNaam, aantal: 1, prijs: pizzaPrijs });
    }

    toonCaddy();
}

function toonCaddy() {

    let table = document.getElementById("selectie");

    //Verwijder eventueel bestaande data
    while (table.rows.length > 1) {
        table.deleteRow(table.rows.length - 1);
    }

    //Voor elk element in arr_winkelmand, voeg het toe aan de table
    for (const x of arr_winkelmand) {

        //Insert een lege rij en voeg deze onderaan toe
        let row = table.insertRow(-1);
        //Insert naam in cell[0] van de nieuwe rij
        let cell0 = row.insertCell(0);
        cell0.innerHTML = x.naam;
        //Insert aantal in cell[1] van de nieuwe rij
        let cell1 = row.insertCell(1);
        cell1.innerHTML = x.aantal;
        //Insert prijs in cell[2] van de nieuwe rij
        let cell2 = row.insertCell(2);
        cell2.innerHTML = "€" + x.prijs;
        //Insert prijs in cell[3] van de nieuwe rij
        let cell3 = row.insertCell(3);
        cell3.innerHTML = "€" + (x.aantal * x.prijs).toFixed(2);
        //insert afbeelding in cell[4] van de nieuwe rij
        let cell4 = row.insertCell(4);
        let img_vuilbak = document.createElement("img");
        img_vuilbak.src = "assets/vuilbak.png";
        img_vuilbak.onclick = function () {
            //verwijder de rij uit de table en de data uit de array
            arr_winkelmand.splice((row.rowIndex - 1), 1);
            toonCaddy();
            saveCaddyAsCookie();
            hideCaddyIfEmpty();

        }
        cell4.appendChild(img_vuilbak);
    }

    //Creër een table foot met het totaal bedrag
    let footer = table.createTFoot();
    let row = footer.insertRow(0);

    //Insert "Totaal" in cell[0] van de nieuwe rij
    let cell0 = row.insertCell(0);
    cell0.innerHTML = "<strong>Totaal</strong>";

    //Insert bedrag in cell[1] van de nieuwe rij
    let cell1 = row.insertCell(1);
    cell1.colSpan = 4;
    let totaal = 0;
    for (const x of arr_winkelmand) {
        totaal += (x.prijs * x.aantal);
    }
    cell1.innerHTML = "<strong>€" + totaal.toFixed(2) + "</strong>";

    //Voeg een lege cel toe
    let cell2 = row.insertCell(2);
    cell2.innerHTML = "";
}

function loadOrderCookie() {
    let name = "order=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            arr_winkelmand = JSON.parse(c.substring(name.length, c.length));
        }
    }
}

function saveCaddyAsCookie() {
    document.cookie = "order=" + JSON.stringify(arr_winkelmand);
}

document.getElementById('caddy-icon-container').onclick = function () {
    if (document.getElementById("caddy").style.display == 'none') {
        document.getElementById("caddy").style.display = 'block';
    } else {
        document.getElementById("caddy").style.display = 'none';
    }
}