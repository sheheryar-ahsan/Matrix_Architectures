using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    private int numOfRows;
    private int numOfCols;
    private string storingRows = "";

    List<List<float>> matrix;
    List<float> listObj;

    void Start()
    {
        //DoubleArray();
    }

    public Matrix() // Contructor
    {
        initializeMatrix();
    }

    public void initializeMatrix() // Initializing the matrix, Insertion based on row
    {
        matrix = new List<List<float>>();
    }

    public void initializeListObj() // Initializing the ListObj, Insertion based on cols
    {
        listObj = new List<float>();
    }

    public Matrix(int row, int col) // constructor with int arguments
    {
        this.numOfRows = row;
        this.numOfCols = col;
        initializeMatrix();
        // For making the matrix of row * col size with intialization of value zero
        for (int i = 0; i < numOfRows; i++)
        {
            initializeListObj();
            for (int j = 0; j < numOfCols; j++)
            {
                listObj.Add(0);
            }
            matrix.Add(listObj);
        }
        PrintMatrix();
    }

    public Matrix(float[,] array) // constructor with 2D array argument
    {
        numOfRows = array.GetLength(0);
        numOfCols = array.GetLength(1);
        initializeMatrix();
        for (int i = 0; i < numOfRows; i++)
        {
            initializeListObj();
            for (int j = 0; j < numOfCols; j++)
            {
                listObj.Add(array[i, j]);
            }
            matrix.Add(listObj);
        }
        PrintMatrix();
    }

    public void SetMatrix(float[,] array)
    {
        for (int x = 0; x < array.GetLength(0); x++)
        {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                matrix[x][y] = array[x, y];
            }
        }
        PrintMatrix();
    }

    public void PrintMatrix() // For display, matrix stored in string
    {
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                storingRows += matrix[i][j]; // sorting the matrix into the string
                storingRows += " ";
            }
            storingRows += "\n";
        }
        Debug.Log(storingRows);
    }

    public void SetElement(int row, int col, float value)
    {
        if (row < numOfRows && col < numOfCols)
        {
            matrix[row][col] = value;
            Debug.Log(value);
        }
        else
        {
            Debug.LogError("Index out of bounds");
        }
    }

    public float GetElement(int row, int col)
    {
        if (row < numOfRows && col < numOfCols)
        {
            return matrix[row][col];
        }
        else
        {
            Debug.LogError("Index out of bounds");
            return 0;
        }
    }

    public void SetRow(int row, float[] array)
    {
        if (row < numOfRows)
        {
            for (int i = 0; i < array.Length; i++)
            {
                matrix[row][i] = array[i];
            }
        }
        else
        {
            Debug.LogError("Index out of bounds");
        }
    }

    public void AddRow(float[] array)
    {
        matrix.Add(new List<float>());
        for (int i = 0; i < array.Length; i++)
        {
            matrix[matrix.Count][i] = array[i];
        }
        numOfRows++;
        numOfCols++;
    }

    public void AddCol(float[] array)
    {
        for (int x = 0; x < array.Length; x++)
        {
            matrix[x].Add(array[x]);
        }
        numOfCols++;
        numOfRows++;
    }

    public void SetCol(int col, float[] array)
    {
        if (col < numOfCols)
        {
            for (int i = 0; i < array.Length; i++)
            {
                matrix[i][col] = array[i];
            }
        }
        else
        {
            Debug.LogError("Index out of bounds");
        }
    }

    public void SpawRows(int row1, int row2)
    {
        if (row1 > numOfRows || row2 > numOfRows || row1 != row2)
        {
            Debug.LogError("Index out of bound OR Row sizes not same");
            return;
        }
        else
        {
            float[] array1 = new float[matrix[row1].Count];
            float[] array2 = new float[matrix[row2].Count];
            for (int x = 0; x < matrix[row1].Count; x++)
            {
                array1[x] = matrix[row1][x];
            }
            for (int x = 0; x < matrix[row2].Count; x++)
            {
                array2[x] = matrix[row2][x];
            }
            for (int x = 0; x < matrix[row1].Count; x++)
            {
                matrix[row1][x] = array2[x];
            }
            for (int x = 0; x < matrix[row2].Count; x++)
            {
                matrix[row2][x] = array1[x];
            }
        }
    }

    public void SpawCols(int col1, int col2)
    {
        if (col1 > numOfCols || col2 > numOfCols || col1 != col2)
        {
            Debug.LogError("Index out of bound OR Col sizes not same");
            return;
        }
        else
        {
            float[] array1 = new float[matrix[col1].Count];
            float[] array2 = new float[matrix[col2].Count];
            for (int x = 0; x < matrix.Count; x++)
            {
                array1[x] = matrix[x][col1];
            }
            for (int x = 0; x < matrix.Count; x++)
            {
                array2[x] = matrix[x][col2];
            }
            for (int x = 0; x < matrix.Count; x++)
            {
                matrix[x][col1] = array2[x];
            }
            for (int x = 0; x < matrix.Count; x++)
            {
                matrix[x][col2] = array1[x];
            }
        }
    }

    public int GetRowLenegth()
    {
        return numOfRows;
    }

    public int GetColLength()
    {
        return numOfCols;
    }

    public Matrix AddMatrix(Matrix matrixRefered)
    {
        if (GetRowLenegth() != matrixRefered.GetRowLenegth() || GetColLength() != matrixRefered.GetColLength())
        {
            Debug.Log("Matrixs size dont match");
            return new Matrix();
        }
        else
        {
            Matrix tempMatrix = new Matrix(GetRowLenegth(), GetColLength());
            for (int i = 0; i < GetColLength(); i++)
            {
                for (int j = 0; j < GetRowLenegth(); j++)
                {
                    tempMatrix.SetElement(i, j, matrix[i][j] + matrixRefered.GetElement(i, j));
                }
            }
            return tempMatrix;
        }
    }

    public Matrix SubMatrix(Matrix matrixRefered)
    {
        if (GetRowLenegth() != matrixRefered.GetRowLenegth() || GetColLength() != matrixRefered.GetColLength())
        {
            Debug.Log("Matrixs size dont match");
            return new Matrix();
        }
        else
        {
            Matrix tempMatrix = new Matrix(GetRowLenegth(), GetColLength());
            for (int i = 0; i < GetColLength(); i++)
            {
                for (int j = 0; j < GetRowLenegth(); j++)
                {
                    tempMatrix.SetElement(i, j, matrix[i][j] - matrixRefered.GetElement(i, j));
                }
            }
            return tempMatrix;
        }
    }

    private void DoubleArray() // 2D array
    {
        int[,] array2D = new int[,]
        {
            {1, 9},
            {8, 3},
            {4, 6}
        };
        Debug.Log("2D array element: " + array2D[2, 1]);

        string[,,] array3D = new string[,,] // 3D array
		{
            {
                {"one", "Two", "three"},
                {"Four", "Five", "six"},
            },
            {
                {"Seven", "Eight", "Nine"},
                {"Ten", "Eleven", "Twelve"},
            }
        };
        Debug.Log("3D array element: " + array3D[1, 0, 2]);
    }

}
