# Singleton

## Problem it solves
Often times you will want one global instance of an object instead of using `static` objects. Instance objects can utilize extension methods whereas a purely static class cannot.

## Common Uses
The Singleton pattern is a good option to use when you'd like to restrict the creation of an object to only one instance. 

A common use may be to use a global object to work as a service object.

There are both thread-safe and non-thread-safe versions to choose from. The main thing to look out for when using non-thread-safe Singletons is during intialization. If your startup code has more than one thread that could invoke your class, you will need to use the thread-safe version. However if you're startup code is single-threaded; you can create a non-thread-safe version (less code). Keep in mind that thread-safety is its own topic and if you manage state in your Singleton, you'll have other things to consider.

A video for you to watch if you so desire: https://www.youtube.com/watch?v=XZl3FgkYazI
