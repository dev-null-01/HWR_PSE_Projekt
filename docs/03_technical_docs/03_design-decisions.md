---
layout: default
title: Design Decisions & Change Management
parent: Technical Documentation
nav_order: 13
---

# Design Decisions & Change Management

> [!IMPORTANT]
> **Maintenance Rule:** This document is a living record. Every major technical choice, pivot, or goal adjustment must be documented here immediately. This also serves as our official **Change Management Log**.

## 1. Dynamic Decision Log & Change Management
*This section tracks how the project evolves and where we deviated from the original plan.*

### [DATUM]: [TITEL DER ENTSCHEIDUNG]
**Status:** `NEW` / `CHANGED` / `DEPRECATED`

**Context:**
Describe the problem or the situation. Why did we have to make a choice now? (e.g., "User feedback showed that...")

**Decision & Justification:**
- **What:** We decided to [Decision].
- **Why:** [Justification]. We prioritized [A] over [B] because [Reason].

**Impact on Goals (Change Management):**
- [ ] No impact on MVP.
- [x] **Goal Shift:** We moved Feature X to "Future Release" to ensure Feature Y is stable.

---

### [BEISPIEL-EINTRAG]: Wechsel des Login-Verfahrens
**Status:** `CHANGED` (22.04.2026)

**Context:**
Original plan was E-Mail-only Login. During internal testing, we realized that students prefer a quick "Nickname" access for faster usage.

**Decision & Justification:**
- **What:** Added Username-based Login as an alternative.
- **Why:** User experience (UX) and speed. Our goal is "Frictionless Learning".

**Impact on Goals:**
- **Change:** Minor scope increase, but higher user acceptance for the Schulungskonzept.

---
***Attachments:***
- image.png
- screenshot.png
---




**2026 | HWR Berlin** | Last build: {{ site.time | date: '%d %b %Y, %H:%M' }}