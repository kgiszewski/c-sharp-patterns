# Delegate

## Problem it solves
Some times a class\method can ALMOST be purely free of specific logic but needs a few lines of code to be removed to achieve this. The delegate pattern allows the executing class to execute a passed in method thus relieving a class of having to know specific details of an implementation.

## Common Uses
Often times code needs a value and it likely doesn't care how the value is obtained. The delegate pattern can be used to get a value from the UI and not be coupled to any specific UI implementation. This pattern is highly useful to decouple logic from another class.
