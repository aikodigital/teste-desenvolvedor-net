BEGIN;
CREATE TABLE olho_vivo.parada (
	id serial4 NOT NULL,
	nome varchar NOT NULL,
	latitude float NOT NULL,
	longitude float NOT NULL,
	ativo bool NOT NULL,
	CONSTRAINT parada_pkey PRIMARY KEY (id)
);

ALTER TABLE olho_vivo.parada OWNER TO postgres;
GRANT ALL ON TABLE olho_vivo.parada TO postgres;
GRANT ALL ON TABLE olho_vivo.parada TO olho_vivo;

ALTER SEQUENCE olho_vivo.parada_id_seq OWNER TO postgres;
GRANT ALL ON SEQUENCE olho_vivo.parada_id_seq TO postgres;
GRANT SELECT, USAGE ON SEQUENCE olho_vivo.parada_id_seq TO olho_vivo;


INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 1', -45.009879848010776, -21.226306477717028, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 2', -45.006785563535765, -21.22734357897103, true); 

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 3', -45.0094599118835, -21.227274251577256, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 4', -45.006112145485815, -21.22967116351771, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 5', -45.00855992130528, -21.232794609597434, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 6', -45.01087632618592, -21.234389231653555, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 7', -45.003891757666025, -21.23187806056546, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 8', -45.00458591066748, -21.234015573458084, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 9', -45.00514319467151, -21.236768496353935, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 10', -45.00608941875548, -21.238403276983018, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 11', -45.00621783486932, -21.239449023071245, true);

INSERT INTO olho_vivo.parada
(nome, longitude, latitude, ativo)
VALUES('Parada 12', -45.00373061750663, -21.239896297747624, true);
COMMIT;