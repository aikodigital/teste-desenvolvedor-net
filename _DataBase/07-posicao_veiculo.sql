BEGIN;
CREATE TABLE olho_vivo.posicao_veiculo (
	id serial4 NOT NULL,
	id_veiculo int NOT NULL,
	latitude float NOT NULL,
	longitude float NOT NULL,
	data_posicao timestamp NOT NULL,
	CONSTRAINT posicao_veiculo_pkey PRIMARY KEY (id)
);

ALTER TABLE olho_vivo.posicao_veiculo ADD CONSTRAINT posicao_veiculo_fk_veiculo FOREIGN KEY (id_veiculo) REFERENCES olho_vivo.veiculo(id);

ALTER TABLE olho_vivo.posicao_veiculo OWNER TO postgres;
GRANT ALL ON TABLE olho_vivo.posicao_veiculo TO postgres;
GRANT ALL ON TABLE olho_vivo.posicao_veiculo TO olho_vivo;

ALTER SEQUENCE olho_vivo.posicao_veiculo_id_seq OWNER TO postgres;
GRANT ALL ON SEQUENCE olho_vivo.posicao_veiculo_id_seq TO postgres;
GRANT SELECT, USAGE ON SEQUENCE olho_vivo.posicao_veiculo_id_seq TO olho_vivo;
COMMIT;