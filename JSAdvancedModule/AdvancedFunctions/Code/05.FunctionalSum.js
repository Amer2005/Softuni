function add(num){
    let sum = num
    
    let newAdd = function(num1){
        sum += num1;

        newAdd.toString = () => sum;

        return newAdd;
    }

    newAdd.toString = () => sum;

    return newAdd;
}

console.log(add(1).toString());