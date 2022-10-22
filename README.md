# NumericBoard_Solution
El objetivo de este juego es dado un tablero de números de mxn (m y n enteros) donde ningún numero se repite ver si es posible rellenar el tablero partiendo desde el número uno y terminando por el número n*m donde al colocar un nuevo número este es el sucesor del anterior y solo se puede colocar arriba,abajo,izquierda o derecha del número de partida.

# Implementation
Entrada: 

Un array bidimensional de enteros que contiene al 1 siendo esta la posición donde se inicia y puede o no contener más números prefijados.


Salida: 

Un array bidimensional de enteros que contiene la solución al problema.

# Ejemplo:

Entrada:

```cs
    int[,] board = new int[7,5]{    
            {1,20,0,0,35},
            {0,0,0,0,0},
            {0,0,0,0,0},   
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}
        };
```

Salida:

```cs
int[,] board = new int[7,5]{    
            {1,20,21,22,35},
            {2,19,18,23,34},
            {3,4,17,24,33},   
            {6,5,16,25,32},
            {7,8,15,26,31},
            {10,9,14,27,30},
            {11,12,13,28,29}
        };
```
Explicación: El objetivo es que se mantengan los valores prefijados del tablero de entrada, entonces a partir de ahí rellenar el tablero donde cada siguiente número (empezando por el 2) es el sucesor del número de partida. En este ejemplo el número final(35) se encontraba en la esquina superior derecha y se mantuvo en la salida al igual que el número intermedio (20).