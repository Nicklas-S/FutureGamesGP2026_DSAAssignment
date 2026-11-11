using TMPro;
using UnityEngine;

public class UiUpdater : MonoBehaviour {
    [SerializeField] private BinarySearchTask binarySearchTask;
    [SerializeField] private BinarySearchTreeTask BST;
    [SerializeField] public static TextMeshProUGUI employeeList;

    public void UpdateFirstDate(string firstDate) {
        binarySearchTask.firstDate = firstDate; //on change. changes value
        BST.firstDate = firstDate;
        Debug.Log(firstDate);
    }
    public void UpdateSecondDate(string secondDate) {
        binarySearchTask.secondDate = secondDate; //on change. changes value
        BST.secondDate = secondDate;
        Debug.Log(secondDate);
    }

    public void UpdateEmployeeList(int index) {
        Employees employee = SortingTask.sortedEmployees[index];
        employeeList.text += "\nName: " + employee.name + "\n" +
                            "   ID: " + employee.employeeId + "\n" +
                            "   Has clearance: " + employee.hasEngineRoomClearance + "\n" +
                            "   Last entered: " + employee.lastEntranceInEngineRoom + "\n" +
                            "   Last exited: " + employee.lastExitFromEngineRoom + "\n";

    }


}
