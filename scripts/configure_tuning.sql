-- Adjust work memory for complex queries
ALTER SYSTEM SET work_mem = '64MB';

-- Increase maintenance memory for faster index creation
ALTER SYSTEM SET maintenance_work_mem = '128MB';

-- Optimize cache size for efficient data retrieval
ALTER SYSTEM SET effective_cache_size = '2GB';

-- Reload configuration to apply changes
SELECT pg_reload_conf();
