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

            return VectorAndKey.OrderBy(x => x.Key).Select(x => x.Value).ToArray();
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

            int[,] matrix5 = new int[,]
        {
               {3,4,5,6,7},
               {0,13,6,7,8},
               {0,0,12,9,10},
               {0,0,0,11,12},
               {0,0,0,0,12},
        };

            int[,] matrix6 = new int[,]
        {
               {3,4,5,6,7},
               {0,13,6,7,8},
               {0,0,12,9,10},
               {0,0,0,11,12},
               {0,0,0,0,12},
        };


            var vectro3x3 = GetVector(matrix);
            var vectrotwo3x3 = GetVector(matrix2);
            var vectro4x4 = GetVector(matrix3);
            var vectrotwo4x4 = GetVector(matrix4);
            var table = new ConsoleTable("Type Matrix", "Method", "Time");
            var tablevector = new ConsoleTable("Type Matrix", "Method", "Time");

            Stopwatch stopWatchMatrix = new Stopwatch();
            Stopwatch stopWatchvector = new Stopwatch();

            #region Matrix3x3
            //Trans
            List<double> Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchMatrix.Start();
                var transmatrix = TransposeMatrix(matrix);
                stopWatchMatrix.Stop();
                Result.Add(stopWatchMatrix.Elapsed.TotalMilliseconds);
                stopWatchMatrix.Reset();
            }
            table.AddRow("3x3", "TransposeMatrix", Result.Average() + " мс");
            //Sum
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchMatrix.Start();
                var sumMatrix = SumMatrix(matrix, matrix2);
                stopWatchMatrix.Stop();
                Result.Add(stopWatchMatrix.Elapsed.TotalMilliseconds);
                stopWatchMatrix.Reset();
            }
            table.AddRow("3x3", "SumMatrix", Result.Average() + " мс");
            //multiplicationMatrix
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchMatrix.Start();
                var multiplicationMatrix = MultiplicationMatrix(matrix, matrix2);
                stopWatchMatrix.Stop();
                Result.Add(stopWatchMatrix.Elapsed.TotalMilliseconds);
                stopWatchMatrix.Reset();
            }
            table.AddRow("3x3", "MultiplicationMatrix", Result.Average() + " мс");
            #endregion

            #region Vector3x3
            
            //Trans
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchvector.Start();
                var transvectror = TransposeVector(vectro3x3);
                stopWatchvector.Stop();
                Result.Add(stopWatchvector.Elapsed.TotalMilliseconds);
                stopWatchvector.Reset();
            }
            tablevector.AddRow("3x3", "TransposeVector", Result.Average() + " мс");
            //Sum
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchvector.Start();
                var sumvector = SumVector(vectro3x3, vectrotwo3x3);
                stopWatchvector.Stop();
                Result.Add(stopWatchvector.Elapsed.TotalMilliseconds);
                stopWatchvector.Reset();
            }
            tablevector.AddRow("3x3", "SumVector", Result.Average() + " мс");
            //mult
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchvector.Start();
                var multiplicationVector = MultiplicationVector(vectro3x3, vectrotwo3x3);
                stopWatchvector.Stop();
                Result.Add(stopWatchvector.Elapsed.TotalMilliseconds);
                stopWatchvector.Reset();
            }
            tablevector.AddRow("3x3", "MultiplicationVector", Result.Average() + " мс");
            #endregion

            var table4x4 = new ConsoleTable("Type Matrix", "Method", "Time");
            var tablevector4x4 = new ConsoleTable("Type Matrix", "Method", "Time");


            #region Matrix4x4
            //Trans
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchMatrix.Start();
                var transmatrix = TransposeMatrix(matrix3);
                stopWatchMatrix.Stop();
                Result.Add(stopWatchMatrix.Elapsed.TotalMilliseconds);
                stopWatchMatrix.Reset();
            }
            table4x4.AddRow("4x4", "TransposeMatrix", Result.Average() + " мс");
            //Sum
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchMatrix.Start();
                var sumMatrix = SumMatrix(matrix3, matrix4);
                stopWatchMatrix.Stop();
                Result.Add(stopWatchMatrix.Elapsed.TotalMilliseconds);
                stopWatchMatrix.Reset();
            }
            table4x4.AddRow("4x4", "SumMatrix", Result.Average() + " мс");
            //multiplicationMatrix
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchMatrix.Start();
                var multiplicationMatrix = MultiplicationMatrix(matrix3, matrix4);
                stopWatchMatrix.Stop();
                Result.Add(stopWatchMatrix.Elapsed.TotalMilliseconds);
                stopWatchMatrix.Reset();
            }
            table4x4.AddRow("4x4", "MultiplicationMatrix", Result.Average() + " мс");
            #endregion

            #region Vector4x4         
            //Trans
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchvector.Start();
                var transvectror = TransposeVector(vectro4x4);
                stopWatchvector.Stop();
                Result.Add(stopWatchvector.Elapsed.TotalMilliseconds);
                stopWatchvector.Reset();
            }
            tablevector4x4.AddRow("4x4", "TransposeVector", Result.Average() + " мс");
            //Sum
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchvector.Start();
                var sumvector = SumVector(vectro4x4, vectrotwo4x4);
                stopWatchvector.Stop();
                Result.Add(stopWatchvector.Elapsed.TotalMilliseconds);
                stopWatchvector.Reset();
            }
            tablevector4x4.AddRow("4x4", "SumVector", Result.Average() + " мс");
            //mult
            Result = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                stopWatchvector.Start();
                var multiplicationVector = MultiplicationVector(vectro4x4, vectrotwo4x4);
                stopWatchvector.Stop();
                Result.Add(stopWatchvector.Elapsed.TotalMilliseconds);
                stopWatchvector.Reset();
            }
            tablevector4x4.AddRow("4x4", "MultiplicationVector", Result.Average() + " мс");
            #endregion

            table.Write(Format.Alternative);
            tablevector.Write(Format.Alternative);

            table4x4.Write(Format.Alternative);
            tablevector4x4.Write(Format.Alternative);



        }
    }
}