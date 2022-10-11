const { expect } = require("chai");

describe('lookUpChar', () =>{
    it('should return undefined if text is not a string', () =>{
        let value = [];

        let result = lookupChar(value, 0);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if index is not a number', () =>{
        let value = 3.4;

        let result = lookupChar('asd', value);

        expect(result).to.be.equal(undefined);
    });

    it('should return error if index is less than zero', () =>{
        let index = -1;

        let result = lookupChar('asd', index);

        expect(result).to.be.equal("Incorrect index");
    });

    it('should return error if index is more than the length of the string', () =>{
        let index = 3;

        let result = lookupChar('asd', index);

        expect(result).to.be.equal("Incorrect index");
    });

    it('should return char at index', () =>{
        let text = 'asdgf3qwsdasdwq';

        for(let i = 0; i < text.length;i++)
        {
            let result = lookupChar(text, i);
            expect(result).to.be.equal(text[i]);
        }
    });
});

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}
