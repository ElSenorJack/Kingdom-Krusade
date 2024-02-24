using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]    //permette l'esecuzione anche durante la modalità #scene
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() //awake è il primissimo ad attivarsi, prima di Start
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }
    void DisplayCoordinates()
    {                                                                  // vvv richiama le impostazioni selezionate della griglia 
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        //RoundtoInt converte il dato per renderlo leggibile
        label.text = coordinates.x + "," + coordinates.y;
    }
    void UpdateObjectName() //per cambiare il nome dell'oggetto e avere la hierarchy più in ordine
    {
        transform.parent.name = coordinates.ToString();
    }
}
