using System.Collections.Generic;
using UnityEngine;

public class ShaderKeyboard : MonoBehaviour
{
    [SerializeField] private List<Renderer> _affectedRenderers;
    private List<Renderer> AffectedRenderers => _affectedRenderers ??= new List<Renderer>();
    
    [SerializeField] private string _shaderProperty = "_KeyboardValues";

    private void Update()
    {
        Vector4 keyboardInputs = Vector4.zero;
        
        // get directional inputs and map them to a vector
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) keyboardInputs.x = 1;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) keyboardInputs.y = 1;
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) keyboardInputs.z = 1;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) keyboardInputs.w = 1;

        //Debug.Log(keyboardInputs);
        
        // apply to all renderers
        foreach(Renderer r in AffectedRenderers)
        {
            if(r == null) continue;
            
            r.material.SetVector(_shaderProperty, keyboardInputs);
        }
    }
}
