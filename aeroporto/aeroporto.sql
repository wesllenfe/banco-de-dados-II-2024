-- Verifica se o banco de dados existe e o remove
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'companhia_aerea')
BEGIN
    DROP DATABASE companhia_aerea;
END
GO

-- Cria o banco de dados
CREATE DATABASE companhia_aerea;
GO

-- Seleciona o banco de dados para uso
USE companhia_aerea;
GO

-- Cria a tabela cliente
CREATE TABLE cliente (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255),
    endereco VARCHAR(255),
    telefone VARCHAR(255),
    email VARCHAR(255),
    num_voos INT
);
GO

-- Cria a tabela aeronave
CREATE TABLE aeronave (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(255),
    poltronas INT,
    modelo VARCHAR(255)
);
GO

-- Cria a tabela aeroporto
CREATE TABLE aeroporto (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255),
    rua VARCHAR(255),
    numero INT,
    bairro VARCHAR(255),
    cidade VARCHAR(255),
    estado VARCHAR(255),
    pais VARCHAR(255)
);
GO

-- Cria a tabela voo
CREATE TABLE voo (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    id_aeronave INT NOT NULL,
    id_aeroporto_origem INT NOT NULL,
    id_aeroporto_destino INT NOT NULL,
    saida DATETIME,
    previsao_chegada DATETIME,
    CONSTRAINT fk_id_aeronave_voo FOREIGN KEY (id_aeronave) REFERENCES aeronave(id),
    CONSTRAINT fk_id_aeroporto_origem_voo FOREIGN KEY (id_aeroporto_origem) REFERENCES aeroporto(id),
    CONSTRAINT fk_id_aeroporto_destino_voo FOREIGN KEY (id_aeroporto_destino) REFERENCES aeroporto(id)
);
GO

-- Cria a tabela poltrona
CREATE TABLE poltrona (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    id_aeronave INT NOT NULL,
    disponivel BIT,
    localizacao VARCHAR(255),
    CONSTRAINT fk_id_aeronave_poltrona FOREIGN KEY (id_aeronave) REFERENCES aeronave(id)
);
GO

-- Cria a tabela passageiro
CREATE TABLE passageiro (
    id_cliente INT NOT NULL,
    id_voo INT NOT NULL,
    passagem INT,
    id_poltrona INT NOT NULL,
    CONSTRAINT pk_client_voo PRIMARY KEY (id_cliente, id_voo),
    CONSTRAINT fk_id_poltrona_passageiro FOREIGN KEY (id_poltrona) REFERENCES poltrona(id),
    CONSTRAINT fk_id_cliente_passageiro FOREIGN KEY (id_cliente) REFERENCES cliente(id),
    CONSTRAINT fk_id_voo_passageiro FOREIGN KEY (id_voo) REFERENCES voo(id)
);
GO

-- Cria a tabela horario
CREATE TABLE horario (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    id_voo INT NOT NULL,
    data DATE,
    inicio_horario TIME,
    final_horario TIME,
    CONSTRAINT fk_id_voo_horario FOREIGN KEY (id_voo) REFERENCES voo(id)
);
GO

-- Cria a tabela escala
CREATE TABLE escala (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    id_voo INT NOT NULL,
    id_aeroporto INT NOT NULL,
    saida DATETIME,
    CONSTRAINT fk_id_voo_escala FOREIGN KEY (id_voo) REFERENCES voo(id),
    CONSTRAINT fk_id_aeroporto_escala FOREIGN KEY (id_aeroporto) REFERENCES aeroporto(id)
);
GO
