using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public class Vertex : IComparable
    {
        private String data;
        public string state = "unVisited";
        public int distance = 0;
        public Vertex parent = null;
        public GameObject NodeObject;
        public int SceneNumber;
        public int NodeIndex;
        public Vertex(String data)
        {
            this.data = data;//Ꝋ(1)
    }

        public override bool Equals(System.Object obj)
        {
            if (!(obj is Vertex)) return false;//Ꝋ(1)

            Vertex v = (Vertex)obj;//Ꝋ(1)
            return data.Equals(v.data);//Ꝋ(1)
        }

        public override int GetHashCode()
        {
            return data.GetHashCode();//Ꝋ(1)

    }

            public String getData()
        {
            return this.data;//Ꝋ(1)
    }

        public int CompareTo(object obj)
        {
            return 0;//Ꝋ(1)
        }
}

