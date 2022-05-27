
# Validador de Schema de NFS-e

![Current Stage](http://img.shields.io/static/v1?label=STATUS&message=DESENVOLVIMENTO&color=GREEN&style=for-the-badge)
![NET Version](http://img.shields.io/static/v1?label=.NET&message=6.0&color=GREEN&style=for-the-badge)

## Descrição do projeto

A Nota Fiscal de Serviços Eletrônica (NFS-e) é um documento fiscal emitido por prefeituras ou por outras entidades governamentais. Um grande número de municípios disponibiliza um ambiente webservice para que as emissões dos contribuintes sejam feitas a partir de uma aplicação de terceiros, mas para isso o XML de envio deve ser válido conforme o esquema previsto pelo padrão do WS. Esse padrão pode ser definido com base no manual disponibilizado pela [ABRASF](http://www.abrasf.org.br), mas as prefeituras e organizações possuem total liberdade para modificar a estrutura do arquivo.

Pensando nessa dificuldade de fazer a validação para os vários padrões disponíveis Brasil afora, foi desenvolvido o validador-nfse. Esse projeto visa homologar padrões/cidades e validar o XML a partir do esquema XSD disponibilizado pelas prefeituras.
Atualmente está implementado validação para:
- ABRASF
- GINFES
- BETHA
- BETHA 2.0
- NATAL

## Executando

O projeto pode ser executado utilizando o comando:

```bash
# Docker é requerido
$ docker build -t validador-nfse .
```

ou

```bash
# .NET 6.0 é requerido
$ dotnet run -project Validador.API
```

## Contribuição
Fique a vontade para criar um fork do projeto e realizar implementações 😊
