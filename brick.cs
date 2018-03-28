using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {



public Sprite[] Sprites_hit;

public int Index_sprite;

public int Maximum_Hits;
private int Times_Hit;
private bool isbreakable;

private Level_Manager level_Manager;
	// Use this for initialization
	void Start () {
	
	level_Manager = GameObject.FindObjectOfType<Level_Manager>();
	Times_Hit = 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
		
	{
	
	isbreakable = this.tag == "Breakable";
	
	if(isbreakable)
	{
	handling_hits ();
	}

 	}
 	
 	void handling_hits ()
 	
 	{
		Times_Hit = Times_Hit +1;
		
		//Maximum_Hits = Sprites_hit.Length + 1;  // ==> you can also use this, this makes reducing to simplicity. doesnt need any change in unity interface.
		print(" collision invoked ");
		
		if( Times_Hit >=Maximum_Hits )
		{ 
			Destroy(gameObject);
		}
		else 
			
		{
			
			LoadSprites();
			
		}		
 	
 	}
 	
void LoadSprites()
{
 
// Index_sprite = Times_Hit - 1 ;

 this.GetComponent<SpriteRenderer>().sprite = Sprites_hit[Index_sprite];
 Index_sprite++;
}
		
	 
	
	void Win_Simulation()  // simple fucntion --> will be removed afterwards.
	
	{
	
	level_Manager.LoadNextLevel();
	}
}
