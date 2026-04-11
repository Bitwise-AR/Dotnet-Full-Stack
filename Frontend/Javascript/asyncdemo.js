async function print1() {
    for (let i=1; i<=10; i++)
        console.log(i);
}

function print2() {
    for (let i=11; i<=20; i++) 
        console.log(i);
}

// print1();
// print2();

async function add(a, b) { return a + b; }
function add2(a, b){
    return new Promise((resolve, reject) => {
        let c = a + b;
        try{
            resolve(c);
        } catch (e) {
            reject(e);
        }
    })
}
async function addAll(a, b, c){
    let s1 = await add(a, b);
    s1 = s1 + await add(s1, c);
    let prm = add (4, 5);
    prm.then((res) => { })
        .catch(err => { });
        w
    return s1;
}

// var s = add(4, 5);
// s.then((result) => {
//     console.log("Promise completed, function runnning is over");
//     console.log("Result is: " + result);
// })
// console.log(s);

// var todo = fetch("https://jsonplaceholder.typicode.com/todos/1");
// todo.then((res) => {
//     console.log(res.json());
// })

async function divide(a, b) { if (b == 0) throw "divide by zero error"; return a / b; }
function divideTest(x, y) {
    divide(x, y).then((res) => {
        console.log("divide success result " + res);
    })
        .catch((err) => {
            console.log("divide failed error " + err);
        });
}

divideTest(5, 1);
divideTest(5, 0);