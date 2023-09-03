using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test", menuName = "ScriptableObject/Test")]
public class Test : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private List<Question> _questions;

    public string Name => _name;

    public List<Question> Questions => _questions;
}
