using UnityEngine;
using System.Collections;
 
public class RealTimeReflection : MonoBehaviour {
    
    ReflectionProbe probe;
    
    void Awake() {
        probe = GetComponent<ReflectionProbe>();
        probe.RenderProbe();
    }

    void Update(){
    	probe.RenderProbe();
    }

}