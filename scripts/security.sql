-- Create read-only role
CREATE ROLE read_only_user WITH LOGIN PASSWORD 'readonlypassword';
GRANT CONNECT ON DATABASE your_database TO read_only_user;
GRANT SELECT ON ALL TABLES IN SCHEMA public TO read_only_user;

-- Create admin role
CREATE ROLE admin_user WITH LOGIN PASSWORD 'adminpassword';
GRANT ALL PRIVILEGES ON DATABASE your_database TO admin_user;

-- Revoke default privileges for public
REVOKE ALL ON ALL TABLES IN SCHEMA public FROM PUBLIC;
