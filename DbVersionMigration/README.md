# DB Version Migration

## Problem it solves
When sync'ing DB schemas against code or across environments, it's good to have a mechanism to version and upgrade (or even downgrade) a schema via a script.

## Common Uses
If you alter the Dev DB but now need to deploy your schema, this is very useful if using a micro-ORM and now need to deploy the schema changes to one or more DB servers without manually doing so.
