using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] agents;
    public GameObject robot;
    public GameObject caja;
    public float coordX;
    public float coordY;
    public float coordZ;
    public int cant = 0;
    public float[,] P = new float[16, 2];

    // Start is called before the first frame update
    void Start()
    {
        agents = new GameObject[15];
        while (cant < 15)
        {

            coordX = Random.Range(40, 200);
            coordY = 64;
            coordZ = Random.Range(40, 200);

            P[cant, 0] = coordX;
            P[cant, 1] = coordZ;

            if (cant < 5)
            {
            agents[cant] = Instantiate(robot, new Vector3(coordX, coordY, coordZ), Quaternion.identity);
            }
            if (cant >= 5)
            {
                agents[cant] = Instantiate(caja, new Vector3(coordX, coordY, coordZ), Quaternion.identity);
            }
            cant += 1;
        }

        Update();

    }

    void Update()
    {
        int s = 0;
        while (s < 5)
        {
            float CordX = 0f, CordZ = 0f, step = 0.6f;
            int opc = Random.Range(1, 8);
            switch (opc)
            {
                case 1: CordX = -step; CordZ = -step; break;
                case 2: CordX = 0f; CordZ = -step; break;
                case 3: CordX = step; CordZ = -step; break;
                case 4: CordX = -step; CordZ = 0f; break;
                case 5: CordX = step; CordZ = 0f; break;
                case 6: CordX = -step; CordZ = step; break;
                case 7: CordX = 0f; CordZ = step; break;
                case 8: CordX = step; CordZ = step; break;
            }

            if (P[s, 0] < -218) CordX = +step;
            if (P[s, 1] > 700) CordZ = -step;
            if (P[s, 0] > 400) CordX = -step;
            if (P[s, 1] < -327) CordZ = +step;

            P[s, 0] += CordX;
            P[s, 1] += CordZ;
            agents[s].transform.position = new Vector3(P[s, 0], coordY, P[s, 1]);
            s++;
        }
    }
}
