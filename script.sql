/*Banco de Dados*/
CREATE DATABASE atividade;

/*Tabela Clientes*/
CREATE TABLE clientes(
codigo int(4) AUTO_INCREMENT,
nome varchar(30) NOT NULL,
endereco varchar(50),

cidade varchar(50),

PRIMARY KEY (codigo)

);

/*Tabela Cidades*/
CREATE TABLE cidades(

codigo int(4) AUTO_INCREMENT,

nome varchar(30) NOT NULL,

estado varchar(50),

UF varchar(2),

PRIMARY KEY (codigo)

);

/*Tabela Estado*/
CREATE TABLE estado(

codigo int(4) AUTO_INCREMENT,

nome varchar(30) NOT NULL,

UF varchar(2),

PRIMARY KEY (codigo)

);
