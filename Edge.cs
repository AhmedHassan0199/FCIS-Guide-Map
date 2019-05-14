using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



    public class Edge
    {
        private int weight;
        private Vertex dest;
        public Vertex Src;

        public Edge( Vertex dest, int w)
        {
            this.dest = dest;//Ꝋ(1)
        this.weight = w;//Ꝋ(1)
    }

        public override bool Equals(System.Object obj)
        {
            if (!(obj is Edge)) return false;//Ꝋ(1)

        Edge e = (Edge)obj;//Ꝋ(1)
        return dest.Equals(e.dest);//Ꝋ(1)
    }

        public override int GetHashCode()
        {
            return dest.GetHashCode();//Ꝋ(1)
    }

        public Vertex getAdj() { return this.dest; }//Ꝋ(1)
    public int getWeight() { return this.weight; }//Ꝋ(1)
}

