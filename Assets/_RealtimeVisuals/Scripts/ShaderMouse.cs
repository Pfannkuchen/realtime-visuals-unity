using System.Collections.Generic;
using UnityEngine;

public class ShaderMouse : MonoBehaviour
{
    [SerializeField] private List<Renderer> _affectedRenderers;
    private List<Renderer> AffectedRenderers => _affectedRenderers ??= new List<Renderer>();
    
    [SerializeField] private string _shaderProperty = "_MouseValues";

    private void Update()
    {
        Vector4 keyboardInputs = Vector4.zero;
        
        // get mouse position and mouse delta and map them to a vector
        keyboardInputs.x = Input.mousePosition.x / Screen.width;
        keyboardInputs.y = Input.mousePosition.y / Screen.height;
        keyboardInputs.z = Input.GetAxis("Mouse X");
        keyboardInputs.w = Input.GetAxis("Mouse Y");

        //Debug.Log(keyboardInputs);
        
        // apply to all renderers
        foreach(Renderer r in AffectedRenderers)
        {
            if(r == null) continue;
            
            r.material.SetVector(_shaderProperty, keyboardInputs);
        }
    }
}
