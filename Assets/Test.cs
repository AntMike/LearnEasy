using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HedgehogTeam.EasyTouch;

public class Test : MonoBehaviour
{
    //Text mesh pro components
    public TMP_InputField NextLable;
    public TextMeshProUGUI CurrentLable;

    //Twist component
    public QuickTwist Twist;

    
    public RectTransform Window;
    public RectTransform TurnButtons;

    
    private bool _isTurned;
    private Vector2 _windowMinOffset;
    private Vector2 _windowMaxOffset;
    private Quaternion _windowRotation;



    private char[] _tempLabel;


    //Set start parametrs
    private void Awake()
    {
        _windowMinOffset = Window.offsetMin;
        _windowMaxOffset = Window.offsetMax;
        _windowRotation = Window.localRotation;
    }

    /// <summary>
    /// Quit the app
    /// </summary>
    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    /// <summary>
    /// Turn on/off window
    /// </summary>
    public void TurnBtn()
    {
        _isTurned = !_isTurned;
        Window.gameObject.SetActive(!Window.gameObject.activeSelf);
        TurnButtons.gameObject.SetActive(!TurnButtons.gameObject.activeSelf);
    }

    public void MaximazeBtn()
    {
        //Turn on window if it turned off
        if (_isTurned)
        {
            TurnBtn();
            return;
        }
        
        //If full screen active - set previous offset
        //else save offset and set them to zero
        if (Twist.IsFullScreen)
        {
            Window.offsetMin = _windowMinOffset;
            Window.offsetMax = _windowMaxOffset;
            Window.localRotation = _windowRotation;
        }
        else
        {
            _windowMinOffset = Window.offsetMin;
            _windowMaxOffset = Window.offsetMax;
            _windowRotation = Window.localRotation;
            Window.offsetMin = Vector2.zero;
            Window.offsetMax = Vector2.zero;
            Window.localRotation = Quaternion.identity;
        }

        //change full screen bool
        Twist.IsFullScreen = !Twist.IsFullScreen;
    }

    /// <summary>
    /// Call setting new label from input field
    /// </summary>
    public void SetNewLable()
    {
        SetNewString();
    }

    /// <summary>
    /// Setting new label from input field
    /// </summary>
    private void SetNewString()
    {
        //check if empty
        if (NextLable.text != "")
        {
            //set array char
            _tempLabel = NextLable.text.ToCharArray();

            //get all spaces
            string[] count = NextLable.text.Split(' ');

            //check if string have smth w/o spaces
            if (count.Length - 1 != _tempLabel.Length)
            {
                //set new color to each char
                string _tmp = "";
                foreach (char symbol in _tempLabel)
                {
                    if (symbol != ' ')
                    {
                        _tmp += "<#" + GetRandomHexColor() + ">" + symbol + "</color>";
                    }
                }

                //Set to label new name
                CurrentLable.text = _tmp;
            }
            else
            {
                //clear input field if it consist of spaces
                NextLable.text = "";
            }
        }
    }


    /// <summary>
    /// Return random color hex code
    /// </summary>
    /// <returns></returns>
    private string GetRandomHexColor()
    {
        return ColorUtility.ToHtmlStringRGB(Random.ColorHSV());
    }

}
