#Factory

The factory pattern is designed to abstract away object creation to another object.

##Example Usages

Let's say Acme Corp has shipped a cool new SDK. Inside the SDK is a model called `Foo`. You decided to build an app against this SDK and create a bunch of `Foo` objects with `new Foo()`. Everything works great but then a feature update arrives from Acme and it contains a breaking change because instead of `Foo`, you now need to use `Bar`.

You then update your code to use `Bar` but find out `Bar` needs a parameter for the contructor. This is not ideal for anyone. Wouldn't it be great to not have to change your app when Acme decides to use `Bar`?

The factory pattern allows for the user to delegate the creation of an object and allows the factory creator to tinker and change the implementation details so long as it returns an interface or abstract class.

##Pros

Read the scenario above :)

##Cons

Requires the use of interface/abstract class and a factory method which will be a bit more involved.