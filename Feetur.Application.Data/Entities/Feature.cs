namespace Feetur.Application.Data.Entities;

public class Feature<TValue>: Entity, IFeature<TValue>
{
    public string Name { get; set; }

    public TValue Value { get; set; }

    public bool Active { get; set; }

    public DateTime? ActiveFrom { get; set; }
}