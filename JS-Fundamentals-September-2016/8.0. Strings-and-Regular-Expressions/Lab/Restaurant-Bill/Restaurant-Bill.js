"use strict";

function restaurantBill(array) {
    let towns = array
        .filter((element, index) => index % 2 == 0);

    let bill = array
        .filter((element, index) => index % 2 != 0)
        .map(Number)
        .reduce((a, b) => a + b);

    console.log(`You purchased ${towns.join(', ')} for a total sum of ${bill}`);
}

restaurantBill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);