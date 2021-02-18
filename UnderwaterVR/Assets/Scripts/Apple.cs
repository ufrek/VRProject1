using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    int score = 100;

    [SerializeField]
    int rotationSpeed = 130; //how many degrees per second
    [SerializeField]
    float bounceSpeed = 3;
    [SerializeField]
    float bounceHeight = 5f;

    GameObject turtle;
    int index;

    ~Apple()
    { 
    }
    // Start is called before the first frame update
    void Start()
    {
        turtle = GameObject.FindGameObjectWithTag("Turtle");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        Vector3 pos = transform.parent.position;
        transform.position = new Vector3(pos.x, Mathf.Sin(Time.time * bounceSpeed) * bounceHeight, pos.z);
    }

    public void addScore()
    {
        ScoreDisplay.S.addScore(score);
    }

    public void loseAlife()
    {
        ScoreDisplay.S.loseLife();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fish")
        {
            addScore();
            Destroy(col.gameObject);
            Destructor();
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Turtle")
        {
            loseAlife();
            col.gameObject.GetComponent<Turtle>().resetTarget();
            Destructor();
            Destroy(this.gameObject);
        }

    }

    public void setIndex(int i) => index = i;

    void Destructor()
    {
        print("destroy");
       
        SpawnManager.S.ResetHasApple(index);
        turtle.GetComponent<Turtle>().resetTarget();   
        
        
    }


}
