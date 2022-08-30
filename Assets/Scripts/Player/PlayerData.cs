using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int KeroseneCapacity;

    /// <summary>
    /// Car name list to store kerosene amounts
    /// </summary>
    private static List<string> cars = new List<string> { "Tako", "Dodger", "Lastrada", "Mord Fustang", "Tirex", "I-11 Thunderbolt" };
    private static int currentCarIndex;

    /// <summary>
    /// Get the kerosene amounts of a car by its index
    /// </summary>
    /// <param name="currentCarIndex"></param>
    /// <returns></returns>
    public static int GetCurrentCarKerosene()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        return PlayerPrefs.GetInt(cars[currentCarIndex]);
    }
    
    public static void SetCurrentCarKerosene(int keroseneCapacity)
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        PlayerPrefs.SetInt(cars[currentCarIndex], keroseneCapacity);
    }
}
