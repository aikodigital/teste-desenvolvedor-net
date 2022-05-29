BEGIN;
CREATE TABLE olho_vivo.rel_linha_parada (
	id serial4 NOT NULL,
	id_linha int NOT NULL,
	id_parada int NOT NULL,
	CONSTRAINT rel_linha_parada_pkey PRIMARY KEY (id)
);

ALTER TABLE olho_vivo.rel_linha_parada ADD CONSTRAINT rel_linha_parada_fk_linha FOREIGN KEY (id_linha) REFERENCES olho_vivo.linha(id);
ALTER TABLE olho_vivo.rel_linha_parada ADD CONSTRAINT rel_linha_parada_fk_parada FOREIGN KEY (id_parada) REFERENCES olho_vivo.parada(id);

ALTER TABLE olho_vivo.rel_linha_parada OWNER TO postgres;
GRANT ALL ON TABLE olho_vivo.rel_linha_parada TO postgres;
GRANT ALL ON TABLE olho_vivo.rel_linha_parada TO olho_vivo;

ALTER SEQUENCE olho_vivo.rel_linha_parada_id_seq OWNER TO postgres;
GRANT ALL ON SEQUENCE olho_vivo.rel_linha_parada_id_seq TO postgres;
GRANT SELECT, USAGE ON SEQUENCE olho_vivo.rel_linha_parada_id_seq TO olho_vivo;

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(1, 1);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(1, 2);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(1, 3);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(1, 4);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(1, 5);


INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(2, 1);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(2, 4);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(2, 6);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(2, 7);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(2, 8);


INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(3, 4);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(3, 6);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(3, 9);

INSERT INTO olho_vivo.rel_linha_parada
(id_linha, id_parada)
VALUES(3, 10);
COMMIT;