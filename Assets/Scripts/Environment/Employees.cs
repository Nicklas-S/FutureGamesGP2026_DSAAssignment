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

    public DateTime Entered;
    public DateTime Exiting;

}
[Serializable]
public class EmployeeArray {
    public Employees[] employees;
}
