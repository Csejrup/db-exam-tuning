
# PostgreSQL Database Setup and Execution Guide

This guide explains how to set up and execute the scripts to create the schema, seed the database, and analyze queries for the project, along with instructions for automating database management using EF Core migrations.

## Prerequisites

Ensure you have the following installed and configured:

1. **PostgreSQL**
   - Download and install PostgreSQL.

2**.NET SDK**
   - Install the .NET SDK to run the application and use EF migrations.

3**Clone Project**
   - Clone or download the repository:
     ```bash
     git clone https://github.com/Csejrup/db-exam-tuning.git
     cd db-exam-tuning
     ```

## Step-by-Step Execution

Follow the steps below to execute the SQL scripts or automate the database setup using EF Core migrations:

### 1. Create Database

Create a new database for the project:
```bash
psql -U <username> -c "CREATE DATABASE project_db;"
```
Replace `<username>` with your PostgreSQL username.

### 2. Execute Schema Script

Create the database schema by running:
```bash
psql -U <username> -d project_db -f scripts/create_schema.sql
```

### 3. Seed the Database

Insert sample data into the database:
```bash
psql -U <username> -d project_db -f scripts/seed_data.sql
```

### 4. Add Indexes

Optimize queries by adding indexes:
```bash
psql -U <username> -d project_db -f scripts/add_indexes.sql
```
### 5. Configuration Tuning

Configurate the Databse:
```bash
psql -U <username> -d project_db -f scripts/configure_tuning.sql
```

### 6. Execute Security Script

Set up database roles and permissions:
```bash
psql -U <username> -d project_db -f scripts/security.sql
```

### 7. Execute Trigger Script

Set up triggers for automatic updates:
```bash
psql -U <username> -d project_db -f scripts/triggers.sql
```

### 8. Analyze Queries

Run the analysis queries to measure performance and verify optimizations:
```bash
psql -U <username> -d project_db -f scripts/analyze_queries.sql
```

### 9. Automating Database Setup Using EF Migrations

EF Core migrations can be used to automate database schema creation and updates.

#### Step 0.1: Apply Initial Migrations
Navigate to the project directory and run:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Step 9.2: Add Future Schema Changes
To apply schema updates:
1. Modify the models or `AppDbContext` in the codebase.
2. Add a new migration:
   ```bash
   dotnet ef migrations add <MigrationName>
   ```
3. Update the database:
   ```bash
   dotnet ef database update
   ```
## Example Outputs

- **Query Plans**: After running `analyze_queries.sql`, you will see query execution plans for each query.
- **Performance Metrics**: Look for improvements in execution time after applying indexes and triggers.

---

## Cleanup

If you want to clean up the database:
```bash
psql -U <username> -c "DROP DATABASE project_db;"
```

---
