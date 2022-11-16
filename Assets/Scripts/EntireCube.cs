using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireCube : MonoBehaviour
{
    [SerializeField]
    private Material[] m_Colors;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCube();
    }

    private void RotateFace(int faceNumber) { }

    void GenerateCube(int cubeSize = 3)
    {
        for (int x = 0; x < cubeSize; x++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int z = 0; z < cubeSize; z++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
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
