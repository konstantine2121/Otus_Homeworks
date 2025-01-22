CREATE EXTENSION IF NOT EXISTS pgcrypto;

DROP TABLE IF EXISTS temp_ids;

CREATE TABLE temp_ids
(
id                  UUID             PRIMARY KEY NOT NULL
);

INSERT INTO temp_ids (id) 
VALUES 
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid()),
(gen_random_uuid());

SELECT * FROM temp_ids;