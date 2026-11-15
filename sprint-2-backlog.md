\# Sprint 2 — Sprint Backlog



\## 1. Sprint Goal



Retrieve tourism data for Gradara from the updated external API,

validate and transform the data, store it in the local database,

and display tourism content to authenticated users.



\## 2. Sprint Information



\- Sprint: 2

\- Duration: 2 weeks (planned)

\- Team: 1 developer

\- Availability: 6 hours/day, 6 days/week

\- Available capacity: 72 hours

\- Estimated workload: 70 hours (preliminary)

\- Status: In Progress



\## 3. Selected User Story



| ID | User Story | Priority | Story Points | Status |

|---|---|---|---|---|

| US-03 | Tourism Content | 3 | 5 | In Progress |



\### User Story



As an authenticated user, I want to browse tourism content

for a selected municipality so that I can discover places

and activities.



\### Acceptance Criteria



\- Tourism data is retrieved from the external API.

\- Valid data is stored in the local database.

\- Stored tourism content is displayed in the application.



\## 4. Task Decomposition



\### US-03 — Tourism Content (5 SP)



| Task | Description | Estimated Hours | Status |

|---|---|---:|---|

| T3.1 | Analyse API endpoints, data formats and available content | 6 | In Progress |

| T3.2 | Design tourism entities and database structure | 8 | Done |

| T3.3 | Implement API data retrieval and pagination | 12 | To Do |

| T3.4 | Implement data validation and transformation | 10 | To Do |

| T3.5 | Implement local storage and duplicate handling | 8 | To Do |

| T3.6 | Implement protected backend endpoints for stored content | 6 | To Do |

| T3.7 | Implement React tourism content display | 10 | To Do |

| T3.8 | Perform testing, integration checks and documentation | 10 | To Do |

| \*\*Total\*\* | | \*\*70\*\* | |



\## 5. Effort Estimation



Estimation method: Relative Estimation supported by

Task Decomposition and Points-to-Hours Approximation.



\- Reference User Story: US-02 = 2 Story Points

\- Reference estimated effort: 28 hours

\- Preliminary approximation: 14 hours per Story Point

\- US-03 estimated complexity: 5 Story Points

\- Preliminary estimated effort: 70 hours



Story Points represent relative complexity and uncertainty,

not a fixed number of hours.



The task estimates are initial planning assumptions and

may be revised based on actual progress.



\## 6. Sprint Capacity



\- Daily availability: 6 hours

\- Weekly availability: 36 hours

\- Planned Sprint duration: 2 weeks

\- Total available capacity: 72 hours

\- Estimated workload: 70 hours

\- Capacity buffer: 2 hours



The limited buffer requires careful monitoring of risks

and remaining work.



\## 7. External API



\- Municipality: Gradara

\- API: https://apipublic.eppoi.io

\- Documentation: https://apipublic.eppoi.io/scalar/



The API supports municipality filtering and pagination.



The cultural sites endpoint returned 15 records for Gradara.



Other content categories will be assessed before finalising

the ingestion implementation scope.





\## 8. Risk Planning



\### Risk Assessment Method



Risks are evaluated using a 4x4 Risk Matrix.



\- Probability: 1 (Very Low) to 4 (Very High).

\- Impact: 1 (Minor) to 4 (Critical).

\- Risk Exposure = Probability x Impact.

\- Low Risk: 1-4.

\- Medium Risk: 5-9.

\- High Risk: 10-16.



All assessments are preliminary and will be reviewed

during Sprint Monitoring.



\### Risk Register



| ID | Risk | Probability | Impact | Exposure | Level |

|---|---|---:|---:|---:|---|

| R1 | External API unavailable or unstable | 3 | 4 | 12 | High |

| R2 | Missing, invalid or complex tourism data | 3 | 3 | 9 | Medium |

| R3 | Pagination or duplicate data handling errors | 2 | 3 | 6 | Medium |

| R4 | Sprint workload exceeds available capacity | 3 | 4 | 12 | High |



\### Risk Response Planning



\#### R1 — External API Availability

\- Mitigation: Verify API availability and response formats early.

\- Contingency: Continue development and testing with previously retrieved sample responses until the API becomes available.

\- Monitoring: Check API availability during ingestion development.



\#### R2 — Data Quality

\- Mitigation: Validate required fields, handle null values and safely process text containing HTML.

\- Contingency: Skip invalid records, log validation failures and preserve valid records.

\- Monitoring: Review validation results and rejected records.



\#### R3 — Pagination and Duplicate Records

\- Mitigation: Use stable external identifiers and test pagination boundaries.

\- Contingency: Correct ingestion logic and repeat the affected import.

\- Monitoring: Compare imported record counts with API results.



\#### R4 — Limited Sprint Capacity

\- Mitigation: Prioritise US-03 acceptance criteria and monitor remaining effort.

\- Contingency: Replan lower-priority implementation details without silently removing acceptance criteria.

\- Monitoring: Review task progress and remaining work regularly.



\### Risk Monitoring



The Risk Register will be reviewed during Sprint execution.



Changes in probability, impact, exposure and response actions

will be documented when new evidence becomes available.





\## 9. Sprint Monitoring



\### Monitoring Strategy



Sprint progress will be monitored by comparing planned

activities with actual progress throughout the Sprint.



The following indicators will be tracked:



\- Task status: To Do, In Progress, Done.

\- Estimated effort versus actual working hours.

\- Remaining effort for incomplete tasks.

\- Completed and remaining Story Points.

\- Schedule deviations and corrective actions.

\- Risk Exposure and changes in the Risk Register.



\### Initial Sprint Baseline



| Indicator | Initial Value |

|---|---|

| Planned User Stories | 1 (US-03) |

| Planned Story Points | 5 |

| Completed Story Points | 0 |

| Remaining Story Points | 5 |

| Estimated Effort | 70 hours |

| Available Capacity | 72 hours |

| Capacity Buffer | 2 hours |



Story Points will be considered completed when US-03

satisfies its acceptance criteria and Definition of Done.



Task progress will be tracked separately to monitor

partial completion during the Sprint.



\### Planned vs Actual Schedule — Sprint 2



| Date | Planned Activities | Actual Progress | Observation |

|---|---|---|---|

| 2026-11-14 | Sprint Planning and initial API analysis | Defined Sprint Goal, Task Decomposition, estimates, Risk Planning, Monitoring and Definition of Done; selected Gradara | Planning completed and pushed to GitHub. T3.1 remains In Progress. |

| 2026-11-15 | Day 2 - T3.2: Tourism database design | Created TourismContent.cs, updated ApplicationDbContext, generated and applied the AddTourismContent migration | T3.2 completed. Both .NET projects compiled successfully. The migration does not modify the Users table. Actual hours not recorded. |



Actual effort will be recorded when reliable working

time information is available.



Remaining effort will be reviewed throughout the Sprint

without assuming that planned hours equal actual hours.



\### Sprint Burndown



The Sprint Burndown will track remaining work over time.



Initial baseline:

\- Planned Story Points: 5.

\- Remaining Story Points: 5.

\- Completed Story Points: 0.



Progress observations will be recorded during Sprint

execution. Missing historical observations will not

be reconstructed using invented values.



\### Risk Monitoring



The Risk Register will be reviewed regularly.



Particular attention will be given to:

\- R1: External API availability.

\- R2: Tourism data quality.

\- R3: Pagination and duplicate handling.

\- R4: Limited Sprint capacity.



Changes in Risk Exposure and corrective actions

will be documented when necessary.



\### Monitoring and Corrective Actions



When deviations from the initial plan are identified,

the following information will be recorded:



\- Description of the deviation.

\- Impact on Sprint Goal, workload or schedule.

\- Corrective action adopted.

\- Updated task status and remaining effort.



Original estimates will be preserved as the planning

baseline to support the Sprint Retrospective.







\## 10. Definition of Done



US-03 will be considered Done only when all the following

criteria have been verified.



\### Functional Requirements



\- \[ ] Tourism data for Gradara is retrieved from the updated external API.

\- \[ ] API pagination is handled correctly for the selected content.

\- \[ ] Retrieved data is validated and transformed.

\- \[ ] Valid tourism records are stored in the local database.

\- \[ ] Repeated ingestion does not create duplicate records.

\- \[ ] Stored tourism content is accessible through backend endpoints.

\- \[ ] Authenticated users can view tourism content in the React application.

\- \[ ] Unauthenticated access to protected content is rejected.



\### Testing and Quality



\- \[ ] US-03 acceptance criteria are verified.

\- \[ ] Relevant automated tests are implemented and passed.

\- \[ ] API failures, missing values and invalid data are handled.

\- \[ ] Backend build and tests pass.

\- \[ ] Frontend ESLint and production build pass.

\- \[ ] The registration, login and tourism content flow is verified.



\### Documentation and Scrum Process



\- \[ ] Sprint Backlog is updated with actual progress.

\- \[ ] Test results and relevant evidence are documented.

\- \[ ] Risks and corrective actions are reviewed.

\- \[ ] Deviations from the Sprint Plan are recorded.

\- \[ ] Formal Definition of Done checklist is verified before merge.



\### Git and Integration



\- \[ ] Implementation changes are committed and pushed.

\- \[ ] Pull Request is created and reviewed.

\- \[ ] All required pre-merge checks are satisfied.

\- \[ ] Pull Request is merged into main.

\- \[ ] Local main is synchronised after the merge.



\### Final Verification



US-03 status: In Progress.



The checklist will be updated during Sprint execution.



The formal pre-merge verification must be completed before

integrating the User Story into main.



Final Sprint Review and Sprint Retrospective will be

documented at the end of Sprint 2.
