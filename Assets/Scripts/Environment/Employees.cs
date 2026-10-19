using System;
using UnityEngine;
[Serializable]
public class Employees
{
    public string name;
    public int employeeId;
    public bool hasEngineRoomClearance;
    public string lastEntranceInEngineRoom;
    public string lastExitFromEngineRoom;

}
[Serializable]
public class EmployeeArray {
    public Employees[] employees;
}
