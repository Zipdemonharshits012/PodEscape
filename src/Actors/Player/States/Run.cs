using Godot;
using System;

public class Run : State
{
    public override String Handle(Player actor, float delta)
    {
        Vector2 direction = actor.GetDirection();

        if (direction == Vector2.Zero && actor.IsOnFloor()) {
            return "Idle";
        }

        Vector2 snap = actor.GetSnapPosition(direction);

        actor.Velocity = actor.CalculateVelocity(
            actor.Velocity,
            direction,
            actor.Speed
        );

        actor.Velocity = actor.MoveAndSlideWithSnap(
            actor.Velocity,
            snap,
            actor.FLOOR_NORMAL,
            true
        );

        actor.AnimationPlayer.Play("Run");

        return null;
    }
}
