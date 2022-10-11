const { expect } = require("chai");

describe('IsOddOrEven', () => {
    it('should return undefined if value is not string', () => {
        let value = 231;

        let result = isOddOrEven(value);

        expect(result).to.be.equal(undefined);
    });

    it('should return even if length is even', () => {
        let value = 'thisIsEven';

        let result = isOddOrEven(value);

        expect(result).to.be.equal('even');
    });

    it('should return odd if length is odd', () => {
        let value = 'thisIsOdd';

        let result = isOddOrEven(value);

        expect(result).to.be.equal('odd');
    });

    it('multipleTests', () => {

        expect(isOddOrEven('even')).to.be.equal('even');
        expect(isOddOrEven('12')).to.be.equal('even');
        expect(isOddOrEven('123')).to.be.equal('odd');
        expect(isOddOrEven('odd')).to.be.equal('odd');
    });
});

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}
