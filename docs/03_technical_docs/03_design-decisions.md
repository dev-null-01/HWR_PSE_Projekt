---
layout: default
title: Design Decisions & Change Management
parent: Technical Documentation
nav_order: 13
---

# Design Decisions & Change Management

> [!IMPORTANT]
> **Maintenance Rule:** This document is a living record. Every major technical choice, pivot, or goal adjustment must be documented here immediately. This also serves as our official **Change Management Log**.

### Dynamic Decision Log & Change Management
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

### 28.04.2026: Festlegung der Hauptzielgruppe (Informatikstudierende)
**Status:** `NEW`

**Context:**
Für die inhaltliche Ausrichtung, den Schwierigkeitsgrad der Dark Patterns und die Art der Reflexion musste eine klare Zielgruppe definiert werden. 

**Decision & Justification:**
- **What:** Wir haben uns entschieden, Informatikstudierende als primäre Hauptzielgruppe für das VR-Szenario festzulegen.
- **Why:** Informatikstudierende sind die zukünftigen Entwickler:innen und Gestalter:innen digitaler Systeme. Wir priorisierten diese spezifische Fachgruppe, weil das Projekt nicht nur das Erkennen von Dark Patterns vermitteln soll, sondern insbesondere die kritische, ethische Reflexion über das eigene zukünftige Handeln in der Softwareentwicklung fördern soll. Außerdem wünscht sich die Auftraggeberin Frau Siegeris diese Zielgruppe.

**Impact on Goals (Change Management):**
- [x] No impact on MVP.
- [ ] **Goal Shift:** -

---

### 05.05.2026: Wahl der Entwicklungsumgebung (Unity)
**Status:** `NEW`

**Context:**
Für die Umsetzung der interaktiven VR-Umgebung musste frühzeitig die zugrundeliegende Technologie festgelegt werden, die Meta Quest 3 optimal unterstützt und eine effiziente Entwicklung ermöglicht.

**Decision & Justification:**
- **What:** Wir haben uns entschieden, Unity (mit C#) als primäre Game-Engine zu verwenden.
- **Why:** Unity bietet eine sehr ausgereifte VR-Integration und eine große Community für Problemlösungen. Wir priorisierten Unity über Unreal Engine oder Godot, weil es für die geforderten VR-Mechaniken und die Bereitstellung auf der Meta Quest 3 am besten geeignet ist und bereits in den Projektvorgaben empfohlen wurde.

**Impact on Goals (Change Management):**
- [x] No impact on MVP.
- [ ] **Goal Shift:** -

---

### 05.05.2026: Interaktionskonzept in VR (Physisches Greifen)
**Status:** `NEW`

**Context:**
Um die Dark Patterns wirklich erlebbar zu machen, mussten wir festlegen, wie die Nutzer:innen mit der digitalen Welt und den UI-Elementen interagieren. Ein rein passives Umschauen reicht für die gewünschte digitale Selbstwirksamkeit nicht aus.

**Decision & Justification:**
- **What:** Wir haben uns entschieden, interaktive VR-Features wie das direkte, physische Anfassen und Greifen von In-Game-Objekten und UI-Elementen mit den Controllern zu implementieren.
- **Why:** Das aktive Greifen maximiert die Immersion. Wir priorisierten direkte räumliche Interaktionen, da das physische Handhaben und Erleben manipulierter Gestaltungselemente die Reflexion und den Lerneffekt deutlich verstärkt.

**Impact on Goals (Change Management):**
- [x] No impact on MVP.
- [ ] **Goal Shift:** -

---

### 05.05.2026: Fortbewegungskonzept in VR (Teleportation)
**Status:** `NEW`

**Context:**
Da die Zielgruppe nicht zwingend aus erfahrenen VR-Nutzer:innen besteht, mussten wir definieren, wie sich die Spieler:innen in der Welt bewegen, ohne dass ihr Wohlbefinden durch Motion Sickness (Kinetose) beeinträchtigt wird.

**Decision & Justification:**
- **What:** Wir haben uns entschieden, die Fortbewegung in der VR-Umgebung primär durch (sinnvolles) Teleportieren in Kombination mit freiem Umschauen zu lösen.
- **Why:** Teleportation ist das bewährteste Mittel zur Vermeidung von Motion Sickness. Wir priorisierten Teleportation über fließendes Laufen, da eine schwindelfreie Erfahrung angenehmer ist und die Spieler:innen sich auf die Lernziele und das Erkennen der Dark Patterns konzentrieren können.

**Impact on Goals (Change Management):**
- [x] No impact on MVP.
- [ ] **Goal Shift:** -

---

### 05.05.2026: Feedback-Mechanik bei Nutzerfehlern (Instant Feedback)
**Status:** `NEW`

**Context:**
Das primäre Ziel des Projekts ist es, Nutzer:innen für Dark Patterns zu sensibilisieren. Wir mussten entscheiden, zu welchem Zeitpunkt die Reflexionsphase am effektivsten ist – direkt während der Situation oder erst am Ende eines Levels.

**Decision & Justification:**
- **What:** Wir haben uns entschieden, den Einsatz von "Instant Feedback" zu implementieren, das sofort auslöst, wenn Nutzer:innen einen Fehler machen (z.B. auf ein Dark Pattern hereinfallen).
- **Why:** Der Lerneffekt wird dadurch deutlich verbessert. Wir priorisierten unmittelbares Feedback über eine nachträgliche Auswertung, weil die direkte Verknüpfung der eigenen (Fehl-)Entscheidung mit der sofortigen Aufklärung die kognitive Reflexion und den Aha-Moment am besten fördert.

**Impact on Goals (Change Management):**
- [x] No impact on MVP.
- [ ] **Goal Shift:** -

---

### Außstehende Design Decisions

* Visueller Stil & Art Direction
* Konkrete Szenarien-Auswahl (5 Szenarien)
* Gamification & Belohnungssystem
* Umsetzung der Barrierefreiheit in VR (Wenn überhaupt aber nicht unbedingt in MVP)
* Evaluationskonzept zur Erfassung der UX
* ...
