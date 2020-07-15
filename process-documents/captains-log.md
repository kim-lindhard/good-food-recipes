# Captains log
A log of thought doing development of the system

## 2020-07-15 13:43

First goal: Lets prove we can operate on a list of ingredients.
Lets write a acceptances test for a scenario related to a list of ingredients. And see if we can write a REST API, a client and domain to facilitate the behavior we expect in the acceptance test.

## 2020-07-15 13:30

The problem space seems like a good candidate for domain driven design.

We can model:
* A list of ingredients.
* A recipe.
* A cookbook.
* A author.

of the border of the domain we can put technical requirements like:
* Pagination
* The ability to search
* protection against sql and html injection.