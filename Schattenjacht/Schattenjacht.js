"use strict";

class Speelveld {
    #hoogte;
    #breedte;

    setGrootte(hoogte, breedte) {
        this.#hoogte = hoogte;
        this.#breedte = breedte;
    }

    getHoogte() {
        return parseInt(this.#hoogte);
    }

    getBreedte() {
        return parseInt(this.#breedte);
    }

    genereerVeld() {
        for (let y = 0; y < this.#hoogte; y++) {
            for (let x = 0; x < this.#breedte; x++) {
                const cel = new Cel("gras", x, y);
                cel.tekenCel();
            }
            const linebreak = document.createElement("br");
            document.getElementById("speelveld").appendChild(linebreak);
        }
    }

    genereerMuren(aantal) {
        //  Genereer een aantal muren
        //  Maak een matrix met een lijst van alle coordinaten
        let lijst_coordinaten = [];
        for (const cel of document.getElementsByClassName('cel')) {
            const x = cel.dataset.x;
            const y = cel.dataset.y;
            const coordinaten = [x, y];
            lijst_coordinaten.push(coordinaten);
        }
        //  We hebben nu een array met lijst_coordinaten[0] als xpositie en lijst_coordinaten[1] als ypositie

        //Shuffle deze array
        for (let i = lijst_coordinaten.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [lijst_coordinaten[i], lijst_coordinaten[j]] = [lijst_coordinaten[j], lijst_coordinaten[i]];
        }



        // Neem het eerste aantal coordinaten, aangezien de array geshuffled is zullen deze altijd puur willikeurig zijn
        const randomCoordinaten = lijst_coordinaten.slice(0, aantal);
        //  We hebben nu een array van 10 willikeurig coordinaten;

        //  Voor elke coordinaat in deze array, teken een muur op deze positie
        for (const coordinaat of randomCoordinaten) {
            //  Selecteer de cel waar de jager op staat
            const cel = document.querySelector(`.cel[data-x="${coordinaat[0]}"][data-y="${coordinaat[1]}"]`);
            const new_cel = new Cel("muur", cel.dataset.x, cel.dataset.y);
            new_cel.tekenCel();
        }



    }

    genereerSchatten(aantal) {
        //  Genereer een aantal schatten
        //  Maak een matrix met een lijst van alle coordinaten, die geen muren zijn
        let lijst_coordinaten = [];
        for (const cel of document.getElementsByClassName('cel gras')) {
            const x = cel.dataset.x;
            const y = cel.dataset.y;
            const coordinaten = [x, y];
            lijst_coordinaten.push(coordinaten);
        }
        //  We hebben nu een array met lijst_coordinaten[0] als xpositie en lijst_coordinaten[1] als ypositie die geen muren kunnen zijn

        //Shuffle deze array
        for (let i = lijst_coordinaten.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [lijst_coordinaten[i], lijst_coordinaten[j]] = [lijst_coordinaten[j], lijst_coordinaten[i]];
        }

        // Neem het eerste aantal coordinaten, aangezien de array geshuffled is zullen deze altijd puur willikeurig zijn
        const randomCoordinaten = lijst_coordinaten.slice(0, aantal);
        //  We hebben nu een array van 10 willikeurig coordinaten;

        //  Voor elke coordinaat in deze array, teken een schat op deze positie
        for (const coordinaat of randomCoordinaten) {
            const cel = document.querySelector(`.cel[data-x="${coordinaat[0]}"][data-y="${coordinaat[1]}"]`);
            const new_cel = new Cel("schat", cel.dataset.x, cel.dataset.y);
            new_cel.tekenCel();
        }

        //  Toon het te vinden aantal schatten
        document.getElementById("totale-schatten").innerText = aantal;
    }

    controleerVoorSchat(x, y) {
        let gevonden_schatten = parseInt(document.getElementById('gevonden-schatten').innerText);
        const benodigde_schatten = parseInt(document.getElementById('totale-schatten').innerText);

        const cel = document.querySelector(`.cel[data-x="${x}"][data-y="${y}"]`);
        if (cel.classList.contains('schat')) {
            cel.classList.remove('schat');
            gevonden_schatten++;
            sfx.playTreasure();
        }


        document.getElementById('gevonden-schatten').innerText = gevonden_schatten;
        //  controleer als de speler alle schatten heeft gevonden
        if (gevonden_schatten === benodigde_schatten) {
            animaties.startDeathAnimatie();
            music.pause();
            jager.stopAchtervolging();
            document.onkeydown = null;
        }
    }

    bepaalCelGrootte() {
        //  only change cell grootte wanneer deze zichtbaar is 
        if (!document.getElementById('speelveld')) {
            return;
        }
        //get screen width in pixels
        let screenHeight = window.innerHeight;
        let screenWidth = window.innerWidth;

        //substract 50px to have a margin
        screenWidth -= 100;
        screenHeight -= 100;

        //Spread the amount of cells over the available width
        const amountOfCellsWide = document.getElementById('breedte').value;
        const amountOfCellsHigh = document.getElementById('hoogte').value;

        let cell_width = Math.floor(screenWidth / amountOfCellsWide);
        let cell_height = Math.floor(screenHeight / amountOfCellsHigh);

        //get lowest of the two since cells must always be square
        const cell_size = Math.min(cell_width, cell_height);


        for (const cel of document.getElementsByClassName('cel')) {
            cel.style.width = cell_size + "px";
            cel.style.height = cell_size + "px";
        }

        const cel = document.getElementById("speelveld").firstElementChild;
        if (cel) {
            let cel_grootte = cel.style.width;
            let int_cel_grootte = parseInt(cel_grootte.substring(0, cel_grootte.length - 2));
            document.getElementById("game").style.minWidth = (int_cel_grootte * this.#breedte) + "px";
        }

    }

    showUI() {
        //  toon levens & info
        document.getElementById('game').style.display = "inline";
        document.getElementById('levens').style.display = "inline-block";
        document.getElementById('spelinfo').style.display = "inline-block";

        //  verberg startmenu
        document.getElementById('start-menu').style.display = "none";
    }
}

class Cel {
    #type; //Gras, muur of schat
    #xPositie;
    #yPositie;

    constructor(type, x, y) {
        this.#type = type;
        this.#xPositie = x
        this.#yPositie = y;
    }

    getType() {
        return this.#type;
    }

    getxPositie() {
        return this.#xPositie;
    }

    getyPositie() {
        return this.#yPositie;
    }

    tekenCel() {
        const cel = document.querySelector(`.cel[data-x="${this.#xPositie}"][data-y="${this.#yPositie}"]`);

        //  Als de cel al bestaat, verwijder alle properties van deze cel
        if (cel) {
            //Verwijder alle bestaande classes van deze cel
            cel.className = "";

            //Voeg opnieuw het default class "cel" toe
            cel.classList.add("cel");

            //Voeg de nieuwe class toe
            cel.classList.add(this.#type);

            //  Als de cel nog niet bestaat, voeg deze toe aan het einde van het speeldveld
        } else {
            let new_cel = document.createElement("div");
            new_cel.classList.add("cel");


            new_cel.dataset.x = this.#xPositie;
            new_cel.dataset.y = this.#yPositie;
            new_cel.dataset.type = this.#type;

            switch (this.#type) {
                case 'gras':
                    new_cel.classList.add('gras');
                    break;
                case 'muur':
                    new_cel.classList.add('muur');
                    break;
                case 'schat':
                    new_cel.classList.add('schat');
                    break;
            }

            document.getElementById("speelveld").appendChild(new_cel);
        }

    }

}

class Speler {
    #xPositie;
    #yPositie;
    #levens = 3;

    getxPositie() {
        return parseInt(this.#xPositie);
    }

    getyPositie() {
        return parseInt(this.#yPositie);
    }

    getLevens() {
        return parseInt(this.#levens);
    }

    setLevens(levens) {
        this.#levens = levens;

        //toon levens
        document.getElementById('levens').innerHTML = "";
        for (let H = 0; H < this.#levens; H++) {
            const heart = document.createElement("div");
            heart.classList.add("heart");
            heart.classList.add("full");
            heart.style.display = "inline-block";
            document.getElementById("levens").appendChild(heart);
        }

    }

    spawn() {
        //  Maak een matrix met een lijst van alle mogelijke coordinaten
        let lijst_coordinaten = [];

        for (const cel of document.getElementsByClassName('cel gras')) {
            const x = cel.dataset.x;
            const y = cel.dataset.y;
            const coordinaten = [x, y];
            lijst_coordinaten.push(coordinaten);
        }
        //  We hebben nu een array met lijst_coordinaten[0] als xpositie en lijst_coordinaten[1] als ypositie

        //Shuffle deze array
        for (let i = lijst_coordinaten.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [lijst_coordinaten[i], lijst_coordinaten[j]] = [lijst_coordinaten[j], lijst_coordinaten[i]];
        }

        // Neem het het eerste resultaat, dit is dus random
        const randomCoordinaten = lijst_coordinaten.slice(0, 1);
        //  We hebben nu de coordinaten van de beginpositie


        const cel = document.querySelector(`.cel[data-x="${randomCoordinaten[0][0]}"][data-y="${randomCoordinaten[0][1]}"]`);
        this.#xPositie = cel.dataset.x;
        this.#yPositie = cel.dataset.y;
        const new_cel = new Cel("speler", cel.dataset.x, cel.dataset.y);
        new_cel.tekenCel();
    }

    beweeg(richting) {
        switch (richting) {
            case 'boven':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie), parseInt(this.#yPositie) - 1)) {
                    this.#yPositie = parseInt(this.#yPositie) - 1;
                    this.verplaatsSpeler(parseInt(this.#xPositie), parseInt(this.#yPositie) + 1, parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('.speler:not(.jager)');
                    cel.className = "";
                    cel.classList.add('cel', 'gras', 'speler', 'spelerboven');
                }
                break;
            case 'onder':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie), parseInt(this.#yPositie) + 1)) {
                    this.#yPositie = parseInt(this.#yPositie) + 1;
                    this.verplaatsSpeler(parseInt(this.#xPositie), parseInt(this.#yPositie) - 1, parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('.speler:not(.jager)');
                    cel.className = "";
                    cel.classList.add('cel', 'gras', 'speler', 'speleronder');
                }
                break;
            case 'links':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie) - 1, parseInt(this.#yPositie))) {
                    this.#xPositie = parseInt(this.#xPositie) - 1;
                    this.verplaatsSpeler(parseInt(this.#xPositie) + 1, parseInt(this.#yPositie), parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('.speler:not(.jager)');
                    cel.className = "";
                    cel.classList.add('cel', 'gras', 'speler', 'spelerlinks');
                }
                break;
            case 'rechts':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie) + 1, parseInt(this.#yPositie))) {
                    this.#xPositie = parseInt(this.#xPositie) + 1;
                    this.verplaatsSpeler(parseInt(this.#xPositie) - 1, parseInt(this.#yPositie), parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('.speler:not(.jager)');
                    cel.className = "";
                    cel.classList.add('cel', 'gras', 'speler', 'spelerrechts');
                }
                break;
        }
    }

    controleerBeweging(nieuw_x_coord, nieuw_y_coord) {

        //controleer op out of bounds
        if ((nieuw_x_coord < 0) || (nieuw_x_coord > speelveld.getBreedte() - 1)) { return false; }
        if ((nieuw_y_coord < 0) || (nieuw_y_coord > speelveld.getHoogte() - 1)) { return false; }

        //controleer op muur of jager
        const cel = document.querySelector(`.cel[data-x="${nieuw_x_coord}"][data-y="${nieuw_y_coord}"]`);
        if (cel.classList.contains('muur') || cel.classList.contains('jager')) {
            return false;
        }

        return true;
    }

    verplaatsSpeler(oud_x_coord, oud_y_coord, nieuw_x_coord, nieuw_y_coord) {
        //  Bepaal de draairichting van de speler
        let richting = 'o';
        if (oud_x_coord > nieuw_x_coord) { richting = 'l' };
        if (oud_x_coord < nieuw_x_coord) { richting = 'r' };
        if (oud_y_coord < nieuw_y_coord) { richting = 'o' };
        if (oud_y_coord > nieuw_y_coord) { richting = 'b' };

        let cel = document.querySelector(`.cel[data-x="${oud_x_coord}"][data-y="${oud_y_coord}"]`);
        cel.className = '';
        cel.classList.add('cel', 'gras');

        //  Voeg speler toe aan het volgende vak
        cel = document.querySelector(`.cel[data-x="${nieuw_x_coord}"][data-y="${nieuw_y_coord}"]`);
        cel.classList.add('speler');
        switch (richting) {
            case 'o':
                cel.classList.add('speleronder');
                break;
            case 'l':
                cel.classList.add('spelerlinks');
                break;
            case 'r':
                cel.classList.add('spelerrechts');
                break;
            case 'b':
                cel.classList.add('spelerboven');
                break;
        }
        speelveld.controleerVoorSchat(this.#xPositie, this.#yPositie);
    }

}

class Jager {
    #xPositie;
    #yPositie;
    #snelheid;
    #ticker;
    #optimalPath;

    getxPositie() {
        return this.#xPositie;
    }

    getyPositie() {
        return this.#yPositie;
    }

    getSnelheid() {
        return this.#snelheid;
    }

    setSnelheid(snelheid) {
        this.#snelheid = snelheid;
    }

    beginAchtervolging() {
        // check if an interval has already been set up

        let calculate_new_path = 1;

        if (!this.#ticker) {
            this.#ticker = setInterval((function () {
                jager.bepaalVolgendeBeweging(calculate_new_path);
                calculate_new_path++;
                if (calculate_new_path == 4) {
                    calculate_new_path = 1;
                }
            }), this.#snelheid);
        }
    }

    stopAchtervolging() {
        clearInterval(this.#ticker);
    }

    spawn() {
        //  Maak een matrix met een lijst van alle mogelijke coordinaten
        let lijst_coordinaten = [];
        for (const cel of document.getElementsByClassName('cel gras')) {
            if ((cel.dataset.x !== '0') && (cel.dataset.y !== '0') && parseInt(cel.dataset.x) !== (speelveld.getBreedte() - 1) && parseInt(cel.dataset.y) !== (speelveld.getHoogte() - 1)) {
                const x = cel.dataset.x;
                const y = cel.dataset.y;
                const coordinaten = [x, y];
                lijst_coordinaten.push(coordinaten);
            }
        }
        //  We hebben nu een array met lijst_coordinaten[0] als xpositie en lijst_coordinaten[1] als ypositie

        //Shuffle deze array
        for (let i = lijst_coordinaten.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [lijst_coordinaten[i], lijst_coordinaten[j]] = [lijst_coordinaten[j], lijst_coordinaten[i]];
        }

        // Neem het het eerste resultaat, dit is dus random
        const randomCoordinaten = lijst_coordinaten.slice(0, 1);
        //  We hebben nu de coordinaten van de beginpositie

        const cel = document.querySelector(`.cel[data-x="${randomCoordinaten[0][0]}"][data-y="${randomCoordinaten[0][1]}"]`);
        this.#xPositie = cel.dataset.x;
        this.#yPositie = cel.dataset.y;
        const new_cel = new Cel("jager", cel.dataset.x, cel.dataset.y);
        new_cel.tekenCel();
    }

    bepaalVolgendeBeweging(calculate_new_path) {

        //bereken het nieuwe optimale pad om de 3 moves
        if (calculate_new_path == 1) {
            //  genereer een array met nodes
            const nodes = [];
            for (let y = 0; y < speelveld.getHoogte(); y++) {
                const row = [];
                for (let x = 0; x < speelveld.getBreedte(); x++) {
                    const cel = document.querySelector(`.cel[data-x="${x}"][data-y="${y}"]`);
                    if (cel && cel.classList.contains('muur')) {
                        row.push(new Node(x, y, true));
                    } else {
                        row.push(new Node(x, y, false));
                    }
                }
                nodes.push(row);
            }

            //  get speler en jager coordinates
            const hunter = new Node(jager.getxPositie(), jager.getyPositie());
            const player = new Node(speler.getxPositie(), speler.getyPositie());

            //  Bepaal optimale pad
            this.#optimalPath = findOptimalPathAStar(hunter, player, nodes);
        }

        const jagerX = this.#xPositie;
        const jagerY = this.#yPositie;

        if (jagerX !== speler.getxPositie() || jagerY !== speler.getyPositie()) {
            if (this.#optimalPath) {
                const node = this.#optimalPath[calculate_new_path];
                if (node) {
                    if ((node.x < jagerX) && (node.y == jagerY)) { this.beweeg('links'); }
                    if ((node.x > jagerX) && (node.y == jagerY)) { this.beweeg('rechts'); }
                    if ((node.x == jagerX) && (node.y < jagerY)) { this.beweeg('boven'); }
                    if ((node.x == jagerX) && (node.y > jagerY)) { this.beweeg('onder'); }
                } else {
                    calculate_new_path == 1;
                }
            }
        }
        //controleer als de jager op de speler staat
        this.controleerAanval(speler.getxPositie(), speler.getyPositie(), this.#xPositie, this.#yPositie);
    }

    beweeg(richting) {
        switch (richting) {
            case 'boven':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie), parseInt(this.#yPositie) - 1)) {
                    this.#yPositie = parseInt(this.#yPositie) - 1;
                    this.verplaatsJager(parseInt(this.#xPositie), parseInt(this.#yPositie) + 1, parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('jager');
                    if (cel.classList.contains('schat')) {
                        cel.className = "";
                        cel.classList.add('cel', 'schat', 'jager', 'jagerboven');
                    } else {
                        cel.className = "";
                        cel.classList.add('cel', 'gras', 'jager', 'jagerboven');
                    }
                }
                break;
            case 'onder':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie), parseInt(this.#yPositie) + 1)) {
                    this.#yPositie = parseInt(this.#yPositie) + 1;
                    this.verplaatsJager(parseInt(this.#xPositie), parseInt(this.#yPositie) - 1, parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('jager');
                    if (cel.classList.contains('schat')) {
                        cel.className = "";
                        cel.classList.add('cel', 'schat', 'jager', 'jageronder');
                    } else {
                        cel.className = "";
                        cel.classList.add('cel', 'gras', 'jager', 'jageronder');
                    }
                }
                break;
            case 'links':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie) - 1, parseInt(this.#yPositie))) {
                    this.#xPositie = parseInt(this.#xPositie) - 1;
                    this.verplaatsJager(parseInt(this.#xPositie) + 1, parseInt(this.#yPositie), parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('jager');
                    if (cel.classList.contains('schat')) {
                        cel.className = "";
                        cel.classList.add('cel', 'schat', 'jager', 'jagerlinks');
                    } else {
                        cel.className = "";
                        cel.classList.add('cel', 'gras', 'jager', 'jagerlinks');
                    }
                }
                break;
            case 'rechts':
                //Als de beweging geldig is
                if (this.controleerBeweging(parseInt(this.#xPositie) + 1, parseInt(this.#yPositie))) {
                    this.#xPositie = parseInt(this.#xPositie) + 1;
                    this.verplaatsJager(parseInt(this.#xPositie) - 1, parseInt(this.#yPositie), parseInt(this.#xPositie), parseInt(this.#yPositie));
                } else {
                    //als de beweging niet geldig is, draai enkel de sprite in de juiste richting
                    const cel = document.querySelector('jager');
                    if (cel.classList.contains('schat')) {
                        cel.className = "";
                        cel.classList.add('cel', 'schat', 'jager', 'jagerrechts');
                    } else {
                        cel.className = "";
                        cel.classList.add('cel', 'gras', 'jager', 'jagerrechts');
                    }
                }
                break;
        }
    }

    controleerBeweging(nieuw_x_coord, nieuw_y_coord) {

        //controleer op out of bounds
        if ((nieuw_x_coord < 0) || (nieuw_x_coord > speelveld.getBreedte() - 1)) { return false; }
        if ((nieuw_y_coord < 0) || (nieuw_y_coord > speelveld.getHoogte() - 1)) { return false; }

        //controleer op muur of jager
        const cel = document.querySelector(`.cel[data-x="${nieuw_x_coord}"][data-y="${nieuw_y_coord}"]`);
        if (cel.classList.contains('muur')) { return false }
        return true;
    }

    verplaatsJager(oud_x_coord, oud_y_coord, nieuw_x_coord, nieuw_y_coord) {
        //  Bepaal de draairichting van de jager
        let richting = 'o';
        if (oud_x_coord > nieuw_x_coord) { richting = 'l' };
        if (oud_x_coord < nieuw_x_coord) { richting = 'r' };
        if (oud_y_coord < nieuw_y_coord) { richting = 'o' };
        if (oud_y_coord > nieuw_y_coord) { richting = 'b' };

        //  Zoek het vak waar de jager opstaat
        let cel = document.querySelector(`.cel[data-x="${oud_x_coord}"][data-y="${oud_y_coord}"]`);

        //  Verwijder jager van het huidige vak
        if (cel.classList.contains('schat')) {
            cel.className = '';
            cel.classList.add('cel', 'schat');
        } else {
            cel.className = '';
            cel.classList.add('cel', 'gras');
        }


        cel = document.querySelector(`.cel[data-x="${nieuw_x_coord}"][data-y="${nieuw_y_coord}"]`);

        //  Voeg jager toe aan het volgende vak
        cel.classList.add('jager');
        switch (richting) {
            case 'o':
                cel.classList.add('jageronder');
                break;
            case 'l':
                cel.classList.add('jagerlinks');
                break;
            case 'r':
                cel.classList.add('jagerrechts');
                break;
            case 'b':
                cel.classList.add('jagerboven');
                break;

        }

        this.controleerAanval(this.#xPositie, this.#yPositie);
    }




    controleerAanval(spelerX, spelerY, jagerX, jagerY) {
        if ((spelerX == jagerX) && (spelerY == jagerY)) {
            this.valAan();
        }
    }

    valAan() {
        speler.setLevens(parseInt(speler.getLevens()) - 1);
        sfx.playInjured();
        if (speler.getLevens() == 0) {
            sfx.playDeath();
            spelVerloren();
        }
    }


}

class Animaties {
    //  Tickers
    death_ticker;
    idle_ticker;

    startDeathAnimatie() {
        let death_animation_state = 0;
        // check if an interval has already been set up
        if (!this.death_ticker) {
            this.death_ticker = setInterval((function () {
                let url = "assets/jager_dood_1.png";
                //death animation here
                switch (death_animation_state) {
                    case 1:
                        url = "assets/jager_dood_2.png";
                        break;
                    case 2:
                        url = "assets/jager_dood_3.png";
                        break;
                    case 3:
                        url = "assets/jager_dood_4.png";
                        break;
                    case 4:
                        url = "assets/jager_dood_5.png";
                        break;
                    case 5:
                        url = "assets/jager_dood_6.png";
                        animaties.stopDeathAnimatie();
                        spelGewonnen();
                        break;
                    default:
                        break;
                }
                death_animation_state++;
                //  Selecteer de cel waar de jager op staat
                const cel = document.querySelector(`.cel[data-x="${jager.getxPositie()}"][data-y="${jager.getyPositie()}"]`);

                //  Pas de juiste sprite toe op deze cel
                cel.style.backgroundImage = "url('" + url + "')";
            }), 200);
        }
    }
    stopDeathAnimatie() {
        clearInterval(this.death_ticker);
    }

    startIdleAnimatie() {
        // check if an interval has already been set up
        let idle_animation_state = 0;
        let idle_looper = '+';

        if (!this.idle_ticker) {
            this.idle_ticker = setInterval((function () {
                let url = "assets/jager_idle_0.png";

                //death animation here
                switch (idle_animation_state) {
                    case 0:
                        url = "assets/jager_idle_0.png";
                        idle_looper = '+';
                        break;
                    case 2:
                        url = "assets/jager_idle_1.png";
                        break;
                    case 3:
                        url = "assets/jager_idle_2.png";
                        break;
                    case 4:
                        url = "assets/jager_idle_3.png";
                        idle_looper = '-';
                        break;
                }

                if (idle_looper == '+') {
                    idle_animation_state++;
                } else {
                    idle_animation_state--;
                }

                //  Selecteer de cel waar de jager op staat
                const cel = document.querySelector(`.cel[data-x="${jager.getxPositie()}"][data-y="${jager.getyPositie()}"]`);
                //  Pas de juiste sprite toe op deze cel
                cel.style.backgroundImage = "url('" + url + "')";
            }), 200);
        }
    }
}

class SFX {

    //  Geluidseffecten initialiseren
    sfx_music;
    sfx_death;
    sfx_injured;
    sfx_treasure;
    sfx_level_start;

    //  Volumes
    music_volume;
    sfx_volume;

    constructor(music_volume, sfx_volume) {
        this.sfx_music = document.querySelector('#music');
        this.sfx_death = document.querySelector('#death');
        this.sfx_injured = document.querySelector('#injured');
        this.sfx_treasure = document.querySelector('#treasure');
        this.sfx_level_start = document.querySelector('#start');

        this.sfx_music.volume = music_volume / 100;
        this.sfx_death.volume = sfx_volume / 100;
        this.sfx_injured.volume = sfx_volume / 100;
        this.sfx_treasure.volume = sfx_volume / 100;
        this.sfx_level_start.volume = sfx_volume / 100;
    }

    changeMusicVolume(music_volume) {
        this.music_volume = (music_volume / 100);
        this.sfx_music.volume = this.music_volume;
    }

    changeSfxVolume(sfx_volume) {
        this.sfx_volume = sfx_volume / 100;
        this.sfx_death.volume = this.sfx_volume;
        this.sfx_injured.volume = this.sfx_volume;
        this.sfx_treasure.volume = this.sfx_volume;
        this.sfx_level_start.volume = this.sfx_volume;
    }

    playMusic() {
        sfx.sfx_music.play();
    }

    stopMusic() {
        sfx.sfx_music.pause();
    }

    playStartLevel() {
        sfx.sfx_level_start.play();
    }

    playDeath() {
        sfx.sfx_death.play();
    }

    playInjured() {
        sfx.sfx_injured.play();
    }

    playTreasure() {
        sfx.sfx_treasure.play();
    }
}

class Node {
    constructor(x, y, isWall = false) {
        this.x = x;
        this.y = y;
        this.isWall = isWall;
        this.g = 0; // Cost from start node
        this.h = 0; // Heuristic (Manhattan distance to target)
        this.f = 0; // Total cost
        this.parent = null; // Parent node
    }
}

function calculateHeuristic(node, target) {
    return Math.abs(node.x - target.x) + Math.abs(node.y - target.y);
}

function findOptimalPathAStar(hunter, player, nodes) {
    const openSet = [hunter];
    const closedSet = [];

    while (openSet.length > 0) {
        let currentNode = openSet[0];
        let currentIndex = 0;

        openSet.forEach((node, index) => {
            if (node.f < currentNode.f) {
                currentNode = node;
                currentIndex = index;
            }
        });

        openSet.splice(currentIndex, 1);
        closedSet.push(currentNode);

        if (currentNode.x === player.x && currentNode.y === player.y) {
            // Reconstruct the path from the end to the start
            const path = [];
            let current = currentNode;
            while (current !== null) {
                path.unshift(current); // Add to the beginning of the array
                current = current.parent;
            }
            return path;
        }

        const possibleMoves = [
            { x: currentNode.x - 1, y: currentNode.y },
            { x: currentNode.x + 1, y: currentNode.y },
            { x: currentNode.x, y: currentNode.y - 1 },
            { x: currentNode.x, y: currentNode.y + 1 }
        ];

        possibleMoves.forEach(move => {
            const neighbor = new Node(move.x, move.y);

            // Check if the move is valid (within the grid bounds and not a wall)
            if (
                move.x >= 0 && move.x < nodes[0].length &&
                move.y >= 0 && move.y < nodes.length &&
                !nodes[move.y][move.x].isWall &&
                !closedSet.some(node => node.x === neighbor.x && node.y === neighbor.y)
            ) {
                const tempG = currentNode.g + 1;

                const existingNode = openSet.find(node => node.x === neighbor.x && node.y === neighbor.y);
                if (!existingNode || tempG < existingNode.g) {
                    neighbor.g = tempG;
                    neighbor.h = calculateHeuristic(neighbor, player);
                    neighbor.f = neighbor.g + neighbor.h;
                    neighbor.parent = currentNode;

                    if (!existingNode) {
                        openSet.push(neighbor);
                    }
                }
            }
        });
    }

    return null; // No path found
}

//  Wanneer de speler gewonnen heeft
function spelGewonnen() {
    //animaties.startDeathAnimatie();
    music.pause();
    jager.stopAchtervolging();
    document.onkeydown = null;
    document.getElementById("win-screen").style.display = "inline-block";
}
//  Wanneer de speler verloren heeft
function spelVerloren() {
    animaties.startIdleAnimatie();
    music.pause();
    jager.stopAchtervolging();
    document.onkeydown = null;
    document.getElementById("kill-screen").style.display = "inline-block";
}
//  Functie voor het bewegen van de pijltjestoetsen
function beweegRichting(e) {
    e = e || window.event;
    if (e.keyCode == '38') {
        speler.beweeg('boven');
    }
    else if (e.keyCode == '40') {
        speler.beweeg('onder');
    }
    else if (e.keyCode == '37') {
        speler.beweeg('links');
    }
    else if (e.keyCode == '39') {
        speler.beweeg('rechts');
    }
}


// Benodigde objecten
const speelveld = new Speelveld();
const speler = new Speler();
const jager = new Jager();
const animaties = new Animaties();
const sfx = new SFX(0, 0); //volumes als parameter

//  Schaal het speelveld automatisch als het scherm word geresized, ook tijdens het spelen
addEventListener("resize", (event) => { speelveld.bepaalCelGrootte() });
onresize = (event) => { speelveld.bepaalCelGrootte() };


//--------------------UI ELEMENTEN---------------------------
document.getElementById('speel').onclick = function () {

    //  Paremeters
    const difficulty = parseInt(document.getElementById('difficulty').value);
    const hoogte = parseInt(document.getElementById('hoogte').value);
    const breedte = parseInt(document.getElementById('breedte').value);
    const oppervlakte = hoogte * breedte;

    //  Verkrijg de game opties afhankelijk van de gekozen difficulty
    let aantal_muren;
    let aantal_schatten;
    let tick_speed;

    //  Afhankelijk van de difficulty, voeg 250ms aan tick_speed toe per lagere difficulty
    tick_speed = (difficulty * 200) - (difficulty * 50);
    jager.setSnelheid(tick_speed);

    //  Afhankelijk van de difficulty, bepaal aantal muren
    aantal_muren = parseInt(((6 - difficulty) / 20) * oppervlakte);

    //  Afhankelijk van de difficulty, bepaal aantal schatten
    aantal_schatten = 10 - (difficulty * 2)

    //  Voor het bewegen met de pijltjes toetsen
    document.onkeydown = beweegRichting;

    speelveld.showUI();

    //  ADD MUSIC BABY
    sfx.playMusic();
    sfx.changeMusicVolume(document.getElementById('music_volume').value);
    sfx.changeSfxVolume(document.getElementById('sfx_volume').value);
    sfx.playStartLevel();

    //  Genereer het speelveld
    speelveld.setGrootte(hoogte, breedte);
    speelveld.genereerVeld();
    speelveld.genereerMuren(aantal_muren);
    speelveld.genereerSchatten(aantal_schatten);
    speelveld.bepaalCelGrootte();

    //  Genereer de speler
    speler.setLevens(3);
    speler.spawn();

    //  Genereer de jager
    jager.spawn();
    jager.beginAchtervolging();
}





