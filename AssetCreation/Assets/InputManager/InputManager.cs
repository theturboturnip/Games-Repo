using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {
	Dictionary<string,object[]> axes= new Dictionary<string,object[]>(),keys=new Dictionary<string,object[]>();

	public void SetAxis (string name,string positiveKey,string negativeKey,float sensitivity=0.1f) {
		if(axes.ContainsKey(name))
			axes[name]=new object[4]{0f,sensitivity,positiveKey,negativeKey};
		else
			axes.Add(name,new object[4]{0f,sensitivity,positiveKey,negativeKey});
	}
	
	public float GetAxis(string name){
		if(axes.ContainsKey(name))
			return (float)axes[name][0];
		return Input.GetAxis(name);
	}

	public bool GetKey(string name){
		if(keys.ContainsKey(name))
			return (bool)keys[name][0];
		return Input.GetKey(name);
	}

	public bool GetKeyDown(string name){
		if(keys.ContainsKey(name))
			return (int)keys[name][1]==0;
		return Input.GetKeyDown(name);
	}

	public bool GetKeyUp(string name){
		if(keys.ContainsKey(name))
			return (int)keys[name][1]==2;
		return Input.GetKeyUp(name);
	}

	// Update is called once per frame
	void Update () {
		foreach (string val in axes.Keys){
			if (Input.GetKey((string)axes[val][2]))
				axes[val][0]=(object)((float)axes[val][0]+(float)axes[val][1]);
			else if (Input.GetKey((string)axes[val][3]))
				axes[val][0]=(object)((float)axes[val][0]-(float)axes[val][1]);
			else
				axes[val][0]=(object)Mathf.Lerp((float)axes[val][0],0f,(float)axes[val][1]);
			axes[val][0]=(object)Mathf.Clamp(-1f,1f,(float)axes[val][0]);
		}
		foreach(string key in keys.Keys){
			bool oldVal=(bool)keys[key][0],newVal=Input.GetKey(key);
			if(oldVal&&!newVal)
				keys[key][1]=(object)2;
			else if(!oldVal&&newVal)
				keys[key][1]=(object)0;
			else
				keys[key][1]=(object)1;
			keys[key][0]=(object)newVal;
		}
	}
}
