using Environment.Tasks;
using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
[CreateAssetMenu(fileName = "BinarySearchTreeTaskData", menuName = "Scriptable Objects/BinarySearchTreeTask")]
public class BinarySearchTreeTask : Task {
    [SerializeField] public string firstDate;
    [SerializeField] public string secondDate;
    private BinaryTree bst;
    [SerializeField] TextAsset jsonFile;
    private Employees[] Emplist;
    public override void Execute() {
        DateTime firstDateTime;
        DateTime secondDateTime;
        Emplist = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;
        foreach (Employees employees in Emplist) {
            employees.Entered = DateTime.ParseExact(employees.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss",
                                      System.Globalization.CultureInfo.InvariantCulture);
            employees.Exiting = DateTime.ParseExact(employees.lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }

        if(!DateTime.TryParseExact(firstDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out firstDateTime) ||
            !DateTime.TryParseExact(secondDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out secondDateTime)) {
            throw new ArgumentException("Invalid date format. Please use 'yyyy-MM-dd'.");
        }
        Employees root = Emplist[400];
        bst = new BinaryTree(root);

        for (int i = 0; i < Emplist.Length; i++) {
            if(i == 400 ) continue;
            bst.Insert(Emplist[i]);
        }
        bst.BFS(bst.root, firstDateTime, secondDateTime);
        bst.DFS(bst.root, firstDateTime, secondDateTime);
       
    }
}
