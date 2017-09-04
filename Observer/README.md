# Observer

## Problem it solves
Often time a class can get wrapped up into handling things such as logging, performance monitoring or even specific business cases which sully up a class or couple it to something. 

The observer pattern is a great way to decouple specifics from a core\engine.

## Common Uses

The observer pattern can be used to broadcast important steps of an execution to other classes. For instance when a long running process begins\ends, you could broadcast these events and act upon them by updating Slack.

By doing so the core code (observable) wouldn't have to know anything about Slack, only the observing class would.

## Demo

I've created a video demo of the Observer Pattern that you can have a peek at here: https://www.youtube.com/watch?v=DgGKt0YgIBY&feature=youtu.be
