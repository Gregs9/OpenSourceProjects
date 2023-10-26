"use strict";

//Steek elementen die regelmatig opgeroepen moeten worden in een variable
const ele_sel = document.getElementById('groente');
const ele_knop = document.getElementById("toevoegen");
const ele_aantal = document.getElementById("aantal");
const ele_melding = document.getElementById("melding")

//Lees het json bestand in
leesData();

//initialiseer 2 arrays, 1 voor de databank van groenten, 1 voor de winkelmand
const arr_groenten = [];
const arr_winkelmand = [];

//Voeg event handler toe aan knop
ele_knop.onclick = function () {
    if (valideerInput() === true) {

        //Voeg het geselecteerde item en aantal toe aan de winkelmand
        voegToeAanWinkelmand(ele_sel.value, Number(ele_aantal.value));

        //Toon dat het item correct is toegevoegd aan het winkelmandje
        ele_melding.innerText = "Item toegevoegd aan winkelmandje!"
        ele_melding.hidden = false;
        ele_melding.style.color = "green";
    }
}

function valideerInput() {
    let valid = true;

    //verberg de melding
    ele_melding.hidden = true;

    //controleer dat er iets is geselecteerd in de select
    if (ele_sel.value === "") {
        valid = false;
        ele_melding.innerText = "U heeft geen item geselecteerd!"
        ele_melding.hidden = false;
        ele_melding.style.color = "red";
    }

    //controleer dat alle html attributen van het aantal voldaan zijn
    if (ele_aantal.checkValidity() === false) {
        valid = false;
        ele_melding.innerText = "Het gegeven aantal klopt niet! (1-99)";
        ele_melding.hidden = false;
        ele_melding.style.color = "red";
    }
    return valid;
}

async function leesData() {
    //Get JSON data
    const response = await fetch("scripts/groenten.json");

    //IF JSON data has been succesfully received
    if (response.ok) {
        const groenten = await response.json();

        //voeg groente toe aan de select, en steek de data in een array voor latere berekeningen
        for (const groente of groenten) {
            createSelect(groente);
            arr_groenten.push(groente);
        }
    }
}

//Crëer een optie in de select
function createSelect(groente) {
    const opt = document.createElement("option");
    opt.innerText = groente.naam + " (" + groente.prijs + "/" + groente.eenheid + ")";
    opt.value = groente.naam;
    ele_sel.appendChild(opt);
}

//Voeg gegeven item toe aan winkelmand
function voegToeAanWinkelmand(groente, pr_aantal) {
    //zoek de data van de geselecteerde groente
    let data_index = -1
    for (let i = 0; i < arr_groenten.length; i++) {
        if (arr_groenten[i].naam === groente) {
            data_index = i;
        }
    }
    //controleer als het winkelmandje de groente al bevat
    let gevonden_index = -1;
    for (let i = 0; i < arr_winkelmand.length; i++) {
        if (arr_winkelmand[i].naam === groente) {
            gevonden_index = i;
        }
    }
    //Als het winkelmandje de groente el bevat, tel het aantal op
    if (gevonden_index !== -1) {
        arr_winkelmand[gevonden_index].aantal += pr_aantal;
    } else {
        //Als het winkelmandje de groente nog niet bevat, voeg het toe met het gegeven aantal
        arr_winkelmand.push({ naam: groente, aantal: pr_aantal, prijs: arr_groenten[data_index].prijs });
    }
    toonArrWinkelmand();
}

function toonArrWinkelmand() {
    //Verwijder eventueel bestaande data
    var table = document.getElementById("winkelmand");
    while (table.rows.length > 1) {
        table.deleteRow(table.rows.length - 1);
    }

    //Voor elk element in arr_winkelmand, voeg het toe aan de table
    for (const x of arr_winkelmand) {
        //Steek de table in een variable
        const table = document.getElementById("winkelmand");

        //toon de table zodra er content aanwezig is
        table.hidden = false;

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
        img_vuilbak.src = "img/vuilbak.png";
        img_vuilbak.onclick = function () {
            //verwijder de rij uit de table en de data uit de array
            arr_winkelmand.splice((row.rowIndex - 1),1);
            toonArrWinkelmand();
            console.log(table.rows.length);

            //verberg de table als er geen content is
            if (table.rows.length === 2) {
                table.hidden = true;
            }

        }
        cell4.appendChild(img_vuilbak);
    }

    //Creër een table foot met het totaal bedrag
    let footer = table.createTFoot();
    let row = footer.insertRow(0);

    //Insert "Totaal" in cell[0] van de nieuwe rij
    let cell0 = row.insertCell(0);
    cell0.innerHTML = "Totaal";

    //Insert bedrag in cell[1] van de nieuwe rij
    let cell1 = row.insertCell(1);
    cell1.colSpan = 3;
    let totaal = 0;
    for (const x of arr_winkelmand) {
        totaal += (x.prijs * x.aantal);
    }
    cell1.innerHTML = "€" + totaal.toFixed(2);

    //Voeg een lege cel toe
    let cell2 = row.insertCell(2);
    cell2.innerHTML = "";
}