(function solve(){
    String.prototype.ensureStart = function(str) {
        if(this.startsWith(str)){
            return `${this}`;
        }

        return `${str + this}`;
    };

    String.prototype.ensureEnd = function(str) {
        if(this.endsWith(str)){
            return `${this}`;
        }

        return `${this + str}`;
    };

    String.prototype.isEmpty = function() {
        return this.length == 0;
    };

    String.prototype.truncate = function(n) {

        if(this.length <= n){
            return `${this}`;
        }

        if(n < 4){
            return '.'.repeat(n);
        }

        let lastSpace = -1

        for(let i = 0; i < Math.min(this.length, n - 2); i++){
            if(this[i] == ' '){
                lastSpace = i;
            }
        }

        if(lastSpace != -1){
            return `${this.slice(0,lastSpace) + '...'}`;
        }

        return `${this.slice(0, n - 3) + '...'}`;
    };

    String.format = function(str, ...params){
        for(let i = 0;i < params.length;i++){
            let replaceText = `{${i}}`;
            str = str.replace(replaceText, params[i]);
        }

        return str;
    }
})();

var testString = 'quick brown fox jumps over the lazy dog';
var answer = testString.ensureStart('the ');
console.log(answer);
answer = answer.ensureStart('the ');
console.log(answer);


let str = 'my string';
console.log(str);
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
  console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
  console.log(str);
