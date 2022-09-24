function createSortedList()
{
    return {
        _elements: [],
        add: function(element){
            this._elements.push(element);

            this._elements.sort((a, b) => a - b);
            this.size = this._elements.length;
        },
        remove: function(index){

            if(index >= this._elements.length || index < 0)
            {
                return;
            }

            this._elements.splice(index, 1);
            this.size = this._elements.length;
        },
        get: function(index){
            return this._elements[index];
        },
        size: 0
    }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);

console.log(list._elements);

console.log(list.get(1)); 
list.remove(1);
console.log(list._elements);
console.log(list.get(1));
console.log(list.size);
