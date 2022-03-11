namespace Feetur.Application.Data;

public interface IFeature<TValue>
{
    public TValue Value { get; set; }
}