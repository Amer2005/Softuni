function extensibleObject(){
    class NewObj{
        constructor(){

        }

        extend(temp){
            //let proto = Object.getPrototypeOf(this);
            //proto = temp;

            Object.setPrototypeOf(this, temp)

            for(let prop in temp){
                this[prop] = temp[prop];
            }
        }
    };


    return new NewObj();
}

var template = {
    fight: function(target) { return `object fights with ${target}` },
    health: 100,
    mana: 50
};
    
var testObject = extensibleObject();
testObject.extend(template);

console.log(testObject.fight('asd'));
console.log(testObject.health);
console.log(testObject.mana);
console.log(Object.getPrototypeOf(testObject) === template)