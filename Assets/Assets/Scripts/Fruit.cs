using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour {

	public GameObject fruitSlicedPrefab;
	public float startForce = 15f;

    int x;
    int y;
    int z;

    int score = 0;
    //public Text curScore;

    private Vector3 originalScale;

    Rigidbody2D rb;
    Dropdown dropdownValue;
    int dv;
    string message;
    public Text mtext;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        dropdownValue = GetComponent<Dropdown>();

    }
    void update()
    {
        dv = dropdownValue.value;
        message = dropdownValue.options[dv].text;
        mtext.text = message;
        if (dropdownValue.value == 1)
        {
            x = 1;
            y = 1;
            z = 1;

        }
        else
        {
            x = 2;
            y = 2;
            z = 2;
        }
        
    }
    public void size()
    {
        transform.localScale = new Vector3(x, y, z);
    }
    
    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			Destroy(slicedFruit, 3f);
			Destroy(gameObject);

            scoreScript.scoreValue += 1;
            
           // score = score + 1;
            //curScore.text = score.ToString();

        }
	}
    
        
    

}
