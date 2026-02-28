using System;
using System.Linq; // Necesario para Enumerable y ToArray()

public class Algoritmo
{
    public int[] GenerarNumeros(int n)
    {
        // Semilla fija (42) garantiza que todos los alumnos ordenen la misma secuencia
        Random r = new Random(42);
        return Enumerable.Range(0, n).Select(_ => r.Next(0, 50000)).ToArray();
    }

    public bool EstaOrdenado(int[] arr)
    {
        if (arr == null || arr.Length == 0) return true;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            // Si el actual es mayor al siguiente, no está ordenado
            if (arr[i] > arr[i + 1]) return false;
        }
        return true;
    }

    public void BubbleSort(int[] arr)
    {
        if (arr == null || arr.Length < 2) return;

        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }
        }
    }

    // QuickSort público que usa un método auxiliar recursivo
    public void QuickSort(int[] arr)
    {
        if (arr == null || arr.Length < 2) return;
        QuickSortRec(arr, 0, arr.Length - 1);
    }

    private void QuickSortRec(int[] arr, int low, int high)
    {
        if (low >= high) return;

        int pivotIndex = Partition(arr, low, high);
        QuickSortRec(arr, low, pivotIndex - 1);
        QuickSortRec(arr, pivotIndex + 1, high);
    }

    // Partición usando el esquema de Lomuto
    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
            }
        }
        int tmp2 = arr[i];
        arr[i] = arr[high];
        arr[high] = tmp2;
        return i;
    }
}
