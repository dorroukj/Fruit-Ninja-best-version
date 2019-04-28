using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;
    int x;
    int y;
    int z;
    Dropdown dropdownValue;
    int dv;
    string message;
    public Text mtext;
    private Vector3 originalScale;

    //private Vector3 originalScale;

    bool isCutting = false;

	Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
        //originalScale = transform.localScale;
        //transform.localScale = new Vector3(x.value, y.value, z.value);
    }

	// Update is called once per frame
	void Update () {
        //transform.localScale = new Vector3(x.value, y.value, z.value);
        //code to control the size of the blade
        
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}


        //dv = dropdownValue.value;
        //message = dropdownValue.options[dv].text;
        //mtext.text = message;
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

	void UpdateCut ()
	{
        
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		} else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}

}
