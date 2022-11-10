namespace Matrices
{
    public partial class FormMatrices : Form
    {
        private TextBox[,] Matriz1;
        private TextBox[,] Matriz2;
        private TextBox[,] MatrizResultado;
        private float determinante;

        int Fila1, Columna1;
        int Fila2, Columna2;

        #region Matrices

        private void btCargarM1_Click(object sender, EventArgs e)
        {
            groupBoxMatriz1.Controls.Clear();

            if (!int.TryParse(txtFilaM1.Text, out Fila1))
            {
                MessageBox.Show("La fila de la matriz 1 es nula.", "Error");
                return;
            }
            if (!int.TryParse(txtColumnaM1.Text, out Columna1))
            {
                MessageBox.Show("La columna de la matriz 1 es nula.", "Error");
                return;
            }

            Matriz1 = new TextBox[Fila1, Columna1];
            int TamañoTexto = groupBoxMatriz1.Width / Columna1;
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = "0";
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamañoTexto + 6;
                    Matriz1[x, y].Width = TamañoTexto;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }

        private void btCargarM2_Click(object sender, EventArgs e)
        {
            groupBoxMatriz2.Controls.Clear();

            if (!int.TryParse(txtFilaM2.Text, out Fila2))
            {
                MessageBox.Show("La fila de la matriz 2 es nula.", "Error");
                return;
            }
            if (!int.TryParse(txtColumnaM2.Text, out Columna2))
            {
                MessageBox.Show("La columna de la matriz 2 es nula.", "Error");
                return;
            }
            int TamañoTexto = groupBoxMatriz2.Width / Columna2;
            Matriz2 = new TextBox[Fila2, Columna2];
            TamañoTexto = groupBoxMatriz2.Width / Columna2;
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = "0";
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamañoTexto + 6;
                    Matriz2[x, y].Width = TamañoTexto;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }


        #endregion

        #region Operaciones
        private void btSuma_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz de valor nulo !", "Error - Matriz nula");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("¡Solo es posible sumar matrices del mismo orden!", "Error - Sumar Matrices");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float numero=0;
                    float.TryParse(Matriz1[x, y].Text, out numero);
                    tempMatriz1[x, y] = numero;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float numero1=0;
                    float.TryParse(Matriz2[x, y].Text, out numero1);
                    tempMatriz2[x, y] = numero1;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.SumaMatrices(tempMatriz1, tempMatriz2);
            MatrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamañoTexto = groupBoxMatrizResultado.Width / MatrizResultado.GetLength(1);
            groupBoxMatrizResultado.Controls.Clear();
            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    MatrizResultado[x, y] = new TextBox();
                    MatrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultado[x, y].Top = (x * MatrizResultado[x, y].Height) + 20;
                    MatrizResultado[x, y].Left = y * TamañoTexto + 6;
                    MatrizResultado[x, y].Width = TamañoTexto;
                    groupBoxMatrizResultado.Controls.Add(MatrizResultado[x, y]);
                }
            }
        }

        private void btDiferencia_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz de valor nulo !", "Error - Matriz nula");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("¡Solo es posible restar matrices del mismo orden!", "Error - Agregar Matrices");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float numero=0;
                    float.TryParse(Matriz1[x, y].Text, out numero);
                    tempMatriz1[x, y] = numero;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float numero1=0;
                    float.TryParse(Matriz2[x, y].Text, out numero1);
                    tempMatriz2[x, y] = numero1;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.DiferenciaMatrices(tempMatriz1, tempMatriz2);
            MatrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamañoTexto = groupBoxMatrizResultado.Width / MatrizResultado.GetLength(1);
            groupBoxMatrizResultado.Controls.Clear();
            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    MatrizResultado[x, y] = new TextBox();
                    MatrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultado[x, y].Top = (x * MatrizResultado[x, y].Height) + 20;
                    MatrizResultado[x, y].Left = y * TamañoTexto + 6;
                    MatrizResultado[x, y].Width = TamañoTexto;
                    groupBoxMatrizResultado.Controls.Add(MatrizResultado[x, y]);
                }
            }
        }

        private void btMultiplicar_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz de valor nulo !", "Error - Matriz nula");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(1) != tempMatriz2.GetLength(0))
            {
                MessageBox.Show("¡Solo es posible multiplicar matrices donde la columna de la matriz 1 es igual a la fila de la matriz 2!", "Error - Multiplicación de matrices");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float numero=0;
                    float.TryParse(Matriz1[x, y].Text, out numero);
                    tempMatriz1[x, y] = numero;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float numero1=0;
                    float.TryParse(Matriz2[x, y].Text, out numero1);
                    tempMatriz2[x, y] = numero1;

                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.MultiplicarMatrices(tempMatriz1, tempMatriz2);
            MatrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultado.Width / MatrizResultado.GetLength(1);
            groupBoxMatrizResultado.Controls.Clear();
            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    MatrizResultado[x, y] = new TextBox();
                    MatrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultado[x, y].Top = (x * MatrizResultado[x, y].Height) + 20;
                    MatrizResultado[x, y].Left = y * TamanhoText + 6;
                    MatrizResultado[x, y].Width = TamanhoText;
                    groupBoxMatrizResultado.Controls.Add(MatrizResultado[x, y]);
                }
            }
        }

        #endregion

        #region MatrizResultado
        private void btOpuestaMresultado_Click(object sender, EventArgs e)
        {
            if (MatrizResultado == null)
            {
                MessageBox.Show("Matriz de valor nulo !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[MatrizResultado.GetLength(0), MatrizResultado.GetLength(1)];

            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    float numero=0;
                    float.TryParse(MatrizResultado[x, y].Text, out numero);
                    tempResultante[x, y] = numero;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.Opuesta(tempResultante);
            int TamañoTexto = groupBoxMatrizResultado.Width / MatrizResultado.GetLength(1);
            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    MatrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }

        private void btTranspuestaMresultado_Click(object sender, EventArgs e)
        {
            if (MatrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[MatrizResultado.GetLength(0), MatrizResultado.GetLength(1)];

            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    float n=0;
                    float.TryParse(MatrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.Transpuesta(tempResultante);
            int TamañoTexto = groupBoxMatrizResultado.Width / MatrizResultado.GetLength(1);
            MatrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatrizResultado.Controls.Clear();
            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    MatrizResultado[x, y] = new TextBox();
                    MatrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultado[x, y].Top = (x * MatrizResultado[x, y].Height) + 20;
                    MatrizResultado[x, y].Left = y * TamañoTexto + 6;
                    MatrizResultado[x, y].Width = TamañoTexto;
                    groupBoxMatrizResultado.Controls.Add(MatrizResultado[x, y]);
                }
            }
        }



        private void btDeterminanteMresultado_Click(object sender, EventArgs e)
        {
            if (MatrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[MatrizResultado.GetLength(0), MatrizResultado.GetLength(1)];

            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    float n=0;
                    float.TryParse(MatrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculoMatrices.Determinante2x2(tempResultante);
                MessageBox.Show("" + $"El valor del determinante 2x2 es:{determinante}");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculoMatrices.Determinante3x3(tempResultante);
                MessageBox.Show("" + $"El valor del determinante 3x3 es: {determinante}");
            }
            else
            {
                MessageBox.Show("¡No se puede generar el determinante!", "Error: matriz no válida");
            }
        }

        private void btInversaMresultado_Click(object sender, EventArgs e)
        {
            if (MatrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[MatrizResultado.GetLength(0), MatrizResultado.GetLength(1)];
            float[,] matrizAdjunta = new float[MatrizResultado.GetLength(0), MatrizResultado.GetLength(1)];
            float[,] matrizCofactor = new float[MatrizResultado.GetLength(0), MatrizResultado.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("¡Matriz inválida!", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            /*Matriz Adjunta(A) = Matriz Transpuesta(Matriz de cofactores(A))
            Matriz Inversa(A) = (1/ Determinante(A)) * Matriz Adjunta(A)*/
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofactor = CalculoMatrices.MatrizCofactor2x2(tempResultante);
                matrizAdjunta = CalculoMatrices.Transpuesta(matrizCofactor);
                determinante = CalculoMatrices.Determinante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofactor = CalculoMatrices.MatrizCofactor3x3(tempResultante);
                matrizAdjunta = CalculoMatrices.Transpuesta(matrizCofactor);
                determinante = CalculoMatrices.Determinante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("¡Matriz 2 invalida !", "Error - Matrix");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz no válida, determinante es igual a 0!", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculoMatrices.Inversa(determinante, matrizAdjunta);
            int TamañoTexto = groupBoxMatrizResultado.Width / MatrizResultado.GetLength(1);
            for (int x = 0; x < MatrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultado.GetLength(1); y++)
                {
                    MatrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }

        #endregion

        

        #region Matriz1
        private void btDeterminanteM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculoMatrices.Determinante2x2(tempResultante);

                MessageBox.Show("" + $"El valor del determinante 2x2 es: {determinante}");

            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculoMatrices.Determinante3x3(tempResultante);

                MessageBox.Show("" + $"El valor del determinante 3x3 es: {determinante}");

            }
            else
            {
                MessageBox.Show("¡No se puede generar el determinante!", "Error: matriz no válida");
            }
        }

        private void btInversaM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] matrizAdjunta = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] matrizCofatora = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            /*Matriz Adjunta(A) = Matriz Transposta(Matriz de cofatores(A))
            Matriz Inversa(A) = (1/ Determinante(A)) * Matriz Adjunta(A)*/
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculoMatrices.MatrizCofactor2x2(tempResultante);
                matrizAdjunta = CalculoMatrices.Transpuesta(matrizCofatora);
                determinante = CalculoMatrices.Determinante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculoMatrices.MatrizCofactor3x3(tempResultante);
                matrizAdjunta = CalculoMatrices.Transpuesta(matrizCofatora);
                determinante = CalculoMatrices.Determinante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz no válida, determinante es igual a 0!", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculoMatrices.Inversa(determinante, matrizAdjunta);
            int TamañoTexto = groupBoxMatriz1.Width / Matriz1.GetLength(1);
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }



        private void btOpuestaM1_Click(object sender, EventArgs e)
        {

            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.Opuesta(tempResultante);
            int TamañoTexto = groupBoxMatriz1.Width / Matriz1.GetLength(1);
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }

        }

        private void btTranspuestaM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.Transpuesta(tempResultante);
            int TamañoTexto = groupBoxMatriz1.Width / Matriz1.GetLength(1);
            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamañoTexto + 6;
                    Matriz1[x, y].Width = TamañoTexto;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }


        #endregion




        #region Matriz2

        private void btDeterminanteM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculoMatrices.Determinante2x2(tempResultante);
                MessageBox.Show("" +  $"El valor del determinante 2x2 es: {determinante}");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculoMatrices.Determinante3x3(tempResultante);
                MessageBox.Show("" + determinante, $"El valor del determinante 3x3 es: {determinante}");
            }
            else
            {
                MessageBox.Show("¡No se puede generar el determinante!", "Error: matriz no válida");
            }
        }



        private void btOpuestaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.Opuesta(tempResultante);
            int TamañoTexto = groupBoxMatriz2.Width / Matriz2.GetLength(1);
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }

        private void btTranspuestaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz nula");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = CalculoMatrices.Transpuesta(tempResultante);
            int TamañoTexto = groupBoxMatriz2.Width / Matriz2.GetLength(1);
            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamañoTexto + 6;
                    Matriz2[x, y].Width = TamañoTexto;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }


        private void btInversaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float[,] matrizAdjunta = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float[,] matrizCofatora = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            /*Matriz Adjunta(A) = Matriz Transposta(Matriz de cofatores(A))
            Matriz Inversa(A) = (1/ Determinante(A)) * Matriz Adjunta(A)*/
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculoMatrices.MatrizCofactor2x2(tempResultante);
                matrizAdjunta = CalculoMatrices.Transpuesta(matrizCofatora);
                determinante = CalculoMatrices.Determinante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculoMatrices.MatrizCofactor3x3(tempResultante);
                matrizAdjunta = CalculoMatrices.Transpuesta(matrizCofatora);
                determinante = CalculoMatrices.Determinante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz no válida, determinante es igual a 0!", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculoMatrices.Inversa(determinante, matrizAdjunta);
            int TamañoTexto = groupBoxMatriz2.Width / Matriz2.GetLength(1);
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }

        #endregion

        private void btLimpiar_Click(object sender, EventArgs e)
        {

            txtFilaM1.Clear();

            txtFilaM2.Clear();

            txtColumnaM1.Clear();

            txtColumnaM2.Clear();

            groupBoxMatriz1.Controls.Clear();

            groupBoxMatriz2.Controls.Clear();

            groupBoxMatrizResultado.Controls.Clear();

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMatrices_Load(object sender, EventArgs e)
        {

        }

        public FormMatrices()
        {
            InitializeComponent();

        }
    }
}