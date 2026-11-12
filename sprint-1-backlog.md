# Sprint 1 — Sprint Backlog



## 1. Sprint Goal



Implement user registration and login functionality to allow users to securely access the Tourism PWA application.



## 2. Sprint Information



- Sprint: 1

- Duration: 2 weeks (planned)

- Team: 1 developer

- Availability: 6 hours/day, 6 days/week

- Available capacity: 72 hours

- Estimated workload: 70 hours (preliminary)

- Status: Done



The sprint may be completed earlier if all selected User Stories meet their acceptance criteria and Definition of Done.



## 3. Selected User Stories



| ID | User Story | Priority | Story Points | Status |
|---|---|---:|---:|---|
| US-01 | User Registration | 1 | 3 | Done |
| US-02 | User Login | 2 | 2 | Done |
| **Total** | | | **5** | |



## 4. Task Decomposition



### US-01 — User Registration (3 SP)



| Task | Description | Estimated Hours | Status |
|---|---|---:|---|
| T1.1 | Design registration form and input fields | 5 | Done |
| T1.2 | Design user entity and database structure | 5 | Done |
| T1.3 | Implement registration API endpoint | 8 | Done |
| T1.4 | Implement password hashing and input validation | 7 | Done |
| T1.5 | Connect frontend registration form to backend | 7 | Done |
| T1.6 | Test registration and error handling | 10 | Done |
| **Total** | | **42** | |



### US-02 — User Login (2 SP)



| Task | Description | Estimated Hours | Status |
|---|---|---:|---|
| T2.1 | Implement login form | 4 | Done |
| T2.2 | Implement credential verification API | 6 | Done |
| T2.3 | Implement authentication and session management | 4 | Done |
| T2.4 | Handle invalid credentials and login errors | 6 | Done |
| T2.5 | Test login and authentication scenarios | 8 | Done |
| **Total** | | **28** |



## 5. Effort Estimation



Estimation method: Relative Estimation supported by Task Decomposition.



- Reference User Story: US-02 = 2 Story Points

- US-02 estimated effort: 28 hours

- Preliminary conversion: 14 hours per Story Point

- US-01 estimated effort: 42 hours

- Total estimated effort: 70 hours



Story Points represent relative complexity and uncertainty, not a fixed number of hours. The hours-per-point conversion is a preliminary planning assumption.



## 6. Sprint Capacity



- Daily availability: 6 hours

- Weekly availability: 36 hours

- Planned sprint duration: 2 weeks

- Total available capacity: 72 hours

- Estimated workload: 70 hours

- Capacity buffer: 2 hours



The capacity buffer is limited. Actual effort and remaining work must be monitored during the sprint.



## 7. Progress Monitoring



Progress will be tracked using:



- Task status: To Do, In Progress, Done

- Estimated effort versus actual effort

- Remaining effort

- Sprint Burndown Chart

- Impediments and risks


### Planned vs Actual Schedule — Sprint 1

During Sprint 1, actual progress was compared with the initial daily work plan.

Some activities were completed earlier than expected, allowing work on subsequent planned activities within the same calendar day.

| Date | Planned Activities | Actual Progress | Observation |
|---|---|---|---|
| 2026-11-02 | Day 3 activities | Day 3 completed; Day 4 started | Progress ahead of the daily plan. Day 2 had been started on earlier dates. |
| 2026-11-07 | US-01 and US-02 activities | US-01 completed and T2.1 of US-02 completed | Work progressed across two User Stories on the same day. |
| 2026-11-08 | Day 9 and Day 10 activities | T2.2 and T2.3 completed | Two planned workdays completed during one calendar day. |

#### Schedule Monitoring Notes

- The original Sprint estimates remain unchanged.
- Planned workdays are used as scheduling references, not as measurements of actual effort.
- Completing multiple planned activities on the same day does not necessarily imply a reduction in working hours.
- Actual effort will be recorded separately when reliable information is available.
- No actual working hours are inferred from the number of planned days completed.
- The causes of schedule deviations will be reviewed during the Sprint Retrospective.
- Remaining work will be monitored to support the Sprint Burndown Chart.

#### Impact on Sprint Planning

The observed progress indicates that some activities were completed earlier than their planned position in the schedule.

This will be considered when reviewing estimation accuracy and planning future sprints.

Story Points and initial effort estimates will be preserved to allow comparison between planned and actual progress.

#### Day 12 — Schedule Deviation and Quality Assurance Extension

Day 12 activities were extended beyond the initial plan to strengthen the Quality Assurance process for US-01 (User Registration) and US-02 (User Login).

Following the successful completion of manual authentication tests, three automated integration tests were introduced using NUnit, Entity Framework Core, and isolated SQLite in-memory databases.

The additional activities included:
- Implementing automated tests for password hashing, duplicate email registration, and credential verification.
- Configuring isolated test databases to ensure repeatable and independent execution.
- Executing and validating the automated test suite.
- Updating the Sprint Backlog with testing results and evidence.

All three automated tests passed successfully.

**Impact on Sprint Planning:** The extension increased the scope of Quality Assurance activities compared with the original daily plan. The initial Story Points and effort estimates remain unchanged to preserve the planned baseline.

Actual working hours will not be inferred from the number of calendar days. This deviation will be reviewed during the Sprint Retrospective to improve testing estimates and planning in subsequent sprints.


### US-01 — Registration API Test Results

The registration API was tested using the HTTP Client in Visual Studio.



| Test ID | Test Scenario | Expected Result | Actual Result | Status |
|---|---|---|---|---|
| TEST 1 | Successful registration with a new email | 200 OK | 200 OK | Passed |
| TEST 2 | Registration with an existing email | 409 Conflict | 409 Conflict | Passed |
| TEST 3 | Registration with an invalid email format | 400 Bad Request | 400 Bad Request | Passed |
| TEST 4 | Registration with mismatched passwords | 400 Bad Request | 400 Bad Request | Passed |



All four backend registration tests passed.



Test evidence is available in `src/SPM.Tourism.Api/SPM.Tourism.Api/SPM.Tourism.Api.http`.



Note: The successful registration test requires an email address
that is not already stored in the database.



### US-01 — Frontend Integration and Test Results

The React registration form was connected to the ASP.NET Core backend using the registration API endpoint.

CORS was configured to allow requests from the React development server.

The following scenarios were successfully tested:
- Successful user registration.
- Registration with an existing email.
- Invalid email format.
- Password shorter than 8 characters.
- Mismatched passwords.
- Display and clearing of validation error messages.
- Display of the registration success message.

Frontend code validation passed using ESLint (`npm run lint`).

The production build completed successfully using `npm run build`.


### US-02 — Login Frontend Progress and Test Results

The login form was implemented as a separate React component (`LoginForm.jsx`).

The following frontend checks were completed:
- Login form displays Email and Password fields.
- Login and Register tabs switch between the two forms.
- Registration form remains accessible.
- The login interface uses React state for Email and Password.
- ESLint completed successfully (`npm run lint`).
- React production build completed successfully (`npm run build`).

T2.1 status: Done.

The login API and credential verification have been implemented
and tested successfully.

The backend JWT authentication mechanism has been implemented
and tested successfully.

The login endpoint now generates a signed JWT after successful
credential verification. Protected API endpoints require a valid
JWT, and tokens expire after one hour.


The React login form is now connected to the ASP.NET Core backend
through the POST /api/Auth/login endpoint.

After successful authentication, the frontend receives a JWT
and stores it temporarily in React component state.

During authentication testing, the JWT was used to access the
protected GET /api/Auth/me endpoint through the Authorization
Bearer header.

The temporary frontend testing control was removed after
successful verification. The protected backend endpoint remains available.

Frontend login error handling has been implemented and tested
for invalid credentials, invalid requests, and network failures.

Previous error messages are cleared after successful authentication.

Final end-to-end authentication tests were completed during Day 12.

GitHub integration and Definition of Done verification
are still pending.


US-02 status: In Progress.

### US-02 — Credential Verification API Test Results

The login API was implemented using ASP.NET Core and C#.

The endpoint `POST /api/Auth/login` verifies user credentials
using the password hash stored in the database.

The API was tested using the HTTP Client in Visual Studio.

| Test ID | Test Scenario | Expected Result | Actual Result | Status |
|---|---|---|---|---|
| TEST 5 | Login with valid credentials | 200 OK | 200 OK | Passed |
| TEST 6 | Login with incorrect password | 401 Unauthorized | 401 Unauthorized | Passed |
| TEST 7 | Login with unregistered email | 401 Unauthorized | 401 Unauthorized | Passed |
| TEST 8 | Login with invalid email format | 400 Bad Request | 400 Bad Request | Passed |

All four login API tests passed.

The ASP.NET Core backend build completed successfully.

Test evidence is available in the
`src/SPM.Tourism.Api/SPM.Tourism.Api/SPM.Tourism.Api.http` file.

T2.2 status: Done.

JWT-based stateless authentication has been implemented
and tested as part of T2.3.

Frontend authentication integration and manual login tests
were completed during Day 11.

Final end-to-end testing and acceptance checks
were completed during Day 12.

GitHub integration and Definition of Done verification
are still pending.

US-02 status: In Progress.


### US-02 — JWT Authentication and Security Test Results

JWT Bearer authentication was implemented in the ASP.NET Core backend.

The login endpoint generates a signed JWT after successful
credential verification.

JWT validation checks the token signature, issuer, audience,
and expiration time.

The signing key is stored locally using ASP.NET Core User Secrets
and is not included in the Git repository.

The following tests were executed using Visual Studio and PowerShell.

| Test ID | Test Scenario | Expected Result | Actual Result | Status |
|---|---|---|---|---|
| TEST 9 | Protected endpoint without JWT | 401 Unauthorized | 401 Unauthorized | Passed |
| TEST 10 | Protected endpoint with valid JWT | 200 OK | 200 OK | Passed |
| TEST 11 | Protected endpoint with malformed JWT | 401 Unauthorized | 401 Unauthorized | Passed |
| TEST 12 | Protected endpoint with modified JWT signature | 401 Unauthorized | 401 Unauthorized | Passed |
| TEST 13 | Protected endpoint with expired JWT | 401 Unauthorized | 401 Unauthorized | Passed |

All five JWT authentication tests passed.

For the expiration test, the JWT lifetime was temporarily
reduced to 10 seconds. The token was rejected after the
configured expiration period and clock skew.

The original JWT lifetime of one hour was restored afterward.

The final backend build completed successfully.
The login and protected endpoint were tested again successfully.

Authentication uses stateless JWT access tokens.
Server-side session storage and refresh tokens are not implemented.

T2.3 status: Done.
US-02 status: In Progress.


### US-02 — Day 11: Frontend Authentication Integration and Test Results

The React login form was integrated with the ASP.NET Core
authentication API.

The frontend sends user credentials using the Fetch API
and receives a JWT after successful authentication.

The JWT is stored temporarily in React component state
and used to access protected backend resources.

The following scenarios were manually tested using Chrome
and its Developer Tools.

| Test ID | Test Scenario | Expected Result | Actual Result | Status |
|---|---|---|---|---|
| TEST 14 | Successful login from React | 200 OK and JWT received | 200 OK and JWT received | Passed |
| TEST 15 | Protected endpoint access with valid JWT | 200 OK | 200 OK | Passed |
| TEST 16 | Protected access without JWT in React | Request blocked by frontend | Request blocked by frontend | Passed |
| TEST 17 | Login with incorrect password | 401 Unauthorized and error message | 401 Unauthorized and error message | Passed |
| TEST 18 | Successful login after incorrect password | Previous error disappears | Previous error disappears | Passed |
| TEST 19 | Login while backend is unavailable | Connection error message displayed | Connection error message displayed | Passed |
| TEST 20 | Login after restarting the backend | 200 OK and error cleared | 200 OK and error cleared | Passed |
| TEST 21 | Login with invalid email format | 400 Bad Request and generic error message | 400 Bad Request and generic error message | Passed |

All eight frontend authentication scenarios passed.

#### Login Error Handling

The following error-handling mechanisms were implemented:

- HTTP 401: Display "Invalid email or password."
- Other HTTP errors: Display "Login failed. Please try again."
- Network failures: Display "Unable to connect to the server. Please try again."
- Successful authentication: Clear previous login errors.

Previous JWT values are cleared after failed authentication.

T2.4 status: Done.

#### Frontend Code Quality and CSS Improvements

ESLint completed successfully using:

`npm run lint --prefix src/frontend`

The React production build completed successfully using:

`npm run build --prefix src/frontend`

The App.css file was refactored to reduce duplicated CSS rules.

The main application container and responsive layout rules
were reorganized while preserving the existing Tourism PWA design.

The application was visually checked in a reduced browser window.

Mobile responsive layout testing was completed during Day 12
using Chrome DevTools at a viewport width of 400px.

Both Login and Registration forms displayed correctly,
with no visible overlapping or clipped elements.

#### Remaining Work

- Review the modified files using Git.
- Commit and push the US-02 changes to GitHub.
- Create and merge the US-02 Pull Request into `main`.
- Verify the Definition of Done for US-02.
- Complete Sprint progress monitoring, including actual effort and remaining work.
- Complete the Sprint Review and Sprint Retrospective.


T2.5 status: Done.
US-02 status: In Progress.


### US-02 — Day 12: Final Authentication and Validation Tests

Final authentication testing was performed using the React frontend, ASP.NET Core backend, and Chrome Developer Tools.

| Test ID | Test Scenario | Expected Result | Actual Result | Status |
|---|---|---|---|---|
| TEST 22 | Login with valid credentials | 200 OK and JWT received | 200 OK and JWT received | Passed |
| TEST 23 | Protected endpoint access with valid JWT | 200 OK | 200 OK | Passed |
| TEST 24 | Login with incorrect password | 401 Unauthorized | 401 Unauthorized | Passed |
| TEST 25 | Invalid credentials error feedback | Error message displayed | Error message displayed | Passed |
| TEST 26 | Successful login after incorrect password | Previous error disappears | Previous error disappears | Passed |
| TEST 27 | Protected access without JWT in React | Request blocked by frontend | Request blocked by frontend | Passed |
| TEST 28 | Empty login fields before validation improvement | 400 Bad Request and generic error | 400 Bad Request and generic error | Observed |
| TEST 29 | Email and password missing | Both field errors displayed | Both field errors displayed | Passed |
| TEST 30 | Password missing | Password is required | Password is required | Passed |
| TEST 31 | Email missing | Email is required | Email is required | Passed |
| TEST 32 | Valid login after validation changes | 200 OK | 200 OK | Passed |
| TEST 33 | Invalid email format | Email validation error | Email validation error | Passed |
| TEST 34 | Mobile responsive layout (400px): Login and Registration | Forms and buttons visible without overlap | Both forms displayed correctly at 400px | Passed |
| TEST 35 | Registration followed by login with the same credentials | Newly registered user can log in successfully | Registration successful; login returned 200 OK and success message displayed | Passed |

#### Testing Strategy and Additional Test Rationale

The testing strategy focused on verifying the acceptance criteria
of US-01 (User Registration) and US-02 (User Login).

Functional tests were performed to verify registration, authentication,
input validation, error handling, and protected API access.

Additional tests were selected based on the criticality of the
functionalities and the expected user experience.

TEST 34 was performed to verify the mobile layout of the Login
and Registration interfaces at a viewport width of 400px.

TEST 35 was performed to verify the complete user workflow,
from registration to successful login using the same credentials.

This integration test confirmed that US-01 and US-02 work together
correctly and provides a reproducible scenario for the Sprint Review
and final live demonstration.


#### Automated Integration Tests — Sprint 1

Automated tests were implemented using NUnit and executed
through Visual Studio Test Explorer.

Each test uses an isolated SQLite in-memory database.

| ID | Test Scenario | Actual Result | Status |
|---|---|---|---|
| AUTO-01 | Registration stores a password hash instead of plaintext | Password hash stored correctly | Passed |
| AUTO-02 | Registration with a duplicate email | Second registration rejected; only one user stored | Passed |
| AUTO-03 | Login with correct and incorrect passwords | Correct password accepted; incorrect password rejected | Passed |

Execution summary:
- Tests executed: 3
- Passed: 3
- Failed: 0
- Skipped: 0
- Total execution time: 1.7 seconds

Testing Strategy:
Automated integration tests focus on critical authentication
behaviours related to US-01 and US-02.

The tests complement the previously completed manual tests
and support regression testing.

Tools: NUnit, Entity Framework Core, SQLite in-memory,
Visual Studio Test Explorer.



#### Additional Validation Checks

- Invalid email and missing password produce two separate validation messages.
- Validation messages appear below the corresponding input fields.
- Invalid fields are highlighted using `aria-invalid`.
- Field validation messages are cleared when the user modifies the corresponding input.
- Invalid login input is blocked before sending an HTTP request.
- Chrome Network confirmed that no POST request to `/api/Auth/login` was sent for invalid input.
- Valid login requests successfully reached the backend and returned HTTP 200.
- The CORS preflight request completed successfully with HTTP 204.

#### Frontend Code Quality

ESLint completed successfully:

`npm run lint --prefix src/frontend`

React production build completed successfully:

`npm run build --prefix src/frontend`

#### Validation Improvement

During final testing, generic error feedback was identified for empty login fields.

Client-side field validation was introduced to provide more specific feedback and prevent unnecessary backend requests.

The login interface was aligned with the registration interface by displaying validation errors below the corresponding fields.

Previously completed authentication functionality was preserved and verified through regression testing.

T2.5 status: Done.

Pull Request, merge into main, and final Definition of Done
verification are still pending.




## 8. Definition of Done

A User Story is considered Done when:



- The required functionality is implemented.

- Acceptance criteria are satisfied.

- Relevant tests have been executed successfully.

- The application builds and runs.

- Changes are committed to Git.

- The feature branch is merged into main through a Pull Request.

- Relevant documentation is updated.

### US-01 — Definition of Done Verification

All US-01 Definition of Done criteria have been satisfied.

- Registration functionality implemented and tested.
- Frontend and backend integration verified.
- ESLint and React production build passed.
- Sprint Backlog updated.
- Changes committed and pushed to GitHub.
- Pull Request #4 merged into `main` on November 7, 2026.

Merge commit: `6ac0922`.

US-01 final status: Done.


### US-02 — Definition of Done Verification

Formal DoD verification was documented on November 12, 2026, following the merge of Pull Request #6.

#### Functional Requirements
- [x] Login functionality implemented using ASP.NET Core and React.
- [x] Password verification implemented using stored password hashes.
- [x] JWT authentication and protected API access implemented.
- [x] Authentication errors and client-side input validation handled.

#### Testing and Quality
- [x] Acceptance criteria verified through manual testing.
- [x] Authentication and registration-to-login workflows tested.
- [x] Three automated NUnit integration tests passed.
- [x] Frontend ESLint and production build passed.
- [x] Relevant testing results documented in the Sprint Backlog.

#### Git and Integration
- [x] Changes committed and pushed to GitHub.
- [x] Pull Request #6 merged into `main` on November 12, 2026.
- [x] Local `main` updated and working tree verified clean after the merge.

Merge commit: `0390ead`.

#### Process Note
Functional testing, automated testing, and the initial Sprint Backlog
documentation were completed before the merge.

The formal Definition of Done verification was documented after
the merge rather than before it. This process deviation will be
reviewed during the Sprint Retrospective.

US-02 final status: Done.




## 9. Sprint Review

### Sprint Goal Evaluation

The Sprint 1 goal was achieved: user registration and login
functionality were implemented and integrated into the Tourism PWA.

### Completed User Stories

- US-01 — User Registration: Done (3 Story Points).
- US-02 — User Login: Done (2 Story Points).

Total completed: 5 out of 5 planned Story Points.

### Increment Verification

The implemented increment supports:
- User registration with input validation.
- Secure password hashing and verification.
- Login with JWT-based authentication.
- Protected API access.
- Error handling for invalid credentials.
- Responsive registration and login interfaces.

Functional behaviour was verified through manual testing,
integration scenarios, and automated NUnit tests.

Automated test results: 3 passed, 0 failed.

A registration-to-login workflow was successfully tested.
The same workflow is available for the final live demonstration.

### Sprint Review Outcome

Both selected User Stories satisfy the documented
Definition of Done.

US-01 was integrated through Pull Request #4.
US-02 was integrated through Pull Request #6.

The Sprint Goal is considered achieved.

## 10. Sprint Retrospective

### What Went Well

- Both planned User Stories were completed.
- Backend and frontend integration was successful.
- JWT authentication and password security were implemented.
- Manual and automated testing verified critical functionality.
- Git branches and Pull Requests supported development traceability.

### What Could Be Improved

- Additional automated testing extended Day 12 activities.
- The initial testing plan underestimated the need for
  isolated automated integration tests.
- Formal Definition of Done verification for US-02
  was documented after the merge rather than before it.

### Planned vs Actual Effort

Initial estimated effort: 70 hours.
Available Sprint capacity: 72 hours.

Actual working hours were not recorded with sufficient
precision for a reliable numerical comparison.

The additional Quality Assurance activities represent
a deviation from the original daily schedule.

The original estimates remain unchanged.

### Improvement Actions for Sprint 2

1. Define the automated testing strategy during Sprint Planning.
2. Include testing and documentation in task decomposition.
3. Complete the formal Definition of Done checklist before merging.
4. Record actual effort and remaining work more consistently.
5. Review schedule deviations during Sprint Monitoring.

### Retrospective Conclusion

Sprint 1 achieved its functional objectives.
The identified process improvements will be applied
during Sprint 2 — Data Ingestion.
