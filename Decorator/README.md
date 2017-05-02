# Decorator

## Problem it solves
If you have a class that you cannot (no access to source) or do not (pick a reason) want to alter, you can still augment a method even if it is not marked `virtual` provided the class to be augmented uses an abstraction.

## Common Uses
Let's say you have a third party class that is closed source. You want one of the methods to be able to return cached responses. The method in question is not marked virtual but the class itself uses a public interface. The example contained here shows how to do such a task.
