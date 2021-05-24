using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleTables;
using System.Diagnostics;

namespace LR7TrianglMatrix
{
    class Program
    {

        public static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] TransposeMatrix(int[,] matrix)
        {
            var trmatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    trmatrix[i, j] = matrix[j, i];
                }
            }
            return trmatrix;
        }

        public static int[,] TransposeVector(int[] vector)
        {
            int n = (-1 + (int)Math.Sqrt(1 - 4 * (-2 * vector.Length))) / (2);

            int[,] matrix = new int[n, n];

            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        continue;
                    }
                    matrix[i, j] = vector[k];
                    k++;
                }
            }
            return matrix;
        }

        public static int[,] SumMatrix(int[,] matrix1, int[,] matrix2)
        {
            var finalMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    finalMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return finalMatrix;
        }

        public static int[] SumVector(int[] vector1, int[] vector2)
        {
            int[] sumVector = new int[vector1.Length];

            for (int i = 0; i < vector1.GetLength(0); i++)
            {
                sumVector[i] = vector1[i] + vector2[i];
            }
            return sumVector;
        }


        public static int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
        {
            var finalMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        finalMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return finalMatrix;
        }

        public static int[] MultiplicationVector(int[] vector1, int[] vector2)
        {
            int n = (-1 + (int)Math.Sqrt(1 - 4 * (-2 * vector1.Length))) / (2);

            int[] finalvectro = new int[vector1.Length];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (i > k)
                        {
                            continue;
                        }
                        if (k > j)
                        {
                            continue;
                        }
                        int key1 = ((k + 1) * (k) / 2 + (i + 1)) - 1;
                        int key2 = ((j + 1) * (j) / 2 + (k + 1)) - 1;
                        if (key1 >= vector1.Length)
                        {
                            key1 = 0;
                        }
                        if (key2 >= vector1.Length)
                        {
                            key2 = 0;
                        }
                        finalvectro[((j + 1) * (j) / 2 + (i + 1)) - 1] += vector1[key1] * vector2[key2];
                    }
                }
            }


            return finalvectro;
        }

        public static int[,] GetMatrix(int[] vector)
        {
            int n = (-1 + (int)Math.Sqrt(1 - 4 * (-2 * vector.Length))) / (2);

            int[,] matrix = new int[n, n];

            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < j)
                    {
                        continue;
                    }
                    matrix[j, i] = vector[k];
                    k++;
                }
            }

            return matrix;
        }

        public static int[] GetVector(int[,] matrix)
        {
            Dictionary<int, int> VectorAndKey = new Dictionary<int, int>();
            List<int> VectroArray = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < i)
                    {
                        continue;
                    }
                    int key = (j + 1) * (j) / 2 + (i + 1);
                    VectorAndKey.Add(key, matrix[i, j]);
                }
            }

            foreach (var item in VectorAndKey.OrderBy(x => x.Key))
            {
                VectroArray.Add(item.Value);
            }
            return VectroArray.ToArray();
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {1,2,3},
                {0,4,5},
                {0,0,6},
            };

            int[,] matrix2 = new int[,]
            {
                {7,8,9},
                {0,10,11},
                {0,0,12},
            };

            int[,] matrix3 = new int[,]
          {
               {1,2,3,4},
               {0,5,6,7},
               {0,0,8,9},
               {0,0,0,10},
          };

            int[,] matrix4 = new int[,]
         {
               {3,4,5,6},
               {0,13,6,7},
               {0,0,12,9},
               {0,0,0,11},
         };

            var vectro3x3 = GetVector(matrix);
            var vectrotwo3x3 = GetVector(matrix2);

            var vectro4x4 = GetVector(matrix3);
            var vectrotwo4x4 = GetVector(matrix4);

            var table = new ConsoleTable("Type Matrix", "Method", "Time");

            var tablevector = new ConsoleTable("Type Matrix", "Method", "Time");



            Stopwatch stopWatchMatrix3x3 = new Stopwatch();

            //Matrix3x3
            //Transpose
            stopWatchMatrix3x3.Start();
            var transmatrix = TransposeMatrix(matrix);
            stopWatchMatrix3x3.Stop();
            table.AddRow("3x3", "TransposeMatrix", stopWatchMatrix3x3.Elapsed.TotalMilliseconds + "мс");
            stopWatchMatrix3x3.Reset();
            //
            //Sum     
            stopWatchMatrix3x3.Start();
            var sumMatrix = SumMatrix(matrix, matrix2);
            stopWatchMatrix3x3.Stop();
            table.AddRow("3x3", "SumMatrix", stopWatchMatrix3x3.Elapsed.TotalMilliseconds + "мс");
            stopWatchMatrix3x3.Reset();
            //
            //multiplicationMatrix
            stopWatchMatrix3x3.Start();
            var multiplicationMatrix = MultiplicationMatrix(matrix, matrix2);
            stopWatchMatrix3x3.Stop();
            table.AddRow("3x3", "MultiplicationMatrix", stopWatchMatrix3x3.Elapsed.TotalMilliseconds + "мс");
            stopWatchMatrix3x3.Reset();
         //Matrix3x3








            //vector3x3
            Stopwatch stopWatchvector3x3 = new Stopwatch();
            //transvect    
            stopWatchvector3x3.Start();
            var transvectror = TransposeVector(vectro3x3);
            stopWatchvector3x3.Stop();
            tablevector.AddRow("3x3", "TransposeVector", stopWatchvector3x3.Elapsed.TotalMilliseconds + "мс");
            stopWatchvector3x3.Reset();
            //sumvect
            stopWatchvector3x3.Start();
            var sumvector = SumVector(vectro3x3, vectrotwo3x3);
            stopWatchvector3x3.Stop();
            tablevector.AddRow("3x3", "SumVector", stopWatchvector3x3.Elapsed.TotalMilliseconds + "мс");
            stopWatchvector3x3.Reset();
            //mult
            stopWatchvector3x3.Start();
            var multiplicationVector = MultiplicationVector(vectro3x3, vectrotwo3x3);
            stopWatchvector3x3.Stop();
            tablevector.AddRow("3x3", "MultiplicationVector", stopWatchvector3x3.Elapsed.TotalMilliseconds + "мс");
            stopWatchvector3x3.Reset();
            //vector3x3




            var table4x4 = new ConsoleTable("Type Matrix", "Method", "Time");
            var tablevector4x4 = new ConsoleTable("Type Matrix", "Method", "Time");






            Stopwatch stopWatchMatrix4x4 = new Stopwatch();
            //Matrix4x4
            //Transpose
            stopWatchMatrix4x4.Start();
            var transmatrix4x4 = TransposeMatrix(matrix3);
            stopWatchMatrix4x4.Stop();
            table4x4.AddRow("4x4", "TransposeMatrix", stopWatchMatrix4x4.Elapsed.TotalMilliseconds + "мс");
            stopWatchMatrix4x4.Reset();
            //
            //Sum     
            stopWatchMatrix4x4.Start();
            var sumMatrix4x4 = SumMatrix(matrix3, matrix4);
            stopWatchMatrix4x4.Stop();
            table4x4.AddRow("4x4", "SumMatrix", stopWatchMatrix4x4.Elapsed.TotalMilliseconds + "мс");
            stopWatchMatrix4x4.Reset();
            //
            //multiplicationMatrix
            stopWatchMatrix4x4.Start();
            var multiplicationMatrix4x4 = MultiplicationMatrix(matrix3, matrix4);
            stopWatchMatrix4x4.Stop();
            table4x4.AddRow("4x4", "MultiplicationMatrix", stopWatchMatrix4x4.Elapsed.TotalMilliseconds + "мс");
            stopWatchMatrix4x4.Reset();
            //Matrix4x4







            Stopwatch stopWatchVector4x4 = new Stopwatch();
            //vectro4x4
            //transvect    
            stopWatchVector4x4.Start();
            var transvectror4x4 = TransposeVector(vectro4x4);
            stopWatchVector4x4.Stop();
            tablevector4x4.AddRow("4x4", "TransposeVector", stopWatchVector4x4.Elapsed.TotalMilliseconds + "мс");
            stopWatchVector4x4.Reset();
            //sumvect
            stopWatchVector4x4.Start();
            var sumvector4x4 = SumVector(vectro4x4, vectrotwo4x4);
            stopWatchVector4x4.Stop();
            tablevector4x4.AddRow("4x4", "SumVector", stopWatchVector4x4.Elapsed.TotalMilliseconds + "мс");
            stopWatchVector4x4.Reset();
            //mult
            stopWatchVector4x4.Start();
            var multiplicationVector4x4 = MultiplicationVector(vectro4x4, vectrotwo4x4);
            stopWatchVector4x4.Stop();
            tablevector4x4.AddRow("4x4", "MultiplicationVector", stopWatchVector4x4.Elapsed.TotalMilliseconds + "мс");
            stopWatchVector4x4.Reset();
            // vextor4x4




            table.Write(Format.Alternative);
            tablevector.Write(Format.Alternative);

            table4x4.Write(Format.Alternative);
            tablevector4x4.Write(Format.Alternative);


            Console.WriteLine("TranseMatrix");
            WriteMatrix(transmatrix);
            Console.WriteLine();
            Console.WriteLine("TranseVectror");
            WriteMatrix(transvectror);
            Console.WriteLine();

            Console.WriteLine("SumMatrix");
            WriteMatrix(sumMatrix);
            Console.WriteLine();
            Console.WriteLine("SumVectror");
            WriteMatrix(GetMatrix(sumvector));
            Console.WriteLine();

            Console.WriteLine("MultipMatrix");
            WriteMatrix(multiplicationMatrix);
            Console.WriteLine();
            Console.WriteLine("MultipVectror");
            WriteMatrix(GetMatrix(multiplicationVector));
            Console.WriteLine();







            Console.WriteLine("TranseMatrix");
            WriteMatrix(transmatrix4x4);
            Console.WriteLine();
            Console.WriteLine("TranseVectror");
            WriteMatrix(transvectror4x4);
            Console.WriteLine();

            Console.WriteLine("SumMatrix");
            WriteMatrix(sumMatrix4x4);
            Console.WriteLine();
            Console.WriteLine("SumVectror");
            WriteMatrix(GetMatrix(sumvector4x4));
            Console.WriteLine();

            Console.WriteLine("MultipMatrix");
            WriteMatrix(multiplicationMatrix4x4);
            Console.WriteLine();
            Console.WriteLine("MultipVectror");
            WriteMatrix(GetMatrix(multiplicationVector4x4));
            Console.WriteLine();
        }
    }
}
