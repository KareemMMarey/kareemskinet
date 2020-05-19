//let data: any;

let data: number| string;

data = '45';
data = 10;

interface ICar  {
color: string ;
model: string;
topspeed?: number;
}
const car1: ICar = {
    color : 'blue',
    model : 'bmw'
};

const car2: ICar = {
    color : 'red',
    model : 'nissan',
    topspeed : 100
};

const multiply = (x: number, y: number): void =>
{
     x * y;
};

const multiplyReturn = (x: number, y: number): number =>
{
     return x * y;
};

const multiplyReturnString = (x: number, y: number): string =>
{
     return (x * y).toString();
};


