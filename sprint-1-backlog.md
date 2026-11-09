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

- Status: In Progress



The sprint may be completed earlier if all selected User Stories meet their acceptance criteria and Definition of Done.



## 3. Selected User Stories



| ID | User Story | Priority | Story Points | Status |
|---|---|---:|---:|---|
| US-01 | User Registration | 1 | 3 | Done |
| US-02 | User Login | 2 | 2 | In Progress |
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
| T2.5 | Test login and authentication scenarios | 8 | To Do |
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

The JWT is used to access the protected GET /api/Auth/me endpoint
through the Authorization Bearer header.

Frontend login error handling has been implemented and tested
for invalid credentials, invalid requests, and network failures.

Previous error messages are cleared after successful authentication.

Final end-to-end authentication testing and acceptance checks
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

Additional mobile-device viewport testing remains pending.

#### Remaining Work

- Complete final authentication acceptance tests.
- Review temporary testing controls in the login interface.
- Complete the Definition of Done for US-02.
- Commit and push Day 11 changes to GitHub.

T2.5 status: To Do.
US-02 status: In Progress.



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



## 9. Sprint Review



At the end of Sprint 1, demonstrate:



- Successful user registration.

- Input validation and registration error handling.

- Successful login with valid credentials.

- Rejection of invalid login credentials.

- Access to functionality protected by authentication.



## 10. Sprint Retrospective



At the end of the sprint, document:



- What went well.

- What could be improved.

- Differences between estimated and actual effort.

- Actions to improve the next sprint.

