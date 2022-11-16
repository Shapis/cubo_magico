using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireCube : MonoBehaviour
{
    [SerializeField]
    private Material[] m_Colors;
    private List<Transform> myCubes = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateCube();
    }

    private void RotateFace(int faceNumber) {
        List<Transform> faceCubes = new List<Transform>();
        if (faceNumber == 0){
            foreach (var item in myCubes){
                if (item.position.z <= 0.1f){
                    item.RotateAround(new Vector3(1f, 1f, 0f), Vector3.forward, 90f);
                }
            }
        }else if (faceNumber == 1){
            foreach (var item in myCubes){
                if (item.position.y >= 1.9f){
                    item.RotateAround(new Vector3(1f, 2f, 1f), Vector3.up, 90f);
                }
            }
        }else if (faceNumber == 2){
            foreach (var item in myCubes){
                if (item.position.z >= 1.9f){
                    item.RotateAround(new Vector3(1f, 1f, 2f), Vector3.forward, -90f);
                }
            }
        }else if (faceNumber == 3){
            foreach (var item in myCubes){
                if (item.position.y <= 0.1f){
                    item.RotateAround(new Vector3(1f, 0f, 1f), Vector3.down, 90f);
                }
            }
        }else if (faceNumber == 4){
            foreach (var item in myCubes){
                if (item.position.x <= 0.1f){
                    item.RotateAround(new Vector3(0f, 1f, 1f), Vector3.right, 90f);
                }
            }
        }else if (faceNumber == 5){
            foreach (var item in myCubes){
                if (item.position.x >= 1.9f){
                    item.RotateAround(new Vector3(2f, 1f, 1f), Vector3.left, 90f);
                }
            }
        }
        
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            RotateFace(0);
        }
        if (Input.GetKeyDown(KeyCode.W)){
            RotateFace(1);
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            RotateFace(2);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            RotateFace(3);
        }
        if (Input.GetKeyDown(KeyCode.A)){
            RotateFace(4);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            RotateFace(5);
        }
    }

    void GenerateCube(int cubeSize = 3)
    {
        for (int x = 0; x < cubeSize; x++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int z = 0; z < cubeSize; z++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    myCubes.Add(cube.transform);
                    if (x == 0)
                    {
                        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        quad.transform.position += new Vector3(-0.51f, 0, 0);
                        quad.transform.parent = cube.transform;
                        quad.GetComponent<Renderer>().material = m_Colors[0];
                        quad.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }

                    if (x == cubeSize - 1)
                    {
                        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        quad.transform.position += new Vector3(0.51f, 0, 0);
                        quad.transform.parent = cube.transform;
                        quad.GetComponent<Renderer>().material = m_Colors[1];
                        quad.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }

                    if (y == 0)
                    {
                        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        quad.transform.position += new Vector3(0, -0.51f, 0);
                        quad.transform.parent = cube.transform;
                        quad.GetComponent<Renderer>().material = m_Colors[2];
                        quad.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    }

                    if (y == cubeSize - 1)
                    {
                        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        quad.transform.position += new Vector3(0, 0.51f, 0);
                        quad.transform.parent = cube.transform;
                        quad.GetComponent<Renderer>().material = m_Colors[3];
                        quad.transform.rotation = Quaternion.Euler(90, 0, 0);
                    }

                    if (z == 0)
                    {
                        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        quad.transform.position += new Vector3(0, 0, -0.51f);
                        quad.transform.parent = cube.transform;
                        quad.GetComponent<Renderer>().material = m_Colors[4];
                    }

                    if (z == cubeSize - 1)
                    {
                        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                        quad.transform.position += new Vector3(0, 0, 0.51f);
                        quad.transform.parent = cube.transform;
                        quad.GetComponent<Renderer>().material = m_Colors[5];
                        quad.transform.rotation = Quaternion.Euler(180, 0, 0);
                    }

                    cube.transform.parent = transform;
                    cube.transform.position = new Vector3(x, y, z);
                }
            }
        }
    }
}
