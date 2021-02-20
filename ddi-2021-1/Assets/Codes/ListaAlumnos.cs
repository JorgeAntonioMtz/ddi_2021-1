using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaAlumnos : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
       string[] student = {"ABIMAEL ALVEZ MADRIGAL", "CRISTIAN ALFREDO ASTORGA SEPULVEDA", "ERICK ARTURO BECERRA PERAZA",
                            "EDGAR ALBERTO CHAGALA JIMENEZ", "LUIS GERARDO DIAZ REYNOSO", "LUIS FERNANDO ESQUEDA GARCIA",
                            "ISAAC HERNANDEZ CANO", "EDGAR MIGUEL LANDA LUNA", "LUIS ELOY LAZCANO ORTIZ",
                            "NEREO CESAR LOPEZ MORENO", "ARACELI LUEVANO CRUZ", "SERGIO ALONSO MARTINEZ SUAREZ",
                            "JORGE ANTONIO MARTINEZ VILLANUEVA", "IVAN ALFREDO MORALES ROSALES", "FELIX ABRAHAM QUINTERO CARRISOZA",
                            "BRANDON RAYGOZA DE LA PAZ", "RAUL ARTURO RODRÍGUEZ CONTRERAS", "MIGUEL ANGEL ROSAS OCAMPO",
                            "DANIEL SANTOS MÉNDEZ", "JOSE LIAM TAPIA OLVERA"}; 

        Array.Sort(student);    //orden alfabético

        string nombre = "JORGE ANTONIO MARTINEZ VILLANUEVA";    //nombre para buscar

        if(isStudent(student, nombre))
            Debug.Log("Está inscrito");
        else
            Debug.Log("No está inscrito");
    }

    private bool isStudent(string[] students, string name){
        //O(n), por ser una búsqueda for
        for(int i=0; i<students.Length; i++)
            if(students[i].Equals(name))
                return true;
            
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
