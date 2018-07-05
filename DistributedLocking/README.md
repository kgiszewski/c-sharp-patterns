# Distributed Locking

## Problem it solves
In a single host environment it is a trivial task to ensure that certain bits of code execute one thread at a time using locks. In a horizontally scaled environment, traditional locking will not work as the workers are spread across several nodes and/or processes on the the same node. In order to ensure that only one node may perform a particular task at a given time in a distributed environment, distributed locking can be used.

Scenario: If a payment collection system is distributed, how can we ensure that we don't accidentally capture a payment twice (e.g. more than one worker is collecting payment for the same customer at the same time)?

Naive solution: Use a DB to keep track of the current 'status' of a customer. For example we set a status field that says "in progress". Any other processes/nodes check this field before proceeding.

The problem with the naive solution is that a race condition still exists. Two queue messages could be picked up at the same time and two workers attempt to read the status field and get the OK to proceed b/c the each process have yet to set the status to 'in progress'.

Distributed locking requires that a semaphore be used to ensure that one and only one process can work a particular message at a time. This can be done with two simple methods:

```
bool AcquireLock(string semaphore)
void ReleaseLock(string semaphore)
```

The semaphore is a deterministic value based on whatever you want so long as it is unique to the task at hand. Some examples of a good semaphore might be:

```
customerId + "collectPayment"
customerId + "refundPayment"
```

The actual usage of our distributed lock would be the following pseduocode:

```
if(AcquireLock("1234collectPayment") 
{
    //collectPayment
}
else
{
    //could not get a lock, ignore this message as someone else is working on this already
}
```

## Common Uses
The exact implementation of you distributed lock can vary easily. You could choose to:
- Store the key in a SQL DB and require that the key be unique. During lock acquisition, if it fails to insert, then you can fail to get a lock. If you do get a lock, be sure to call `ReleaseLock` in a `finally` statement when finished.
- You could dedicate a single process and store the locks into memory. You'd want to make sure you use traditional locking to force threads to get into a single line.
- You could use a distributed cache like Redis to simply store the lock keys. Existence of a key would equate to a lock already being issued. Simply remove the key from Redis to release the lock. Be sure to account for using traditional locking when setting the locks.
