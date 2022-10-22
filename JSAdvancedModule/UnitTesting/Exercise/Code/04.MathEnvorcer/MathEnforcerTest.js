const { expect } = require("chai");

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('should return undefined if value is not a number', () =>{
            let value = [];

            let result = mathEnforcer.addFive(value);

            expect(result).to.be.equal(undefined);
        });

        it('should add five to a number', () =>{
            let value = 3.42;

            let result = mathEnforcer.addFive(value);

            expect(result).to.be.closeTo(value + 5, 0.01);
        });

        it('should add five to a number', () =>{
            let value = -3.4;

            let result = mathEnforcer.addFive(value);

            expect(result).to.be.closeTo(value + 5, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('should return undefined if value is not a number', () =>{
            let value = ['not number'];

            let result = mathEnforcer.subtractTen(value);

            expect(result).to.be.equal(undefined);
        });

        it('should subtract ten from a number', () =>{
            let value = 3.42;

            let result = mathEnforcer.subtractTen(value);

            expect(result).to.be.equal(value - 10);
        });

        it('should subtract ten from a number', () =>{
            let value = -3.42;

            let result = mathEnforcer.subtractTen(value);

            expect(result).to.be.equal(value - 10);
        });
    });

    describe('sum', () => {
        it('should return undefined if first value is not a number', () =>{
            let value1 = 'not number';
            let value2 = 2;

            let result = mathEnforcer.sum(value1, value2);

            expect(result).to.be.equal(undefined);
        });

        it('should return undefined if second value is not a number', () =>{
            let value1 = 2;
            let value2 = ['asd'];

            let result = mathEnforcer.sum(value1, value2);

            expect(result).to.be.equal(undefined);
        });

        it('should sum two numbers', () =>{
            let value1 = 2;
            let value2 = 5;

            let result = mathEnforcer.sum(value1, value2);

            expect(result).to.be.equal(value1 + value2);
        });

        it('should sum two numbers', () =>{
            let value1 = 2;
            let value2 = -5;

            let result = mathEnforcer.sum(value1, value2);

            expect(result).to.be.equal(value1 + value2);
        });

        it('should sum two numbers', () =>{
            let value1 = -2.2;
            let value2 = 5.4;

            let result = mathEnforcer.sum(value1, value2);

            expect(result).to.be.equal(value1 + value2);
        });
    });
});

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};
