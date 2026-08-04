Here is a comprehensive breakdown of the system architecture, database schema, and UI design we have locked in so far. This is structured so you can drop it directly into a team update or project documentation.

## System Architecture & Tech Stack

* **Application Type:** Windows Desktop Application
* **Framework:** C# with WPF (Windows Presentation Foundation)
* **Design Pattern:** Strict MVVM (Model-View-ViewModel) to separate UI from business logic
* **Database Backend:** SQL Server (Relational Database)

## Core Application Features

* **Role-Based Access Control (RBAC):** Strict permission separation between Cashiers (POS access only) and Managers/Admins (Inventory, Employees, Reports).
* **Optimized POS Terminal:** Touch-friendly interface with large buttons for fast-moving items, plus USB barcode scanner integration for zero-touch product entry.
* **Workshop Employee Tab System:** Dedicated tracking for staff buying on credit, featuring hard credit limits to prevent overspending and monthly CSV payroll exports for automatic wage deductions.
* **Automated Alerting:** Dashboard widgets that automatically display low-stock warnings when inventory drops below predefined thresholds.
* **Audit Logging:** Silent backend tracking of manual inventory adjustments (logging the UserID, timestamp, and quantity) to prevent and investigate shrinkage.

## Database Schema Decisions

We opted for a highly normalized 6-table structure (`SystemUsers`, `WorkshopEmployees`, `Products`, `InventoryLogs`, `SalesHeader`, `SaleItems`).

**Key Technical Decision: Branded Receipt Numbers**
Instead of using slow, error-prone string primary keys to generate the requested `kzn_` receipt numbers, we are utilizing a high-performance **Computed Column**.

* The database uses a standard, lightning-fast `SaleID` (Integer Identity) for relationships.
* SQL automatically concatenates the prefix via `ReceiptNumber AS ('kzn_' + CAST(SaleID AS VARCHAR)) PERSISTED`.
* This provides a bespoke brand experience for the UI/receipts while maintaining enterprise-grade database performance.

## Visual Design & UI Layout

* **Aesthetic Theme:** Premium, modern, and clean. The color palette relies on crisp whites/light grays paired with **petrol blue** accents to bridge the gap between a modern cafe and a high-end automotive workspace.
* **Layout Structure:** A split-screen Grid structure.
* *Left Column:* A fixed, dark petrol blue `StackPanel` sidebar containing the main navigation icons (POS, Inventory, Employees, Reports).
* *Right Column:* A dynamic `ContentControl` workspace (white/light gray) that swaps out views based on sidebar clicks.


* **UI Libraries:** The project will leverage external WPF UI packages (like `MaterialDesignInXAML` or `MahApps.Metro`) to replace standard Windows borders with modern drop shadows, rounded corners, and flat styling.