# Contributing

This repository contains information about what the weather policy will be like regarding branches and confirmation messages, please read before you start using our repositories.

## Index

[How can i contribute?](#how-can-i-contribute)

  * [Reportando Bugs](#reportando-bugs)
  * [Fluxo Git](#fluxo-git)
  * [Pull Requests](#pull-requests)
  * [Pull Request Labels](#pull-request-labels)

[Styleguides](#styleguides)
  * [Git Commit Messages](#git-commit-messages)

## How can i contribute?

### Reporting Bugs

This section shows how to report a bug to Chameleon. Following these _guidelines_ helps the team understand its _report_: pencil: and reproduce the behavior: computer:: computer :.

Before creating a bug report make sure there is no longer a [issue](https://github.com/yurisouza/expressionbuildernetcore/issues) open to the same problem. When creating a new bug report, include [as much detail as possible](#how-to-create-a-good-report-bug) please.

#### How to create a good report bug?

Explain the bug and include additional details to help reproduce the problem:

* ** Use a clear and descriptive title ** in Issue to identify the problem.
* ** Describe the exact steps that reproduce the problem ** in as much detail as possible.
* ** If possible, provide specific examples to reproduce the steps **. Include links or files that show where the problem occurs.
* ** Describe the behavior observed after following the steps ** and point out exactly what is the problem with this behavior.
* ** Explain what was expected behavior and why. **

### Pull Requests

* Follow the code styleguides.
* Verify that all tests are passing.
* Follow the pattern of commit messages.
* No ** Title ** briefly describe what the pull request represents, followed by one of the appropriate labels described here (#pull-request-labels).
* Na ** Description ** document the change according to styleguide:
 
   - `What was done?`
   - `Why was it made?`
   - `How was it done?`

**Example:**

```
Title:      [#bug] Correção de erros de validação no login

Description:  
    What was done?
    - Corrects login.
    Implements fields validation at login.

    Why was it made?
    - When trying to log in with wrong information the page was
    recharging unnecessarily.

    How was it done?

    - At login, in the unauthorized state, the
    URIEncoded (responsible for the problem).
```

### Pull Request Labels

This section lists the labels used in the pull request message.
Each label will represent a section in the changelog, followed by the pull requests commit message that will describe the change.

| Label |  Description |
| --- | --- |
| `enhancement` |  New Feature or improvement |
| `bug` | Fix bugs |
|`documentation`| Add/Update the docs |
| `fire` |  Removing code or files. |

## Styleguides

### Git Commit Messages

* Use this imperative ("Add feature" not "Added feature"). Tip: Think about the action the commit is taking.
* Limit first line to 72 characters or less
Consider starting the commit message with an [emoji] (https://gitmoji.carloscuesta.me/) that applies.

[:arrow_left: Back](README.md)
