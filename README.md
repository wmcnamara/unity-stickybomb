# Sticky Bomb Unity Script

A simple stickybomb script that applies explosion force to nearby rigidbodies, and will play effects/sounds.

Works for Unity, works with single script, and is highly customizable.

# Example

![StickyBomb Showcase](StickybombShowcase.gif)
(if you see weird checkerboarding on the gif, its because of video compression)

## What you should know

By itself, the sticky bomb will:

1. When spawned, will move based on physics (fall based on gravity)
2. Attach to the first object it hits, and then explode 1 second later

You should add your own logic for throwing moving the stickybomb, and spawning it.

## Keep in mind:
 - To attach to an object, it must have a collider.
 - To be effected by explosions from the stickybomb, an object must have a collider and rigidbody.

Feel free to open an issue if you have any questions.

