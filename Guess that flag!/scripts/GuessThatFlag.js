"use strict";

//Ahh yes.. very OOP
class Country {
    #name;
    #flag_url;

    constructor(name, flag_url) {
        this.#name = name;
        this.#flag_url = flag_url;
    }

    getName() {
        return this.#name;
    }

    getFlagUrl() {
        return this.#flag_url;
    }
}

class Player {
    #score;

    constructor(score) {
        this.#score = score;
    }

    addScore() {
        this.#score++;
    }

    getScore() {
        return this.#score;
    }

    showScore() {
        //Clear potentially existing buttons
        if (document.contains(document.getElementById("answer0"))) document.getElementById("answer0").remove();
        if (document.contains(document.getElementById("answer1"))) document.getElementById("answer1").remove();
        if (document.contains(document.getElementById("answer2"))) document.getElementById("answer2").remove();
        if (document.contains(document.getElementById("answer3"))) document.getElementById("answer3").remove();


        //add title
        document.getElementById("title").innerText = `Your score: ${this.#score}/10`;
        document.getElementById("play").value = "Play again";
        document.getElementById("play").onclick = function () {
            location.reload();
        }
        document.getElementById("play").hidden = false;
        document.getElementById("quit").hidden = false;
        document.getElementById("flag").remove();
        document.querySelector("span").remove();
    }
}

class Game {
    #allCountries = [];
    #roundCount = 1;

    getRoundCount() {
        return this.#roundCount;
    }

    async loadCountries() {
        //Get JSON data
        const response = await fetch('https://restcountries.com/v3.1/all');
        const countries = await response.json();

        //IF JSON data has been succesfully received
        if (response.ok) {
            for (const country of countries) {
                //Only add countries that are independent
                if (country.independent === true) {
                    this.#allCountries.push(new Country(country.name.common, country.flags.png))
                }
            }
            //Fill in a random flag as soon as it finishes loading
            document.getElementById("flag").src = this.#allCountries[Math.floor(Math.random() * this.#allCountries.length)].getFlagUrl();
        }
    }

    getAllCountries() {
        return this.#allCountries;
    }

    createStartScreen() {
        //Create necessary elements
        const div_container = document.createElement("div");
        const rounds = document.createElement("span");
        const title = document.createElement("h1");
        const img_flag = document.createElement("img")
        const button_play = document.createElement("input");
        const button_quit = document.createElement("input");

        //Makeup -- should be moved to CSS classes but for the purpose of demonstrating exclusive JS it is here
        div_container.id = "playfield";
        div_container.style.border = "solid #008080 1px";
        div_container.style.borderRadius = "10px";
        div_container.style.margin = "auto";
        div_container.style.marginTop = "10%";
        div_container.style.padding = "1rem";
        div_container.style.color = "#008080";
        div_container.style.fontFamily = "Verdana, Geneva, Tahoma, sans-serif";
        div_container.style.maxWidth = "1000px";
        div_container.style.display = "flex";
        div_container.style.flexWrap = "wrap";
        div_container.style.justifyContent = "space-around";
        rounds.id = "rounds";
        rounds.innerText = "0/10";
        rounds.style.width = "100%";
        rounds.hidden = true;
        title.id = "title";
        title.innerText = "Guess that flag!"
        img_flag.id = "flag"
        img_flag.style.width = "100%";
        img_flag.style.maxHeight = "200px";
        img_flag.style.objectFit = "contain";
        button_play.id = "play";
        button_play.type = "submit";
        button_play.value = "Play";
        button_play.style.width = "20%";
        button_play.style.height = "3rem";
        button_play.style.backgroundColor = "#008080"
        button_play.style.color = "white";
        button_play.style.padding = "12px 20px";
        button_play.style.border = "none";
        button_play.style.borderRadius = "4px"
        button_play.style.cursor = "pointer";
        button_play.style.marginLeft = "40%";
        button_play.style.marginRight = "40%";
        button_play.style.marginTop = "10%";
        button_quit.id = "quit";
        button_quit.type = "submit";
        button_quit.value = "Quit";
        button_quit.style.width = "20%";
        button_quit.style.height = "3rem";
        button_quit.style.backgroundColor = "#008080"
        button_quit.style.color = "white";
        button_quit.style.padding = "12px 20px";
        button_quit.style.border = "none";
        button_quit.style.borderRadius = "4px"
        button_quit.style.cursor = "pointer";
        button_quit.style.marginLeft = "40%";
        button_quit.style.marginRight = "40%";
        button_quit.style.marginTop = "1%";

        //Element mousemove event handlers
        button_quit.onmouseover = function () {
            button_quit.style.backgroundColor = "#00c4c4";
        }
        button_quit.onmouseleave = function () {
            button_quit.style.backgroundColor = "#008080";
        }
        button_play.onmouseover = function () {
            button_play.style.backgroundColor = "#00c4c4";
        }
        button_play.onmouseleave = function () {
            button_play.style.backgroundColor = "#008080";
        }

        //Add elements to page
        document.body.appendChild(div_container);
        div_container.appendChild(rounds);
        div_container.appendChild(title);
        div_container.appendChild(img_flag);
        div_container.appendChild(button_play);
        div_container.appendChild(button_quit);
    }

    showRound() {
        if (document.contains(document.getElementById("answer0"))) document.getElementById("answer0").remove();
        if (document.contains(document.getElementById("answer1"))) document.getElementById("answer1").remove();
        if (document.contains(document.getElementById("answer2"))) document.getElementById("answer2").remove();
        if (document.contains(document.getElementById("answer3"))) document.getElementById("answer3").remove();


        //Update round label
        document.querySelector("span").innerText = `Round ${this.#roundCount}/10`
        document.querySelector("span").hidden = false;

        //hide play & quit button
        document.getElementById("play").hidden = true;
        document.getElementById("quit").hidden = true;

        //generate a new round
        const round = new Round();
        const round_options = round.getOptions();
        const round_solution = round.getSolution();

        //set solution flag
        document.getElementById("flag").src = round_solution.getFlagUrl();

        //create 4 possible answers
        for (let i = 0; i < 4; i++) {
            const button_answer = document.createElement("input");
            button_answer.id = "answer" + i;
            button_answer.type = "submit";
            button_answer.value = round_options[i].getName();
            button_answer.style.width = "20%";
            button_answer.style.height = "3rem";
            button_answer.style.backgroundColor = "#008080"
            button_answer.style.color = "white";
            button_answer.style.padding = "12px 20px";
            button_answer.style.border = "none";
            button_answer.style.borderRadius = "4px"
            button_answer.style.cursor = "pointer";
            button_answer.style.margin = "1%";
            button_answer.style.marginTop = "10%";
            button_answer.onmouseover = function () {
                button_answer.style.backgroundColor = "#00c4c4";
            }
            button_answer.onmouseleave = function () {
                button_answer.style.backgroundColor = "#008080";
            }
            button_answer.onclick = function () {
                //Add score when answer is correct
                button_answer.value === round_solution.getName() && player.addScore(1);
                //Only continue if round count is less or equal to 10
                guessThatFlag.getRoundCount() <= 10 ? guessThatFlag.showRound() : player.showScore();
            }
            document.getElementById("playfield").appendChild(button_answer);
        }
        this.#roundCount++;
    }
}

class Round {
    #options = [];
    #solution;

    constructor() {
        //generate 4 random numbers between 0 and amount of countries - 1, these will be the options
        const arr_random_countries = [];
        while (arr_random_countries.length < 4) {
            const r = (Math.floor(Math.random() * guessThatFlag.getAllCountries().length));
            if (arr_random_countries.indexOf(r) === -1) arr_random_countries.push(r);
        }

        arr_random_countries.forEach(option => this.#options.push(guessThatFlag.getAllCountries()[option]));

        //Pick a random index (0-3) of these random numbers as the answer
        const random_index = Math.floor((Math.random() * 3));
        this.#solution = guessThatFlag.getAllCountries()[arr_random_countries[random_index]];
    }

    getOptions() {
        return this.#options
    }

    getSolution() {
        return this.#solution;
    }
}

const guessThatFlag = new Game();
const player = new Player(0);

guessThatFlag.loadCountries();
guessThatFlag.createStartScreen();

document.getElementById("play").onclick = function () {
    guessThatFlag.showRound();
}
document.getElementById("quit").onclick = function () {
    window.location.href = 'portfolio.html';
}

//Used OOP
//Used ternary operators
//used template literals
//used lambda's

