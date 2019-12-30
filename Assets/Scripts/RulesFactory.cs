using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesFactory
{
    public enum AvailableRules
    {
        Position,
        Color
    }

    private readonly Dictionary<AvailableRules, IRule> _factories;

    public RulesFactory()
    {
        _factories = new Dictionary<AvailableRules, IRule>
        {
            { AvailableRules.Position, new PositionalRule() },
            { AvailableRules.Color, new ColorRule() }
        };
    }

    public IRule Create(AvailableRules action) => _factories[action];

    //public bool Validate(AvailableRules action, GameObject current, List<GameObject> processed) => _factories[action].Validate(current, processed);
}
