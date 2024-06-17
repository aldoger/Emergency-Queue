﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency;

public class Node
{
    public string Nama;
    public int Umur;
    public string Alamat;
    public string Kondisi;
    public int Number_Priority;

    public Node(string name, int age,string alamat, string kondisi)
    {
        this.Nama = name;
        this.Umur = age;
        this.Alamat = alamat;
        this.Kondisi = kondisi;
        if(Kondisi == "Fatal")
        {
            this.Number_Priority = 3;
        }else if(Kondisi == "Cedera")
        {
            this.Number_Priority = 2; 
        }else if(Kondisi == "Sakit")
        {
            this.Number_Priority = 1;
        }
    }
}

public class EmergencyQueue
{
    public int Kapasitas { get; }
    public int Size { get; private set; } = 0;
    public Node[] Pasien { get; private set; }

    public EmergencyQueue()
    {
        this.Kapasitas = 10;
        this.Pasien = new Node[10];
    }

    private int GetLeftChildIndex(int index) { return 2 * index + 1; }
    private int GetRightChildIndex(int index) { return 2 * index + 2; }
    private int GetParentIndex(int index) { return (index - 1) / 2; }

    private bool HasLeftChild(int index) { return GetLeftChildIndex(index) < Size; }
    private bool HasRightChild(int index) { return GetRightChildIndex(index) < Size; }
    private bool HasParent(int index) { return GetParentIndex(index) >= 0; }

    private Node LeftChild(int index) { return Pasien[GetLeftChildIndex(index)]; }
    private Node RightChild(int index) { return Pasien[GetRightChildIndex(index)]; }
    private Node Parent(int index) { return Pasien[GetParentIndex(index)]; }

    public void HeapfyUp()
    {
        int index = Size - 1;
        while (HasParent(index) && Parent(index).Number_Priority < Pasien[index].Number_Priority)
        {
            swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }

    public void HeapfyDown()
    {
        int indeks = 0;
        while (HasLeftChild(indeks))
        {
            int smallerChildIndex = GetLeftChildIndex(indeks);
            if (HasRightChild(indeks) && RightChild(indeks).Number_Priority > LeftChild(indeks).Number_Priority)
            {
                smallerChildIndex = GetRightChildIndex(indeks);
            }
            if (Pasien[indeks].Number_Priority > Pasien[smallerChildIndex].Number_Priority)
            {
                break;
            }
            else
            {
                swap(indeks, smallerChildIndex);
            }
            indeks = smallerChildIndex;

        }
    }

    public void swap(int indexOne, int indexTwo)
    {
        Node temp = Pasien[indexOne]; Pasien[indexOne] = Pasien[indexTwo]; Pasien[indexTwo] = temp;
    }

    public void Insert(Node pasien)
    {
        if (Size == Kapasitas)
        {
            Console.WriteLine("Antrian sudah penuh");
        }
        Pasien[Size] = pasien;
        Size++;
        HeapfyUp();
    }

    public void Delete()
    {
        if (Size == 0)
            Console.WriteLine("Antrian kosong");
        Node temp = Pasien[0];
        Pasien[0] = Pasien[Size - 1];
        Pasien[Size - 1] = temp;
        Size--;
        HeapfyDown();
    }

    public Node LihatAntrian()
    {
        if (Pasien == null)
          throw new Exception("Antrian kosong");
        return Pasien[0]; 
    }

}
