# Threading

## Problem it solves
Unless utilizing a framework that handles multithreading, a program can only do one thing at a time. If you need additional independent processes to perform work, you can use a new thread.

## Common Uses
A web application can serve more than one request at a time due to threading. Otherwise a website could only serve one visitor at a time creating a long line of visitors waiting to get a webpage served.

The example contained uses creates a thread pool with the `Thread` class and keeps track of the work before exiting.

Threads are not commonly used directly as this is more of the 'bare metal'. You should have a look at [ThreadPool](https://msdn.microsoft.com/en-us/library/system.threading.threadpool(v=vs.110).aspx) and [Tasks](https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx) which are abstracted uses of Threads.
