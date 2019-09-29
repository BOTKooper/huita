/* 
insertion:

step |array             |N sr   |N obm  |Summ|
0    |(3)(4 5 6 10 2 3  |-    |-      |-
1    |(3 4)(5 6 10 2 3  |1    |0      |1
2    |(3 4 5)(6 10 2 3  |1    |0      |1
3    |(3 4 5 6)(10 2 3) |1    |0      |1
4    |(3 4 5 6 10)(2 3) |1    |0      |1
5    |(2 3 4 5 6 10)(3) |5    |5      |10
6    |(2 3 3 4 5 6 10)  |5    |5      |10
                      --/14   /10     /24


bubble:
step |array             |Nsr    |Nobm   |Summ
0    |3 4 5 6 (10 2) 3  |-      |-      |-
1    |3 4 5 6 2 (10 3)  |5      |1      |6
2    |3 4 5 (6 2) 3 10  |1      |1      |2
3    |3 4 5 2 (6 3) 10  |4      |1      |5
4    |3 4 (5 2) 3 6 10  |1      |1      |2
5    |3 4 2 (5 3) 6 10  |3      |1      |4
6    |3 (4 2) 3 5 6 10  |1      |1      |2
7    |3 2 (4 3) 5 6 10  |2      |1      |3
8    |(3 2) 3 4 5 6 10  |1      |1      |2
9    |(2 3 3 4 5 6 10)
                      --/18     /8      /26

*/

// Реализация сортировки пузырькем (возвращает кол-во сравнений и обменов)
function BubbleSort(ARR) {
    let arr = ARR.slice(0);
    let n = arr.length;
    let sravn = 0;
    let obmen = 0;
    for (let i = 0; i < n - 1; i++) {
        for (let j = 0; j < n - 1 - i; j++) {
            if (sravn++ && (arr[j + 1] < arr[j])) {
                obmen++;
                let t = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = t;
            }
        }
    }
    return {
        sravn: sravn,
        obmen: obmen
    };
}

// Реализация сортировки вставками (возвращает кол-во сравнений и обменов)
function InsertionSort(ARR) {
    let arr = ARR.slice(0);

    let length = arr.length;
    let sravn = 0;
    let obmen = 0;

    for (let i = 1; i < length; i++) {
        let key = arr[i];
        let j = i - 1;
        while (sravn++ && j >= 0 && arr[j] > key) {
            obmen++;
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
    return {
        sravn: sravn,
        obmen: obmen
    };
}

// Получение случайного числа от 0, по {max}
function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}

//Генерация случаного массива  [0..600] 
function generage(n) { // random 
    var arr = [];
    for (let i = 0; i < n; i++) {
        arr[i] = getRandomInt(600);
    }
    return arr;
}

// Кол-во повторений для каждого из кол-ва элементов массива
const REPEATINGS = 5000;

// Массив с результатами, для каждого прогона
var answers = [];
for (let i = 0; i < REPEATINGS; i++) {
    answers[i] = [];
    for(let j = 0; j < 11; j++){
        answers[i][j] = [];
    }
}

// Общий цикл повторений
for (let repeating = 0; repeating < REPEATINGS; repeating++) {
    let ARRAY = [];
    for (let i = 0; i < 3; i++) {
        ARRAY[i] = [];
    }
    // Цикл генерации массивов заданных размеров ( 5..50 с шагом 5)
    for (let i = 1; i < 11; i++) {
        let tmparr = generage(i*5);
        ARRAY[0] = tmparr.slice(0);
        ARRAY[1] = tmparr.sort((a, b) => a - b).slice(0);
        ARRAY[2] = tmparr.sort((a, b) => b - a).slice(0);
        let sort_insert = [
            InsertionSort(ARRAY[0]),
            InsertionSort(ARRAY[1]),
            InsertionSort(ARRAY[2])
        ];
        let sort_bubble = [
            BubbleSort(ARRAY[0]),
            BubbleSort(ARRAY[1]),
            BubbleSort(ARRAY[2])
        ];
        answers[repeating][i][0] = [
            [
                sort_insert[0].sravn,   // sravn
                sort_insert[0].obmen,   // obmen
            ],
            [
                sort_insert[1].sravn,
                sort_insert[1].obmen,
            ],
            [
                sort_insert[2].sravn,
                sort_insert[2].obmen,
            ],

        ];
        answers[repeating][i][1] = [
            [
                sort_bubble[0].sravn,
                sort_bubble[0].obmen,
            ],
            [
                sort_bubble[1].sravn,
                sort_bubble[1].obmen,
            ],
            [
                sort_bubble[2].sravn,
                sort_bubble[2].obmen,
            ]
        ];
    }
}
// Нормализация результатов, методом подсчета среднего арифметического
var summ = []
for(let i = 0; i < 11; i++){
    
        summ[i] = {
            INSsravn: [0, 0, 0],
            INSobmen: [0, 0, 0],
            INSsumm: [0, 0, 0],
            BUBsravn: [0, 0, 0],
            BUBobmen: [0, 0, 0],
            BUBsumm: [0, 0, 0],
        };
}
for(let i = 1; i < 11; i++){
    for(let j = 0; j < REPEATINGS; j++){
        for(let k = 0; k < 3; k++){
            
            summ[i].INSsravn[k] += answers[j][i][0][k][0] // sravn // random -> sorted -> sorted & reversed
            summ[i].INSobmen[k] += answers[j][i][0][k][1] // obmen

            summ[i].BUBsravn[k] += answers[j][i][1][k][0] // sravn // random -> sorted -> sorted & reversed
            summ[i].BUBobmen[k] += answers[j][i][1][k][1] // obmen
        }
    }
}

for(let i = 1; i < 11; i++){
    for(let k = 0; k < 3; k++){
        summ[i].INSsravn[k] /= REPEATINGS;
        summ[i].INSobmen[k] /= REPEATINGS;

        summ[i].INSsumm[k] = summ[i].INSsravn[k] + summ[i].INSobmen[k]

        summ[i].BUBsravn[k] /= REPEATINGS;
        summ[i].BUBobmen[k] /= REPEATINGS;

        summ[i].BUBsumm[k] = summ[i].BUBsravn[k] + summ[i].BUBobmen[k]

    }
    // Вывод результатов 
    console.log(`${i*5} elements: ${JSON.stringify(summ[i])}\n\n`);
}
