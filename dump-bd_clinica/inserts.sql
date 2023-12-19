insert into medico (codigo, nome, especialidade, salario) values ("123654", "Medico 1", "Esp 1", 5000.00);
insert into medico (codigo, nome, especialidade, salario) values ("321456", "Medico 2", "Esp 2", 7599.15);

insert into paciente (cpf, nome, endereco, telefone) values ("123.456.789-01", "Paciente 1", "Rua Qualquer, Bairro Algum - N° Tal", "+5573912345678");
insert into paciente (cpf, nome, endereco, telefone) values ("123.456.789-02", "Paciente 2", "Rua Qualquer, Bairro Algum - N° Outro", "+5573912345876");

insert into consulta (data_consulta, valor, id_medico, id_paciente) values (NOW(), 0, 1, 2);
insert into consulta (data_consulta, valor, id_medico, id_paciente) values (NOW(), 0, 2, 2);
insert into consulta (data_consulta, valor, id_medico, id_paciente) values ('2023-12-19 17:09:00', 0, 2, 2);

insert into exame (codigo, nome, tipo, preco) values ("123", "Exame 1", "Tipo 1", 399.99);
insert into exame (codigo, nome, tipo, preco) values ("321", "Exame 2", "Tipo 2", 500.00);

insert into exame_consulta (id_consulta, id_exame) values (1, 1);
insert into exame_consulta (id_consulta, id_exame) values (1, 2);
insert into exame_consulta (id_consulta, id_exame) values (2, 1);