create table Entregador(
Id int primary key,
Nome varchar not null,
Cnpj varchar not null,
DataNasc date,
NumeroCnh varchar not null,
TipoCnh varchar,
FotoCnh varchar
);

create table Moto(
Id int primary key,
Ano varchar not null,
Modelo varchar not null,
Placa varchar not null
);

create table Locacao(
Id int primary key,
EntregadorId int REFERENCES Entregador(Id),
MotoId int REFERENCES Moto(Id),
ValorDiaria int,
DataInicio date,
DataPrevisaoTermino date,
DataTermino date,
DataDevolucao date,
Plano int
);