# Dynamic Dispatch

## Problem it solves
Sometimes you'll want to be able to 'publish something' and it be 'handled' by another class.

The effect you'd like to create is a 'routed' message; from client to handler.

Dynamic dispatch allows for a one-time setup of a 'dispatcher' that routes a published POCO to the appropriate handler.

Subsequent message\handler pairs can be created quickly.

i.e. `FooMessage` gets published and handled by `IHandleMessages<FooMessage>`

## Common Uses

Messaging systems can send\receive messages that get handled by the appropriate handler class. 

This allows for quick and easy publish\handle pattern.

The example contained can be modified to publish data on one box and the handlers on another box. To do that will require a transport such as a queue or http and the appropriate serialization.

Combined with threading you can make a high-performance service router.
