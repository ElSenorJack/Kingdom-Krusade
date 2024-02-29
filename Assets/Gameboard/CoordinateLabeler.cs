using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;


[ExecuteAlways]    //permette l'esecuzione anche durante la modalità #scene
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() //awake è il primissimo ad attivarsi, prima di Start
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
        //label.enabled = true;
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else 
        {
            label.color = blockedColor;
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
