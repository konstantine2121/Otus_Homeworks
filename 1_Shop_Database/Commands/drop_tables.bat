SET PGCLIENTENCODING=utf-8
set PGPASSWORD=postgres
psql -h localhost -p 5432 -U postgres -f ..\Scripts\drop_tables.sql

pause