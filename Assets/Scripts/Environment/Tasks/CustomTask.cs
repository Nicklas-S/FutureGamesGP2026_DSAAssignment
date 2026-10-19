using Environment.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "CustomTaskData", menuName = "Scriptable Objects/CustomTask")]

public class CustomTask : Task {
    [SerializeField] EmployeeData employeeData;
    [SerializeField] TextAsset jsonFile;

    //overrides the abstract(empty) functuion "Execute"
    public override void Execute() {
        if(jsonFile == null) {
            return;
        }

        Employees[] employees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;

        if(employees != null && employees.Length == 0) {
            return;
        }
        employeeData.employees = employees;
        foreach(Employees employee in employees) {
                Debug.Log(
                "\nName: " + employee.name + "\n" +
                "ID: " + employee.employeeId + "\n" +
                "Has clearance: " + employee.hasEngineRoomClearance + "\n" +
                "Last entered: " + employee.lastEntranceInEngineRoom + "\n" +
                "Last exited: " + employee.lastExitFromEngineRoom);
        }
    }
}
