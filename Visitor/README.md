# Visitor

## Problem it solves
An author of a class may not make his\her code accessible for modification but may share some of it's implementation with another class.
The author of the original class can allow another class to receive a callback with specific information from the class.

## Common Uses
The visitor pattern can be used to create a pipeline of behavior.

For example a visitor class can be given to a visitable class in an e-commerce system. The visitable class may have information about the current transaction and one or more visitor classes can be given to this class to perform additional processing.
