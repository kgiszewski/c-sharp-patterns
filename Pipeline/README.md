# Pipeline

## Problem it solves
When an object needs to be processed conditionally based on a series of steps, the Pipeline pattern separates each step in the process into discrete classes.

The pipeline is just a series of ordered steps that can be adjusted to suit custom needs without having a large class that tries to handle all situations.

## Common Uses
Image processing makes use of pipelines quite often. You may need to first crop, adjust color and then save an image. An e-commerce system (like [uCommerce](https://ucommerce.net)) uses pipelines to allow the default behavior of a checkout process to be altered as needed by the developer.
