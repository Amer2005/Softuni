function solve(type, weightInGrams, pricePerKilo)
{
    let weightInKilos = weightInGrams / 1000;

    let totalPirce = weightInKilos * pricePerKilo;

    console.log(`I need $${totalPirce.toFixed(2)} to buy ${weightInKilos.toFixed(2)} kilograms ${type}.`)
}

solve('orange', 2500, 1.80);