BEGIN;
CREATE TABLE olho_vivo.linha (
	id serial4 NOT NULL,
	nome varchar NOT NULL,
	ativo bool NOT NULL,
	CONSTRAINT linha_pkey PRIMARY KEY (id)
);

ALTER TABLE olho_vivo.linha OWNER TO postgres;
GRANT ALL ON TABLE olho_vivo.linha TO postgres;
GRANT ALL ON TABLE olho_vivo.linha TO olho_vivo;

ALTER SEQUENCE olho_vivo.linha_id_seq OWNER TO postgres;
GRANT ALL ON SEQUENCE olho_vivo.linha_id_seq TO postgres;
GRANT SELECT, USAGE ON SEQUENCE olho_vivo.linha_id_seq TO olho_vivo;


INSERT INTO olho_vivo.linha
(nome, ativo)
VALUES('Linha 1', true);

INSERT INTO olho_vivo.linha
(nome, ativo)
VALUES('Linha 2', true);

INSERT INTO olho_vivo.linha
(nome, ativo)
VALUES('Linha 3', true);
COMMIT;