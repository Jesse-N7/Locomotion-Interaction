using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField]
    public float threshold = 0.5f;  // percentage needed to activate button

    public bool _isPress;  // see's if button has been pressed. 
    public ConfigurableJoint _joint;  
    public Vector3 _startPos;  // Compares start position to how far it has moved
    public float deadZ = 0.09f;  //the buttons Deadzone

    public UnityEvent onPress, onRelease;
    // Start is called before the first frame update
    void Start()
    {
        _joint = GetComponent<ConfigurableJoint>();
        _startPos = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPress && GetValue() + threshold >= 1)  //if 
            Pressed();
        if (_isPress && GetValue() - threshold <= 0)   //
            Released();
    }
    
    float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;  //the distance between the start position and local position

        if (Mathf.Abs(value) < deadZ)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);   //this will return the values between -1 and 1.
    }


    void Pressed()
    {

        _isPress = true;
        onPress.Invoke();
        Debug.Log("It's Pressed!");  //this method will display a message on the console when the button is pressed
    }

           


        void Released()
    {
        _isPress = false ;
        onPress.Invoke();
        Debug.Log("It's Released!");  //this method will display a message on the console when the button is released
    }
}
