# Decorator

## Problem it solves
If you have a class that you cannot (no access to source) or do not want to alter (pick a reason), you can still augment a method even if it is not marked `virtual` provided the class to be augmented uses an abstraction.

## Common Uses
Let's say you have a third party class that is closed source. You want one of the methods to be able to return cached responses. The method in question is not marked virtual but the class itself uses a public interface. The example contained here shows how to do such a task.

This pattern is also known as the wrapper pattern.

Here's a video I've put together for you to help out: https://www.youtube.com/watch?v=brsmxMkTM8I
