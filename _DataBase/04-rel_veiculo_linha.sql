BEGIN;
CREATE TABLE olho_vivo.rel_veiculo_linha (
	id serial4 NOT NULL,
	id_veiculo int NOT NULL,
	id_linha int NOT NULL,
	data_inicio timestamp NOT NULL,
	data_fim timestamp NOT NULL,
	CONSTRAINT rel_veiculo_linha_pkey PRIMARY KEY (id)
);

ALTER TABLE olho_vivo.rel_veiculo_linha ADD CONSTRAINT rel_veiculo_linha_fk_veiculo FOREIGN KEY (id_veiculo) REFERENCES olho_vivo.veiculo(id);
ALTER TABLE olho_vivo.rel_veiculo_linha ADD CONSTRAINT rel_veiculo_linha_fk_linha FOREIGN KEY (id_linha) REFERENCES olho_vivo.linha(id);

ALTER TABLE olho_vivo.rel_veiculo_linha OWNER TO postgres;
GRANT ALL ON TABLE olho_vivo.rel_veiculo_linha TO postgres;
GRANT ALL ON TABLE olho_vivo.rel_veiculo_linha TO olho_vivo;

ALTER SEQUENCE olho_vivo.rel_veiculo_linha_id_seq OWNER TO postgres;
GRANT ALL ON SEQUENCE olho_vivo.rel_veiculo_linha_id_seq TO postgres;
GRANT SELECT, USAGE ON SEQUENCE olho_vivo.rel_veiculo_linha_id_seq TO olho_vivo;

INSERT INTO olho_vivo.rel_veiculo_linha
(id_veiculo, id_linha, data_inicio, data_fim)
VALUES(1, 1, '2022-05-20 05:00:00', '2022-05-20 23:00:00');

INSERT INTO olho_vivo.rel_veiculo_linha
(id_veiculo, id_linha, data_inicio, data_fim)
VALUES(2, 1, '2022-05-20 05:00:00', '2022-05-20 23:00:00');

INSERT INTO olho_vivo.rel_veiculo_linha
(id_veiculo, id_linha, data_inicio, data_fim)
VALUES(3, 2, '2022-05-20 05:00:00', '2022-05-20 23:00:00');

INSERT INTO olho_vivo.rel_veiculo_linha
(id_veiculo, id_linha, data_inicio, data_fim)
VALUES(4, 3, '2022-05-20 05:00:00', '2022-05-20 23:00:00');

INSERT INTO olho_vivo.rel_veiculo_linha
(id_veiculo, id_linha, data_inicio, data_fim)
VALUES(5, 3, '2022-05-20 05:00:00', '2022-05-20 23:00:00');
COMMIT;