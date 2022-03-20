// let surname = "Altun_3";

let person = {
    name: "Ahmet Tarik",
    surname: "Altun",
    age: 22,
    abilities: ['NodeJS', 'Python3'],
    brother: {
        name: "Omer",
        surname: "Altun_2",
        brotherDetail: function () {
            // console.log(this);
            return this.name + " " + surname;
        }
    }
};

console.log(person.brother.brotherDetail());