# Strategy

## Problem it solves
Often times we will write a class then ends up having quite a bit of conditional logic that handles many behaviors via if\then\else\switch. 
This leads to having classes that are long with trapped logic. The strategy pattern allows us to encapsulate each behavior as a discrete class that we can assign to another which makes it easier to read and the code becomes portable.

## Common Uses
When more than one distinct behavior is possible based on some sort of condition, it is much cleaner to refactor the behaviors into their own classes.
In the video game world, you may want Goomba's to react a certain way to a character while having Bowser react another. Rather than put all of that into a single class, you can put each behvavior into its own class.

In finance, you may want checking accounts to handle overdrawn accounts differently based upon their account type. For example, a free checking account may have a fee incurred immediately while a premium account may have forgiveness up to a point.
Each behavior can be handled separately without having a mess of if\then\else\switch statements.
