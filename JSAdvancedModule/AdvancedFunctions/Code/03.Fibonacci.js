function getFibonator()
{
    let count = 0;
    let last = 1;// first current
    let current = 1;

    return function(){
        if(count < 2)
        {
            count++;

            return 1;
        }

        let sum = last + current;

        last = current;
        current = sum;

        return sum;
    };
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
