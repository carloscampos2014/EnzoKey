# Arquitetura do Sistema EnzoKey

## Camadas Principais
- Domain: Entidades e regras de negócio
- Application: Casos de uso e serviços
- Infrastructure: Acesso a dados e serviços externos
- API: Interface RESTful
- Cliente Desktop (.NET MAUI)

## Comunicação
- API RESTful consumida pelo cliente interno
- API de validação acessada por softwares da empresa