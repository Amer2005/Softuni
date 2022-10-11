function solve(data, sortType){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = data.map(x => x.split('|')).map(x => new Ticket(x[0], Number(x[1]), x[2]));

    if(sortType === 'destination'){
        tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    }
    else if(sortType === 'price')
    {
        tickets.sort((a, b) => a.price - b.price);
    }
    else if(sortType === 'status')
    {
        tickets.sort((a, b) => a.status.localeCompare(b.status));
    }

    return tickets;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
);