using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

   public  class VertexColour
    {
        public static string white = "White";
        public static string grey = "Grey";
        public static string black = "Black";
        
        public string color;
        public int dist;
        public Vertex parent;

        public VertexColour()
        {
            color = VertexColour.white;//Ꝋ(1)
        dist = int.MaxValue;//Ꝋ(1)
        parent = null;//Ꝋ(1)
        }
   }

