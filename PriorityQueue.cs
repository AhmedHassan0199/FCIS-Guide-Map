using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class PriorityQueue<T, Int>
{
    private List<KeyValuePair<T, int>> data;
    private Dictionary<T, int> positions;

    private int getParentIndex(int i) { return (i / 2); } //Ꝋ(1)
    private int getLeftChildIndex(int i) { return 2 * i; }//Ꝋ(1)
    private int getRightChildIndex(int i) { return (2 * i) + 1; }//Ꝋ(1)

    private void swap(int indx1, int indx2)//Total = Ꝋ(1)
    {
        KeyValuePair<T, int> tmp = data[indx1];//Ꝋ(1)
        data[indx1] = data[indx2];//Ꝋ(1)
        positions[data[indx1].Key] = indx1;//Ꝋ(1)
        data[indx2] = tmp;//Ꝋ(1)
        positions[data[indx2].Key] = indx2;//Ꝋ(1)
    }

    private void min_heapify(int i)// Total = O(LogN)
    {
        int left = getLeftChildIndex(i);//Ꝋ(1)
        int right = getRightChildIndex(i);//Ꝋ(1)
        int min = i;//Ꝋ(1)
        if (left < data.Count//Ꝋ(1)
            && data[left].Value < data[i].Value)
        {
            min = left;//Ꝋ(1)
        }
        if (right < data.Count//Ꝋ(1)
            && data[right].Value < data[min].Value)
        {
            min = right;//Ꝋ(1)
        }

        if (min != i)//Ꝋ(1)
        {
            swap(i, min);//Ꝋ(1)
            min_heapify(min);//O(LogN)
        }
    }

    public PriorityQueue()
    {
        this.data = new List<KeyValuePair<T, int>>();//Ꝋ(1)
        this.positions = new Dictionary<T, int>();//Ꝋ(1)
    }

    public PriorityQueue(int n)
    {
        this.data = new List<KeyValuePair<T, int>>(n);//Ꝋ(N)
        this.positions = new Dictionary<T, int>(n);//Ꝋ(N)
    }

    public int Count()
    {
        return data.Count - 1;//Ꝋ(1)
    }


    public void Enqueue(T item, int weight)//Total = O(LogN)
    {
        if (data.Count == 0) data.Add(new KeyValuePair<T, int>());//Ꝋ(1)
        KeyValuePair<T, int> pair = new KeyValuePair<T, int>(item, int.MaxValue);//Ꝋ(1)
        data.Add(pair);//Ꝋ(1)
        positions[item] = data.Count - 1;//Ꝋ(1)
        decrease_value(data.Count - 1, weight);//O(LogN)
    }

    public T Dequeue()//Total = O(LogN)
    {
        T min = data[1].Key;//Ꝋ(1)
        data[1] = data[data.Count - 1];//Ꝋ(1)
        positions[data[1].Key] = 1;//Ꝋ(1)
        data.RemoveAt(data.Count - 1);//Ꝋ(1)
        positions.Remove(min);//Ꝋ(1)
        min_heapify(1);//O(LogN)
        return min;//Ꝋ(1)
    }

    public void update_value(T item, int weight)//O(LogN)
    {
        
        int pos = positions[item]; //Ꝋ(1)
        decrease_value(pos, weight);//O(LogN)

    }
    private void decrease_value(int indx, int weight)
    {
        data[indx] = new KeyValuePair<T, int>(data[indx].Key, weight);//Ꝋ(1)
        int parent = getParentIndex(indx);//Ꝋ(1)
        while (indx > 1 && data[parent].Value > data[indx].Value)// Total = #Iterations*Ꝋ(1) = O(LogN)
        {
            swap(indx, parent);//Ꝋ(1)
            indx = getParentIndex(indx);//Ꝋ(1)
            parent = getParentIndex(indx);//Ꝋ(1)
        }
    }
}
