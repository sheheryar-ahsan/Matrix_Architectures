using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixSimulation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Matrix matrixObj1 = new Matrix();
        Matrix matrixObj2, matrixObj3;
        //matrixObj2 = new Matrix(3, 4);
        float[,] tempArray = new float[,]
        {
            {1, 2},
            {3, 4},
            {5, 6}
        };
        matrixObj3 = new Matrix(tempArray);
    }
}
