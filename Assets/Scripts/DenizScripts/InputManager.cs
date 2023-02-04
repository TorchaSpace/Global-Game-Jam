using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour,InputData
{
    
    public Action<Vector3> OnKeyboardInputGiven { get; set; }
    public Action<Vector3> OnMouseMove { get; set; }
    public Action OnMouseClick { get; set; }
    public Action OnMouseReleased { get; set; }

    

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            OnKeyboardInputGiven?.Invoke(new Vector3(horizontal,0,vertical));
        }


        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseReleased?.Invoke();
        }

        Vector3 pos = Raycast();
        if (pos != Vector3.negativeInfinity)
        {
            OnMouseMove?.Invoke(pos);
        }
        
        
        
    }



    private Vector3 Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            return hit.point;
        }
        
        return Vector3.negativeInfinity;
    }
    
    
    
    
}




public interface InputData
{
    public Action<Vector3> OnKeyboardInputGiven { get; set; }
    public Action<Vector3> OnMouseMove { get; set; }
    public Action OnMouseClick { get; set; }
    public Action OnMouseReleased { get; set; }

}




