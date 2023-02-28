using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Element")]
public class Element : ScriptableObject //this script creates the scriptable object class element, which contains information for each individual atom. 
{ //this means i dont have to make this information for each element, rather can use this and slightly alter the numbers. 
    public int Neutrons;
    public int Protons;
    public int shells;
    public int electronsS1;
    public int electronsS2;
    public int electronsS3;
    public int electronsS4;
    public int electronsS5;
    public int electronsS6;
    public int electronsS7;
    public string description;
 
}
