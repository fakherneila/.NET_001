<div align="center">

# TP1 — C# : Basic Syntax

**Technology Environment (.net)**


</div>

---

## Table of Contents

- [TP1 — C# : Basic Syntax](#tp1--c--basic-syntax)
  - [Table of Contents](#table-of-contents)
  - [Objective](#objective)
  - [Prerequisites](#prerequisites)
  - [Project Structure](#project-structure)
  - [Exercise 1 — Network Connection Analysis](#exercise-1--network-connection-analysis)
    - [Modeling](#modeling)
    - [Required Operations](#required-operations)
    - [LINQ Operators Used](#linq-operators-used)
  - [Exercise 2 — Store Inventory Management](#exercise-2--store-inventory-management)
    - [Interfaces](#interfaces)
    - [Class Hierarchy](#class-hierarchy)
      - [`Article` — Abstract Class](#article--abstract-class)
      - [`Electromenager`](#electromenager)
      - [`Primeur`](#primeur)
      - [`Magasin`](#magasin)
    - [Progressive Refactoring](#progressive-refactoring)
  - [Build and Run](#build-and-run)
  - [Expected Results](#expected-results)
    - [Exercise 1](#exercise-1)
    - [Exercise 2](#exercise-2)
  - [C# Concepts Covered](#c-concepts-covered)

---

## Objective

> This TP explores two complementary facets of modern C#: **querying data with LINQ** and **object-oriented modeling with interfaces**.

| Part | Theme | Skills |
|:----:|:------|:-------|
| **Exercise 1** | Network log analysis | Filtering, sorting, aggregation, anomaly detection with LINQ |
| **Exercise 2** | Store inventory | Abstract classes, inheritance, interfaces, polymorphism |

---

## Prerequisites

| Tool | Minimum version | Check |
|:-----|:---------------:|:------|
| .NET SDK | `10.0.x` | `dotnet --version` |
| VS Code | recent | with **C# Dev Kit** extension |
| Terminal | — | zsh, bash, or equivalent |

---

## Project Structure

```
Tp1/
├── Tp1.sln
├── Tp1.csproj
├── Program.cs
├── Exercice1/
│   └── Connexion.cs
└── Exercice2/
    ├── Interfaces.cs
    ├── Article.cs
    ├── Electromenager.cs
    ├── Primeur.cs
    └── Magasin.cs
```

| File | Role |
|:-----|:-----|
| `Program.cs` | Entry point — instantiates data and runs queries |
| `Exercice1/Connexion.cs` | Data model for network analysis |
| `Exercice2/Interfaces.cs` | Contracts: `IVendableKg`, `IVendablePiece`, `ISolde`, `IDescriptible`, `IRendement` |
| `Exercice2/Article.cs` | Abstract base class |
| `Exercice2/Electromenager.cs` | Item sold by piece, eligible for discounts |
| `Exercice2/Primeur.cs` | Item sold by kilogram |
| `Exercice2/Magasin.cs` | Aggregates items and computes yields |

---

## Exercise 1 — Network Connection Analysis

### Modeling

The `Connexion` class represents a network log entry:

| Property | Type | Description |
|:---------|:----:|:------------|
| `Id` | `int` | Unique identifier |
| `AdresseIP` | `string` | Source IP address |
| `Protocole` | `string` | TCP or UDP |
| `Port` | `int` | Destination port |
| `Pays` | `string` | Country of origin |
| `Duree` | `double` | Duration in seconds |
| `EstSuspecte` | `bool` | Suspicion flag |

### Required Operations

**Filtering** — Conditional selection by protocol, port, country, duration, or status.

**Projection** — Extraction of a reduced view: only `AdresseIP` and `Port`.

**Sorting** — Ascending and descending by duration, then multi-criteria (country + duration).

**Aggregation** — Count, average, maximum, minimum over the collection.

**Grouping** — Classification by protocol.

**Verification** — Existence of a suspicious connection, a port 23, or compliance with a threshold.

**Anomaly Detection** — Application of the dangerousness criterion:

> A connection is **potentially dangerous** if it uses port 22, **or** if its duration exceeds 60 seconds, **or** if it is already flagged as suspicious.

### LINQ Operators Used

| Operator | Category | Purpose |
|:---------|:--------:|:--------|
| `Where` | Filtering | Keep elements matching a predicate |
| `Select` | Projection | Transform each element |
| `OrderBy` / `OrderByDescending` | Sorting | Sort by a key |
| `ThenByDescending` | Sorting | Secondary sort |
| `Count` / `Average` / `Max` / `Min` | Aggregation | Statistics |
| `GroupBy` | Grouping | Partition the collection |
| `Any` / `All` | Verification | Existential / universal predicates |

> Lambda expressions (`c => c.Protocole == "TCP"`) act as **predicates** passed to LINQ operators.

---

## Exercise 2 — Store Inventory Management

### Interfaces

| Interface | Methods | Role |
|:----------|:--------|:-----|
| `IVendableKg` | `double Vendre(double quantiteKg)` | Items sold by kilogram |
| `IVendablePiece` | `double Vendre(int quantite)` | Items sold by piece |
| `ISolde` | `LancerSolde(double)`, `TerminerSolde(double)` | Items eligible for discounts |
| `IDescriptible` | `void Decrire()` | Classes able to describe themselves |
| `IRendement` | `double CalculerRendement()` | Classes able to compute a yield |

### Class Hierarchy

```
           Article (abstract)
           /              \
    Electromenager      Primeur
    + IVendablePiece    + IVendableKg
    + ISolde
```

#### `Article` — Abstract Class

> **Not instantiable.** Serves as a common template for all store items.

- **Properties**: `PrixAchat`, `PrixVente`, `Nom`, `Fournisseur`
- **Methods**: `CalculerRendement()`, `Decrire()`
- **Interfaces**: none — as specified in the initial TP statement

#### `Electromenager`

- **Inherits from**: `Article`
- **Property**: `NombrePieces`
- **Methods**: `RemplirStock(int)`, `Vendre(int)`, `Decrire()`
- **Implements**: `IVendablePiece`, `ISolde`

#### `Primeur`

- **Inherits from**: `Article`
- **Property**: `QuantiteStock` (kg)
- **Methods**: `RemplirStock(double)`, `Vendre(double)`, `Decrire()`
- **Implements**: `IVendableKg`
- **Constraint**: cannot be put on sale

#### `Magasin`

- **Properties**: `Depenses`, `Revenus`, item lists
- **Methods**: `AjouterElectromenager`, `AjouterPrimeur`, `VendreElectromenager`, `VendrePrimeur`, `Decrire()`, `CalculerRendement()`

### Progressive Refactoring

The TP follows a realistic two-step approach:

1. **Initial build** — Code the classes without interfaces, then write the `Main` that simulates the store.
2. **Extracting abstractions** — Identify shared behaviors and formalize them via `IDescriptible` and `IRendement`.

> This progression illustrates a truth of software engineering: **good abstractions emerge from code, they cannot be guessed upfront.**

---

## Build and Run

From the `Tp1` folder:

```bash
dotnet build      # Compile
dotnet run        # Compile + run
```

---

## Expected Results

### Exercise 1

| Metric | Value |
|:-------|:-----:|
| Total connections | **8** |
| Suspicious connections | **2** (Id 4, 6) |
| TCP connections | **5** |
| UDP connections | **3** |
| Average duration | **35.74 s** |
| Longest connection | Id **6** (91.7 s) |
| Shortest connection | Id **3** (5.8 s) |
| Dangerous connections | Id **4** and **6** |

### Exercise 2

| Metric | Value |
|:-------|:-----:|
| Expenses | **801** |
| Revenue | **2438.75** |
| Fridge yield | **50 %** |
| Tomato yield | **150 %** |

---

## C# Concepts Covered

| Concept | Illustration in the TP |
|:--------|:-----------------------|
| Auto-implemented properties | `public int Id { get; set; }` |
| Object initializers | `new Connexion { Id = 1, ... }` |
| Generic collections | `List<Connexion>` |
| LINQ (fluent syntax) | `connexions.Where(...).OrderBy(...)` |
| Lambda expressions | `c => c.Port == 22` |
| Anonymous types | `new { c.AdresseIP, c.Port }` |
| Abstract classes | `abstract class Article` |
| Virtual methods | `public virtual void Decrire()` |
| Inheritance | `class Primeur : Article` |
| Polymorphism | Usage via `IDescriptible` |
| Interfaces | `IVendableKg`, `IRendement`, ... |
| Namespaces | `namespace Tp1.Exercice1` |

---

<div align="center">

**Note**

This TP provides a foundation for understanding modern C# syntax and the LINQ library.
Abstraction and interface concepts are introduced progressively
to demonstrate their practical value in a realistic context.

</div>