# PostgreSQL Database Setup and Execution Guide

This guide explains how to set up and execute the scripts to create the schema, seed the database, and analyze queries for the project.

## Prerequisites

Ensure you have the following installed and configured:

1. **PostgreSQL**
    - Download and install PostgreSQL.

2. **Database User**
    - Create a user with sufficient privileges to create schemas and execute scripts.

3. **Clone Project**
    - Clone or download the repository https://github.com/Csejrup/db-exam-tuning.git

## Step-by-Step Execution

Follow the steps below to execute the SQL scripts in order:

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

### 5. Execute Security Script

Set up database roles and permissions:
```bash
psql -U <username> -d project_db -f scripts/security.sql
```

### 6. Execute Trigger Script

Set up triggers for automatic updates:
```bash
psql -U <username> -d project_db -f scripts/triggers.sql
```

### 7. Analyze Queries

Run the analysis queries to measure performance and verify optimizations:
```bash
psql -U <username> -d project_db -f scripts/analyze_queries.sql
```

## Example Outputs

- **Query Plans**: After running `analyze_queries.sql`, you will see query execution plans for each query.
- **Performance Metrics**: Look for improvements in execution time after applying indexes and triggers.

## Cleanup

If you want to clean up the database:
```bash
psql -U <username> -c "DROP DATABASE project_db;"
```
