INSERT INTO cliente (nome, endereco, telefone, email, num_voos)
VALUES
('João Silva', 'Rua das Flores, 123', '11987654321', 'joao.silva@example.com', 5),
('Maria Oliveira', 'Avenida Brasil, 456', '21987654321', 'maria.oliveira@example.com', 3),
('Carlos Souza', 'Rua dos Pinheiros, 789', '31987654321', 'carlos.souza@example.com', 2);

INSERT INTO aeronave (tipo, poltronas, modelo)
VALUES
('Comercial', 180, 'Boeing 737'),
('Executivo', 50, 'Gulfstream G650'),
('Comercial', 300, 'Airbus A330');

INSERT INTO aeroporto (nome, rua, numero, bairro, cidade, estado, pais)
VALUES
('Aeroporto Internacional de Guarulhos', 'Rodovia Hélio Smidt', 1, 'Cumbica', 'Guarulhos', 'SP', 'Brasil'),
('Aeroporto Santos Dumont', 'Praça Senador Salgado Filho', 0, 'Centro', 'Rio de Janeiro', 'RJ', 'Brasil'),
('Aeroporto Internacional de Brasília', 'Epia Sul', 1, 'Lago Sul', 'Brasília', 'DF', 'Brasil');

INSERT INTO voo (id_aeronave, id_aeroporto_origem, id_aeroporto_destino, saida, previsao_chegada)
VALUES
(1, 1, 2, '2024-12-01 08:00:00', '2024-12-01 10:00:00'),
(2, 2, 3, '2024-12-01 12:00:00', '2024-12-01 14:30:00'),
(3, 3, 1, '2024-12-01 16:00:00', '2024-12-01 19:00:00');

INSERT INTO poltrona (id_aeronave, disponivel, localizacao)
VALUES
(1, 1, 'A1'),
(1, 1, 'A2'),
(1, 0, 'B1'),
(2, 1, 'E1'),
(2, 1, 'E2'),
(3, 1, 'F1'),
(3, 0, 'F2');

-- Popula a tabela passageiro
INSERT INTO passageiro (id_cliente, id_voo, passagem, id_poltrona)
VALUES
(1, 1, 101, 1),
(2, 2, 102, 4),
(3, 3, 103, 6);

INSERT INTO horario (id_voo, data, inicio_horario, final_horario)
VALUES
(1, '2024-12-01', '08:00:00', '10:00:00'),
(2, '2024-12-01', '12:00:00', '14:30:00'),
(3, '2024-12-01', '16:00:00', '19:00:00');

INSERT INTO escala (id_voo, id_aeroporto, saida)
VALUES
(1, 3, '2024-12-01 09:00:00'),
(2, 1, '2024-12-01 13:00:00'),
(3, 2, '2024-12-01 18:00:00');
