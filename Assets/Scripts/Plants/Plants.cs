using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public Sprite[] plantIncrease;
    public SpriteRenderer myRenderer;
    public GameObject Fruit;

    [SerializeField]private float f_currenTime;
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

            if (growUp <= f_currenTime)
            {
                b_growUpPlant = false;
            }
        }
    }

    public void OnPlantInteract()
    {
        if (b_growUpPlant == false)
        {
            if (i_growPlant < plantIncrease.Length)// if my plant can growUp
            {
                //Update sprite image
                i_growPlant++;

                if (i_growPlant == plantIncrease.Length)
                {
                    DropFruit();
                }
                else
                {
                    myRenderer.sprite = plantIncrease[i_growPlant];
                }

                // enable continue growUp
                b_growUpPlant = true;
                f_currenTime = 0f;


            }
        }
    }

    private void DropFruit()
    {
        b_growUpPlant = false;

        //Reset plant
        i_growPlant--;
        myRenderer.sprite = plantIncrease[i_growPlant];

        float randomx = Random.Range(-2f,2f);
        float randomy = Random.Range(-2f,2f);
        Vector2 instantiatePoint = new Vector2(transform.position.x + randomx,transform.position.y + randomy);
        Debug.Log(instantiatePoint);
        //Instantiate Fruit
        Instantiate(Fruit, instantiatePoint,transform.localRotation);
    }
}
