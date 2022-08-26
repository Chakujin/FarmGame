using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public Sprite[] plantIncrease;
    public SpriteRenderer myRenderer;
    public GameObject Fruit;
    public Transform instantiatePoint;

    private float f_currenTime;
    public float growUp;
    private bool b_growUpPlant = true;
    private int i_growPlant = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer.sprite = plantIncrease[0];
    }

    private void Update()
    {
        if (b_growUpPlant == true)
        {
            f_currenTime += Time.deltaTime;

            if (growUp >= f_currenTime)
            {
                b_growUpPlant = false;
            }
        }
        else if(b_growUpPlant == false && i_growPlant <= plantIncrease.Length)
        {
            DropFruit();
        }
    }

    public void OnPlantInteract()
    {
        if (i_growPlant > plantIncrease.Length)// if my plant can growUp
        {
            //Update sprite image
            i_growPlant++;
            myRenderer.sprite = plantIncrease[i_growPlant];

            // enable continue growUp
            b_growUpPlant = true;
        }
    }

    private void DropFruit()
    {
        b_growUpPlant = false;

        //Reset plant
        i_growPlant--;
        myRenderer.sprite = plantIncrease[i_growPlant];

        //Instantiate Fruit
        Instantiate(Fruit, instantiatePoint);
    }
}
