using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.Data.Text;

namespace MathNetPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            M<int> a = new M<int>(new int[,]{ {1,2},
                                              {4,5},
                                              {7,8} });
            a.Display();
        }

    }




    class M<T>{

        public T[,] arr; 
        
            public M(T[,] inputArr){
                
                arr = inputArr;

            }

                public void Display(){

                    for(int i = 0; i < arr.Col(0).Length; i++){
                        arr.Row(i).Display();
                        Console.WriteLine();
                    }

                }

            public void Reset(){
                arr = default(T[,]);

            }


    }



    public static class genericARRextensionMethods{
        
        public static void Display<T>(this T[] arr){

            Console.Write("[");
                for(int i = 0; i<arr.Length; i++){

                    String c;

                        String cVal = (i < arr.Length-1) ? c = "," : c = "";

                    Console.Write(arr[i]+cVal);

                }
            Console.Write("]");

        }

        public static T[] SubArray<T>(this T[] arr, int index, int lenght){
            T[] subarr = new T[lenght];
                Array.Copy(arr, index, subarr, 0, lenght);
            return subarr;
        }
        
                public static T[] Col<T>(this T[,] matrix, int columnNumber){
                    return Enumerable.Range(0, matrix.GetLength(0))
                            .Select(x => matrix[x, columnNumber])
                            .ToArray();
                }

                public static T[] Row<T>(this T[,] matrix, int rowNumber){
                    return Enumerable.Range(0, matrix.GetLength(1))
                            .Select(x => matrix[rowNumber, x])
                            .ToArray();
                }

            
            public static T[] DDSubArray<T>(this T[,] arr, int index, int length, Boolean pickFromCol = false){
                if(pickFromCol){
                            T[] subarr = new T[length];
                            T[] subarrRow = arr.Col(index);
                        Array.Copy(subarrRow, index, subarr, 0, length);
                    return subarr;
                }else{
                            T[] subarr = new T[length];
                            T[] subarrRow = arr.Row(index);
                        Array.Copy(subarrRow, index, subarr, 0, length);
                    return subarr;
                }

            }
            


    }

}
