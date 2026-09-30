# HelpDesk Lite — Project Plan

## Problem

Small support teams need a simple way to record incidents, identify urgency and track progress without relying on scattered messages or spreadsheets.

## Version 0.1 scope

The first version intentionally supports one workflow only:

1. A ticket is created.
2. The issue receives a category and priority.
3. Support changes the status as work progresses.
4. The system records timestamps.
5. The ticket can be searched, reviewed, edited or removed.

## Out of scope for Version 0.1

- Login and user accounts.
- Roles and permissions.
- File attachments.
- Email notifications.
- Ticket comments.
- Cloud deployment.

Keeping these features out of the first version makes the deliverable small enough to understand, test and finish.

## Suggested GitHub milestones

- `v0.1-foundation`: project structure and database model.
- `v0.1-crud`: ticket CRUD and validation.
- `v0.1-dashboard`: dashboard, filters and interface.
- `v0.1-release`: documentation, screenshots and final testing.
