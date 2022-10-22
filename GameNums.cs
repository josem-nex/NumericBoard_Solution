public class GameLogic{
    public static void Main()
    {
        
        int[,] tablerp = new int[7,5]{    // introducir el tablero
            {1,0,0,0,35},
            {0,0,0,0,0},
            {0,0,1,0,0},   
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}
        };
        
        int[] dx = new[]{0,0,-1,1};  // Array de direcciones
        int[] dy = new[]{1,-1,0,0};


        Dictionary<int, (int,int)> nums = Conv(tablerp);
        //En este diccionario añado los numeros prefijados !=0 del tablero de entrada
        //lo usare en la poda de la distancia

        PRINT(tablerp);
        System.Console.WriteLine();

        PRINT(GameLogicSolution(tablerp,1,0,0,dx,dy,nums));  // retorna el tablero válido si tiene solución, null si no.

    }
    private static Dictionary<int, (int,int)> Conv(int[,] table){
        Dictionary<int, (int,int)> nums = new Dictionary<int, (int, int)>();
        for (int i = 0; i < table.GetLength(0); i++){
            for (int j = 0; j < table.GetLength(1); j++){
                if(table[i,j]!=0) nums.Add(table[i,j], (i,j));
            }
        }
        return nums;
    }
    private static int[,] GameLogicSolution(int[,] table, int n, int fil, int col, int[] dx, int[] dy, Dictionary<int,(int,int)> nums){
        if(n==table.Length){
            return table;
        }

        for (int i = 0; i < 4; i++){
            int newfil= fil+dx[i];  int newcol = col+dy[i]; // la posicion que voy a verificar
            if(!(IsValid(table, newfil, newcol))) continue;   
            // si no es una posición válida compruebo la sgte
            int pos = table[newfil,newcol];
            if(pos==n+1) return GameLogicSolution(table,n+1, newfil, newcol, dx,dy, nums);
            // si es un número prefijado(correcto) continuo por ese camino
            if(pos!=0) continue; // si es un número prefijado incorrecto compruebo la sgte posición

            if(!(CalculateDistance(table,newfil,newcol,n+1,nums))) continue;  // "PODA DE LA DISTANCIA
            
            table[newfil,newcol]= n+1;
            var sol = GameLogicSolution(table,n+1, newfil, newcol,dx,dy,nums);
            // coloco el número correcto en la posición vacía y continuo
            if(sol is not null) return sol;
            table[newfil,newcol]=0;
            //si no era un camino correcto elimino
        }
        return null;
    }
    private static bool CalculateDistance(int[,] table, int fil, int col, int n, Dictionary<int,(int,int)> nums){
        if ((n+1)>table.Length-1) return true;  // si me quedan pocas iteraciones no continuo
        
        for (int i = n; i < table.Length; i++)
        {
            if(nums.ContainsKey(i)){                // encontrar siguiente numero prefijado 
                (int, int) coord = nums[i];   //obtengo el value (las coordenadas)
                int newfil = coord.Item1;
                int newcol = coord.Item2;
                int distance = Math.Abs(fil-newfil)+Math.Abs(col-newcol);
                // calculo la distancia cuadriculada entre el sgte número y el actual(posiciones)
                // |x1-x2|+|y1-y2|  distancia cuadriclado
                int diff = i-n;
                // calculo la diferencia entre los números
                if(diff<distance) return false; 
                // si la diferencia es menor q la distancia es imposible llegar
                else return true;
            }
        }
        
        return true;
    }
    private static bool IsValid(int[,] table, int fil, int col){
        // verificar si la posicion está dentro del tablero (es correcta)
        if(((fil<0)||(fil>=table.GetLength(0)))) return false;
        if(((col<0||(col>=table.GetLength(1))))) return false;
        return true;
    }
    private static void PRINT(int[,] mask){
        // escribir en consola un array bidimensional
        if(mask==null){
            System.Console.WriteLine("null");
            return;
        }
        for (int p = 0; p < mask.GetLength(0); p++)
        {
            for (int o = 0; o < mask.GetLength(1); o++)
            {
                System.Console.Write(mask[p,o]+" ");
                
            }
            System.Console.WriteLine();
        }
    }
}