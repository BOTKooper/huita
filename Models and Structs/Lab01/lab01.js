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


function BubbleSort(ARR) {
    var arr = ARR.slice(0);
    var n = arr.length;
    var sravn = 0;
    var obmen = 0;
    for (var i = 0; i < n - 1; i++) {
        for (var j = 0; j < n - 1 - i; j++) {
            sravn++
            if (arr[j + 1] < arr[j]) {
                obmen++;
                var t = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = t;
            }
        }
    }
    return [arr, sravn, obmen];
}


function InsertionSort(ARR) {
    var arr = ARR.slice(0);

    let length = arr.length;
    let sravn = 0;
    let obmen = 0;

    for (let i = 1; i < length; i++) {
        let key = arr[i];
        let j = i - 1;
        while (j >= 0 && arr[j] > key && sravn++) {
            obmen++;
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
    return [arr, sravn, obmen];
}

function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}


//  [0..600] 
function generage(n) { // random 
    var arr = [];
    for (let i = 0; i < n; i++) {
        arr[i] = getRandomInt(600);
    }
    return arr;
}

var answers = [];
for (let i = 0; i < 15; i++) {
    answers[i] = [];
}



//array gen

for (let repeating = 0; repeating < 1; repeating++) {
    let ARRAY = [];

    for (let i = 0; i < 3; i++) {
        ARRAY[i] = [];
    }
    for (let i = 1; i < 11; i++) {
        let tmparr = generage(i*5);
        ARRAY[0] = tmparr;
        ARRAY[1] = tmparr.sort((a, b) => a - b).slice(0);
        ARRAY[2] = ARRAY[1].reverse();

//console.log(ARRAY[1]);



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

        answers[i][0] = [
            [
                sort_insert[0][1],
                sort_insert[0][2]
            ],
            [
                sort_insert[1][1],
                sort_insert[1][2]
            ],
            [
                sort_insert[2][1],
                sort_insert[2][2]
            ]

        ];
        answers[i][1] = [
            [
                sort_bubble[0][1],
                sort_bubble[0][2]
            ],
            [
                sort_bubble[1][1],
                sort_bubble[1][2]
            ],
            [
                sort_bubble[2][1],
                sort_bubble[2][2]
            ]
        ];
        console.log(answers[i][0]);
        console.log('');
        console.log(answers[i][1]);
        console.log('');
        console.log('');
        console.log('');



    }



}