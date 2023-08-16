# RecruitmentTasks

For both tasks LightBdd framework was used.

### Task: API Testing exercise:

In the solution there are two Scenarios: one with multiple small methods and
the other one more general with bigger methods (however, they contain
same assertions). I couldn't decide on the approach. The scenario with more
details is harder to manage but whenever tests fail, it's easier to know
straight away which tests failed from the Reports. The second, more generic
approach is better when there are multiple tests run at the same time, so the
test reports are not so cluttered with multiple results.

The task solution is in folder *ApiTester*. To run tests open the terminal
(console), go to the folder \ApiTester, and run the command:

    dotnet test

or for more details

    dotnet test --logger:"console;verbosity=detailed"

---
### Task: UI Automation Testing Exercise:

The solution for the task is in folder *OrderingTests*. To run tests open the
terminal, go to the folder \Ordering tests, and run the command:
    
    dotnet test

or for more details
    
    dotnet test --logger:"console;verbosity=detailed"
