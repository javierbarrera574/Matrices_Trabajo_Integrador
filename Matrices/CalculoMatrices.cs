namespace Matrices
{
    public class CalculoMatrices
    {

        #region Operaciones
        public static float[,] SumaMatrices(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    matrizResultante[x, y] = matriz1[x, y] += matriz2[x, y];
                }
            }
            return matrizResultante;
        }


        public static float[,] DiferenciaMatrices(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    matrizResultante[x, y] = matriz1[x, y] -= matriz2[x, y];
                }
            }
            return matrizResultante;
        }


        public static float[,] MultiplicarMatrices(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultante = new float[matriz1.GetLength(0), matriz2.GetLength(1)];
            for (int x = 0; x < matrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultante.GetLength(1); y++)
                {
                    for (int n = 0; n < matriz2.GetLength(0); n++)
                    {
                        string i = "" + matriz1[x, n];
                        matrizResultante[x, y] += matriz1[x, n] * matriz2[n, y];
                    }
                }
            }
            return matrizResultante;
        }

        public static float[,] Opuesta(float[,] matriz)
        {
            float[,] matrizOpuesta = new float[matriz.GetLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizOpuesta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizOpuesta.GetLength(1); y++)
                {
                    matrizOpuesta[x, y] += matriz[x, y] * -1;
                }
            }
            return matrizOpuesta;
        }


        public static float[,] Transpuesta(float[,] matriz)
        {
            float[,] matrizTranspuesta = new float[matriz.GetLength(1), matriz.GetLength(0)];
            for (int x = 0; x < matrizTranspuesta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizTranspuesta.GetLength(1); y++)
                {
                    matrizTranspuesta[x, y] += matriz[y, x];
                }
            }
            return matrizTranspuesta;
        }



        public static float Determinante2x2(float[,] matriz)
        {
            float diagonalPrincipal = 1;
            float diagonalSecundaria = 1;
            float determinanteFinal = 0;
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    if (x == y)
                    {
                        diagonalPrincipal *= matriz[x, y];
                    }
                }
            }
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    if (x != y)
                    {
                        diagonalSecundaria *= matriz[x, y];
                    }
                }
            }
            determinanteFinal = diagonalPrincipal - diagonalSecundaria;
            return determinanteFinal;
        }
        public static float Determinante3x3(float[,] matriz)
        {
            float diagonalPrincipal = 0;
            float diagonalSecundaria = 0;
            float determinanteFinal = 0;
            int tamanhoSarrus = (((matriz.GetLength(0) * matriz.GetLength(1)) * 2) / 3) - 1;
            float[,] Sarrus = new float[matriz.GetLength(0), tamanhoSarrus];
            for (int x = 0; x < Sarrus.GetLength(0); x++)
            {
                for (int y = 0; y < Sarrus.GetLength(1); y++)
                {
                    if (y > matriz.GetLength(0) - 1)
                    {
                        Sarrus[x, y] += matriz[x, y - matriz.GetLength(0)];
                    }
                    else
                    {
                        Sarrus[x, y] += matriz[x, y];
                    }
                }
            }
            int voltas = 3;
            for (int i = 0; i < voltas; i++)
            {
                int numero = i;
                float mDiagonal = 1;
                for (int x = 0; x < Sarrus.GetLength(0); x++)
                {
                    for (int y = 0; y < Sarrus.GetLength(1); y++)
                    {
                        if (x == y)
                        {
                            string z = "" + Sarrus[x, y + numero];
                            mDiagonal *= Sarrus[x, y + numero];
                        }
                    }
                }
                diagonalPrincipal += mDiagonal;
            }

            for (int i = 0; i < voltas; i++)
            {
                int numero = i;
                float mDiagonal = 1;
                for (int x = 0; x < Sarrus.GetLength(0); x++)
                {
                    for (int y = Sarrus.GetLength(1) - 1; y > 0; y--)
                    {
                        if (x == (Sarrus.GetLength(1) - 1) - y)
                        {
                            string z = "" + Sarrus[x, y - numero];
                            mDiagonal *= Sarrus[x, y - numero];
                        }
                    }
                }
                diagonalSecundaria += mDiagonal;
            }
            determinanteFinal = diagonalPrincipal - diagonalSecundaria;
            return determinanteFinal;
        }





        public static float[,] MatrizCofactor2x2(float[,] matriz1)
        {
            float[,] matrizCofactor = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            float determinantePrincipal = 0;

            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    if (x == 0 && y == 0)
                    {
                        determinantePrincipal = matriz1[x + 1, y + 1];
                    }
                    else if (x == 0 && y == 1)
                    {
                        determinantePrincipal = matriz1[x + 1, y - 1];
                    }
                    else if (x == 1 && y == 0)
                    {
                       determinantePrincipal = matriz1[x - 1, y + 1];
                    }
                    else if (x == 1 && y == 1)
                    {
                       determinantePrincipal = matriz1[x - 1, y - 1];
                    }
                    double i = Math.Pow(-1, (x + y));
                    matrizCofactor[x, y] += (float)i * determinantePrincipal;
                }
            }
            return matrizCofactor;
        }
        public static float[,] MatrizCofactor3x3(float[,] matriz1)
        {
            float[,] matrizCofactor = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            float determinantePrincipal = 0;

            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    determinantePrincipal = DeterminanteCofactor(x, y, matriz1);
                    double i = Math.Pow(-1, (x + y));
                    matrizCofactor[x, y] += (float)i * determinantePrincipal;
                }
            }
            return matrizCofactor;
        }
        private static float DeterminanteCofactor(int posX, int posY, float[,] matriz)
        {
            float[,] matrizResultante = new float[2, 2];
            int id = 0;
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    if (x != posX && y != posY)
                    {
                        if (id == 0)
                        {
                            matrizResultante[0, 0] += matriz[x, y];
                        }
                        else if (id == 1)
                        {
                            matrizResultante[0, 1] += matriz[x, y];
                        }
                        else if (id == 2)
                        {
                            matrizResultante[1, 0] += matriz[x, y];
                        }
                        else if (id == 3)
                        {
                            matrizResultante[1, 1] += matriz[x, y];
                        }
                        id++;
                    }
                }
            }
            float determinate = Determinante2x2(matrizResultante);
            return determinate;
        }
        public static float[,] Inversa(float determinante, float[,] matriz1)
        {
            float[,] matrizInversa = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    float n = matriz1[x, y];
                    n = n / determinante;
                    matrizInversa[x, y] += n;
                }
            }

            return matrizInversa;
        }


    }

    #endregion
}