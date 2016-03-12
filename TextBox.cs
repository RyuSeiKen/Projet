using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextBox : MonoBehaviour 
{
	public Coroutine co;
	public bool typing;
	public float pause = 0.1f;
	public AudioClip dialogue;
	public AudioSource source;
	public List<string> messages = new List<string>();
	public int i = 0;
	public int nulle;
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.X))
		{
			StopCoroutine(co);
			typing = false;
			GetComponent<Text>().text = (messages[i]); 
		}

		if(Input.GetKeyDown(KeyCode.Z) && typing == false)
		{
			StopCoroutine(co);
			GetComponent<Text>().text = ""; 
			i++;
			if(i >= messages.Count)
			{
				messages.Clear();
				i = 0;
				transform.parent.parent.gameObject.SetActive(false);
				return;
			}
			co = StartCoroutine(TypeLetters(messages[i]));
		}

		if(Input.GetKeyDown(KeyCode.C))
		{
			StopCoroutine(co);
			messages.Clear();
			GetComponent<Text>().text = ""; 
			i = 0;
			transform.parent.parent.gameObject.SetActive(false);
			return;
		}
	}

	public IEnumerator TypeLetters (string currentMessage) 
	{
		typing = true;
		foreach (char letter in currentMessage.ToCharArray()) 
		{
			GetComponent<Text>().text += letter; 
			if(letter != " "[0] && letter != "."[0] && letter != "?"[0] && letter != "!"[0])
			{
				source.PlayOneShot(dialogue,1);
			}
			yield return new WaitForSeconds(pause);
		}
		typing = false;
	}
//c'est nul
}