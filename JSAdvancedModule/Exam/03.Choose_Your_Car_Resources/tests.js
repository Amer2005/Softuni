let expect = require("chai").expect;
const { assert } = require("chai");
const chooseYourCar = require('./chooseYourCar.js');

describe("chooseYourCar", () => {
    describe("choosingType", () => {
        it("should throw error if year is invalid", () => {
            expect(() => chooseYourCar.choosingType('asd', 'asd', 1899)).to.throw("Invalid Year!");
            expect(() => chooseYourCar.choosingType('asd', 'asd', 2023)).to.throw("Invalid Year!");
            expect(() => chooseYourCar.choosingType('asd', 'asd', 3000)).to.throw("Invalid Year!");
            expect(() => chooseYourCar.choosingType('asd', 'asd', 1)).to.throw("Invalid Year!");
        });

        it("should throw error if type is not Sedan", () => {
            expect(() => chooseYourCar.choosingType('Sedas', 'crl', 2011)).to.throw("This type of car is not what you are looking for.");
            expect(() => chooseYourCar.choosingType('bob', 'crl', 2011)).to.throw("This type of car is not what you are looking for.");
            expect(() => chooseYourCar.choosingType('ras', 'crl', 2011)).to.throw("This type of car is not what you are looking for.");
        });

        it("should work with years above 2010", () => {
            let inputs = [['Sedan', 'bob', 2011],
            ['Sedan', 'xxrt', 2010],
            ['Sedan', 'chroma', 2022]];

            for(let indx in inputs){
                let result = chooseYourCar.choosingType(inputs[indx][0], inputs[indx][1], inputs[indx][2]);
                expect(result).to.be.equal(`This ${inputs[indx][1]} ${inputs[indx][0]} meets the requirements, that you have.`)
            }
        });

        it("should not work with years below 2010", () => {
            let inputs = [['Sedan', 'bob', 1980],
            ['Sedan', 'xxrt', 2009],
            ['Sedan', 'chroma', 1900]];

            for(let indx in inputs){
                let result = chooseYourCar.choosingType(inputs[indx][0], inputs[indx][1], inputs[indx][2]);
                expect(result).to.be.equal(`This ${inputs[indx][0]} is too old for you, especially with that ${inputs[indx][1]} color.`)
            }
        });
    });

    describe("brandName", () => {
        it("should throw error if invalid inforamtion is given", () => {
            brands = ["BMW", "Toyota", "Peugeot"];

            expect(() => chooseYourCar.brandName('asd', 1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.brandName(1, 1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.brandName(brands, '1')).to.throw("Invalid Information!");
            expect(() => chooseYourCar.brandName(brands, {})).to.throw("Invalid Information!");
            expect(() => chooseYourCar.brandName(brands, -1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.brandName(brands, 3)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.brandName('ree', '1')).to.throw("Invalid Information!");
        });

        it("should remove element correctly", () => {
            brands = ["BMW", "Toyota", "Peugeot", "newBrand", "wow", "hehe"];
            
            for(let i = 0; i < brands.length;i++){
                let result = chooseYourCar.brandName(brands, i);
                let newBrands = [];

                for (let j = 0; j < brands.length; j++) {
                    if (j !== i) {
                        newBrands.push(brands[j]);
                    }
                }

                expect(result).to.be.equal(newBrands.join(", "));
            }
        })
    });

    describe("CarFuelConsumption", () => {
        it("should throw error if invalid inforamtion is given", () => {
            expect(() => chooseYourCar.carFuelConsumption('1', 1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption({}, 1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(-1, 1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(0, 1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(1, -1)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(1, '1')).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(1, 0)).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(1, {})).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption('1', '1')).to.throw("Invalid Information!");
            expect(() => chooseYourCar.carFuelConsumption(-1, -1)).to.throw("Invalid Information!");
        });

        it("should give that car is efficeint enough if fueld per 100 is less than or equal to 7", () => {

            let inputs = [[100, 7],
            [100, 6.9],
            [100, 1]];

            for(let indx in inputs){
                let result = chooseYourCar.carFuelConsumption(inputs[indx][0], inputs[indx][1]);
                let litersPerHundredKm = ((inputs[indx][1] / inputs[indx][0])* 100).toFixed(2);
                expect(result).to.be.equal(`The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`)
            }
        });

        it("should give that car is burning too much fuel", () => {

            let inputs = [[100, 7.1],
            [100, 8],
            [100, 15]];

            for(let indx in inputs){
                let result = chooseYourCar.carFuelConsumption(inputs[indx][0], inputs[indx][1]);
                let litersPerHundredKm = ((inputs[indx][1] / inputs[indx][0])* 100).toFixed(2);
                expect(result).to.be.equal(`The car burns too much fuel - ${litersPerHundredKm} liters!`)
            }
        });
    });
});