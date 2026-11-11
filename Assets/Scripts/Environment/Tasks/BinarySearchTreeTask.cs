using Environment.Tasks;
using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
[CreateAssetMenu(fileName = "BinarySearchTreeTaskData", menuName = "Scriptable Objects/BinarySearchTreeTask")]
public class BinarySearchTreeTask : Task {
    [SerializeField] public string firstDate;
    [SerializeField] public string secondDate;
    private BinaryTree bst;
   
    public override void Execute() {
        DateTime firstDateTime;
        DateTime secondDateTime;

        if(!DateTime.TryParseExact(firstDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out firstDateTime) ||
            !DateTime.TryParseExact(secondDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out secondDateTime)) {
            throw new ArgumentException("Invalid date format. Please use 'yyyy-MM-dd'.");
        }
        Employees root = SortingTask.sortedEmployees[400];
        bst = new BinaryTree(root);

        foreach(Employees employee in SortingTask.sortedEmployees) {
            bst.Insert(employee);
        }
        //bst.BFS(bst.root, firstDateTime, secondDateTime);
        bst.DFS(bst.root, firstDateTime, secondDateTime);
       
    }
}
