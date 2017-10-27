# Simple Factory

## Problem it solves
Often times code will have many places where the `new` operator is used to create a new class. However over time if the implementation needs altered (signature update) or completely swapped out, this can become cumbersome. The simple factory pattern allows to centralize the creation of a class.

## Common Uses
The most common use is to create a class with a single method named `.Create()`. This method does one thing, it creates another object and any class who needs a new object it provides will delegate the task to the method. This greatly increases future maintainability.

A better factory can be found by using the [Abstract Factory](../AbstractFactory/README.md).

Check out a video I made on factories: https://www.youtube.com/watch?v=qzxp9p7UP_Y
