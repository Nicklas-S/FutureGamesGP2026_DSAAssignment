using UnityEngine;

[CreateAssetMenu(fileName = "EmployeeData", menuName = "Scriptable Objects/EmployeeData")]
public class EmployeeData : ScriptableObject
{
    [SerializeField] public Employees[] employees;


   
}
