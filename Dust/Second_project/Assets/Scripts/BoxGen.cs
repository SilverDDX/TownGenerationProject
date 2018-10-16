using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using Generation;

    [ExecuteInEditMode]
    public class BoxGen : GenFunctions
    {
    
        private GameObject dest;
      

        [SerializeField]
        public Material mat;
        public string name;
        public float width = 2, height = 2;
        public Vector3 initPos;
        private List<string> names = new List<string>();

        private bool ValidName = true;



        private List<GameObject> buildingList = new List<GameObject>();
        private int buildingIndex = 0;

    
    public void genBox( string currentname, Vector3 pos, float width, float height)
        {

            MeshFilter mfilter = new MeshFilter();
            Mesh cube = new Mesh();
            List<Vector3> verticies = new List<Vector3>();
            List<int> triangles = new List<int>();


            //Creates a gameobject and add needed components
            GameObject dest = new GameObject();
            dest.transform.position = pos;
            dest.name = currentname;
            dest.AddComponent<MeshRenderer>();
            dest.GetComponent<Renderer>().material = mat;
            mfilter = dest.AddComponent<MeshFilter>();


            //Creates a new mesh and applies it to the meshfilter of new gameobject
            cube = new Mesh();
            cube.name = currentname;
            mfilter.mesh = cube;


            //Adds Verticies according to width and Height
            genVertice(verticies, 0, 0, 0);
            genVertice(verticies, width, 0, 0);
            genVertice(verticies, 0, 0, width);
            genVertice(verticies, width, 0, width);

            genVertice(verticies, 0, height, 0);
            genVertice(verticies, width, height, 0);
            genVertice(verticies, 0, height, width);
            genVertice(verticies, width, height, width);


            //Sets the verticies list on the mesh
            cube.SetVertices(verticies);


            //creates a submesh
            cube.subMeshCount = 1;

            //generates faces (two triangles per faces)
            genQuad(triangles, 0, 1, 2, 3);
            genQuad(triangles, 5, 4, 7, 6);
            genQuad(triangles, 4, 5, 0, 1);
            genQuad(triangles, 5, 4, 7, 6);
            genQuad(triangles, 7, 6, 3, 2);
            genQuad(triangles, 5, 7, 1, 3);
            genQuad(triangles, 6, 4, 2, 0);

            //Displays the mesh
            setMesh(cube, triangles, 0);
         

        }

    public void genAdvancedBox(string currentname, Vector3 pos, float width, float height)
    {

        MeshFilter mfilter = new MeshFilter();
        Mesh cube = new Mesh();
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();


        //Creates a gameobject and add needed components
        GameObject dest = new GameObject();
        dest.transform.position = pos;
        dest.name = currentname;
        dest.AddComponent<MeshRenderer>();
        dest.GetComponent<Renderer>().material = mat;
        mfilter = dest.AddComponent<MeshFilter>();


        //Creates a new mesh and applies it to the meshfilter of new gameobject
        cube = new Mesh();
        cube.name = currentname;
        mfilter.mesh = cube;


        //Adds Verticies according to width and Height
        genVertice(verticies, 0, 0, 0);
        genVertice(verticies, width, 0, 0);
        genVertice(verticies, 0, 0, width);
        genVertice(verticies, width, 0, width);

        genVertice(verticies, 0, height, 0);
        genVertice(verticies, width, height, 0);
        genVertice(verticies, 0, height, width);
        genVertice(verticies, width, height, width);


        //Sets the verticies list on the mesh
        cube.SetVertices(verticies);


        //creates a submesh
        cube.subMeshCount = 1;

        //generates faces (two triangles per faces)
        genQuad(triangles, 0, 1, 2, 3);
        genQuad(triangles, 5, 4, 7, 6);
        genQuad(triangles, 4, 5, 0, 1);
        genQuad(triangles, 5, 4, 7, 6);
        genQuad(triangles, 7, 6, 3, 2);
        genQuad(triangles, 5, 7, 1, 3);
        genQuad(triangles, 6, 4, 2, 0);

        //Displays the mesh
        setMesh(cube, triangles, 0);


    }


    public void randBoxGen()
    {

        float randWidth = UnityEngine.Random.Range(1f, 3f);
        float randHeight = UnityEngine.Random.Range(2f, 5f);
        string randName = "Building " + buildingIndex.ToString();


        Vector3 randInitPos = new Vector3(UnityEngine.Random.Range(-10f, 10f), 0, UnityEngine.Random.Range(-10f, 10f));

        genCube(randName,randInitPos,randWidth,randHeight);

        buildingIndex += 1;

    }

    
}

