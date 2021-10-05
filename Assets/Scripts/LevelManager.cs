using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Dictionary<String, int> paintQuantity;
    private String currentSelectedColour;
    private bool _isColourSwitched;
    public bool dev_mode;

    private UpdateUI _updateUI;
    private bool _isExitActive = false;

    // Start is called before the first frame update
    void Start()
    {
        paintQuantity = new Dictionary<String, int>();
        paintQuantity.Add("Blue", 0); // Freezes Platform
        paintQuantity.Add("Green", 0); // Growing Platform
        paintQuantity.Add("Red", 0); // Drops Platform
        //paintQuantity.Add("Black", 30); 
        paintQuantity.Add("Yellow", 4); // Raises Platform
        if (dev_mode)
        {
            paintQuantity["Blue"] = 30;
            paintQuantity["Green"] = 30;
            paintQuantity["Red"] = 30;
            paintQuantity["Yellow"] = 30;
        }

        currentSelectedColour = "Yellow";
        _updateUI = FindObjectOfType<UpdateUI>(); // Auto-sets orange to 3/10
    }

    // Update is called once per frame
    void Update()
    {
        _isColourSwitched = Input.GetButtonDown("Fire2");
        if (_isColourSwitched)
        {
            switch (currentSelectedColour)
            {
                case "Blue":
                    currentSelectedColour = "Red";
                    _updateUI.ChangePaint(Paints.RED_PAINT, paintQuantity[currentSelectedColour]);
                    break;
                case "Red":
                    currentSelectedColour = "Green";
                    _updateUI.ChangePaint(Paints.GREEN_PAINT, paintQuantity[currentSelectedColour]);
                    break;
                case "Green":
                    currentSelectedColour = "Yellow";
                    _updateUI.ChangePaint(Paints.ORANGE_PAINT, paintQuantity[currentSelectedColour]);
                    break;
                //case "Black":
                //    currentSelectedColour = "Yellow";
                //    _updateUI.ChangePaint(Paints.ORANGE_PAINT, paintQuantity[currentSelectedColour]);
                //    break;
                case "Yellow":
                    currentSelectedColour = "Blue";
                    _updateUI.ChangePaint(Paints.BLUE_PAINT, paintQuantity[currentSelectedColour]);
                    break;
            }
        }
    }

    public void IncreasePaint(String paintColour, int quantity)
    {
        int amount = quantity;
        paintQuantity[paintColour] += amount;
        if (currentSelectedColour == paintColour)
        {
            _updateUI.SetPaint(paintQuantity[paintColour]);
        }
    }
    public void DecreasePaint(String paintColour, int quantity)
    {
        int amount = quantity;
        paintQuantity[paintColour] -= amount;
        if (currentSelectedColour == paintColour)
        {
            _updateUI.SetPaint(paintQuantity[paintColour]);
        }
    }

    public void DecreaseCurrentSelectedPaint(int amount)
    {
        paintQuantity[currentSelectedColour] -= amount;
        _updateUI.SetPaint(paintQuantity[currentSelectedColour]);
    }

    public string GetCurrentlySelectedPaint()
    {
        return currentSelectedColour;
    }

    public void SetCurrentlySelectedPaint(string color)
    {
        currentSelectedColour = color;
    }

    public bool HasEnoughPaint()
    {
        return paintQuantity[currentSelectedColour] > 0;
    }

    public int GetPaintQuantity()
    {
        string color = GetCurrentlySelectedPaint();
        return paintQuantity[color];
    }
    
    public int GetPaintQuantity(string colour)
    {
        return paintQuantity[colour];
    }

    public bool IsExitActive()
    {
        return _isExitActive;
    }
    
    public void SetExitActive(bool isActive)
    {
        _isExitActive = isActive;
    }
}