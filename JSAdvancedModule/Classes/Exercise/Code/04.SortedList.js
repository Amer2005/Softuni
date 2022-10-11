class List{
    constructor(){
        this.numbers = [];
        this.size = 0;
    }

    get numbers(){
        return this._numbers;
    }

    set numbers(value){
        this._numbers = value;

        this._numbers.sort((a, b) => a - b);
    }

    add(element){
        this.size++;
        this.numbers.push(element);

        this.numbers.sort((a, b) => a - b);
    }

    remove(index){
        if(index < 0 || index >= this.size)
        {
            return;
        }

        this.size--;
        this.numbers.splice(index, 1);

        this.numbers.sort((a, b) => a - b);
    }

    get(index){
        if(index < 0 || index >= this.size)
        {
            return;
        }

        return this.numbers[index];
    }
}

let list = new List();
list.add(7);
list.add(6);
list.add(5);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);
