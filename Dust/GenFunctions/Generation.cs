using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Generation
{
    public class GenFunctions
    {


        //Generates a face using 4 vertices (creates two triangles)
        static public void genQuad(List<int> tris, int vert1, int vert2, int vert3, int vert4)
        {

            genTriangle(tris, vert1, vert2, vert3);
            genTriangle(tris, vert4, vert3, vert2);

        }

        //Creates a triangle using 3 verticies index
        static public void genTriangle(List<int> tris, int vert1, int vert2, int vert3)
        {

            tris.Add(vert1);
            tris.Add(vert2);
            tris.Add(vert3);

        }

        //Creates a Vertice at given values
        static public void genVertice(List<Vector3> verticies, float x, float y, float z)
        {
            verticies.Add(new Vector3(x, y, z));
        }

        //Apply modifications to the mesh
        static public void setMesh(Mesh obj, List<int> _tris, int index)
        {
            obj.SetTriangles(_tris, index);
        }

    }
}
