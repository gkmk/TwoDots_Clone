using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRule
{
    bool Validate(GameObject current, GameObject previous);
}
