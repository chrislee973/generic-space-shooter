 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ScrollStarfield : MonoBehaviour 
{
	public float			theScrollSpeed = 0.025f;
 
	public Transform starfield;
 
	void Start () 
	{
        starfield=starfield.transform;	
	}
	
	void Update ()
	{
        starfield.position = new Vector3(starfield.position.x, starfield.position.y - theScrollSpeed, starfield.position.z);
	}
}