# Composition over Inheritance

## Problem it solves
Inheritance isn't evil, but it does lock a class to another classes' destiny. Over-use of inheritance can lead to classes with default values\null as the 'norm' rather than having a class that models exactly what is needed.

Further when such classes become bloated, serialization and persistence do more work than they need to.

I prefer to compose a class by assembling it's parts and implement a common interface. While it may be more work upfront to model, it'll keep things nice and tidy.

## Common Uses
Often time as a business evolves, there is a natural tendency to simply 'just add a new field' to a class to cover the new requirement or create a derived class and add properties there.

If an ordering scheme requires new functionality, you should consider composing a new object rather than inherit and add properties. Inheritance should be used in moderation.
