using UnityEngine;

public interface IMovement
{
    public bool IsControlEnabled {get; set;}
    public void Move(Vector2 direction);
    public void SlowDown(float intensity);
    public void Boost(float intensity);
    public void Rotate(Vector2 direction);
    
}
