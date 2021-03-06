use bd_asofacil
  
  go
  INSERT INTO TIPOSUSUARIOS(ID, CODIGO, DESCRICAO, MENUSISTEMA) VALUES('8fabf23d-28bf-4494-afd5-6d59bada7e86', 'ASOFACIL_ADMIN', 'Administrador do AsoFacil', 'Empresas;Usuários;Candidatos;Médicos;Cargos;Agendamentos;Documentos;Tipos de Usuários;Status de Agendamento;Status de Solicitação de Ativação');
  go
  INSERT INTO TIPOSUSUARIOS(ID, CODIGO, DESCRICAO, MENUSISTEMA) VALUES('da4b6ce5-b5b3-4142-b854-31122319e132', 'EMPRESA_ADMIN', 'Administrador da Empresa', 'Empresas;Usuários;Candidatos;Cargos;Agendamentos');
  go
  INSERT INTO TIPOSUSUARIOS(ID, CODIGO, DESCRICAO, MENUSISTEMA) VALUES('638f8f4b-1cc0-4960-8b6c-8f2ed9d95742', 'EMPRESA_OPR', 'Operador da Empresa', 'Candidatos;Cargos;Agendamentos');
  go
  INSERT INTO TIPOSUSUARIOS(ID, CODIGO, DESCRICAO, MENUSISTEMA) VALUES('59b1f553-59b9-40e0-9474-ab25867413b1', 'CLINICA_ADMIN', 'Administrador da Clínica', 'Empresas;Usuários;Candidatos;Médicos;Agendamentos');
  go
  INSERT INTO TIPOSUSUARIOS(ID, CODIGO, DESCRICAO, MENUSISTEMA) VALUES('29b38b23-b303-4df1-999d-cb2a2b1b9573', 'CLINICA_OPR', 'Operador da Clínica', 'Candidatos;Agendamentos');
  go
  INSERT INTO TIPOSUSUARIOS(ID, CODIGO, DESCRICAO, MENUSISTEMA) VALUES('19624fb7-2bc5-480d-959a-e5cab5bf347b', 'CLINICA_MED', 'Médico da Clínica', 'Agendamentos;Documentos');
  go
  
  -- SELECT * FROM StatusSolicitacoesAtivacaoEmpresas
  
  --ALTER TABLE StatusSolicitacoesAtivacaoEmpresas
  --ADD Codigo varchar(255);
  
  insert into StatusSolicitacoesAtivacaoEmpresas(Id, Descricao, Codigo) values ('30da482e-b3be-468c-a52e-1bae79ce7d09', 'Solicitada', 'SOLICITADA');
  go
  insert into StatusSolicitacoesAtivacaoEmpresas(Id, Descricao, Codigo) values ('b90c84e9-48a8-40bf-99af-5de42193a78e', 'Em análise', 'EM_ANALISE');
  go
  insert into StatusSolicitacoesAtivacaoEmpresas(Id, Descricao, Codigo) values ('bfe2640c-781e-4d40-a5ab-853dee8782a2', 'Aprovada', 'APROVADA');
  go
  insert into StatusSolicitacoesAtivacaoEmpresas(Id, Descricao, Codigo) values ('4e0b2486-48ca-4133-845c-67fe3e8f52aa', 'Reprovada', 'REPROVADA');
  go
  
  -- alter table Empresas add FlagClinica bit not null default 0;
  
  -- Disable the constraints on a table called tableName:
  ALTER TABLE Empresas NOCHECK CONSTRAINT ALL
  ALTER TABLE SolicitacoesAtivacaoEmpresas NOCHECK CONSTRAINT ALL
  
  --SELECT * FROM Empresas
  INSERT INTO EMPRESAS(ID, CNPJ, RazaoSocial, Email, Ativa, SolicitacaoAtivacaoEmpresaId, FlagClinica)
  VALUES('b882df84-09dd-4e90-a4ca-6b3a79351e60', '77423044000159', 'AsoFácil', 'suporte@asofacil.com.br', 1, 'b882df84-09dd-4e90-a4ca-6b3a79351e60', 0);
  go
  INSERT INTO EMPRESAS(ID, CNPJ, RazaoSocial, Email, Ativa, SolicitacaoAtivacaoEmpresaId, FlagClinica)
  VALUES('0ef5918b-8d58-49b5-a3db-5d2d1b435594', '43019009000157', 'Maxipas', 'contato@maxipas.com.br', 1, '8b98ef75-b6a8-4440-9271-0955deb82c25', 0);
  go
  INSERT INTO EMPRESAS(ID, CNPJ, RazaoSocial, Email, Ativa, SolicitacaoAtivacaoEmpresaId, FlagClinica)
  VALUES('881ddeef-a8fb-4435-a5d1-a288171bd530', '69161788000114', 'Dortprev', 'clinica@dortprev.com.br', 1, '7bd3c64d-91c7-473f-9176-595dca2230e7', 1);
  go
  
  --SELECT * FROM SolicitacoesAtivacaoEmpresas
  INSERT INTO SolicitacoesAtivacaoEmpresas(Id, EmpresaId, StatusSolicitacaoAtivacaoEmpresaId) 
  VALUES('b882df84-09dd-4e90-a4ca-6b3a79351e60', 'b882df84-09dd-4e90-a4ca-6b3a79351e60','bfe2640c-781e-4d40-a5ab-853dee8782a2');
  go
  INSERT INTO SolicitacoesAtivacaoEmpresas(Id, EmpresaId, StatusSolicitacaoAtivacaoEmpresaId) 
  VALUES('8b98ef75-b6a8-4440-9271-0955deb82c25', '0ef5918b-8d58-49b5-a3db-5d2d1b435594','bfe2640c-781e-4d40-a5ab-853dee8782a2');
  go
  INSERT INTO SolicitacoesAtivacaoEmpresas(Id, EmpresaId, StatusSolicitacaoAtivacaoEmpresaId) 
  VALUES('7bd3c64d-91c7-473f-9176-595dca2230e7', '881ddeef-a8fb-4435-a5d1-a288171bd530','bfe2640c-781e-4d40-a5ab-853dee8782a2');
  go
  
  -- Re-enable the constraints on a table called tableName:
  ALTER TABLE Empresas WITH CHECK CHECK CONSTRAINT ALL
  ALTER TABLE SolicitacoesAtivacaoEmpresas WITH CHECK CHECK CONSTRAINT ALL

  -- SELECT * FROM Usuarios
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('234f7e20-a703-46ad-97a0-7e8843067d65', 'marcelo.seabra@asofacil.com', 'abc123', '8fabf23d-28bf-4494-afd5-6d59bada7e86', 'b882df84-09dd-4e90-a4ca-6b3a79351e60'); --admin asofacil
  go
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('95c81897-0ccc-493e-a882-ef5ce4e265ef', 'denilson.lobo@asofacil.com', 'abc123', '8fabf23d-28bf-4494-afd5-6d59bada7e86', 'b882df84-09dd-4e90-a4ca-6b3a79351e60'); --admin asofacil
  go
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('f5c093a6-b343-4b51-bbb6-d08e25129295', 'adm@maxipas.com.br', 'abc123', 'da4b6ce5-b5b3-4142-b854-31122319e132', '0ef5918b-8d58-49b5-a3db-5d2d1b435594'); --admin empresa
  go
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('1bf3d7d2-64b2-4a58-b039-1fea2e9b378f', 'opr@maxipas.com.br', 'abc123', '638f8f4b-1cc0-4960-8b6c-8f2ed9d95742', '0ef5918b-8d58-49b5-a3db-5d2d1b435594'); --opr empresa
  go
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('45f24762-4a87-4e77-b7c5-03c65e5536f1', 'adm@dortprev.com.br', 'abc123', '59b1f553-59b9-40e0-9474-ab25867413b1', '881ddeef-a8fb-4435-a5d1-a288171bd530'); --admin clinica
  go
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('acb64374-2e56-4d87-8f64-39109c5a6067', 'opr@dortprev.com.br', 'abc123', '29b38b23-b303-4df1-999d-cb2a2b1b9573', '881ddeef-a8fb-4435-a5d1-a288171bd530'); --opr clinica
  go
  INSERT INTO USUARIOS(ID, LOGIN, SENHA, TipoUsuarioId, EmpresaId) VALUES('bfdee224-17d7-4f04-8589-a5a47b749e14', 'med@dortprev.com,br', 'abc123', '19624fb7-2bc5-480d-959a-e5cab5bf347b', '881ddeef-a8fb-4435-a5d1-a288171bd530'); --medico clinica
  go
  