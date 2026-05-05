---
layout: default
title: Project Organisation
parent: Management
nav_order: 7
---

# Projektmanagement-Konzept

**Projektstart:** 28. April (Kickoff)

## Arbeitszyklus

Der Arbeitsprozess folgt einem zweiwöchigen Rhythmus:

**Woche 1:** Kick-off, Sprint-Planung und autonome Entwicklung
- Festlegung der Prioritäten für den aktuellen Zyklus
- Dezentralisierte Teamarbeit
- Asynchrone Statusmitteilungen

**Woche 2:** Demo, Feedback und Planung des nächsten Zyklus
- Präsentation der fertiggestellten Funktionen vor dem Kunden
- Sammlung von Feedback
- Retrospektive und Priorisierung für den nächsten Zyklus

## Kommunikationswege

### WhatsApp
**Verwendung:** Asynchrone Statusmitteilungen und Blocker-Handling
- Wöchentliche Statusmitteilung der Teamm­itglieder (Fertigstellung, aktuelle Aufgabe, Hindernis­se)
- Schnelle Eskalation bei Blockern, die die nächste Demo gefährden

### Discord
**Verwendung:** Echtzeit-Teamkommunikation und technische Zusammenarbeit
- Co-Programming-Sessions mit Bildschirm­freigabe
- Gruppengespräche für kritische Probleme oder dringende Entscheidungen
- Asynchrone Nachrichten für schnelle Klärungen

### GitHub Projects
**Verwendung:** Zentrale Arbeitsverfolgung und Aufgabenverwaltung
- Einzige Wahrheitsquelle für den Projektfortschritt
- Sichtbarkeit des aktuellen Sprints und anstehender Aufgaben
- Automatische Verfolgung von Blockern
- Keine täglichen Standups erforderlich

### GitHub Pages
**Verwendung:** Öffentliche Dokumentation und Feedback-Archiv
- Projektbeschreibung und aktuelle Features
- Archivierung von Client-Feedback aus jeder Demo
- Technische Dokumentation und Richtlinien

## Dienstagstrukturen (In-Präsenz)

Woche 1 ist immer die Woche ohne Kundenmeeting und Woche 2 ist dementsprechend die Woche in der wir mit Frau Dr. Siegeris sprechen.

### Sprint-Planung (Woche 1)
- Abstimmung über Prioritäten für den kommenden Zyklus
- Selbstorganisierte Aufgabenvergabe
- Klärung von Akzeptanzkriterien

### Demo und Feedback (Woche 2)
- Live-Demonstration der fertiggestellten Funktionen
- Direktes Feedback vom Kunden
- Erkennung von neuen Anforderungen

### Retrospektive (Woche 2)
- Analyse von Herausforderungen und deren Ursachen
- Verbesserungsvorschläge für den nächsten Zyklus

### Nächste Sprint-Planung (Woche 2)
- Priorisierung basierend auf Client-Feedback
- Selbständige Übernahme von Aufgaben durch Teamm­itglieder

## Qualitätssicherung

- Code-Reviews erfolgen asynchron in GitHub (vor dem Merge)
- Alle Funktionen müssen vor der Demo getestet und integriert sein
- Build-Fehler blockieren den Merge zu den Main-Branches
- Demo-Readiness wird vor Woche-2-Dienstag validiert

## Verantwortlichkeit

Jedes Teamm­itglied ist eigenverantwortlich für:
- Klare Verfolgung seiner zugewiesenen Aufgaben in GitHub Projects
- Zeitnahe Meldung von Blockern über WhatsApp
- Aktive Teilnahme bei asynchronen Code-Reviews
- Bereitschaft zur Zusammenarbeit über Discord bei kritischen Fragen

Die Verfolgung des Projektfortschritts erfolgt über GitHub Projects. Bei konsistenten Verzögerungen oder fehlender Kommunikation wird eine Absprache mit dem betroffenen Teamm­itglied geführt.

## Zielsetzung

Die Struktur minimiert Organisationsaufwand und Mikromanagement, während gleichzeitig:
- Klare Sichtbarkeit des Projektfortschritts für alle Stakeholder gewährleistet wird
- Regelmäßiges Client-Feedback in den Entwicklungsprozess fließt
- Autonome Teamarbeit unter strukturierten Rahmenbedingungen ermöglicht wird


> **2026, HWR Berlin** <br>
Last build: {{ site.time | date: '%d %b %Y, %H:%M' }}
