# Poor Man's Dependency Injection

## Problem it solves
This pattern allows for depenencies to be easily changed for unit testing without the need for magical things like IoC containers.

## Common Uses
Rather than `new` a dependency within a constructor or method in a class, all dependencies are taken via the contructor or a default is provided with a public getter.

This is most useful when performing unit testing so you can easily return happy signals on irrelevant dependencies (things you didn't want to test anyway).

Checkout a video I made on Poor man's DI and IoC containers: https://www.youtube.com/watch?v=xR0LotJQzlk
