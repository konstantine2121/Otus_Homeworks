SET PGCLIENTENCODING=utf-8
set PGPASSWORD=postgres
psql -h localhost -p 5432 -U postgres -f ..\Scripts\create_tables.sql

pause