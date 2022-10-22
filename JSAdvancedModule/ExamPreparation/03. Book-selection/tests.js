let expect = require("chai").expect;
const { assert } = require("chai");
const bookSelection = require('./solution.js');

describe("bookSelection", () => {
    describe("isGenreSuitable", () => {
// o	If the value of the string genre is equal to "Thriller" or "Horror" and the value of age is less or equal to 12, 
//  return: `Books with ${genre} genre are not suitable for kids at ${age} age`

// o	Otherwise, if the above conditions are not met, return the following message:
//       `Those books are suitable`
// o	There is no need for validation for the input, you will always be given string and number.

        it("should return suitable book output", () => {
            let genre = 'New genre';
            let age = 9; 

            let result = bookSelection.isGenreSuitable(genre, age);

            expect(result).to.be.equal('Those books are suitable');
        });

        it("should return suitable book output", () => {
            let genre = 'New genre';
            let age = 17; 

            let result = bookSelection.isGenreSuitable(genre, age);

            expect(result).to.be.equal('Those books are suitable');
        });

        it("should return suitable book output", () => {
            let genre = 'Thriller';
            let age = 13; 

            let result = bookSelection.isGenreSuitable(genre, age);

            expect(result).to.be.equal('Those books are suitable');
        });

        it("should return suitable book output", () => {
            let genre = 'Horror';
            let age = 13; 

            let result = bookSelection.isGenreSuitable(genre, age);

            expect(result).to.be.equal('Those books are suitable');
        });

        it("should return that books are not suitable", () => {
            let genre = 'Horror';
            let age = 12; 

            let result = bookSelection.isGenreSuitable(genre, age);

            expect(result).to.be.equal(`Books with ${genre} genre are not suitable for kids at ${age} age`);
        });

        it("should return that books are not suitable", () => {
            let genre = 'Thriller';
            let age = 9; 

            let result = bookSelection.isGenreSuitable(genre, age);

            expect(result).to.be.equal(`Books with ${genre} genre are not suitable for kids at ${age} age`);
        })
    });

    describe("isItAffordable", () => {
// •	isItAffordable (price, budget) - A function that accepts two parameters: number and number.
// o	You need to calculate if you can afford buying the book by subtracting the price of the book from your budget.
// o	If the result is lower than 0, return: 
// "You don't have enough money"
// o	Otherwise, if the above conditions are not met, return the following message:
// `Book bought. You have ${result}$ left`
// o	You need to validate the input, if the price and budget are not a number, throw an error: "Invalid input".

        it("should return not enough money if you dont have money", () => {
            let price = 12;
            let budget = 11;

            let result = bookSelection.isItAffordable(price, budget);

            expect(result).to.be.equal("You don't have enough money");
        });

        it("should return not enough money if you dont have money", () => {
            let price = 12;
            let budget = -1;

            let result = bookSelection.isItAffordable(price, budget);

            expect(result).to.be.equal("You don't have enough money");
        });

        it("should return not enough money if you dont have money", () => {
            let price = 12;
            let budget = -1;

            let result = bookSelection.isItAffordable(price, budget);

            expect(result).to.be.equal("You don't have enough money");
        });

        it("should throw error if input is not a number", () => {
            expect(() => bookSelection.isItAffordable(['asd'], 12)).to.throw("Invalid input");
            expect(() => bookSelection.isItAffordable(['asd'], {asd: 'wow'})).to.throw("Invalid input");
            expect(() => bookSelection.isItAffordable(12, 'asd')).to.throw("Invalid input");
        });

        it("should calculate money left correctly", () => {
            let price = 12;
            let budget = 12;

            let result = bookSelection.isItAffordable(price, budget);

            expect(result).to.be.equal(`Book bought. You have ${budget - price}$ left`);
        });

        it("should calculate money left correctly", () => {
            let price = 12;
            let budget = 15;

            let result = bookSelection.isItAffordable(price, budget);

            expect(result).to.be.equal(`Book bought. You have ${budget - price}$ left`);
        });
    });

    describe("suitableTitles", () => {
// •	suitableTitles (books, wantedGenre) - A function that accepts an array and string.
// o	The books array will store the titles and the genre of its books ([{ title: "The Da Vinci Code", genre: "Thriller" }, ...])
// o	You must add the title of the book that its genre is equal to the wantedGenre.
// o	Finally, return the changed array of book titles.
// o	There is a need for validation for the input, an array and string may not always be valid. In case of submitted invalid parameters, throw an error "Invalid input":
// 	If passed books parameter is not an array.
// 	If the wantedGenre is not a string.
        it("should throw error if input is not a correct", () => {
            expect(() => bookSelection.suitableTitles(['asd'], 12)).to.throw("Invalid input");
            expect(() => bookSelection.suitableTitles(['asd'], [])).to.throw("Invalid input");
            expect(() => bookSelection.suitableTitles('asd', 12)).to.throw("Invalid input");
            expect(() => bookSelection.suitableTitles('asd', 'ree')).to.throw("Invalid input");
            expect(() => bookSelection.suitableTitles(['bee'], ['ree'])).to.throw("Invalid input");
        });

        it("should filter array correctly", () => {
            let books = [
                {title: "fan2",
                 genre: "Fantasy"},
                 {title: "5",
                 genre: "Action"},
                 {title: "3",
                 genre: "Beeps"},
                 {title: "fan1",
                 genre: "Fantasy"},
            ];

            let genre = "Fantasy";

            let newBooks = books.filter(x => x.genre == genre).map(x => x.title);
            expect(newBooks.join(" ")).to.be.equal(bookSelection.suitableTitles(books, genre).join(" "));
        });
    });
});