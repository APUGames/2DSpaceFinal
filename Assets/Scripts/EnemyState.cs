using System.Collections;
using System.Collections.Generic;

public struct EnemyState
{
    public bool grunt;
    public bool brute;
    public string currentType;

    public EnemyState(string type)
    {
        currentType = type;
        grunt = false;
        brute = false;
    }
}