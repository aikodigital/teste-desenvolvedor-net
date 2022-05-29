BEGIN;
CREATE TABLE olho_vivo.veiculo (
	id serial4 NOT NULL,
	nome varchar NOT NULL,
	modelo varchar NOT NULL,
	ativo bool NOT NULL,
	CONSTRAINT veiculo_pkey PRIMARY KEY (id)
);

ALTER TABLE olho_vivo.veiculo OWNER TO postgres;
GRANT ALL ON TABLE olho_vivo.veiculo TO postgres;
GRANT ALL ON TABLE olho_vivo.veiculo TO olho_vivo;

ALTER SEQUENCE olho_vivo.veiculo_id_seq OWNER TO postgres;
GRANT ALL ON SEQUENCE olho_vivo.veiculo_id_seq TO postgres;
GRANT SELECT, USAGE ON SEQUENCE olho_vivo.veiculo_id_seq TO olho_vivo;

INSERT INTO olho_vivo.veiculo
(nome, modelo, ativo)
VALUES('7745', 'Volvo', true);

INSERT INTO olho_vivo.veiculo
(nome, modelo, ativo)
VALUES('4351', 'Mercedes-Benz', true);

INSERT INTO olho_vivo.veiculo
(nome, modelo, ativo)
VALUES('2123', 'VW', true);
COMMIT;

INSERT INTO olho_vivo.veiculo
(nome, modelo, ativo)
VALUES('8756', 'Buscar', true);

INSERT INTO olho_vivo.veiculo
(nome, modelo, ativo)
VALUES('1213', 'Mercedes-Benz', true);
COMMIT;