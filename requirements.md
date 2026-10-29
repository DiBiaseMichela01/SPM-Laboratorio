

# Software Project Management — Requirements



## 1. Project Overview



The project aims to develop a tourism application that allows users to access information about a selected municipality, explore tourist content, receive personalised recommendations and interact with a tourism chatbot.



The application will be developed incrementally across four Sprints:



- **Sprint 1 — Authentication:** user registration and login.

- **Sprint 2 — Data Ingestion:** retrieval, validation, transformation, storage and display of real tourism data.

- **Sprint 3 — User Profiling and Personalisation:** questionnaire, user preferences and personalised content ranking.

- **Sprint 4 — Tourism Chatbot:** chatbot integration using information available in the application.



## 2. Actors and External Systems



**Visitor:** a person who has not yet logged in and can register or authenticate.



**Authenticated User:** a registered user who can access tourism content, provide preferences, receive recommendations and interact with the chatbot.



**External Tourism API:** an external system that provides tourism data for the selected municipality.



## 3. Functional Requirements



- **FR-01:** The system shall allow visitors to register.

- **FR-02:** The system shall allow registered users to log in.

- **FR-03:** The system shall retrieve tourism data from the external API.

- **FR-04:** The system shall store validated tourism data in a local database.

- **FR-05:** The system shall display tourism content to authenticated users.

- **FR-06:** The system shall allow users to complete a preferences questionnaire.

- **FR-07:** The system shall create a preference profile based on questionnaire answers.

- **FR-08:** The system shall rank tourism content according to user preferences.

- **FR-09:** The system shall provide fallback recommendations when personalised results are insufficient.

- **FR-10:** The system shall provide a tourism chatbot that answers questions using application data.



## 4. Non-Functional Requirements



- **NFR-01 — Security:** Passwords shall be securely hashed and never stored in plain text.

- **NFR-02 — Input Validation:** User input shall be validated.

- **NFR-03 — Access Control:** Protected features shall require authentication.

- **NFR-04 — Testability:** The main application behaviours shall be verifiable through appropriate tests.



## 5. Initial User Stories



### US-01 — User Registration



As a visitor, I want to create an account so that I can access the application's reserved features.



**Acceptance Criteria:**



- Required registration fields are validated.

- Invalid registration data is rejected.

- Duplicate email registration is prevented.

- Passwords are stored using secure hashing.

- Valid registration creates a user account.



### US-02 — User Login



As a registered user, I want to log in so that I can access protected application features.



**Acceptance Criteria:**



- Valid credentials allow access.

- Invalid credentials are rejected.

- Missing required fields produce validation feedback.

- Unauthenticated users cannot access protected pages.



### US-03 — Tourism Content



As an authenticated user, I want to browse tourism content for a selected municipality so that I can discover places and activities.



**Acceptance Criteria:**



- Tourism data is retrieved from the external API.

- Valid data is stored in the local database.

- Stored tourism content is displayed in the application.



### US-04 — Preferences Questionnaire



As a user, I want to indicate my tourism interests so that the application can understand my preferences.



**Acceptance Criteria:**



- The user can complete the questionnaire.

- Answers are processed into a preference profile.



### US-05 — Personalised Recommendations



As a user, I want tourism content to be ranked according to my interests so that I can discover relevant experiences.



**Acceptance Criteria:**



- Recommendations use the user's preference profile.

- Content is ranked using a defined scoring approach.

- Fallback results are available when necessary.



### US-06 — Tourism Chatbot



As a user, I want to ask tourism-related questions so that I can obtain information about available places and activities.



**Acceptance Criteria:**



- The chatbot is accessible within the application.

- Answers are grounded in available application data.

- Out-of-domain questions are handled appropriately.

- The chatbot provides a fallback when relevant information is unavailable.



## 6. Open Decisions



The following decisions must be documented during project planning:



- Municipality to be selected for tourism data ingestion.

- Detailed technology stack and development environment.

- Product Backlog priorities and Story Point estimates.

- Sprint schedule and individual working process.

- Definition of Done and testing strategy.



## 7. Document Status



**Status:** Initial draft.



This document is a starting point and will be reviewed and refined during the project. Changes must reflect actual project decisions and implementation progress.



